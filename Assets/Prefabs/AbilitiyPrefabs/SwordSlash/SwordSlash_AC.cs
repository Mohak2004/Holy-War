using Unity.VisualScripting;
using UnityEngine;

public class SwordSlash_AC : MonoBehaviour
{
    Collider2D Collider;
    AbilitySO abilityData;

    public void Initialize(AbilitySO ability)
    {
        abilityData = ability;
    }

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
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(abilityData.damage);
            enemy.TakeKnockback(abilityData.knockback);
        }
    }
}
