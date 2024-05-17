using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    public LoadGameManager loadGameManager;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(LoadGame);

        // Gör knappen icke interaktiv om ingen sparad data finns
        if (!PlayerPrefs.HasKey("SavedScene"))
        {
            btn.interactable = false;
        }
    }

    void LoadGame()
    {
        loadGameManager.LoadSavedGame();
    }
}
