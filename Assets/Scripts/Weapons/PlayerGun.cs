using System;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    private GunShooting gunCtrl;
    private Func<string, bool> fireCheckFunction;

    private void Start()
    {
        gunCtrl = GetComponent<GunShooting>();
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
        gunCtrl.firePressed = fireCheckFunction("Fire1");
    }
}
