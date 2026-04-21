using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Enemy enemy;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = GetComponent<Enemy>();
        animator = GetComponent<Animator>();

        if (animator == null || enemy == null)
            return;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isChasing", enemy.isChasing);
        animator.SetBool("isAttacking", enemy.isAttacking);
        animator.SetBool("isKnockback", enemy.isKnockback);
        animator.SetInteger("attackType", Random.Range(0, 2));
    }
}
