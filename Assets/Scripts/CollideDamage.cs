using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDamage : MonoBehaviour
{
    public int attack;

    public LayerMask targetLayerMask;

    public Action<Health> eventDamageDone;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (targetLayerMask.IsLayerInMask(other.gameObject.layer))
        {
            var health = other.gameObject.GetComponent<Health>();
            if (health)
            {
                health.Damage(attack);
                eventDamageDone?.Invoke(health);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (targetLayerMask.IsLayerInMask(other.gameObject.layer))
        {
            var health = other.gameObject.GetComponent<Health>();
            if (health)
            {
                health.Damage(attack);
                eventDamageDone?.Invoke(health);
            }
        }
    }
}
