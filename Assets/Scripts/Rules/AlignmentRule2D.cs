using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Regla para dirigirse hacia donde se dirigen los otros boids.
/// </summary>
public class AlignmentRule2D : AbstractFlockRule2D
{
    public AbstractBoidSelector2D selector;

    public override Vector2 Steer(Rigidbody2D boid)
    {
        var overlaps = selector.Select(boid);
        Vector2 steer = Vector2.zero;
        int count = 0;
        foreach (var otherBoid in overlaps)
        {
            if (otherBoid.attachedRigidbody)
            {
                steer += otherBoid.attachedRigidbody.velocity;
                count++;
            }
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
