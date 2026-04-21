using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Collider2D col;
    public PlayerStats playerStat;

    public Rigidbody2D rb;

    private void Start()
    {
        playerStat = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        rb.linearVelocity = transform.right * 5;
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
        Debug.Log("Entered Trigger");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Damage taken");
            playerStat.TakeDamage(50);
            Destroy(gameObject);
        }
    }
}
