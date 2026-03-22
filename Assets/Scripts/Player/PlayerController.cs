using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerStats playerStats;

    [SerializeField] private InputActionReference moveInput, dashInput;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float moveSpeed, dashDistance, dashTime, dashStaminaCost;
    private Vector2 moveDir;
    private bool isDashing = false;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    private void FixedUpdate()
    {
        if(!isDashing)
        {
            rb.linearVelocity = moveDir * moveSpeed;
        }
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;

        Vector2 startPos = rb.position;
        Vector2 endPos = startPos + (moveDir.normalized * dashDistance);

        float elapsed = 0f;

        if(playerStats.currentStamina > dashStaminaCost && moveDir.magnitude != 0)
        {
            playerStats.UseStamina(dashStaminaCost);

            while (elapsed <= dashTime)
            {
                rb.MovePosition(Vector2.Lerp(startPos, endPos, elapsed / dashTime));
                elapsed += Time.fixedDeltaTime;
                yield return new WaitForFixedUpdate();
            }
        }


        isDashing = false;
    }
}
