using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private bool isGamePaused;
    private List<VideoPlayer> pausedVideoPlayers = new List<VideoPlayer>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        isGamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        PauseAllVideoPlayers();
    }

    public void Resume()
    {
        isGamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        ResumePausedVideoPlayers();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    private void PauseAllVideoPlayers()
    {
        pausedVideoPlayers.Clear();
        VideoPlayer[] videoPlayers = FindObjectsOfType<VideoPlayer>();
        foreach (VideoPlayer player in videoPlayers)
        {
            if (player.isPlaying)
            {
                player.Pause();
                pausedVideoPlayers.Add(player);
            }
        }
    }

    private void ResumePausedVideoPlayers()
    {
        foreach (VideoPlayer player in pausedVideoPlayers)
        {
            if (player != null && !player.isPlaying)
            {
                player.Play();
            }
        }
        pausedVideoPlayers.Clear();
    }
}
