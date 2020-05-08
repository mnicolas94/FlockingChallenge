using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;

    public Action<int> eventHealed;
    public Action<int> eventDamaged;
    public Action eventDied;

    private int _currentHealth;
    [NaughtyAttributes.ShowNativeProperty]
    public int CurrentHealth => _currentHealth;

    void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void Heal(int heal)
    {
        int oldHealth = _currentHealth;
        _currentHealth += heal;
        int receivedHealing = oldHealth - _currentHealth;
        eventHealed?.Invoke(receivedHealing);
    }
    
    public void Damage(int dmg)
    {
        int oldHealth = _currentHealth;
        _currentHealth = Math.Max(_currentHealth - dmg, 0);
        int receivedDmg = oldHealth - _currentHealth;
        eventDamaged?.Invoke(receivedDmg);

        if (_currentHealth <= 0)
        {
            eventDied?.Invoke();
        }
    }
}
