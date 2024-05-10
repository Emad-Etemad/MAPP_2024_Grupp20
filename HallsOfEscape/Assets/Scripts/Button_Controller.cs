using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public VideoPlayer backgroundVideoPlayer;
    public VideoPlayer buttonVideoPlayer;
    public string sceneToLoad;

    void Start()
    {
        Button[] buttons = FindObjectsOfType<Button>(); // H�mta alla knappar i scenen
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button)); // L�gg till lyssnare f�r varje knapp
        }
    }

    void OnButtonClick(Button clickedButton)
    {
        // Stoppa bakgrundsvideon om den redan spelas
        if (backgroundVideoPlayer.isPlaying)
            backgroundVideoPlayer.Stop();

        // Stoppa knappvideon om den redan spelas
        if (buttonVideoPlayer.isPlaying)
            buttonVideoPlayer.Stop();

        // D�lj alla knappar n�r videon spelas
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }

        // Spela knappvideon
        buttonVideoPlayer.Play();

        // Lyssna p� h�ndelsen n�r knappvideon har spelats klart
        buttonVideoPlayer.loopPointReached += vp => OnButtonVideoEnd(clickedButton);
    }

    void OnButtonVideoEnd(Button clickedButton)
    {
        // F�rst�r alla knappar
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            Destroy(button.gameObject);
        }

        // Ladda den nya scenen som anges fr�n Unity-editorn
        SceneManager.LoadScene(sceneToLoad);
    }
}
