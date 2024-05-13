using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndScene4 : MonoBehaviour
{



    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

}
