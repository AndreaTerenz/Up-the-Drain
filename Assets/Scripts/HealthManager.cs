using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float startingHealth = 200f;
    
    private float _health;

    public float currentHealth
    {
        get => _health;
        set
        {
            _health = value;
            CheckHealth();
        }
    }

    private void Start()
    {
        _health = startingHealth;
    }

    void CheckHealth()
    {
        Debug.Log(gameObject.name + " hit");
        if (_health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}