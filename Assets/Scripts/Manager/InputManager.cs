using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public static InputManager Instance { get; private set; }
    private PlayerInput playerInput;
    private InputAction interactAction;
    private InputAction paperAction;

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
        paperAction = playerInput.actions["Paper"];
    }

    public bool GetInteractPressed() => interactAction.WasPressedThisFrame();
    public bool GetPaperPressed() => paperAction.WasPressedThisFrame();

    public void SwitchToPlayer() => playerInput.SwitchCurrentActionMap("Player");
    public void SwitchToUI() => playerInput.SwitchCurrentActionMap("UI");
}
