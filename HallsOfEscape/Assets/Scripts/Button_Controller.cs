using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ButtonController : MonoBehaviour
{
    public Button myButton;
    public VideoPlayer backgroundVideoPlayer;
    public VideoPlayer buttonVideoPlayer;

    void Start()
    {
        if (myButton == null)
            myButton = GetComponent<Button>();

        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // Stoppa bakgrundsvideon om den redan spelas
        if (backgroundVideoPlayer.isPlaying)
            backgroundVideoPlayer.Stop();

        // Stoppa knappvideon om den redan spelas
        if (buttonVideoPlayer.isPlaying)
            buttonVideoPlayer.Stop();

        // Dölj knappen när videon spelas
        myButton.gameObject.SetActive(false);

        // Spela knappvideon
        buttonVideoPlayer.Play();
    }

}

