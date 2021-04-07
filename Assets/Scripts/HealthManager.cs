using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private float _health = 20f;

    public float currentHealth
    {
        get => _health;
        set
        {
            _health = value;
            if (_health <= 0f)
            {
                Kill();
            }
        }
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}