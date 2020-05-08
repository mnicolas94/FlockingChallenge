using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Obsolete("Use NearSelectorFilter2D instead")]
public class NearSelector2D : AbstractBoidSelector2D
{
    public float radius;
    
    public override IEnumerable<Collider2D> Select(Boid2D boid)
    {
        var pos = (Vector2) boid.transform.position;
        var overlaps = Physics2D.OverlapCircleAll(pos, radius);
        foreach (var overlap in overlaps)
        {
            if (overlap.gameObject != boid.gameObject)
                yield return overlap;
        }
    }
}
