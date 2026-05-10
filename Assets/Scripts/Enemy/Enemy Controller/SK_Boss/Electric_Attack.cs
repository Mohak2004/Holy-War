using UnityEngine;

public class Electric_Attack : MonoBehaviour
{
    public GameObject lightningPrefab;
    public GameObject fireballPrefab;
    public Collider2D col;

    public Transform staffEnd;
    public Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        staffEnd = gameObject.GetComponentInChildren<Transform>();
    }

    public void lightningAttack()
    {
        Vector3 spawnpos = player.position + new Vector3(0, 4f, 0);
        Instantiate(lightningPrefab, spawnpos, Quaternion.identity);
    }

    public void fireballAttack()
    {
        Vector3 direction = (player.position - staffEnd.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Instantiate(fireballPrefab, staffEnd.position, Quaternion.Euler(0, 0, angle));
    }

    public void EnableCollider()
    {
        col.enabled = true;
    }

    public void DisableCollider()
    {
        col.enabled = false;
    }
}
