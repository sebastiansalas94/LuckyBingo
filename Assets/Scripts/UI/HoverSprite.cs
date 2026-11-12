using UnityEngine;
using UnityEngine.EventSystems;

public class HoverSprite : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Sprite hoverSprite;

    private SpriteRenderer sr;
    private Sprite normalSprite;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        normalSprite = sr.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer entered " + gameObject.name);
        sr.sprite = hoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer exit " + gameObject.name);
        sr.sprite = normalSprite;
    }
}
