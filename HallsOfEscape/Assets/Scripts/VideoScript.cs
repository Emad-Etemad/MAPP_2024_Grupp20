using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{

    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] GameObject camera;

    public void Start()
    {
        videoPlayer.targetCamera = camera.GetComponent<Camera>();
        playVideo();
    }

    public void playVideo()
    {
        videoPlayer.Play();
        videoPlayer.loopPointReached += loopMethod;
    }

    void loopMethod(VideoPlayer vp)
    {
        playVideo();
    }
}
