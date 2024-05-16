using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SaveGameManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void SaveGame()
    {
        // Spara aktuell scen
        string currentSceneName = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SavedScene", currentSceneName);

        // Spara videons uppspelningsposition
        float videoTime = (float)videoPlayer.time;
        PlayerPrefs.SetFloat("VideoTime", videoTime);

        PlayerPrefs.Save();
    }
}
