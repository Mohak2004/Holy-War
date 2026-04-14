using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class EnemyStateMachine
{
    public EnemyState currentState;

    public void Initialize(EnemyState enemyState)
    {
        currentState = enemyState;
        currentState.Enter();
    }

    public void ChangeState(EnemyState newEnemyState)
    {
        currentState.Exit();
        currentState = newEnemyState;
        currentState.Enter();
    }

    public void FixedUpdate()
    {
        currentState.FixedUpdate();
    }
}
