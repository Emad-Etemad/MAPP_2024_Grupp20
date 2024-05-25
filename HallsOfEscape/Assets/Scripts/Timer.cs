using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
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
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;


    void Update()
    {
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if(remainingTime < 0)
        {
            remainingTime = 0;
            //GameOver();
            timerText.color = Color.red;
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}");


    }

}