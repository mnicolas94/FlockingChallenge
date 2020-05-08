using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingRule2D : AbstractFlockRule2D
{
    public AbstractBoidSelector2D selector;
    
    public override Vector2 Steer(Boid2D boid)
    {
        var overlaps = selector.Select(boid);
        Vector2 sum = Vector2.zero;
        int count = 0;
        foreach (var otherBoid in overlaps)
        {
            sum += (Vector2) otherBoid.transform.up;  // dirección en la que apunta
            count++;
        }

        if (count > 0)
        {
            return (sum / count);
        }
        else
        {
            return Vector2.zero;
        }
    }
}
