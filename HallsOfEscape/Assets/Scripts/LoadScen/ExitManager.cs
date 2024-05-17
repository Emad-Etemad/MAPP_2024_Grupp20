using UnityEngine;
using UnityEngine.UI;

public class ExitManager : MonoBehaviour
{
    public GameObject exitDialog;
    public Button yesButton;
    public Button noButton;
    public Button exitButton;

    void Start()
    {
        // Se till att dialogrutan är inaktiv i början
        exitDialog.SetActive(false);

        // Lägg till lyssnare till knapparna
        exitButton.onClick.AddListener(ShowExitDialog);
        yesButton.onClick.AddListener(ExitGame);
        noButton.onClick.AddListener(HideExitDialog);
    }

    void ShowExitDialog()
    {
        exitDialog.SetActive(true);
    }

    void HideExitDialog()
    {
        exitDialog.SetActive(false);
    }

    void ExitGame()
    {
        // Avsluta spelet
        Application.Quit();

        // Om vi kör i editor, stoppa spelkörning
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
