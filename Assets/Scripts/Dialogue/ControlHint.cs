using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlHint : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text label;
    [SerializeField] private CanvasGroup group;
    [SerializeField] private float fadeSpeed = 4f;

    private float targetAlpha = 0f;

    private void Awake()
    {
        group.alpha = 0f;
    }

    public void Show(Sprite iconSprite, string text)
    {
        icon.sprite = iconSprite;
        icon.gameObject.SetActive(iconSprite != null);
        label.text = text;
        targetAlpha = 1f;
    }

    public void Hide()
    {
        targetAlpha = 0f;
    }

    private void Update()
    {
        group.alpha = Mathf.MoveTowards(group.alpha, targetAlpha, fadeSpeed * Time.unscaledDeltaTime);
    }
}
