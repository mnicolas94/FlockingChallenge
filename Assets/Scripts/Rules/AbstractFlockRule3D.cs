using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFlockRule3D : MonoBehaviour
{
    public abstract Vector3 Steer(Rigidbody boid);
}