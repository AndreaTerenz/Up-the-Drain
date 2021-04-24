using System;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionManager : MonoBehaviour
{
    public int roundsPerMag;
    public int magsCount;
    public int magsLimit;
    
    private List<AmmunitionStatusListener> _ammoListeners = new List<AmmunitionStatusListener>();
    private int _shotsLeft;
    private int shots
    {
        get => _shotsLeft;
        set
        {
            _shotsLeft = value;
                
            if (_shotsLeft <= 0)
            {
                if (magsCount > 0)
                {
                    Debug.Log("Reload");
                    _shotsLeft = roundsPerMag;
                    magsCount -= 1;
                }
            }

            _ammoListeners.ForEach(listener => listener.OnNewStatus(_shotsLeft, magsCount));
        }
    }
    public bool hasShots
    {
        get => _shotsLeft > 0 || magsCount > 0;
    }

    private void Start()
    {
        _shotsLeft = roundsPerMag;
    }

    public void ShootOne()
    {
        shots -= 1;
    }

    public bool AddAmmo(int count)
    {
        if (magsLimit == 0 || magsCount+count <= magsLimit)
        {
            magsCount += count;
            _ammoListeners.ForEach(listener => listener.OnNewStatus(shots, magsCount));
            
            return true;
        }

        return false;
    }
    
    public void AddAmmoListener(AmmunitionStatusListener l)
    {
        _ammoListeners.Add(l);
        l.OnNewStatus(roundsPerMag, magsCount);
    }
}