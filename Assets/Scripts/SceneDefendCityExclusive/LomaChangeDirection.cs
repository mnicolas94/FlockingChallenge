using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LomaChangeDirection : MonoBehaviour
{
    public LayerMask mask;
    public List<Flock2D> removeFlocks;
    public List<Flock2D> addFlocks;
    public int orderInLayer;
    public string newLayerName;
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (mask.IsLayerInMask(other.gameObject.layer))
        {
            other.gameObject.layer = LayerMask.NameToLayer(newLayerName);  // cambiar el layer
            Boid2D boid = other.GetComponent<Boid2D>();
            if (boid)
            {
                foreach (var flock in removeFlocks)
                {
                    boid.RemoveFromFlock(flock);
                }
                foreach (var flock in addFlocks)
                {
                    boid.AddToFlock(flock);
                }
            }

            SpriteRenderer sp = other.GetComponent<SpriteRenderer>();
            if (sp)
            {
                sp.sortingOrder = orderInLayer;
            }
        }
    }
}
