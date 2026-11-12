using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointAndClick : MonoBehaviour
{
    [SerializeField] private ControlHint hint;

    [SerializeField] public bool canInteract;

    private Camera camera;
    private IInteractable hovered;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        canInteract = true;
    }

    void Update()
    {
        Vector2 worldPos = camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Collider2D hit = Physics2D.OverlapPoint(worldPos);

        IInteractable current = null;
        if (hit != null)
            hit.TryGetComponent(out current);

        if (current != hovered)
        {
            hovered = current;

            if (canInteract && hovered != null)
            {
                if (hovered.ShowHint)
                    hint.Show(hovered.HintIcon, hovered.HintText);
                hovered.HoveredCount++;
                hovered.ChangeSprite(true);
            }
            else
            {
                hint.Hide();
                GameManager.Instance.ResetBackground();
            }
        }

        if (canInteract && hovered != null && InputManager.Instance.GetInteractPressed())
            hovered.Interact();
    }

    public void SetCanInteract(bool newCanInteract)
    {
        canInteract = newCanInteract;
    }
}
