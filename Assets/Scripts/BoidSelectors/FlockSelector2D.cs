using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockSelector2D : AbstractBoidSelector2D
{
    public Flock2D flock;
    private List<Collider2D> _boids;

    private void Awake()
    {
        var boids = flock.boids;
        _boids = new List<Collider2D>(boids.Count);
        foreach (var boid in boids)
        {
            _boids.Add(boid.GetComponent<Collider2D>());
        }

        flock.eventBoidAdded += OnBoidAdded;
        flock.eventBoidRemoved += OnBoidRemoved;
    }

    private void OnBoidAdded(Rigidbody2D boid)
    {
        _boids.Add(boid.GetComponent<Collider2D>());
    }
    
    private void OnBoidRemoved(Rigidbody2D boid)
    {
        _boids.Remove(boid.GetComponent<Collider2D>());
    }

    public override IEnumerable<Collider2D> Select(Rigidbody2D boid)
    {
        foreach (var b in _boids)
        {
            if (b.attachedRigidbody != boid)
                yield return b;
        }
    }
}
