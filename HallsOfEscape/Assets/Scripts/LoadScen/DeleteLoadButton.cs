using UnityEngine;
using UnityEngine.UI;

public class DeleteLoadButton : MonoBehaviour
{
    public Button loadButton;


    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(DeleteLoad);
    }

    void DeleteLoad()
    {
        // Radera sparade data
        PlayerPrefs.DeleteKey("SavedScene");
        PlayerPrefs.DeleteKey("VideoTime");
        PlayerPrefs.Save();

        // Gör Load-knappen icke interaktiv
        loadButton.interactable = false;
    }
}
