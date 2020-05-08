using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomRule2D : AbstractFlockRule2D
{
    [Range(0.0f, 1.0f)]
    public float probRandom;  // prbabilidad de moverse random
    
    public override Vector2 Steer(Boid2D boid)
    {
        float random = Random.value;

        if (random < probRandom)
        {
            return Random.insideUnitCircle;
        }
        else
        {
            return boid.velocity;  // devolver la velocidad que ya tenía
        }
    }
}
