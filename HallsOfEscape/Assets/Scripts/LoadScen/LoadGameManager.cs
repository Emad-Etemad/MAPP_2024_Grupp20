using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadGameManager : MonoBehaviour
{
    public void LoadSavedGame()
    {
        // Kolla om en sparad scen finns
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            string savedSceneName = PlayerPrefs.GetString("SavedScene");
            SceneManager.LoadScene(savedSceneName);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == PlayerPrefs.GetString("SavedScene"))
        {
            if (PlayerPrefs.HasKey("VideoTime"))
            {
                float savedTime = PlayerPrefs.GetFloat("VideoTime");
                VideoPlayer videoPlayer = FindObjectOfType<VideoPlayer>();
                if (videoPlayer != null)
                {
                    videoPlayer.time = savedTime;
                    videoPlayer.Play();
                }
            }
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
