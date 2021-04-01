using System;
using DefaultNamespace;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public enum TURRET_KIND
    {
        NORMAL,
        SMALL
    }
        
    public TURRET_KIND kind;
    public Transform player;
    public Transform leftGun;
    public Transform rightGun;
    public Transform gunsJoint;
    
    protected bool frozen = true;
    protected Vector3 gunsRotAxis = new Vector3();
    
    void Update()
    {
        if (!frozen)
        {
            Vector3 selfPos = gameObject.transform.position;
            Vector3 playerPos = player.position;
            Vector3 targetPos = new Vector3(playerPos.x, selfPos.y, playerPos.z);
            transform.LookAt(targetPos);
            transform.Rotate(Vector3.up, -90.0f);

            if (kind == TURRET_KIND.NORMAL)
            {
                float dist = Vector3.Distance(selfPos, playerPos);
                float vDist = Mathf.Abs(selfPos.y - playerPos.y);
                float angle = Mathf.Rad2Deg * Mathf.Asin(vDist / dist);
                gunsJoint.localEulerAngles = new Vector3(0, 0, angle - 90);
            }

            switch (kind)
            {
                case TURRET_KIND.NORMAL: gunsRotAxis = Vector3.left;
                    break;
                case TURRET_KIND.SMALL: gunsRotAxis = Vector3.up;
                    break;
            }

            leftGun.Rotate(gunsRotAxis, 500.0f * Time.deltaTime);
            rightGun.Rotate(gunsRotAxis, 500.0f * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        frozen = false;
    }

    private void OnTriggerExit(Collider other)
    {
        frozen = true;
    }
}
