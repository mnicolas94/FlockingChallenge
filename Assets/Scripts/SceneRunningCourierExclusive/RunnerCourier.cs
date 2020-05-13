using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class RunnerCourier : MonoBehaviour
{
    public UnityEvent eventOnRunEnded;
    public GameObject loseMenu;
    
    public Rigidbody2D rb;
    public float speed;
    public float xDirLimit;
    public bool running;

    public bool Running
    {
        get => running;
        set => running = value;
    }

    void Start()
    {
        Move(0);
    }
    
    public void Move(float x)
    {
        if (running)
        {
            float norm = xDirLimit * x;
            Vector2 dir = new Vector2(norm, 1).normalized;
            rb.velocity = dir * speed;
            transform.up = dir;
        }
        else
        {
            rb.velocity = Vector2.zero;
            transform.up = Vector3.up;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Enemies")
        {
            running = false;
            loseMenu.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RoadEnd"))
        {
            running = false;
            eventOnRunEnded?.Invoke();
        }
    }
}
