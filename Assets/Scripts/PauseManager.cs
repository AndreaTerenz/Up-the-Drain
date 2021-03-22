using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameManager mngr;
    public GameObject optMenu;
    public GameObject mainPanel;
    
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

    public void onOptionsClick()
    {
        optMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void onOptionsMenuClosed()
    {
        gameObject.SetActive(true);
    }
}
