using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateFlockingZone : MonoBehaviour
{
    public Bounds bounds;

    // Update is called once per frame
    void LateUpdate()
    {
        var pos = transform.position;
        if (pos.x < bounds.min.x)
        {
            pos.x = bounds.max.x;
        }
        if (pos.y < bounds.min.y)
        {
            pos.y = bounds.max.y;
        }
        if (pos.x > bounds.max.x)
        {
            pos.x = bounds.min.x;
        }
        if (pos.y > bounds.max.y)
        {
            pos.y = bounds.min.y;
        }

        transform.position = pos;
    }
}
