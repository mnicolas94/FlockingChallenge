using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearSelectorFilter2D : AbstractBoidSelector2D
{
    public AbstractBoidSelector2D delegateSelector;
    public float radius;
    public LayerMask mask;

    private Collider2D[] _overlapsBuffer;

    private void Awake()
    {
        _overlapsBuffer = new Collider2D[1000];  // número que cogí arbitrariamente
    }

    public override IEnumerable<Collider2D> Select(Boid2D boid)
    {
        IEnumerable<Collider2D> selections;
        if (delegateSelector)
        {
            Vector2 pos = boid.transform.position;
            selections = delegateSelector.Select(boid);
            foreach (var overlap in selections)
            {
                Vector2 p = overlap.ClosestPoint(pos);  // TODO ver si por fin dejo esto o lo de abajo
//                Vector2 p = overlap.transform.position;
                var sqrdist = (pos - p).sqrMagnitude;
                if (sqrdist < radius*radius && mask.IsLayerInMask(overlap.gameObject.layer))
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

    private IEnumerable<Collider2D> GetNear(Boid2D boid)
    {
        var pos = (Vector2) boid.transform.position;
        int overlapsCount = Physics2D.OverlapCircleNonAlloc(pos, radius, _overlapsBuffer, mask);
        for (int i = 0; i < overlapsCount; i++)
        {
            var overlap = _overlapsBuffer[i];
            if (overlap.gameObject != boid.gameObject)
                yield return overlap;
        }
    }
}
