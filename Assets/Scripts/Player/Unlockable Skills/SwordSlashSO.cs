using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "SwordSlashSO", menuName = "Scriptable Objects/SwordSlashSO")]
public class SwordSlashSO : AbilitySO
{
    public GameObject swordSlashPrefab;

    public override void Activate(Transform owner)
    {
        // Get mouse position in world space
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = owner.position.z; // Keep same Z as player (important for 2D)

        // Get normalized direction from player to mouse
        Vector3 direction = (mouseWorldPos - owner.position).normalized;

        // Calculate the angle for rotation (so the slash sprite faces the right way)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Spawn at the same distance (2 units) but in the cursor's direction
        GameObject obj = Instantiate(
            swordSlashPrefab,
            owner.position + direction * 2f,        // Position: 2 units toward cursor
            Quaternion.Euler(0, 0, angle),           // Rotation: facing toward cursor
            owner
        );
    }
}
