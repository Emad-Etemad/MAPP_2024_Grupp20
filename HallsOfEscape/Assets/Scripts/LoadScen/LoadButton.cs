using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    public LoadGameManager loadGameManager;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(LoadGame);
    }

    void LoadGame()
    {
        loadGameManager.LoadSavedGame();
    }
}
