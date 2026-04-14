using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void Enter()
    {
        enemy.isAttacking = true;
    }

    public override void FixedUpdate()
    {
        if (enemy.player == null) return;

        float dist = Vector2.Distance(
            enemy.transform.position,
            enemy.player.position);

        Vector2 moveDir = new Vector2(enemy.player.position.x - enemy.transform.position.x, enemy.player.position.y - enemy.transform.position.y).normalized;

        if (dist < enemy.attackRange && moveDir.x < 0)
        {
            enemy.isAttackingLeft = true;
            enemy.isAttackingRight = false;
            enemy.spriteRenderer.flipX = true;
        }
        else if (dist < enemy.attackRange && moveDir.x > 0)
        {
            enemy.isAttackingLeft = false;
            enemy.isAttackingRight = true;
            enemy.spriteRenderer.flipX = false;
        }
        else
        {
            enemyStateMachine.ChangeState(enemy.chaseState);
        }
    }

    public override void Exit()
    {
        enemy.isAttackingLeft = false;
        enemy.isAttackingRight = false;
    }

    public override void OnCollisionEnter(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerStats stats = other.gameObject.GetComponent<PlayerStats>();
            stats?.TakeDamage(enemy.enemyData.enemyCollisionDamage);
        }
    }
}
