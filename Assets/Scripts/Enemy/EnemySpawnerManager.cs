using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] BoxCollider2D spawnArea;
    public List<EnemySO> spawnableEnemies;

    List<EnemySpawnTimer> active = new();

    private void Start()
    {
        foreach (var w in spawnableEnemies)
        {
            active.Add(new EnemySpawnTimer { enemy = w });
        }
    }
    void Update()
    {
        foreach(var a in active)
        {
            a.Tick(spawnArea, Time.deltaTime);
        }
    }
}
