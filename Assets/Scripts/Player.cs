using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private PlayerInput playerInput;
    private float clampVertical = 60f;
    private float clampHorizontal = 60f;
    private float sensitivity = 0.1f;

    private InputAction lookAction;
    private InputAction slowTimeAction;

    [SerializeField] float slowTimeRate = 0.2f;
    [SerializeField] private float slowDuration = 5f;

    private float startHorizontal;
    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    private void Awake()
    {        
        lookAction = playerInput.actions["Look"];
        slowTimeAction = playerInput.actions["Attack"];

        verticalRotation = mainCam.transform.localRotation.eulerAngles.x;
        horizontalRotation = mainCam.transform.localRotation.eulerAngles.y;

        verticalRotation = Mathf.DeltaAngle(0f, mainCam.transform.localEulerAngles.x);
        horizontalRotation = Mathf.DeltaAngle(0f, mainCam.transform.localEulerAngles.y);

        startHorizontal = horizontalRotation;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        DetectInputs();

    }

    private void DetectInputs()
    {
        if (slowTimeAction.IsPressed())
        {
            SlowTime();
        }
    }

    private void Look()
    {
        Vector2 lookInput = lookAction.ReadValue<Vector2>();

        verticalRotation -= lookInput.y * sensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -clampVertical, clampVertical);

        horizontalRotation += lookInput.x * sensitivity;
        horizontalRotation = Mathf.Clamp(horizontalRotation,
            startHorizontal - clampHorizontal,
            startHorizontal + clampHorizontal);

        mainCam.transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);
    }

    private void SlowTime()
    {
        StartCoroutine(SlowTimeRoutine());
    }

    private IEnumerator SlowTimeRoutine()
    {
        Time.timeScale = slowTimeRate;
        Time.fixedDeltaTime = (slowTimeRate / 10) * Time.timeScale;

        yield return new WaitForSecondsRealtime(slowDuration);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }
}
