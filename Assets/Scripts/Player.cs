using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gm;
    public Collider groundCollider;
    private float startY;
    
    // Start is called before the first frame update
    void Start()
    {
        startY = this.transform.position.y;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider == groundCollider)
        {
            this.transform.position = new Vector3(0, startY, 0); 
            
            gm.OnPlayerDeath();
        }
    }
}
