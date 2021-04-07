using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject helpPane;
    private bool isShowingHelp = false;
    
    public void OnStartClick()
    {
        if (!isShowingHelp)
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void OnHelpClick()
    {
        if (!isShowingHelp)
        {
            helpPane.SetActive(true);
            isShowingHelp = true;
        }
    }

    public void OnHelpClosed()
    {
        isShowingHelp = false;
    }

    public void OnQuitClick()
    {
        if (!isShowingHelp)
        {
            Application.Quit();
        }
    }
}
