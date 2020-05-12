using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public CollideDamage arrowPrefab;
    public float arrowSpeed;
    public float fireCooldown;

    private float _lastTimeAttack;
    
    public void Attack(Vector2 dir)
    {
        if (Time.time >= _lastTimeAttack + fireCooldown)
        {
            var arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            arrow.transform.up = dir;
            arrow.GetComponent<Rigidbody2D>().velocity = dir.normalized * arrowSpeed;
            _lastTimeAttack = Time.time;
        }
    }
}
