using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockSelector2D : AbstractBoidSelector2D
{
    public Flock2D flock;

    public override IEnumerable<Collider2D> Select(Boid2D boid)
    {
        foreach (var b in flock.boids)
        {
            yield return b.attachedCollider;
        }
    }
}
