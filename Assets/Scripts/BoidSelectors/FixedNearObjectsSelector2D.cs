using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// 
/// </summary>
[Obsolete("Use FixedObjectSelector2D as delegate of NearSelectorFilter2D instead.")]
public class FixedNearObjectsSelector2D : AbstractBoidSelector2D
{
    public List<Collider2D> boids;
    public float radius;
    
    public override IEnumerable<Collider2D> Select(Boid2D boid)
    {
        Vector2 pos = boid.transform.position;
        foreach (var b in boids)
        {
            Vector2 bpos = b.ClosestPoint(pos);  // TODO ver si por fin dejo esto o lo de abajo
//            Vector2 bpos = b.transform.position;
            float sqrDist = (pos - bpos).sqrMagnitude;
            if (sqrDist < radius * radius)
                yield return b;
        }
    }
}
