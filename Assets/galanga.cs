using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class galanga : MonoBehaviour
{
    public GameObject player;
    
    void Update()
    {
        Vector3 selfPos = gameObject.transform.position;
        Vector3 playerPos = gameObject.transform.position;
        Vector3 pos = new Vector3(selfPos.x, selfPos.y, playerPos.z);
        transform.LookAt(player.transform);
        //transform.Rotate(Vector3.up, -90.0f);
    }
}
