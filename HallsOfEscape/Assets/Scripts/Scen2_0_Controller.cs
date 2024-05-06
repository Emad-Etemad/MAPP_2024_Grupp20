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

    public string sceneToLoad = "Scen2"; // Namnet p� den scen som ska laddas efter f�rdr�jningen
    public float delayInSeconds = 5f; // F�rdr�jningstid i sekunder

    void Start()
    {
        Invoke("LoadNextScene", delayInSeconds); // Anropa LoadNextScene efter en viss f�rdr�jning
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(3);// Ladda n�sta scen
    }

}