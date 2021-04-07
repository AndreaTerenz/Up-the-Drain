using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    [HideInInspector]
    public Vector3 hitPoint;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce((hitPoint - transform.position).normalized * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<HealthManager>().currentHealth -= 5.0f;
        }
        
        Destroy(gameObject);
    }
}
