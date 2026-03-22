using UnityEngine;

public class SwordSlash_AC : MonoBehaviour
{
    Collider2D Collider;

    private void OnStart()
    {
        Collider = GetComponent<Collider2D>();
        Collider.enabled = true;
    }


    private void OnComplete()
    {
        Collider.enabled = false;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
