using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scen2_1_Controller : MonoBehaviour
{

    public void GoUpstairs()
    {

        SceneManager.LoadScene(6);

    }

    public void OpenDoor()
    {

        SceneManager.LoadScene(7);

    }

}