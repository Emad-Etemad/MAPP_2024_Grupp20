using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoControl : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button[] buttons; // Array av knappar där varje knapp representerar en video
    public VideoClip[] videoClips; // Array av VideoClips som matchar knapparna
    private int lastVideoIndex = -1; // Index för senast spelade videoklippet
    public string[] sceneNames = {
    "Ending_1", "Ending_2", "Ending_3", "Ending_3_Info", "IntroScen",
    "Menu", "Scene1", "Scene2.0", "Scene2.0_Loop", "Scene2.1",
    "Scene3", "Scene4", "Scene5", "Scene6", "Scene7", "Scene8",
    "Scene9", "Scene10", "Scene11"
};



    void Start()
    {
        // Ställ in varje knapp att spela en specifik video
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Lokal kopia av index för att undvika problem i lambda-uttryck
            buttons[i].onClick.AddListener(() => PlayVideo(index));
        }

        videoPlayer.loopPointReached += OnVideoFinished; // Prenumerera på eventet när videon är klar
    }

    void PlayVideo(int index)
    {
        Debug.Log("PlayVideo called with index: " + index);
        if (index < videoClips.Length)
        {
            Debug.Log("Playing video clip: " + videoClips[index].name);
            videoPlayer.clip = videoClips[index];
            videoPlayer.Play();
            lastVideoIndex = index;
        }
        else
        {
            Debug.LogError("Video index out of range: " + index);
        }
    }




    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("Video finished for index: " + lastVideoIndex);
        if (lastVideoIndex >= 0 && lastVideoIndex < sceneNames.Length)
        {
            Debug.Log("Loading scene: " + sceneNames[lastVideoIndex]);
            SceneManager.LoadScene(sceneNames[lastVideoIndex]);
        }
        else
        {
            Debug.LogError("Scene index out of range or video index not set correctly");
        }
    }



}
