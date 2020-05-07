using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class FixedNearObjectsSelector2D : AbstractBoidSelector2D
{
    public List<Collider2D> boids;
    public float radius;
    
    public override IEnumerable<Collider2D> Select(Rigidbody2D boid)
    {
        Vector2 pos = boid.transform.position;
        foreach (var b in boids)
        {
            Vector2 bpos = b.ClosestPoint(pos);
//            Vector2 bpos = b.transform.position;
            float dist = (pos - bpos).magnitude;
            if (dist < radius)
                yield return b;
        }
    }
}
