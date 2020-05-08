using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoid : MonoBehaviour
{
    public Boid2D boid;
    public Health health;

    private void Start()
    {
        health.eventDied += OnDied;
    }

    private void OnDied()
    {
        boid.flockOwner.RemoveBoid(boid);
        Destroy(boid.gameObject);
    }
}
