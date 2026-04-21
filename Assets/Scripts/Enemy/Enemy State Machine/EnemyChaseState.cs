using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine) { }

    public override void Enter()
    {
        enemy.isChasing = true;
    }

    public override void FixedUpdate()
    {
        if (enemy.player == null) return;

        float dist = Vector2.Distance(
            enemy.transform.position,
            enemy.player.position);

        if (dist > enemy.attackRange && !enemy.isKnockback)
        {
            enemy.rb.linearVelocity = enemy.moveDir * enemy.moveSpeed;
        }
        else if (dist < enemy.attackRange && enemy.cooldownTimer < 0)
        {
            enemyStateMachine.ChangeState(enemy.attackState);
            enemy.cooldownTimer = enemy.enemyData.cooldownTime;
        }

        if (enemy.moveDir.x < 0)
        {
            enemy.spriteRenderer.flipX = true;
        }
        else
        {
            enemy.spriteRenderer.flipX = false;
        }
    }

    public override void Exit()
    {
        enemy.isChasing = false;
    }

    public override void OnCollisionEnter(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerStats stats = other.gameObject.GetComponent<PlayerStats>();
            stats?.TakeDamage(enemy.enemyData.enemyCollisionDamage);
        }
    }
}
