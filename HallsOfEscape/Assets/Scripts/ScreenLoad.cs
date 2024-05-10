using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenLoad : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingBar;

    public void LoadScene(int levelIndex)
    {
        StartCoroutine(LoadSceneAsynchronously(levelIndex));  // Se till att stavningen här matchar med IEnumerator metoden nedan
    }

    IEnumerator LoadSceneAsynchronously(int levelIndex)  // Namnet här måste matcha det som anropas i LoadScene
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;
            yield return new WaitForSeconds(0.1f);  // Vänta 0.1 sekunder mellan varje uppdatering
        }
    }
}
