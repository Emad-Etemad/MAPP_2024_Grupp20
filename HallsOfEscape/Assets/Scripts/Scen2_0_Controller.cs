using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scen2_0_Controller : MonoBehaviour
{
 
    public void ChoiceOne_Scen2_0()
    {
      
        SceneManager.LoadScene(4);
       
    }

    public void ChoiceTwo_Scen2_0()
    {

        SceneManager.LoadScene(6);

    }

    public string sceneToLoad = "Scen2"; // Namnet på den scen som ska laddas efter fördröjningen
    public float delayInSeconds = 5f; // Fördröjningstid i sekunder

    void Start()
    {
        Invoke("LoadNextScene", delayInSeconds); // Anropa LoadNextScene efter en viss fördröjning
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(3);// Ladda nästa scen
    }

}