using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidFighter : MonoBehaviour
{
    public Boid2D boid;
    public Health health;

    private void Start()
    {
        health.eventDied += OnDied;
    }

    private void OnDied()
    {
        boid.RemoveFromAllFlocks();
        Destroy(boid.gameObject);
    }
}
