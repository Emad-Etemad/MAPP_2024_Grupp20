using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    public SaveGameManager saveGameManager;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(SaveGame);
    }

    void SaveGame()
    {
        saveGameManager.SaveGame();
    }
}
