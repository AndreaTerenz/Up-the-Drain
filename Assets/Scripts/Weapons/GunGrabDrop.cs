using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGrabDrop : MonoBehaviour
{
    public GameObject gunHolderPF;
    public GameObject gun;
    public Transform pickupRayOrigin;

    private void Update()
    {
        if (Input.GetButton("Drop Weapon"))
        {
            Drop();
        }
    }

    void Drop()
    {
        var position = transform.position;
        GameObject gigi = Instantiate(gunHolderPF, position, Quaternion.identity);
        gigi.transform.position = position;

        gun.GetComponent<GunController>().onGround = true;
        gun.transform.SetParent(gigi.transform);
    }
}
