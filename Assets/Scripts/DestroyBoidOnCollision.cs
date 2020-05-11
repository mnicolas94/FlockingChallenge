using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoidOnCollision : MonoBehaviour
{
    public LayerMask mask;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (mask.IsLayerInMask(other.gameObject.layer))
        {
            var boid = other.gameObject.GetComponent<Boid2D>();
            if (boid)
            {
                DestroyBoid(boid);
            }
        }
    }

    private void DestroyBoid(Boid2D boid)
    {
        // eliminarlo de su/s flock/s
        boid.RemoveFromAllFlocks();
        Destroy(boid.gameObject);
    }
}
