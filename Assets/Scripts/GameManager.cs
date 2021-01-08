using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform lightTr;
    public Transform player;
    public GameObject startPlatform;
    
    private float lightDist;
    
    // Start is called before the first frame update
    void Start()
    {
        lightDist = Math.Abs(player.position.y - lightTr.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) {
            Application.Quit();
        }

        if (startPlatform != null)
        {
            Transform spTr = startPlatform.transform;
        
            if (spTr.position.y <= -2.0f) {
                Destroy(startPlatform);
                startPlatform = null;
            } else
                spTr.Translate(Vector3.down * (Level.descentSpeed * Time.deltaTime), Space.World);
        }
        
        lightTr.position = new Vector3(0, player.position.y + lightDist, 0);
    }
}
