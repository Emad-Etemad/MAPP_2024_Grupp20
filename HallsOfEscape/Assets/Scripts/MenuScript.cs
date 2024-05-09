using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject settingsPanel;


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadBackScene()
    {
        SceneManager.LoadScene(0); // Ladda nästa scen
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void closeCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void closeSettings()
    {
        settingsPanel.SetActive(false);
    }

}