using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
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
    }
}