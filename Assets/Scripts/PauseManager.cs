using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameManager mngr;
    public GameObject optMenu;
    
    public void onRestartClick()
    {
        gameObject.SetActive(false);
        mngr.ResetGame(false);    
    }

    public void onQuitClick()
    {
        Application.Quit();
    }
        
    public void onResumeClick()
    {
        gameObject.SetActive(false);
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
    
    public void Update()
    {
        if (gameObject.activeSelf && Input.GetButtonDown("Cancel"))
        {
            mngr.handleEsc = false;
            onResumeClick();
        }
    }
}
