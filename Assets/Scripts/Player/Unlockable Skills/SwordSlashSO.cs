using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "SwordSlashSO", menuName = "Scriptable Objects/SwordSlashSO")]
public class SwordSlashSO : AbilitySO
{
    public GameObject swordSlashPrefab;

    public override void Activate(Transform owner)
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = owner.position.z;

        Vector3 direction = (mouseWorldPos - owner.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        GameObject obj = Instantiate(
            swordSlashPrefab,
            owner.position + direction * 2f,
            Quaternion.Euler(0, 0, angle),
            owner
        );

        SwordSlash_AC slashScript = obj.GetComponent<SwordSlash_AC>();
        slashScript.Initialize(this);
    }
}
