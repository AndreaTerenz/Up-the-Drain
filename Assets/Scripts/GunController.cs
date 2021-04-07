using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GunController : MonoBehaviour
{
    public float fireRate;
    public float maxSpreadAngle;
    public float timeTillMaxSpread;
    public bool autoFire = true;
    
    public GameObject bullet;
    public Transform shootPoint;

    private float _inaccuracy;
    private float _shootingCoolDown;
    private float _recoilCoolDown;

    public void Shoot(bool firePressed)
    {
        _shootingCoolDown += Time.deltaTime * 60f;

        if (firePressed && (_shootingCoolDown >= fireRate))
        {
            _inaccuracy += Time.deltaTime * 4f;
        
            RaycastHit info;
            float currentSpread = Mathf.Lerp(0.0f, maxSpreadAngle, _inaccuracy / timeTillMaxSpread);
        
            Quaternion rot = Quaternion.LookRotation(transform.forward);
            rot = Quaternion.RotateTowards(rot, Random.rotation, Random.Range(0f, currentSpread));

            if (Physics.Raycast(transform.position, rot * Vector3.forward, out info, 10000f))
            {
                GameObject tmp = Instantiate(bullet, shootPoint.position, rot);
                tmp.GetComponent<BulletController>().hitPoint = info.point;
            }
        
            _shootingCoolDown = 0;
            _recoilCoolDown = 1;
        }
        else
        {
            if (_recoilCoolDown >= 0)
            {
                _recoilCoolDown -= Time.deltaTime;
            }
            else
            {
                _inaccuracy = 0f;
                _recoilCoolDown = 0f;
            }
        }
    }
}
