using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFlockRule3D : MonoBehaviour, IFlockRule3D
{
    public abstract Vector3 Steer(Rigidbody boid);
}

public interface IFlockRule3D
{
    Vector3 Steer(Rigidbody boid);
}