using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Regla para que los boids se dirijan al centro de masa de los boids vecinos.
/// </summary>
public class CohesionRule2D : AbstractFlockRule2D
{
    public AbstractBoidSelector2D selector;
    
    public override Vector2 Steer(Rigidbody2D boid)
    {
        var pos = (Vector2) boid.transform.position;
        var overlaps = selector.Select(boid);
        Vector2 sum = Vector2.zero;
        int count = 0;
        foreach (var otherBoid in overlaps)
        {
            sum += (Vector2) otherBoid.transform.position;
            count++;
        }

        if (count > 0)
        {
            return (sum / count) - pos;
        }
        else
        {
            return Vector2.zero;
        }
    }
}
