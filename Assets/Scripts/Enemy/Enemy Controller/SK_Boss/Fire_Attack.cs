using UnityEngine;

public class Fire_Attack : MonoBehaviour
{
    public GameObject fireRodPrefab;
    public Transform player;
    public Collider2D col;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    public void lightningAttack()
    {
        Vector3 spawnpos = player.position + new Vector3(0, -0.5f, 0);
        Instantiate(fireRodPrefab, spawnpos, Quaternion.identity);
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
