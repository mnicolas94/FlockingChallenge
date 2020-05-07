using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedDirRule2D : AbstractFlockRule2D
{
    public Vector2 dir;
    public float magnitude;
    
    public override Vector2 Steer(Rigidbody2D boid)
    {
        return dir.normalized * magnitude;
    }
}
