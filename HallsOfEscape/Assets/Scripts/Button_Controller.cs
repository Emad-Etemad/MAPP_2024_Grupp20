using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public Button myButton;
    public VideoPlayer backgroundVideoPlayer;
    public VideoPlayer buttonVideoPlayer;

    public string sceneToLoad; // Variabel för att ange scenens namn från Unity-editorn

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

        // Dölj alla knappar när videon spelas
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }

        // Spela knappvideon
        buttonVideoPlayer.Play();

        // Lyssna på händelsen när knappvideon har spelats klart
        buttonVideoPlayer.loopPointReached += OnButtonVideoEnd;
    }

    void OnButtonVideoEnd(UnityEngine.Video.VideoPlayer vp)
    {
        // När knappvideon har spelats klart, förstör knappen
        Destroy(myButton.gameObject);

        // Ladda den nya scenen som anges från Unity-editorn
        SceneManager.LoadScene(sceneToLoad);
    }
}

