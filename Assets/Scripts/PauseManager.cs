using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Button resumeBtn;
    public Button restartBtn;
    public Button quitBtn;
    public GameManager mngr;
    
    // Start is called before the first frame update
    void Start()
    {
        resumeBtn.onClick.AddListener(onResumeClick);
        restartBtn.onClick.AddListener(onRestartClick);
        quitBtn.onClick.AddListener(onQuitClick);
    }

    void onRestartClick()
    {
        mngr.ResetGame(false);    
    }

    void onQuitClick()
    {
        Application.Quit();
    }
        
    void onResumeClick()
    {
        mngr.gameIsPaused = false;
    }
}
