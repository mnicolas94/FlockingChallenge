using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flock2D : MonoBehaviour
{
    public DictionaryRule2DWeight rules;
    public List<Boid2D> boids;
    public Action<Boid2D> eventBoidAdded;
    public Action<Boid2D> eventBoidRemoved;

    public bool flocking;

    public bool Flocking
    {
        get => flocking;
        set => flocking = value;
    }

    private void Awake()
    {
        if (boids != null)
        {
            foreach (var boid in boids)
            {
                boid.AddFlockAsOwner(this);
            }
        }
    }

    public void AddBoid(Boid2D boid)
    {
        if (!boids.Contains(boid))  // si no está ya
        {
            boid.AddFlockAsOwner(this);
            boids.Add(boid);
            eventBoidAdded?.Invoke(boid);
        }
    }

    public Boid2D RemoveBoid(Boid2D boid)
    {
        if (boids.Contains(boid))
        {
            boid.RemoveFlockAsOwner(this);
            boids.Remove(boid);
            eventBoidRemoved?.Invoke(boid);
            return boid;
        }
        return null;
    }
}

[System.Serializable]
public class DictionaryRule2DWeight : SerializableDictionaryBase<AbstractFlockRule2D, float>
{
}
