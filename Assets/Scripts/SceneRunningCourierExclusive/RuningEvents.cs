using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class RuningEvents : MonoBehaviour
{
    public FollowRunner fr;
    public Flock2D flock;

    public Collider2D roadEnd;
    public float startSlowY;
    public float endSlowY;

    private float _boidsSpeed;

    private void Start()
    {
        _boidsSpeed = flock.boids[0].maxSpeed;  // TODO esto así está majá
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == roadEnd)  // dejar de moverse
        {
            fr.follow = false;
        }
    }

    private void Update()
    {
        float y = transform.position.y;
        if (y >= startSlowY && y <= endSlowY)
        {
            var normSpeed = ((endSlowY - y) / (endSlowY - startSlowY)) * _boidsSpeed;
            if (normSpeed <= Mathf.Epsilon)
            {
                flock.flocking = false;
            }
            SetBoidsSpeed(normSpeed);
        }
    }

    private void SetBoidsSpeed(float speed)
    {
        foreach (var boid in flock.boids)
        {
            boid.maxSpeed = speed;
        }
    }
}
