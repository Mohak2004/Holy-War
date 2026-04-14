using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/EnemySO")]
public abstract class EnemySO : ScriptableObject
{
    public GameObject enemyPrefab;

    public float enemyHealth;
    public float enemySpeed;
    public float enemyCollisionDamage;
    public float enemyAttackDamage;
    public float attackRange;
    public float spawnRate;
    public float spawnLevel;
    public float enemyXPReward;

}
