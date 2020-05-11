using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refuge : MonoBehaviour
{
    public Action<Boid2D> eventRefugeeArrived;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boid"))
        {
            Boid2D boid = other.GetComponent<Boid2D>();
            if (boid)
            {
                boid.RemoveFromAllFlocks();
                Destroy(other.gameObject);
                eventRefugeeArrived?.Invoke(boid);
            }
        }
    }
}
