using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform lightTr;
    public Transform player;
    public Transform startPlatform;
    public Tube tube;
    
    private float startY;
        
    private float lightDist;
    
    // Start is called before the first frame update
    void Start()
    {
        lightDist = Math.Abs(player.position.y - lightTr.position.y);
        startY = startPlatform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) {
            Application.Quit();
        }

        if (startPlatform.position.y > -2.0f) {
            startPlatform.Translate(Vector3.down * (Level.descentSpeed * Time.deltaTime), Space.World);
        }
        
        lightTr.position = new Vector3(0, player.position.y + lightDist, 0);
    }

    public void OnPlayerDeath()
    {
        Debug.Log("DED");
        startPlatform.position = new Vector3(0, startY, 0);
    }
}
