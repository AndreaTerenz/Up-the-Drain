using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform fogPlane;
    public Transform lightTr;
    public Transform player;

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
        
        Vector3 pl = player.position;
        fogPlane.position = new Vector3(0, fogDist, 0);
        lightTr.position = new Vector3(0, lightDist, 0);
    }
}
