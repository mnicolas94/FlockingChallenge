using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/// <summary>
/// Regla para evadir/alejarse de otros boids.
/// </summary>
public class AvoidanceRule2D : AbstractFlockRule2D
{
    public AbstractBoidSelector2D selector;

    private const float Eps = 1e-8f;
    public override Vector2 Steer(Rigidbody2D boid)
    {
        var pos = (Vector2) boid.transform.position;
        var overlaps = selector.Select(boid);
        Vector2 steer = Vector2.zero;
        int count = 0;
        foreach (var otherBoid in overlaps)
        {
            var diff = pos - (Vector2) otherBoid.transform.position;
            var dist = diff.sqrMagnitude;
            if (dist == 0)
                dist = Eps;
            steer += diff / dist;
            count++;
        }

        if (count > 0)
        {
            return (steer / count);
        }
        else
        {
            return Vector2.zero;
        }
    }
}
