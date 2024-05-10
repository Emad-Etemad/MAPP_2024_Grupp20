using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button[] buttons;
    public VideoClip[] videoClips;
    public int[] sceneIndexes;

    private Dictionary<Button, (VideoClip clip, int sceneIndex)> buttonToVideoClip = new Dictionary<Button, (VideoClip clip, int sceneIndex)>();

    void Start()
    {
        for (int i = 0; i < buttons.Length && i < videoClips.Length && i < sceneIndexes.Length; i++)
        {
            if (!buttonToVideoClip.ContainsKey(buttons[i]))
            {
                buttonToVideoClip.Add(buttons[i], (videoClips[i], sceneIndexes[i]));

                // Skapa en lokal kopia av indexet för att använda i lambda-uttrycket
                int localIndex = i;
                buttons[i].onClick.AddListener(delegate { PlayVideo(buttons[localIndex]); });
            }
        }
    }

    void PlayVideo(Button button)
    {
        if (buttonToVideoClip.TryGetValue(button, out var videoData))
        {
            videoPlayer.clip = videoData.clip;
            videoPlayer.Prepare();
            StartCoroutine(StartVideoWhenReady(videoData.sceneIndex));
        }
    }

    IEnumerator StartVideoWhenReady(int sceneIndex)
    {
        yield return new WaitUntil(() => videoPlayer.isPrepared);
        videoPlayer.Play();

        yield return new WaitForSeconds(0.1f);

        yield return new WaitUntil(() => !videoPlayer.isPlaying);
        SceneManager.LoadScene(sceneIndex);
    }



}
