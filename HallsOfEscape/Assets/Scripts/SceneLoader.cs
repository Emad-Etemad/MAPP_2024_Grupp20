using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad = "Scene1"; // Namnet på den scen som ska laddas efter fördröjningen
    public float delayInSeconds = 5f; // Fördröjningstid i sekunder

    void Start()
    {
        Invoke("LoadNextScene", delayInSeconds); // Anropa LoadNextScene efter en viss fördröjning
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(2); // Ladda nästa scen
    }

}
