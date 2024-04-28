using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Inkludera detta namespace för TextMesh Pro

public class Scen3 : MonoBehaviour
{
    public GameObject inactiveImage;  // Referens till GameObject med inaktiv bild
    public TextMeshProUGUI timerText;  // Referens till TextMeshPro-objektet
    private float countdown = 10f;  // Startvärde för nedräkningen

    void Start()
    {
        StartCoroutine(CountdownTimer());
    }

    IEnumerator CountdownTimer()
    {
        while (countdown > 0)
        {
            countdown -= Time.deltaTime;  // Minska countdown med tiden som gått sedan senaste frame
            UpdateTimerDisplay(countdown);  // Uppdatera textdisplayen
            yield return null;
        }

        SceneManager.LoadScene(0);  // Ladda om scen 0 när timern når 0
    }

    void UpdateTimerDisplay(float currentTime)
    {
        timerText.text = Mathf.Ceil(currentTime).ToString();  // Visa avrundat till närmaste heltal uppåt

        // Ändra textfärg till röd under de sista 3 sekunderna, annars svart
        if (currentTime <= 3)
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color = Color.white;
        }
    }

    // Metod för att hantera knapptryck
    public void OnButtonPressed()
    {
        StartCoroutine(ShowInactiveImageAndSwitchScene());
    }

    IEnumerator ShowInactiveImageAndSwitchScene()
    {
        inactiveImage.SetActive(true);  // Aktiverar den inaktiva bilden
        yield return new WaitForSeconds(3);  // Vänta 3 sekunder
        SceneManager.LoadScene(0);  // Byt till scen 0
    }

    public void ChoiceOne_Scen_3()
    {
        SceneManager.LoadScene(9);
    }
    public void ChoiceTwo_Scen_3()
    {
        SceneManager.LoadScene(8);
    }

    public void Restart()
    {
        Time.timeScale = 1f;  // Reset time scale to normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


