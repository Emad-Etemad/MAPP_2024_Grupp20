
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private bool isGamePaused;

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

        //Pausa alla videospelare i scenen
        PauseAllVideoPlayers();
    }

    public void Resume()
    {
        isGamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        //Återuppta alla videospelare i scenen
        ResumeAllVideoPlayers();
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
        VideoPlayer[] videoPlayers = FindObjectsOfType<VideoPlayer>();
        foreach (VideoPlayer player in videoPlayers)
        {
            if (player.isPlaying)
                player.Pause();
        }
    }

    private void ResumeAllVideoPlayers()
    {
        VideoPlayer[] videoPlayers = FindObjectsOfType<VideoPlayer>();
        foreach (VideoPlayer player in videoPlayers)
        {
            if (!player.isPlaying)
                player.Play();
        }
    }
}

