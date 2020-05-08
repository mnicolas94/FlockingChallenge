using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Boid2D : MonoBehaviour
{
    public Flock2D flockOwner;
    public float maxSpeed;

    [HideInInspector]
    public Rigidbody2D attachedRigidbody;
    [HideInInspector]
    public Collider2D attachedCollider;
    
    private void Awake()
    {
        attachedRigidbody = GetComponent<Rigidbody2D>();
        attachedCollider = GetComponent<Collider2D>();
    }

    public Vector2 velocity
    {
        get => attachedRigidbody.velocity;
        set => attachedRigidbody.velocity = Vector2.ClampMagnitude(value, maxSpeed);
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
}

[System.Serializable]
public class DictionaryRule2DWeight : SerializableDictionaryBase<AbstractFlockRule2D, float>
{
}
