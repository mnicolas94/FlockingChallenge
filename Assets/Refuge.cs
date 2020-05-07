using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refuge : MonoBehaviour
{
    public Flock2D flock;

    public Action<Rigidbody2D> eventRefugeeArrived;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // TODO implementar
        if (other.CompareTag("Boid"))
        {
            flock.RemoveBoid(other.attachedRigidbody);
            Destroy(other.gameObject);
            eventRefugeeArrived?.Invoke(other.attachedRigidbody);
        }
    }
}
