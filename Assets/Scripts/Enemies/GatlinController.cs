using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlinController : MonoBehaviour
{
    private bool _shoot;
    public bool Shoot
    {
        get => _shoot;
        set
        {
            _shoot = alwaysOn || value;
            if (_shoot)
            {
                muzzleFlash.Play();
            }
            else
            {
                muzzleFlash.Stop();
            }
        }
    }

    public bool alwaysOn;
    
    public Transform gunBody;
    public ParticleSystem muzzleFlash;

    private GunController gunCtrl;

    private void Start()
    {
        Shoot = alwaysOn;
        gunCtrl = GetComponent<GunController>();
    }

    void Update()
    {
        gunCtrl.firePressed = Shoot;
        
        if (Shoot)
        {
            gunBody.Rotate(Vector3.up, Constants.GatlinRotSpeed * Time.deltaTime);
        }
    }
}
