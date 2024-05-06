using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Scen1Controller : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Referens till VideoPlayer-komponenten

    void Start()
    {
        videoPlayer.loopPointReached += EndReached; // Prenumerera på händelsen
    }

    public void ChoiceOne()
    {
        videoPlayer.Play(); // Starta videon
    }

    void EndReached(VideoPlayer vp)
    {
        SceneManager.LoadScene(3); // Ladda nästa scen när videon är klar
    }

    public void ChoiceTwo()
    {
        SceneManager.LoadScene(5);
    }

    private void OnDestroy()
    {
        videoPlayer.loopPointReached -= EndReached; // Glöm inte att avprenumerera
    }
}
