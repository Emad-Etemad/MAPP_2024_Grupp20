using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public GameObject pauseMenuUI;   // Referens till pausmenyn
    //public GameObject playButton;    // Referens till Play-knappen för att återuppta spelet

    //void Start()
    //{
    //    //playButton.SetActive(false); // Göm Play-knappen när spelet startar
    //}

    public void LoadScene()
    {
        SceneManager.LoadScene(1); // Ladda nästa scen
    }

    public void LoadBackScene()
    {
        SceneManager.LoadScene(0); // Ladda nästa scen
    }

    //public void TogglePause()
    //{
    //    bool isPaused = pauseMenuUI.activeSelf;

    //    if (!isPaused)
    //    {
    //        Time.timeScale = 0; // Pausa spelet
    //        pauseMenuUI.SetActive(true); // Visa pausmenyn
    //        playButton.SetActive(false); // Visa Play-knappen
    //    }
    //    else
    //    {
    //        Time.timeScale = 1; // Återuppta spelet
    //        pauseMenuUI.SetActive(false); // Göm pausmenyn
    //        playButton.SetActive(true); // Göm Play-knappen
    //    }
    //}

    //public void PlayGame()
    //{
    //    // Kallas när Play-knappen trycks
    //    Time.timeScale = 1; // Återuppta spelet
    //    //pauseMenuUI.SetActive(true); // Göm pausmenyn
    //    //playButton.SetActive(false); // Göm Play-knappen
    //}
}
