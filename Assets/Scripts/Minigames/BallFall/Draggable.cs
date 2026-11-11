using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera cam;
    private Vector3 startPosition;
    private Vector3 offset;
    private SpriteRenderer sr;
    private int startOrder;

    private void Awake()
    {
        cam = Camera.main; // or assign the 2D camera in the Inspector
        sr = GetComponent<SpriteRenderer>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        offset = transform.position - MouseWorld(eventData);

        startOrder = sr.sortingOrder;
        sr.sortingOrder = 100; // draw on top while dragging
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = MouseWorld(eventData) + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        sr.sortingOrder = startOrder;

        DropZone zone = FindDropZone(eventData);
        if (zone != null && zone.Accepts(this))
            zone.Drop(this);
        else
            transform.position = startPosition; // snap back
    }

    private Vector3 MouseWorld(PointerEventData eventData)
    {
        Vector3 pos = cam.ScreenToWorldPoint(eventData.position);
        pos.z = transform.position.z;
        return pos;
    }

    private DropZone FindDropZone(PointerEventData eventData)
    {
        Vector2 point = cam.ScreenToWorldPoint(eventData.position);
        foreach (Collider2D hit in Physics2D.OverlapPointAll(point))
        {
            if (hit.TryGetComponent(out DropZone zone))
                return zone;
        }
        return null;
    }
}
