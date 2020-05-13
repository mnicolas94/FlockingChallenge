using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinCondition : MonoBehaviour
{
    public WavesController wc;
    public Flock2D enemyFlock;

    public UnityEvent eventWin;

    private int _enemiesAliveCount;
    
    void Start()
    {
        wc.eventLastWaveSpawned += OnLastWave;
    }

    private void OnLastWave()
    {
        var enemies = enemyFlock.boids;
        _enemiesAliveCount = enemies.Count;
        foreach (var boid in enemies)
        {
            boid.GetComponent<Health>().eventDied.AddListener(OnBoidDied);
        }
    }

    private void OnBoidDied()
    {
        _enemiesAliveCount--;
        if (_enemiesAliveCount <= 0)
            eventWin?.Invoke();
    }
}
