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
    public GatlinController leftGun;
    public GatlinController rightGun;
    public Transform gunsJoint;
    
    protected bool frozen = true;
    protected Vector3 gunsRotAxis = new Vector3();
    
    void Update()
    {
        leftGun.spin = !frozen;
        rightGun.spin = !frozen;
        
        if (!frozen)
        {
            Vector3 selfPos = gameObject.transform.position;
            Vector3 playerPos = player.position;
            Vector3 targetPos = new Vector3(playerPos.x, selfPos.y, playerPos.z);
            transform.LookAt(targetPos);
            transform.Rotate(Vector3.up, -90.0f);

            if (true)//(kind == TURRET_KIND.NORMAL)
            {
                Vector3 jointPos = gunsJoint.position;
                
                float dist = Vector3.Distance(jointPos, playerPos);
                float vDist = Mathf.Abs(jointPos.y - playerPos.y);
                float angle = Mathf.Rad2Deg * Mathf.Asin(vDist / dist);
                gunsJoint.localEulerAngles = new Vector3(0, 0, angle - 0);
            }
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
