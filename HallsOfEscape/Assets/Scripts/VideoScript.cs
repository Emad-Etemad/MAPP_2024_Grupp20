using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{

    [SerializeField] private VideoPlayer[] videoPlayer;
    [SerializeField] GameObject camera;
    public int index;

    public void Start()
    {
        videoPlayer[0].targetCamera = camera.GetComponent<Camera>();
        index = 0;
        playVideo(0);
    }

    public void playVideo(int i)
    {
        videoPlayer[i].Play();
        index = i;
        videoPlayer[i].loopPointReached += loopMethod;
    }

    void loopMethod(VideoPlayer vp)
    {
        if (index == 0)
            playVideo(index);
        else if (index == 1)
            SceneManager.LoadScene(3);
        else if (index == 2)
            SceneManager.LoadScene(5);
    }

    public void choice2()
    {
        videoPlayer[0].Pause();
        videoPlayer[2].targetCamera = camera.GetComponent<Camera>();
        index = 1;
        playVideo(index);
    }

    public void choice3()
    {
        videoPlayer[0].Pause();
        videoPlayer[3].targetCamera = camera.GetComponent<Camera>();
        index = 2;
        playVideo(index);
    }
}
