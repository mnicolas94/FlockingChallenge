using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Elemento de flocking que puede morir
/// </summary>
public class BoidAlive : MonoBehaviour
{
    public Boid2D boid;
    public Health health;

    private void Start()
    {
        health.eventDied.AddListener(OnDied);
    }

    private void OnDied()
    {
        boid.RemoveFromAllFlocks();
        Destroy(boid.gameObject);
    }
}
