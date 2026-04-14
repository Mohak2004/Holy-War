using UnityEngine;
using UnityEngine.InputSystem;

public class VirtualCursorController : MonoBehaviour
{
    [SerializeField] InputActionReference mouseInput, gamepadInput;
    [SerializeField] Rigidbody2D mrb;

    private bool isUsingGamepad;

    [SerializeField] Transform player;
    [SerializeField] private Camera cam;
    [SerializeField] private float gamepadCursorDistance;
    private Vector2 mouseScreenPosition, stickInput;

    private void Awake()
    {
        cam = Camera.main;
    }


    public void OnLook(InputAction.CallbackContext context)
    {
        if(context.control.device is Gamepad)
        {
            if (context.ReadValue<Vector2>().magnitude > 0.1f)
            {
                stickInput = context.ReadValue<Vector2>();
            }

            isUsingGamepad = true;
        }
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        if (context.control.device is Mouse)
        {
            mouseScreenPosition = context.ReadValue<Vector2>();
            isUsingGamepad = false;
        }
    }

    private void Update()
    {
        if (isUsingGamepad)
        {
            UpdateGamepadCursor();
            
        }
        else
        {
            UpdateMouseCursor();
        }
    }

    private void UpdateMouseCursor()
    {
        Vector3 worldPos = cam.ScreenToWorldPoint(mouseScreenPosition);
        worldPos.z = 0;
        transform.position = worldPos;
    }

    private void UpdateGamepadCursor()
    {
        if (stickInput.magnitude < 0.1f)
        {
            return;
        }

        Vector2 dir = stickInput.normalized;
        transform.position = (Vector2)player.position + dir * gamepadCursorDistance;
    }

    private Vector2 GetAimDirection()
    {
        return (transform.position - player.position).normalized;
    }
}
