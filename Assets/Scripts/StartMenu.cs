using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject helpPane;
    
    public void OnStartClick()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnHelpClick()
    {
        helpPane.SetActive(true);
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}
