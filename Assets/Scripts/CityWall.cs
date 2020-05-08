using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityWall : MonoBehaviour
{
    public Health health;

    public List<Flock2D> flocks;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var boid = other.gameObject.GetComponent<Boid2D>();
            if (boid)
            {
                DestroyBoid(boid);
            }
        }
    }

    private void DestroyBoid(Boid2D boid)
    {
        // eliminarlo de su/s flock/s
        foreach (var flock in flocks)
        {
            flock.RemoveBoid(boid);
        }
        Destroy(boid.gameObject);
    }
}
