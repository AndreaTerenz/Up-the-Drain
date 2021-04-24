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
            muzzleFlash.SetActive(_shoot);
        }
    }

    public bool alwaysOn;
    
    public Transform gunBody;
    public GameObject muzzleFlash;

    private GunShooting gunCtrl;

    private void Start()
    {
        Shoot = alwaysOn;
        gunCtrl = GetComponent<GunShooting>();
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
