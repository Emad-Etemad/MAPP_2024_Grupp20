using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public Button myButton;
    public VideoPlayer backgroundVideoPlayer;
    public VideoPlayer buttonVideoPlayer;

    public string sceneToLoad; // Variabel f�r att ange scenens namn fr�n Unity-editorn

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

        // D�lj knappen n�r videon spelas
        myButton.gameObject.SetActive(false);

        // D�lj alla knappar n�r videon spelas
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }

        // Spela knappvideon
        buttonVideoPlayer.Play();

        // Lyssna p� h�ndelsen n�r knappvideon har spelats klart
        buttonVideoPlayer.loopPointReached += OnButtonVideoEnd;
    }

    void OnButtonVideoEnd(UnityEngine.Video.VideoPlayer vp)
    {
        // N�r knappvideon har spelats klart, f�rst�r knappen
        Destroy(myButton.gameObject);

        // Ladda den nya scenen som anges fr�n Unity-editorn
        SceneManager.LoadScene(sceneToLoad);
    }
}

