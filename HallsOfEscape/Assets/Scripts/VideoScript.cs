using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoScript : MonoBehaviour
{
    [SerializeField] private VideoPlayer[] videoPlayers; // Array av VideoPlayer för att spela videor
    [SerializeField] private RawImage[] displayImages; // Array av RawImage för att visa videoklipp
    [SerializeField] private int[] sceneTransitions; // Indexer av scener att ladda efter varje video
    private int currentIndex = -1; // Startvärde satt till -1 för att indikera ingen video spelas initialt

    void Start()
    {
        // Kontrollera att det finns minst ett objekt i varje lista och att de är korrekt instansierade
        if (videoPlayers.Length > 0 && videoPlayers[0] != null &&
            displayImages.Length > 0 && displayImages[0] != null &&
            sceneTransitions.Length > 0)
        {
            SetupVideoPlayer(0); // Starta första videon om allt är korrekt inställt
        }
        else
        {
            Debug.LogError("One or more of the required components are not assigned or the list is empty.");
        }
    }

    private void SetupVideoPlayer(int index)
    {
        if (index >= videoPlayers.Length || index >= displayImages.Length || videoPlayers[index] == null || displayImages[index] == null)
        {
            Debug.LogError("Index out of range or null reference encountered in Video Players or Display Images.");
            return;
        }

        VideoPlayer vp = videoPlayers[index];
        if (vp.targetTexture == null)
        {
            vp.targetTexture = new RenderTexture((int)displayImages[index].rectTransform.rect.width, (int)displayImages[index].rectTransform.rect.height, 0);
        }
        displayImages[index].texture = vp.targetTexture;

        vp.loopPointReached -= OnVideoFinished;
        vp.loopPointReached += OnVideoFinished;
        vp.Play();
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        if (currentIndex >= 0 && currentIndex < sceneTransitions.Length)
        {
            int sceneIndex = sceneTransitions[currentIndex];
            if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings) // Säkerställer att sceneIndex är giltig
            {
                SceneManager.LoadScene(sceneIndex);
            }
            else
            {
                Debug.LogError("Invalid scene index for transition: " + sceneIndex);
            }
        }
        else
        {
            Debug.LogError("Invalid current index or no scene transitions defined for this index: " + currentIndex);
        }
    }

    public void PlayVideo(int index)
    {
        if (index >= 0 && index < videoPlayers.Length)
        {
            if (currentIndex >= 0 && currentIndex < videoPlayers.Length)
                videoPlayers[currentIndex].Stop();

            currentIndex = index; // Uppdatera currentIndex till det nya indexet
            SetupVideoPlayer(index);
        }
        else
        {
            Debug.LogError("Attempted to play video with invalid index: " + index);
        }
    }
}
