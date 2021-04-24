using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    #region Publics
    [Header("Firing settings")]
    //Rounds per second
    public float fireRate;
    public bool autoFire = true;
    public LayerMask bulletLayerMask;

    [Header("Assets")]
    public GameObject bullet;
    public Transform shootPoint;

    #endregion
    
    #region Privates

    private float _shootingCoolDown;
    private AmmunitionManager _ammoMngr;
    private GunGroundCheck _ground;
    private bool isDropped
    {
        get => !(ReferenceEquals(_ground, null) || !_ground.dropped);
    }
    
    private bool _firePrssd;
    public bool firePressed
    {
        get => _firePrssd && (ReferenceEquals(_ammoMngr, null) || _ammoMngr.hasShots) && !isDropped;
        set => _firePrssd = value;
    }

    #endregion

    private void Start()
    {
        _ground = GetComponent<GunGroundCheck>();
        _ammoMngr = GetComponent<AmmunitionManager>();
    }
    
    private void Update()
    {
        _shootingCoolDown = Mathf.Max(1f, _shootingCoolDown + Time.deltaTime * fireRate);
        
        if (_shootingCoolDown >= 1 && firePressed)
        {
            Quaternion rot = Quaternion.LookRotation(transform.forward);
        
            if (Physics.Raycast(transform.position, rot * Vector3.forward, out RaycastHit info, 10000f))
            {
                GameObject tmp = Instantiate(bullet, shootPoint.position, rot);
                BulletController tmpCtrl = tmp.GetComponent<BulletController>();
                tmpCtrl.hitPoint = info.point;
                tmpCtrl.targetsMask = bulletLayerMask;
            }
                
            _ammoMngr.ShootOne();
            _shootingCoolDown = 0f;
        }
    }
}
