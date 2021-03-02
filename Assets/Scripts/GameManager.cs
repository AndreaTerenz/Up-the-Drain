using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform lightTr;
    public GameObject player;
    public Transform startPlatform;
    public GameObject pauseMenu;
    public Tube tube;

    private Transform plr_tr;
    private PlayerManager plr_mngr;
    
    private bool _paused = false;
    public bool gameIsPaused
    {
        get => this._paused;
        set
        {
            _paused = value;
            
            pauseMenu.SetActive(_paused);
            Time.timeScale = (_paused) ? 0f : 1f;
            Cursor.visible = _paused;
            Cursor.lockState = (_paused) ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
    
    private float startY;
    private float lightDist;
    
    // Start is called before the first frame update
    void Start()
    {
        plr_tr = player.transform;
        plr_mngr = player.GetComponent<PlayerManager>();
        
        lightDist = Math.Abs(plr_tr.position.y - lightTr.position.y);
        startY = startPlatform.position.y;
        
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.P) && !gameIsPaused)
        {
            gameIsPaused = true;
        }
        
        if (!gameIsPaused)
        {
            if (startPlatform.position.y > -2.0f)
            {
                startPlatform.Translate(Vector3.down * (Level.descentSpeed * Time.deltaTime), Space.World);
            }

            lightTr.position = new Vector3(0, plr_tr.position.y + lightDist, 0);
        }
    }

    public void ResetGame(bool resetFromPlayer = true)
    {
        gameIsPaused = false;
        startPlatform.position = new Vector3(0, startY, 0);

        if (!resetFromPlayer)
        {
            plr_mngr.Reset();
        }
    }
}
