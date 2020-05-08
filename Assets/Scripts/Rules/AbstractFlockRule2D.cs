using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFlockRule2D : MonoBehaviour
{
    public abstract Vector2 Steer(Boid2D boid);
}