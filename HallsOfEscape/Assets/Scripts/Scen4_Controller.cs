using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scen4_Controller : MonoBehaviour
{
    public void ChoiceOne()
    {
        SceneManager.LoadScene(6);
    }

    public void ChoiceTwo()
    {
        SceneManager.LoadScene(10);
    }
}
