using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public GameObject audioPlayerPrefab;

    void Start()
    {
        if (AudioPlayer.instance == null)
        {
            Instantiate(audioPlayerPrefab);
        }
    }
}
 