using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

[RequireComponent(typeof(Rigidbody2D))]
public class Boid2D : MonoBehaviour
{
//    public DictionaryRule2DWeight rules;  // TODO ver si le pongo reglas independientes también
    public float maxSpeed;
    public bool fixedSpeed;
    public bool lookAtVelocity = true;
    
    [HideInInspector]
    public Rigidbody2D attachedRigidbody;
    [HideInInspector]
    public Collider2D attachedCollider;
    
    private List<Flock2D> _flockOwners;
    public List<Flock2D> FlockOwners
    {
        get
        {
            if (_flockOwners == null)
                _flockOwners = new List<Flock2D>();
            return _flockOwners;
        }
    }

    private void Awake()
    {
        if (_flockOwners == null)
            _flockOwners = new List<Flock2D>();
        attachedRigidbody = GetComponent<Rigidbody2D>();
        attachedCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        ApplyRules();
    }

    public Vector2 velocity
    {
        get => attachedRigidbody.velocity;
        set
        {
            if (fixedSpeed)
            {
                attachedRigidbody.velocity = value.normalized * maxSpeed;
            }
            else
            {
                attachedRigidbody.velocity = Vector2.ClampMagnitude(value, maxSpeed);
            }
        }
    }

    public Vector2 position
    {
        get => transform.position;
        set
        {
            var t = transform;
            var pos = t.position;
            pos.x = value.x;
            pos.y = value.y;
            t.position = pos;
        }
    }

    public void AddFlockAsOwner(Flock2D flock)
    {
        
        FlockOwners?.Add(flock);
    }
    
    public void RemoveFlockAsOwner(Flock2D flock)
    {
        FlockOwners?.Remove(flock);
    }

    public void AddToFlock(Flock2D flock)
    {
        flock.AddBoid(this);
    }
    
    public void RemoveFromFlock(Flock2D flock)
    {
        flock.RemoveBoid(this);
    }
    
    public void RemoveFromAllFlocks()
    {
        while (FlockOwners.Count > 0)
        {
            RemoveFromFlock(FlockOwners[0]);
        }
    }
    
    public void ApplyRules()
    {
        Vector2 steer = Vector3.zero;
        foreach (var flock in FlockOwners)
        {
            if (!flock.flocking)
                continue;
            var rules = flock.rules;
            foreach (var rule in rules.Keys)
            {
                float weight = rules[rule];
                if (Math.Abs(weight) > 0)
                {
                    var rs = rule.Steer(this);
                    steer += rs * weight;    
                }
            }
        }
        
        velocity = steer;
        if (lookAtVelocity)
            transform.up = velocity;
    }
}
