using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform fogPlane;
    public Transform lightTr;
    public Transform player;
    public GameObject startPlatform;

    private float fogDist;
    private float lightDist;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pl = player.position;
        fogDist = Math.Abs(pl.y - fogPlane.position.y);
        lightDist = Math.Abs(pl.y - lightTr.position.y);
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
                spTr.Translate(Vector3.down * (Sector.descentSpeed * Time.deltaTime), Space.World);
        }
        
        Vector3 pl = player.position;
        fogPlane.position = new Vector3(0, pl.y + fogDist, 0);
        lightTr.position = new Vector3(0, pl.y + lightDist, 0);
    }
}
