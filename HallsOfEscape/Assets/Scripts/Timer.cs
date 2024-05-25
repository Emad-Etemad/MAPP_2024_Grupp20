using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public TextMeshProUGUI timerText;
    public float gameTime;
    public float delayBeforeStart = 5f; // Lägg till denna variabel för fördröjning
    public int mainMenuSceneIndex = 0; // Lägg till denna variabel för huvudmenyns scen index

    private bool stopTimer;
    private bool isCountingDown = false;
    private float startTime;

    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        startTime = Time.time; // Spara starttiden

        // Sätt timeslidern och timerText till osynlig i början
        timerSlider.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);

        StartCoroutine(StartCountdownAfterDelay());
    }

    private IEnumerator StartCountdownAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeStart);
        isCountingDown = true;
        startTime = Time.time; // Återställ starttiden när nedräkningen börjar

        // Gör timeslidern och timerText synlig
        timerSlider.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true);
    }

    void Update()
    {
        if (isCountingDown && !stopTimer)
        {
            float time = gameTime - (Time.time - startTime);

            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (time <= 0)
            {
                stopTimer = true;
                time = 0; // Sätt tiden till 0 om den går under noll

                // Dölj timeslidern och timerText
                timerSlider.gameObject.SetActive(false);
                timerText.gameObject.SetActive(false);

                // Ladda huvudmenyn
                SceneManager.LoadScene(mainMenuSceneIndex);
            }

            timerText.text = textTime;
            timerSlider.value = time;
        }
    }
}


/*public Text timerText;
   private float timeRemaining = 10f;
   private bool timerIsRunning = false;

   void Start()
   {
       // Start the timer
       timerIsRunning = true;
   }

   void Update()
   {
       if (timerIsRunning)
       {
           // Update the timer
           if (timeRemaining > 0)
           {
               timeRemaining -= Time.deltaTime;
               DisplayTime(timeRemaining);
           }
           else
           {
               // Timer ends
               timerIsRunning = false;
               timeRemaining = 0;
               LoadMainMenu();
           }
       }

       // Change text color to red when 3 seconds remaining
       if (timeRemaining <= 3)
       {
           timerText.color = Color.red;
       }
   }

   void DisplayTime(float timeToDisplay)
   {
       // Convert time to minutes and seconds
       float minutes = Mathf.FloorToInt(timeToDisplay / 60);
       float seconds = Mathf.FloorToInt(timeToDisplay % 60);

       // Update timer text
       timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
   }

   void LoadMainMenu()
   {
       // Load the main menu scene
       SceneManager.LoadScene("MainMenu");
   }*/