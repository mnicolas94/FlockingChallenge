using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class WavesController : MonoBehaviour
{
    /// <summary>
    /// Aquí se definen el flock populator, la cantidad de boids a instanciar, y el tiempo (segundos) a partir de que
    /// comenzó la escena en que se instanciará
    /// </summary>
    public List<Wave> waves;

    #region Parámetros para facilitar la edición en el editor

    public float secondsSumAll;
    public float secondsMultiplyAll = 1;
    public FlockPopulator2D oldFpSwap;
    public FlockPopulator2D newFpSwap;

    #endregion

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
            if (Time.timeSinceLevelLoad >= waves[_nextWaveIndex].seconds)
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

    [NaughtyAttributes.Button()]
    public void SumAll()
    {
        foreach (var wave in waves)
        {
            wave.seconds += secondsSumAll;
        }
    }
    
    [NaughtyAttributes.Button()]
    public void MultiplyAll()
    {
        foreach (var wave in waves)
        {
            wave.seconds *= secondsSumAll;
        }
    }

    [NaughtyAttributes.Button()]
    public void SwapPopulators()
    {
        foreach (var wave in waves)
        {
            if (wave.populator == oldFpSwap)
            {
                wave.populator = newFpSwap;
            }
        }
    }
}

[System.Serializable]
public class Wave
{
    public FlockPopulator2D populator;
    public int boidsCount;
    public float seconds;
}

[System.Serializable]
public class DictionaryFlockPopulatorSeconds : SerializableDictionaryBase<FlockPopulator2D, float>{}