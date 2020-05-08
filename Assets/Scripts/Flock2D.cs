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

    public float maxSpeed;
    public bool fixedSpeed;  // si es true, tratar a maxSpeed como la velocidad fija
    public bool flocking;

    private void Awake()
    {
        if (boids != null)
        {
            foreach (var boid in boids)
            {
                boid.flockOwner = this;
            }
        }
    }

    public void AddBoid(Boid2D boid)
    {
        if (!boids.Contains(boid))  // si no está ya
        {
            boid.flockOwner = this;
            boids.Add(boid);
            eventBoidAdded?.Invoke(boid);
        }
    }

    public Boid2D RemoveBoid(Boid2D boid)
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

//[System.Serializable]
//public class DictionaryRule2DWeight : SerializableDictionaryBase<AbstractFlockRule2D, float>
//{
//}
