using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndScene4 : MonoBehaviour
{
    [SerializeField] private GameObject readMoreInfoPanel;
    [SerializeField] private AudioClip returnToMenuSound, readMorePanelSound, closeReadMorePanelSound;
    private AudioSource audioSource;


    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
        audioSource.PlayOneShot(returnToMenuSound, 0.5f);
    }
    public void ShowReadMorePanel()
    {
        readMoreInfoPanel.SetActive(true);
        audioSource.PlayOneShot(readMorePanelSound, 0.5f);
    }
    public void closeReadMorePanel()
    {
        readMoreInfoPanel.SetActive(false);
        audioSource.PlayOneShot(closeReadMorePanelSound, 0.5f);
    }


}
