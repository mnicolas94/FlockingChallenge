using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockInitializer2D : MonoBehaviour
{
    public Flock2D flock;
    public Rigidbody2D boidPrefab;
    public int count;
    public float spawnRadius;

    [NaughtyAttributes.Button()]
    public void SpawnBoids()
    {
        for (int i = 0; i < count; i++)
        {
            var flockTransform = flock.transform;
            Vector3 flockPos = flockTransform.position;
            Vector3 randPos = (Vector3)(Random.insideUnitCircle * spawnRadius) + flockPos;
            Rigidbody2D boid = Instantiate(boidPrefab, randPos, Quaternion.identity, flockTransform);
            flock.AddBoid(boid);
        }
    }
    
    void Start()
    {
        SpawnBoids();
    }
}
