﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WavesController : MonoBehaviour
{
    /// <summary>
    /// Aquí se definen el flock populator, la cantidad de boids a instanciar, y el tiempo (segundos) a partir de que
    /// comenzó la escena en que se instanciará
    /// </summary>
    public List<Wave> waves;

    public Action eventLastWaveSpawned;

    private int _nextWaveIndex;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (waves != null)
        {
            waves = new List<Wave>(waves.OrderBy(w => w.seconds));
            foreach (var wave in waves)
            {
                wave.populator.count = 0;
            }
        }
    }

    void Update()
    {
        if (_nextWaveIndex < waves.Count)
        {
            if (Time.time >= waves[_nextWaveIndex].seconds)
            {
                SpawnWave(waves[_nextWaveIndex]);
                _nextWaveIndex++;
                
                if (_nextWaveIndex == waves.Count)  // notificar que se instanció la última oleada
                    eventLastWaveSpawned?.Invoke();
            }  
        }
    }

    private void SpawnWave(Wave wave)
    {
        wave.populator.count = wave.boidsCount;
        wave.populator.SpawnBoids();
    }
}

[System.Serializable]
public struct Wave
{
    public FlockPopulator2D populator;
    public int boidsCount;
    public float seconds;
}

[System.Serializable]
public class DictionaryFlockPopulatorSeconds : SerializableDictionaryBase<FlockPopulator2D, float>{}