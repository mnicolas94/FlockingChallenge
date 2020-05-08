using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public LayerMask notDestroyCollision;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!notDestroyCollision.IsLayerInMask(other.gameObject.layer))
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!notDestroyCollision.IsLayerInMask(other.gameObject.layer))
        {
            Destroy(gameObject);
        }
    }
}
