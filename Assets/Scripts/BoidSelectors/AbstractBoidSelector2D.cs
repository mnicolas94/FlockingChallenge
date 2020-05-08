using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBoidSelector2D : MonoBehaviour
{
    public abstract IEnumerable<Collider2D> Select(Boid2D boid);
}
