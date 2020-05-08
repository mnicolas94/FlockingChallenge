using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedObjectsSelector2D : AbstractBoidSelector2D
{
    public List<Collider2D> boids;

    public override IEnumerable<Collider2D> Select(Boid2D boid)
    {
        foreach (var b in boids)
        {
            if (b != boid.attachedCollider)
                yield return b;
        }
    }
}
