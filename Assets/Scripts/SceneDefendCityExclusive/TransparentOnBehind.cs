using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentOnBehind : MonoBehaviour
{
    public SpriteRenderer sp;
    public float transparency;

    private int _objectsBehind;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _objectsBehind++;
        SetTransparency(transparency);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _objectsBehind--;
        if (_objectsBehind == 0)
        {
            SetTransparency(1f);
        }
    }

    private void SetTransparency(float alpha)
    {
        Color c = sp.color;
        c.a = alpha;
        sp.color = c;
    }
}
