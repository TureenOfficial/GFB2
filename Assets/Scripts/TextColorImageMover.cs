using UnityEngine;
using TMPro;

public class TextColorImageMover : MonoBehaviour
{
    public TMP_Text hueText;
    public TMP_Text satText;
    public TMP_Text valText;

    public RectTransform hueColorImage;
    public RectTransform satColorImage;
    public RectTransform valColorImage;

    public float padding = 10f;

    private void Update()
    {
        AdjustAnchoredPosition(hueText, hueColorImage);
        AdjustAnchoredPosition(satText, satColorImage);
        AdjustAnchoredPosition(valText, valColorImage);
    }

    private void AdjustAnchoredPosition(TMP_Text textElement, RectTransform colorImage)
    {
        float textWidth = textElement.preferredWidth;
        colorImage.anchoredPosition = new Vector2(textElement.rectTransform.anchoredPosition.x + textWidth + padding - 620, colorImage.anchoredPosition.y);
    }
}