using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFlock : MonoBehaviour
{
    public Flock2D flock;
    public float xoffset;
    public bool freezeY;
    public bool following = true;

    // Update is called once per frame
    void LateUpdate()
    {
        if (following)
        {
            var t = transform;
            Vector3 pos = MaxX();
//        Vector3 pos = MeanPos();
            if (pos.x > t.position.x)
            {
                pos.x += xoffset;
                if (freezeY)
                    pos.y = t.position.y;
                pos.z = t.position.z;
                t.position = pos;
            }
        }
    }

    private Vector2 MaxX()
    {
        var max = Vector2.zero;
        float maxX = Mathf.NegativeInfinity;
        foreach (var boid in flock.boids)
        {
            var pos = boid.position;
            if (pos.x > maxX)
            {
                max = pos;
                maxX = pos.x;
            }
        }

        return max;
    }
    
    private Vector2 MeanPos()
    {
        var mean = Vector2.zero;
        foreach (var boid in flock.boids)
        {
            var pos = boid.position;
            mean += pos;
        }

        mean /= flock.boids.Count;
        return mean;
    }
}
