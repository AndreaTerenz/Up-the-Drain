using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GunController : MonoBehaviour
{
    //Rounds per second
    public float fireRate;
    //public float maxSpreadAngle;
    //public float timeTillMaxSpread;
    public bool autoFire = true;

    public GameObject bullet;
    public Transform shootPoint;
    
    [Header("Magazine")]
    public int roundsPerMag;
    public int magsCount;

    private bool _firePrssd;
    public bool firePressed
    {
        get => _firePrssd && hasShots;
        set => _firePrssd = value;
    }
    
    private float _shootingCoolDown;
    private int _shotsLeft;

    private int shots
    {
        get => _shotsLeft;
        set
        {
            if (_shotsLeft <= 0)
            {
                if (magsCount > 0)
                {
                    Debug.Log("Reload");
                    _shotsLeft = roundsPerMag;
                    magsCount -= 1;
                }
            }
            else
            {
                _shotsLeft = value;
            }
            
            _ammoListeners.ForEach(listener => listener.OnNewStatus(_shotsLeft, magsCount));
        }
    }
    private bool hasShots
    {
        get => _shotsLeft > 0 || magsCount > 0;
    }

    private List<AmmunitionStatusListener> _ammoListeners = new List<AmmunitionStatusListener>();
    
    private void Start()
    {
        _shotsLeft = roundsPerMag;
    }
    
    private void Update()
    {
        if (_shootingCoolDown >= 1)
        {
            if (firePressed)
            {
                SpawnBullet();
                
                shots -= 1;
                _shootingCoolDown = 0f;
            }
        }
        else
        {
            _shootingCoolDown += Time.deltaTime * fireRate;
        }
    }

    private void SpawnBullet()
    {
        Quaternion rot = Quaternion.LookRotation(transform.forward);
        
        if (Physics.Raycast(transform.position, rot * Vector3.forward, out RaycastHit info, 10000f))
        {
            GameObject tmp = Instantiate(bullet, shootPoint.position, rot);
            tmp.GetComponent<BulletController>().hitPoint = info.point;
        }
    }

    public void AddAmmoListener(AmmunitionStatusListener l)
    {
        _ammoListeners.Add(l);
        l.OnNewStatus(roundsPerMag, magsCount);
    }
}
