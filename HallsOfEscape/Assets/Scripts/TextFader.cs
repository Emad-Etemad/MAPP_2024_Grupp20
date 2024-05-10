using UnityEngine;
using UnityEngine.UI;

public class TextFadeIn : MonoBehaviour
{
    public float fadeInTime = 2.0f; // Tid det tar för texten att fada in (i sekunder)

    private Text textComponent;
    private Color originalColor;
    private float timer = 0.0f;

    void Start()
    {
        textComponent = GetComponent<Text>();
        originalColor = textComponent.color;
        textComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0); // Börja med genomskinlig text
    }

    void Update()
    {
        if (timer < fadeInTime)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0, originalColor.a, timer / fadeInTime);
            textComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
        }
    }
}
