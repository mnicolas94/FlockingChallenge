using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FlockSettings : ScriptableObject
{
    /// <summary>
    /// Cantidad de frames entre cada actualización del movimiento de los boids.
    /// </summary>
    [Min(0)]
    public int framesBetweenFlockStep;  // Esto es un mojón
}
