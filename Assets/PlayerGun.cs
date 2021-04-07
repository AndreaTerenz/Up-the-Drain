using System;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    private GunController gunCtrl;
    private Func<string, bool> fireCheckFunction;

    private void Start()
    {
        gunCtrl = GetComponent<GunController>();
        if (gunCtrl.autoFire)
        {
            fireCheckFunction = Input.GetButton;
        }
        else
        {
            fireCheckFunction = Input.GetButtonDown;
        }
    }

    void Update()
    {
        gunCtrl.Shoot(fireCheckFunction("Fire1"));
    }
}
