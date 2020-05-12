using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public Health health;
    public TextMeshProUGUI text;

    private void Start()
    {
        UpdateText();
        health.eventDamaged += OnDamaged;
        health.eventHealed += OnHealed;
    }

    private void OnHealed(int obj)
    {
        UpdateText();
    }

    private void OnDamaged(int obj)
    {
        UpdateText();
    }

    private void UpdateText()
    {
        text.SetText(health.CurrentHealth.ToString());
    }
}
