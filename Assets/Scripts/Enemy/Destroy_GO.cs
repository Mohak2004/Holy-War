using UnityEngine;

public class Destroy_GO : MonoBehaviour
{
    public Collider2D col;
    public PlayerStats playerStat;

    private void Start()
    {
        playerStat = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

    public void OnCollider()
    {
        col.enabled = true;
    }

    public void OffCollider()
    {
        col.enabled = false;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStat.TakeDamage(50);
        }
    }
}
