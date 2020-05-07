using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flock2D : MonoBehaviour
{
    public DictionaryRule2DWeight rules;
    public List<Rigidbody2D> boids;

    public float maxSpeed;
    public bool fixedSpeed;  // si es true, tratar a maxSpeed como la velocidad fija
    public bool flocking;

    public Action<Rigidbody2D> eventBoidAdded;
    public Action<Rigidbody2D> eventBoidRemoved;

    public void AddBoid(Rigidbody2D boid)
    {
        if (!boids.Contains(boid))  // si no está ya
        {
            boids.Add(boid);
            eventBoidAdded?.Invoke(boid);
        }
    }

    public Rigidbody2D RemoveBoid(Rigidbody2D boid)
    {
        if (boids.Contains(boid))
        {
            boids.Remove(boid);
            eventBoidRemoved?.Invoke(boid);
            return boid;
        }
        return null;
    }

    /// <summary>
    /// Actualizar velocidades de todos los boids según las reglas de flocking definidas.
    /// </summary>
    public void FlockUpdate()
    {
        foreach (var boid in boids)
        {
            Vector2 steer = Vector3.zero;
            foreach (var rule in rules.Keys)
            {
                float weight = rules[rule];
                if (Math.Abs(weight) > 0)
                {
                    var rs = rule.Steer(boid);
                    steer += rs * weight;    
                }
            }

            if (fixedSpeed)
            {
                steer = steer.normalized * maxSpeed;
            }
            else
            {
                steer = Vector2.ClampMagnitude(steer, maxSpeed);
            }
            boid.velocity = steer;
            boid.transform.LookAt2D(boid.position + boid.velocity);
        }
    }
    
    void FixedUpdate()
    {
        if (flocking)
        {
            FlockUpdate();
        }
    }
}

[System.Serializable]
public class DictionaryRule2DWeight : SerializableDictionaryBase<AbstractFlockRule2D, float>
{
}
