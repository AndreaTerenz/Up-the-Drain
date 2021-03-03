using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameManager mngr;

    public void onRestartClick()
    {
        mngr.ResetGame(false);    
    }

    public void onQuitClick()
    {
        Application.Quit();
    }
        
    public void onResumeClick()
    {
        mngr.gameIsPaused = false;
    }
}
