using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSFX : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip clickSound;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (button.interactable)
            AudioManager.Instance.PlaySFX(hoverSound);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (button.interactable)
            AudioManager.Instance.PlaySFX(clickSound);
    }
}
