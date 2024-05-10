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
        Button[] buttons = FindObjectsOfType<Button>(); // Hämta alla knappar i scenen
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button)); // Lägg till lyssnare för varje knapp
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

        // Dölj alla knappar när videon spelas
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }

        // Spela knappvideon
        buttonVideoPlayer.Play();

        // Lyssna på händelsen när knappvideon har spelats klart
        buttonVideoPlayer.loopPointReached += vp => OnButtonVideoEnd(clickedButton);
    }

    void OnButtonVideoEnd(Button clickedButton)
    {
        // Förstör alla knappar
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            Destroy(button.gameObject);
        }

        // Ladda den nya scenen som anges från Unity-editorn
        SceneManager.LoadScene(sceneToLoad);
    }
}
