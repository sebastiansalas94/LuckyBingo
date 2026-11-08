using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public static InputManager Instance { get; private set; }
    private PlayerInput playerInput;
    private InputAction interactAction;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(Instance);
            Instance = this;
        }

        playerInput = GetComponent<PlayerInput>();
        interactAction = playerInput.actions["Interact"];
    }

    public bool GetInteractPressed() => interactAction.WasPressedThisFrame();

    public void SwitchToPlayer() => playerInput.SwitchCurrentActionMap("Player");
    public void SwitchToUI() => playerInput.SwitchCurrentActionMap("UI");
}
