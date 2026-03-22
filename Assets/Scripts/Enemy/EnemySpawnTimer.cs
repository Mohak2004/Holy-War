using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnTimer
{
    public EnemySO enemy;
    float timer;
    public BoxCollider2D spawnArea;


    public void Tick(BoxCollider2D spawnArea, float time)
    {
        timer += time;

        if ( timer > enemy.spawnRate)
        {
            Spawn(spawnArea);
            timer = 0;
        }
    }

    public void Spawn(BoxCollider2D spawnArea)
    {
        Vector2 spawnPos = GetRandomEdgePoint(spawnArea);
        GameObject.Instantiate(enemy.enemyPrefab, spawnPos, Quaternion.identity);
    }

    Vector2 GetRandomEdgePoint(BoxCollider2D spawnArea)
    {
        Bounds b = spawnArea.bounds;

        int edge = Random.Range(0, 4);

        switch(edge)
        {
            case 0:return new Vector2(
                Random.Range(b.min.x, b.min.y),
                b.max.y);

            case 1:return new Vector2(
                Random.Range(b.min.x, b.min.y),
                b.min.y);

            case 2:return new Vector2(
                b.min.x,
                Random.Range(b.min.y, b.max.y));

            default:return new Vector2(
                b.max.x,
                Random.Range(b.min.y, b.max.y));
        }
    }
}