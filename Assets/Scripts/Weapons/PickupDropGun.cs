using System.Linq;
using UnityEngine;

public class PickupDropGun : MonoBehaviour
{
    public Transform pickupRayOrigin;
    public Transform playerGroundCheck;
    
    private GameObject _lastGun;
    private Transform _tr;
    
    private float _gunTimer = 0f;
    private bool ignoreLastGun
    {
        get => _gunTimer >= Constants.WeaponPickupLastGunCooldown;
    }
    
    private void Start()
    {
        _tr = transform;
    }

    private void Update()
    {
        _gunTimer = Mathf.Min(_gunTimer + Time.deltaTime, Constants.WeaponPickupLastGunCooldown);

        if (_tr.childCount > 0)
        {
            if (Input.GetButton("Drop Weapon"))
            {
                GameObject gun = transform.GetChild(0).gameObject;
                gun.GetComponentInChildren<GunGroundCheck>().parentTransform = null;
                _lastGun = gun;
                _gunTimer = 0f;
            }
        }
        else
        {
            RaycastHit info;
            
            if (Input.GetButtonDown("Pick up Weapon"))
            {
                if (Physics.Raycast(pickupRayOrigin.position, pickupRayOrigin.forward, out info,
                                    Constants.WeaponPickupMaxDist, LayerMask.GetMask("Dropped Weapon"))) 
                {
                    GameObject gunBody = info.collider.gameObject;
                    gunBody.GetComponentInParent<GunGroundCheck>().parentTransform = _tr;
                }
            }
            else
            {
                Collider[] colliders = Physics.OverlapSphere(playerGroundCheck.position, Constants.WeaponPickupMaxDist * 2 / 4, LayerMask.GetMask("Dropped Weapon"));

                foreach (Collider coll in colliders)
                {
                    GameObject gun = coll.gameObject;
                    if (!ReferenceEquals(gun.transform.parent, null))
                    {
                        gun = gun.transform.parent.gameObject;
                    }
                    
                    if (ignoreLastGun || !ReferenceEquals(gun, _lastGun))
                    {
                        gun.GetComponentInParent<GunGroundCheck>().parentTransform = _tr;
                        break;
                    }
                }
            }
        }
    }
}
