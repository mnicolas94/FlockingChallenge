using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFlockRule2D : MonoBehaviour, IFlockRule2D
{
    public abstract Vector2 Steer(Rigidbody2D boid);
}

public interface IFlockRule2D
{
    Vector2 Steer(Rigidbody2D boid);
}