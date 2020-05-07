using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearSelectorFilter2D : AbstractBoidSelector2D
{
    public AbstractBoidSelector2D delegateSelector;
    public float radius;
    public LayerMask mask;
    
    public override IEnumerable<Collider2D> Select(Rigidbody2D boid)
    {
        IEnumerable<Collider2D> selections;
        if (delegateSelector)
        {
            Vector2 pos = boid.transform.position;
            selections = delegateSelector.Select(boid);
            foreach (var overlap in selections)
            {
                Vector2 p = overlap.ClosestPoint(pos);
//                Vector2 p = overlap.transform.position;
                var sqrdist = (pos - p).sqrMagnitude;
                if (sqrdist < radius*radius && ValidLayer(overlap.gameObject))
                    yield return overlap;
            }
        }
        else
        {
            selections = GetNear(boid);
            foreach (var overlap in selections)
            {
                yield return overlap;
            }
        }
    }

    private bool ValidLayer(GameObject go)
    {
        return ((1 << go.layer) & mask.value) > 0;
    }

    private IEnumerable<Collider2D> GetNear(Rigidbody2D boid)
    {
        var pos = (Vector2) boid.transform.position;
        var overlaps = Physics2D.OverlapCircleAll(pos, radius, mask);
        foreach (var overlap in overlaps)
        {
            if (overlap.gameObject != boid.gameObject)
                yield return overlap;
        }
    }
}
