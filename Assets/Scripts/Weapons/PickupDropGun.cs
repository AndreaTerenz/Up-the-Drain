using System.Linq;
using UnityEngine;

public class PickupDropGun : MonoBehaviour
{
    public Transform pickupRayOrigin;
    
    private Transform _tr;
    
    private void Start()
    {
        _tr = transform;
    }

    private void Update()
    {
        if (_tr.childCount > 0)
        {
            if (Input.GetButton("Drop Weapon"))
            {
                GameObject gun = transform.GetChild(0).gameObject;
                gun.GetComponentInChildren<GunGroundCheck>().parentTransform = null;
            }
        }
        else if (Physics.Raycast(pickupRayOrigin.position, pickupRayOrigin.forward, out RaycastHit info,
            Constants.WeaponPickupMaxDist, LayerMask.GetMask("Dropped Weapon")))
        {
            //TODO: highlight the weapon hit by the ray
            
            if (Input.GetButtonDown("Pick up Weapon"))
            {
                GameObject gunBody = info.collider.gameObject;
                gunBody.GetComponentInParent<GunGroundCheck>().parentTransform = _tr;
            }
        }
    }
}
