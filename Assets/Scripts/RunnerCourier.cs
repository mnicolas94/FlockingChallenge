using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerCourier : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float xDirLimit;
    
    void Start()
    {
        Move(0);
    }

    public void Move(float x)
    {
        float norm = xDirLimit * x;
        Vector2 dir = new Vector2(norm, 1).normalized;
        rb.velocity = dir * speed;
        transform.up = dir;
    }
}
