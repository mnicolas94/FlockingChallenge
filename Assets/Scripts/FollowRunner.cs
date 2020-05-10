using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRunner : MonoBehaviour
{
    public RunnerCourier runner;
    public float yOffset;
    public bool follow = true;
    
    [NaughtyAttributes.Button()]
    void LateUpdate()
    {
        if (follow)
        {
            Vector3 pos = transform.position;
            pos.y = Math.Max(runner.transform.position.y + yOffset, pos.y);
            transform.position = pos;
        }
    }
}



public class FlechaController : MonoBehaviour
{
    public Transform flecha;
    public Transform punto;
    public float radio;

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(h, v);
        flecha.up = dir;
        Vector2 pos = (Vector2)punto.position + dir * radio;
        flecha.position = pos;
    }
}
