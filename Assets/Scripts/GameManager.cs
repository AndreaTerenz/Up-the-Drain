using UnityEngine;

public class GameManager : BaseManager
{
    public GameObject player;
    public Transform startPlatform;
    public GameObject pauseMenu;
    public GameObject HUD;
    public Tube tube;
    
    [HideInInspector] public bool handleEsc = true;

    private HUDManager HUDmngr;
    private PlayerManager plr_mngr;
    private float startY;
    
    private bool _paused = false;
    public bool gameIsPaused
    {
        get => this._paused;
        set
        {
            _paused = value;
            
            HUD.SetActive(!_paused);
            plr_mngr.SetPaused(!_paused);
            Time.timeScale = (_paused) ? 0f : 1f;
            Cursor.visible = _paused; 
            Cursor.lockState = (_paused) ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        plr_mngr = player.GetComponent<PlayerManager>();
        HUDmngr = HUD.GetComponent<HUDManager>();

        startY = startPlatform.position.y;

        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsPaused)
        {
            if (Input.GetButtonUp("Cancel"))
            {
                if (handleEsc)
                {
                    Application.Quit();
                }
                else
                {
                    handleEsc = true;
                }
            }

            if (Input.GetButton("Pause") || Input.GetButton("Console"))
            {
                pauseMenu.SetActive(true);
                gameIsPaused = true;
            }
        
            if (startPlatform.position.y > -2.0f)
            {
                startPlatform.Translate(Vector3.down * (Level.descentSpeed * Time.deltaTime), Space.World);
            }
        }
    }

    public void UpdateLevelsInHUD(int currentLvl)
    {
        HUDmngr.SetCurrentLevel(currentLvl);
    }

    public void ResetGame(bool resetFromPlayer = true)
    {
        gameIsPaused = false;
        startPlatform.position = new Vector3(0, startY, 0);
        tube.Reset();
        HUDmngr.SetCurrentLevel(3);

        if (!resetFromPlayer)
        {
            plr_mngr.Reset();
        }
        else
        {
            HUDmngr.UpdateDeaths();
        }
    }
}
