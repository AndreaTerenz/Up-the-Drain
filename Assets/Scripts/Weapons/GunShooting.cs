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

    [Header("Magazine")]
    public bool usesMags = true;
    public int roundsPerMag;
    public int magsCount;

    #endregion
    
    #region Privates

    private float _shootingCoolDown;
    private GunGroundCheck _ground;
    private List<AmmunitionStatusListener> _ammoListeners = new List<AmmunitionStatusListener>();
    
    private bool _firePrssd;
    public bool firePressed
    {
        get => _firePrssd && hasShots && !_ground.dropped;
        set => _firePrssd = value;
    }
    
    private int _shotsLeft;
    private int shots
    {
        get => _shotsLeft;
        set
        {
            if (usesMags)
            {
                if (_shotsLeft <= 0)
                {
                    if (magsCount > 0)
                    {
                        Debug.Log("Reload");
                        _shotsLeft = roundsPerMag;
                        magsCount -= 1;
                    }
                }
                else
                {
                    _shotsLeft = value;
                }

                _ammoListeners.ForEach(listener => listener.OnNewStatus(_shotsLeft, magsCount));
            }
        }
    }
    private bool hasShots
    {
        get => !usesMags || _shotsLeft > 0 || magsCount > 0;
    }

    #endregion

    private void Start()
    {
        _ground = GetComponent<GunGroundCheck>();
        _shotsLeft = roundsPerMag;
    }
    
    private void Update()
    {
        if (_shootingCoolDown >= 1)
        {
            if (firePressed)
            {
                SpawnBullet();
                
                shots -= 1;
                _shootingCoolDown = 0f;
            }
        }
        else
        {
            _shootingCoolDown += Time.deltaTime * fireRate;
        }
    }

    private void SpawnBullet()
    {
        Quaternion rot = Quaternion.LookRotation(transform.forward);
        
        if (Physics.Raycast(transform.position, rot * Vector3.forward, out RaycastHit info, 10000f))
        {
            GameObject tmp = Instantiate(bullet, shootPoint.position, rot);
            BulletController tmpCtrl = tmp.GetComponent<BulletController>();
            tmpCtrl.hitPoint = info.point;
            tmpCtrl.targetsMask = bulletLayerMask;
        }
    }

    public void AddAmmoListener(AmmunitionStatusListener l)
    {
        _ammoListeners.Add(l);
        l.OnNewStatus(roundsPerMag, magsCount);
    }
}
