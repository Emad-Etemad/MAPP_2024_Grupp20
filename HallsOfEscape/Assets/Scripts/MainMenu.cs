using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour

{
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private AudioClip startSound, settingsSound, creditsSound, closeSettingsSound, closeCreditsSound;
    //public GameObject pauseMenuUI;   // Referens till pausmenyn
    //public GameObject playButton;    // Referens till Play-knappen för att återuppta spelet

    //void Start()
    //{
    //    //playButton.SetActive(false); // Göm Play-knappen när spelet startar
    //}
        private AudioSource audioSource;

    public void Start()
    {
       // audioSource.GetComponent<AudioSource>();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1); // Ladda nästa scen
        audioSource.PlayOneShot(startSound, 0.5f);

    }

    public void LoadBackScene()
    {
        SceneManager.LoadScene(0); // Ladda nästa scen
    }
    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
        audioSource.PlayOneShot(creditsSound, 0.5f);
    }
    public void closeCredits()
    {
        creditsPanel.SetActive(false);
        audioSource.PlayOneShot(closeCreditsSound, 0.5f);
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
        audioSource.PlayOneShot(settingsSound, 0.5f);
    }

    public void closeSettings()
    {
        settingsPanel.SetActive(false);
        audioSource.PlayOneShot(closeSettingsSound, 0.5f);
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
