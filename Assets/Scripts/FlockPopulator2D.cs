using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockPopulator2D : MonoBehaviour
{
    public List<Flock2D> flocks;
    public Boid2D boidPrefab;
    public int count;
    public float spawnRadius;
    public Vector2 relPosition;

    [NaughtyAttributes.Button()]
    public void SpawnBoids()
    {
        if (flocks == null || flocks.Count == 0)
            return;
        
        for (int i = 0; i < count; i++)
        {
            // Instacnciar como hijo y relativo a la posición del 1er flock
            var flockTransform = flocks[0].transform;
            Vector3 flockPos = flockTransform.position;
            Vector3 randPos = (Vector3)(Random.insideUnitCircle * spawnRadius) + flockPos;
            Vector3 spawnPos = randPos + (Vector3)relPosition;
            Boid2D boid = Instantiate(boidPrefab, spawnPos, Quaternion.identity, flockTransform);
            foreach (var flock in flocks)
            {
                // añadirlo a todos los flocks
                flock.AddBoid(boid);    
            }
        }
    }
    
    void Start()
    {
        SpawnBoids();
    }
}
