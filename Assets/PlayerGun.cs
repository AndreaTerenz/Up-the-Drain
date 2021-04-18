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
        gunCtrl.firePressed = fireCheckFunction("Fire1");
    }
}
