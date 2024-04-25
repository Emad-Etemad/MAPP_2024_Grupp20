using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public enum SceneToLoad
    {
        Scene1,
        Ending_3_Info,
        Menu
    }

    public SceneToLoad sceneToLoad; // Välj vilken scen som ska laddas från inspektören
    public float delayInSeconds = 5f; // Fördröjningstid i sekunder
    void Start()
    {
        Invoke("LoadNextScene", delayInSeconds); // Anropa LoadNextScene efter en viss fördröjning
    }
    void LoadNextScene()
    {
        string sceneName = GetSceneName(sceneToLoad);
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is null. Make sure SceneToLoad enum is set correctly.");
        }
    }

    string GetSceneName(SceneToLoad scene)
    {
        switch (scene)
        {
            case SceneToLoad.Scene1:
                return "Scene1";
            case SceneToLoad.Ending_3_Info:
                return "Ending_3_Info";
            case SceneToLoad.Menu:
                return "Menu";
            default:
                Debug.LogError("Unknown scene to load.");
                return null;
        }
    }
}
