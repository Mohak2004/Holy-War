using UnityEngine;

public class Animation_Controller : MonoBehaviour
{
    private Enemy enemy;
    private Animator animator;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        animator = GetComponent<Animator>();

        if (animator == null || enemy == null)
            return;
    }

    private void Update()
    {

        animator.SetBool("isAttackingLeft", enemy.isAttackingLeft);
        animator.SetBool("isAttackingRight", enemy.isAttackingRight);
        animator.SetBool("isChasing", enemy.isChasing);
        animator.SetFloat("moveDir", enemy.moveDir.x);

    }
}
