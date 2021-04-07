using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlinController : MonoBehaviour
{
    private bool _shoot;
    public bool Shoot
    {
        get => _shoot;
        set
        {
            _shoot = value;
            if (_shoot)
            {
                muzzleFlash.Play();
            }
            else
            {
                muzzleFlash.Stop();
            }
        }
    }

    public Transform gunBody;
    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if (Shoot)
        {
            gunBody.Rotate(Vector3.up, Constants.GatlinRotSpeed * Time.deltaTime);
        }
    }
}
