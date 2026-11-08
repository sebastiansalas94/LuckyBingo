using UnityEngine;
using UnityEngine.InputSystem;

public class PointAndClick : MonoBehaviour
{
    private Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (!Mouse.current.leftButton.wasPressedThisFrame) return;

        Vector2 worldPos = camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Collider2D hit = Physics2D.OverlapPoint(worldPos);

        if (hit != null && hit.TryGetComponent(out IInteractable interactable))
            interactable.Interact();
    }
}
