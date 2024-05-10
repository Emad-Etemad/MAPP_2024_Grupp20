using System.Collections;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float delayBeforeFadeIn = 10f; // F�rsening innan fade-in b�rjar (i sekunder)
    public float fadeInDuration = 1f;      // Tid det tar att fada in (i sekunder)

    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f; // G�m knappen vid start

        StartCoroutine(StartFadeInAfterDelay());
    }

    private IEnumerator StartFadeInAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeFadeIn);

        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            float alphaValue = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            canvasGroup.alpha = alphaValue;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f; // S�kerst�ll att alpha �r exakt 1 n�r faden �r klar
    }
}
