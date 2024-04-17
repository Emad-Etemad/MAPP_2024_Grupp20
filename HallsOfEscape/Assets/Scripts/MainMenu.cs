using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{



    public void LoadScene()
    {
        SceneManager.LoadScene(1); // Ladda nästa scen
    }

    public void LoadBackScene()
    {
        SceneManager.LoadScene(0); // Ladda nästa scen
    }

}
