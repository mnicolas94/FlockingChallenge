using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public CollideDamage arrowPrefab;
    public float arrowSpeed;
    
    public void Attack(Vector2 dir)
    {
        var arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrow.transform.up = dir;
        arrow.GetComponent<Rigidbody2D>().velocity = dir.normalized * arrowSpeed;
    }
}
