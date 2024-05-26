using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    private float countdown = 10f;

    void Start()
    {
        countdown = 10f;

        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        while (countdown > 0)
        {
            countdown -= Time.deltaTime;

            UpdateTimerDisplay(countdown);

            yield return null;
        }

        SceneManager.LoadScene(19);
    }

    void UpdateTimerDisplay(float currentTime)
    {
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

    public void destroyTimer()
    {
        Destroy(timerText);
    }
}
