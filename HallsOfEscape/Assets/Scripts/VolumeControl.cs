using UnityEngine;
using UnityEngine.UI;  // Gör det möjligt att referera till UI-element

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;  // Referens till vår slider
    public AudioSource audioSource;  // Referens till vår audio source

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = FindObjectOfType<AudioSource>();  // Hitta och tilldela en audio source
        }

        volumeSlider.value = audioSource.volume;  // Sätt sliderens värde till nuvarande volym
        volumeSlider.onValueChanged.AddListener(SetVolume);  // Lägg till en lyssnare som kallas när sliderns värde ändras
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;  // Sätt ljudkällans volym baserat på sliderns värde
    }
}
