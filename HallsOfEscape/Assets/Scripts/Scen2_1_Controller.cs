using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Scene2_1_Controller : MonoBehaviour
{
    public GameObject pauseMenuUI;   // Referens till pausmenyn
    public GameObject inactiveImage;
    public TextMeshProUGUI timerText;
    private float countdown = 30f;
    private bool isGamePaused = false;

    public Button pb; // Referens till Play-knappen

    public void Start()
    {
        countdown = 30f;  // Reset countdown to initial value
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        while (countdown > 0)
        {
            if (!isGamePaused)
            {
                countdown -= Time.deltaTime;
                UpdateTimerDisplay(countdown);
            }
            yield return null;
        }

        SceneManager.LoadScene(0);  // Reset or change scene as necessary
    }

    void UpdateTimerDisplay(float currentTime)
    {
        Debug.Log("Current Time: " + currentTime);  // Log current time for debugging
        timerText.text = Mathf.Ceil(currentTime).ToString();

        if (currentTime <= 5)
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color = Color.white;
        }
    }

    public void OnButtonPressed()
    {
        StartCoroutine(ShowInactiveImageAndSwitchScene());
    }

    IEnumerator ShowInactiveImageAndSwitchScene()
    {
        inactiveImage.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }

    public GameObject firstImage;
    public GameObject secondImage;

    public void ActivateImages()
    {
        firstImage.SetActive(true);
        Invoke("ActivateSecondImage", 3f);
    }

    void ActivateSecondImage()
    {
        secondImage.SetActive(true);
    }

    public void TogglePause()
    {
        isGamePaused = !isGamePaused;

        if (!isGamePaused)
        {
            Time.timeScale = 0; // Återuppta spelet
            pauseMenuUI.SetActive(true); // Göm pausmenyn
        }
        else
        {
            Time.timeScale = 1; // Pausa spelet
            pauseMenuUI.SetActive(false); // Visa pausmenyn
        }
    }

    public void PlayGame()
    {
        // Kallas när Play-knappen trycks
        Time.timeScale = 1; // Återuppta spelet
        isGamePaused = false;
        pauseMenuUI.SetActive(true); // Göm pausmenyn
    }

    public void SetSceneInteractivity(bool isActive)
    {
        // Invertera isActive för att hantera spellogik som pausas
        isGamePaused = !isActive;

        // Aktivera eller inaktivera tiden
        Time.timeScale = isActive ? 1 : 0;

        // Antag att pb har en egen CanvasGroup
        CanvasGroup playButtonCanvasGroup = pb.GetComponent<CanvasGroup>();
        if (playButtonCanvasGroup == null)
        {
            playButtonCanvasGroup = pb.gameObject.AddComponent<CanvasGroup>();
        }
        playButtonCanvasGroup.interactable = true; // Gör Play-knappen alltid interaktiv
        playButtonCanvasGroup.blocksRaycasts = true; // Tillåter klick på Play-knappen
        playButtonCanvasGroup.alpha = 1; // Säkerställer att den är fullt synlig
    }

    public void Restart()
    {
        Time.timeScale = 1f;  // Reset time scale to normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HideTimerText()
    {
        timerText.gameObject.SetActive(false);  // Dölj timerText
    }
}
