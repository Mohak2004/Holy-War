using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] BoxCollider2D spawnArea;
    public List<EnemySO> spawnableEnemiesL1;
    public List<EnemySO> spawnableEnemiesL2;

    List<EnemySpawnTimer> active = new();

    private void Start()
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1"))
        {
            foreach (var w in spawnableEnemiesL1)
            {
                active.Add(new EnemySpawnTimer { enemy = w });
            }
        }
        else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
        {
            foreach (var w in spawnableEnemiesL2)
            {
                active.Add(new EnemySpawnTimer { enemy = w });
            }
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
