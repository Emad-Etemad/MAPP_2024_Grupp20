using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipIntro : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Referens till VideoPlayer-komponenten
    public Button skipButton;       // Referens till UI-knappen

    void Start()
    {
        skipButton.onClick.AddListener(SkipVideo); // Lägg till en lyssnare till skipButton
    }

    public void SkipVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop(); // Stoppa videouppspelningen
            LoadNextPart(); // Ladda nästa del av spelet eller applikationen
        }
    }

    public void LoadNextPart()
    {
 
        SceneManager.LoadScene(2);
       
    }
}
