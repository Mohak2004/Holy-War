using System;
using UnityEngine;

public abstract class EnemyState
{

    protected Enemy enemy;
    protected EnemyStateMachine enemyStateMachine;

    public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
    }

    public virtual void Enter() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
    public virtual void OnCollisionEnter(Collision2D other) { }
    public virtual void OnCollisionStay(Collision2D other) { }
    public virtual void OnCollisionExit(Collision2D other) { }
}
