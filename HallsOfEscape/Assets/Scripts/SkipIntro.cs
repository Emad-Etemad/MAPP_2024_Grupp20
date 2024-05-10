using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SkipIntroController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Referens till VideoPlayer-komponenten
    public Button skipButton;       // Referens till UI-knappen
    public float fastForwardSpeed = 3.0f; // Snabbspolningshastighet

    void Start()
    {
        // Lägg till lyssnare till skipButton för att kalla på FastForwardVideo när den klickas
        skipButton.onClick.AddListener(FastForwardVideo);
    }

    private void FastForwardVideo()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.playbackSpeed = fastForwardSpeed; // Ändra uppspelningshastigheten för att snabbspola videon
        }
    }

    void OnDestroy()
    {
        // Glöm inte att ta bort lyssnaren när objektet förstörs
        skipButton.onClick.RemoveListener(FastForwardVideo);
    }
}

