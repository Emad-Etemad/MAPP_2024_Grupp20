using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoadScene : MonoBehaviour
{
    public int sceneIndex = 4;

    public void LoadSceneOnClick()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
