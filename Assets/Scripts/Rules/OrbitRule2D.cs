using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitRule2D : AbstractFlockRule2D
{
    public AbstractBoidSelector2D selector;
    public bool clockwise;
    
    public override Vector2 Steer(Rigidbody2D boid)
    {
        Vector2 pos = boid.position;
        var boids = new List<Collider2D>(selector.Select(boid));
        if (boids.Count > 0)
        {
            var meanPos = meanPosition(boids);
            var radiusVec = pos - meanPos;
            var tangent = radiusVec.ortoNormalized();
            var clockOriented = GetOrientation(radiusVec, tangent, clockwise);
            return clockOriented;
        }
        else
        {
            return Vector2.zero;
        }
        
    }

    Vector2 meanPosition(List<Collider2D> boids)
    {
        var mean = Vector2.zero;
        foreach (var boid in boids)
        {
            Vector2 pos = boid.transform.position;
            mean += pos;
        }

        return mean / boids.Count;
    }

    Vector2 GetOrientation(Vector2 vec, Vector2 ortogonal, bool cw)
    {
        int xsing = Math.Sign(vec.x);
        int ysing = Math.Sign(vec.y);
        if (cw)
        {
            ortogonal.x = Math.Abs(ortogonal.x) * ysing;
            ortogonal.y = Math.Abs(ortogonal.y) * -xsing;
        }
        else
        {
            ortogonal.x = Math.Abs(ortogonal.x) * -ysing;
            ortogonal.y = Math.Abs(ortogonal.y) * xsing;
        }
        return ortogonal;
    }
}
