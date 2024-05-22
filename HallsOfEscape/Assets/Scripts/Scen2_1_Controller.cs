using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Scene2_1_Controller : MonoBehaviour
{
    public GameObject pauseMenuUI;   // Referens till pausmenyn
    //public GameObject playButton;    // Referens till Play-knappen för att återuppta spelet
    public GameObject inactiveImage;
    public TextMeshProUGUI timerText;
    private float countdown = 30f;
    private bool isGamePaused = false;

    //public CanvasGroup uiCanvasGroup; // Används för att hantera interaktiviteten för all UI utom Play-knappen
    public Button pb; // Referens till Play-knappen
    //public Behaviour[] interactableScripts; // Skript som ska inaktiveras

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

        if (currentTime <= 3)
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

    public void OpenDoor()
    {
        SceneManager.LoadScene(6);
        Destroy(timerText);
    }

    public void GoUpstairs()
    {
        SceneManager.LoadScene(7);
        Destroy(timerText);
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
            //playButton.SetActive(false); // Göm Play-knappen
        }
        else
        {
            Time.timeScale = 1; // Pausa spelet
            pauseMenuUI.SetActive(false); // Visa pausmenyn
            //playButton.SetActive(true); // Visa Play-knappen
        }
    }

    public void PlayGame()
    {
        // Kallas när Play-knappen trycks
        Time.timeScale = 1; // Återuppta spelet
        isGamePaused = false;
        pauseMenuUI.SetActive(true); // Göm pausmenyn
        //playButton.SetActive(false); // Göm Play-knappen
        //ReactivateUI(); // Återaktivera all UI interaktivitet

    }

    public void SetSceneInteractivity(bool isActive)
    {
        // Invertera isActive för att hantera spellogik som pausas
        isGamePaused = !isActive;

        // Aktivera eller inaktivera tiden
        Time.timeScale = isActive ? 1 : 0;

        // Hantera interaktiviteten för alla UI-element via CanvasGroup, förutom Play-knappen
        //if (uiCanvasGroup != null)
        //{
        //    uiCanvasGroup.interactable = isActive;
        //    uiCanvasGroup.blocksRaycasts = isActive;
        //    uiCanvasGroup.alpha = isActive ? 1.0f : 0.5f; // Full opacitet eller delvis genomskinlig
        //}


        // Antag att pb har en egen CanvasGroup
        CanvasGroup playButtonCanvasGroup = pb.GetComponent<CanvasGroup>();
        if (playButtonCanvasGroup == null)
        {
            playButtonCanvasGroup = pb.gameObject.AddComponent<CanvasGroup>();
        }
        playButtonCanvasGroup.interactable = true; // Gör Play-knappen alltid interaktiv
        playButtonCanvasGroup.blocksRaycasts = true; // Tillåter klick på Play-knappen
        playButtonCanvasGroup.alpha = 1; // Säkerställer att den är fullt synlig

        // Loopa igenom och aktivera/inaktivera alla skript som styr interaktiva delar av spelet
        //foreach (var script in interactableScripts)
        //{
        //    script.enabled = isActive;
        //}
    }

    public void Restart()
    {
        Time.timeScale = 1f;  // Reset time scale to normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    //public void ReactivateUI()
    //{
    //    // Aktivera interaktiviteten för alla UI-element via CanvasGroup, förutom Play-knappen
    //    if (uiCanvasGroup != null)
    //    {
    //        uiCanvasGroup.interactable = true;
    //        uiCanvasGroup.blocksRaycasts = true;
    //        uiCanvasGroup.alpha = 1.0f; // Full opacitet
    //    }

    //    // Loopa igenom och aktivera alla skript som styr interaktiva delar av spelet
    //    foreach (var script in interactableScripts)
    //    {
    //        script.enabled = true;
    //    }
    //}


}

