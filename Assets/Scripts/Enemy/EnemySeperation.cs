using UnityEngine;

public class EnemySeperation : MonoBehaviour
{
    public float separationRadius = 0.8f;
    public float separationStrength = 2f;

    void Update()
    {
        Collider2D[] nearby =
            Physics2D.OverlapCircleAll(
                transform.position,
                separationRadius
            );

        Vector2 push = Vector2.zero;

        foreach (var col in nearby)
        {
            if (col.gameObject == gameObject)
                continue;

            if (col.CompareTag("Player"))
            {
                Vector2 diff =
                    (Vector2)transform.position -
                    (Vector2)col.transform.position;

                float distance = diff.magnitude;

                if (distance > 0)
                    push += diff.normalized / distance;
            }
        }

        transform.position +=
            (Vector3)(push * separationStrength * Time.deltaTime);
    }
}
