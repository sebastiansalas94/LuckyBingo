using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointAndClick : MonoBehaviour
{
    [SerializeField] private ControlHint hint;

    private Camera camera;
    private IInteractable hovered;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        //if (!InputManager.Instance.GetInteractPressed()) return;

        Vector2 worldPos = camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Collider2D hit = Physics2D.OverlapPoint(worldPos);

        IInteractable current = null;
        if (hit != null)
            hit.TryGetComponent(out current);

        if (current != hovered)
        {
            hovered = current;

            if (hovered != null && hovered.ShowHint)
                hint.Show(hovered.HintIcon, hovered.HintText);
            else
                hint.Hide();
        }

         if(hovered != null && InputManager.Instance.GetInteractPressed())
            hovered.Interact();

    }
}
