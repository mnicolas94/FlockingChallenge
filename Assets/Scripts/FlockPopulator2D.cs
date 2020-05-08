using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockPopulator2D : MonoBehaviour
{
    public Flock2D flock;
    public Boid2D boidPrefab;
    public int count;
    public float spawnRadius;
    public Vector2 relPosition;

    [NaughtyAttributes.Button()]
    public void SpawnBoids()
    {
        for (int i = 0; i < count; i++)
        {
            var flockTransform = flock.transform;
            Vector3 flockPos = flockTransform.position;
            Vector3 randPos = (Vector3)(Random.insideUnitCircle * spawnRadius) + flockPos;
            Vector3 spawnPos = randPos + (Vector3)relPosition;
            Boid2D boid = Instantiate(boidPrefab, spawnPos, Quaternion.identity, flockTransform);
            flock.AddBoid(boid);
        }
    }
    
    void Start()
    {
        SpawnBoids();
    }
}
