using System;
using UnityEngine;

public class FloaterPickup : MonoBehaviour
{
    public Transform pickupRefPoint;
    public AmmunitionManager ammoManager;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(pickupRefPoint.position, 1f, LayerMask.GetMask("Floater"));
        
        foreach (Collider c in colliders)
        {
            GameObject obj = c.gameObject;

            if (!ReferenceEquals(ammoManager, null) && obj.TryGetComponent(out AmmoFloater af) && ammoManager.AddAmmo(af.size))
            {
                Destroy(obj);
            }
        }
    }
}