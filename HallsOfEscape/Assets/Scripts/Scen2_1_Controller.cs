using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class Scene2_1_Controller : MonoBehaviour
{
    public GameObject inactiveImage; 
    public TextMeshProUGUI timerText;  
    private float countdown = 10f; 

    void Start()
    {
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

        SceneManager.LoadScene(0);
    }

    void UpdateTimerDisplay(float currentTime)
    {
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
    }

    public void GoUpstairs()
    {
        SceneManager.LoadScene(7);
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
}
