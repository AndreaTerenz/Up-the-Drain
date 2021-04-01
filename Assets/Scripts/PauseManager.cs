using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameManager mngr;
    public GameObject optMenu;
    
    public void OnEnable()
    {
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), Constants.TWEEN_LENGHT).setIgnoreTimeScale(true);
    }
    
    public void onResumeClick()
    {
        gameObject.SetActive(false);
        ClosingTween(() => mngr.gameIsPaused = false);
    }
    
    public void onRestartClick()
    {
        gameObject.SetActive(false);
        ClosingTween(() => mngr.ResetGame(false));
    }

    public void onQuitClick()
    {
        Application.Quit();
    }

    public void onOptionsClick()
    {
        optMenu.SetActive(true);
        ClosingTween(() => gameObject.SetActive(false));
    }

    public void onOptionsMenuClosed()
    {
        gameObject.SetActive(true);
    }

    void ClosingTween(Action onCompl)
    {
        LeanTween.scale(gameObject, new Vector3(1, 0, 1), Constants.TWEEN_LENGHT).setIgnoreTimeScale(true).setOnComplete(() => onCompl());
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
