using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameManager mngr;
    public GameObject optMenuPF;
    public GameObject mainPanel;
    private GameObject optMenu;
    
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
        optMenu = Instantiate(optMenuPF, transform.position, Quaternion.identity);
        Debug.Log("sad");
        optMenu.GetComponent<OptionsMenu>().parentMngr = this;
        optMenu.SetActive(true);
        optMenu.transform.SetParent(transform);
        Debug.Log("sad");
        mainPanel.SetActive(false);
        Debug.Log("sad");
    }

    public void onOptionsMenuClosed()
    {
        Destroy(optMenu);
        mainPanel.SetActive(true);
    }
}
