using System;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //TODO The parent menu should be of a more generic type than PauseManager in order to use this code for an option menu in the start screen
    public PauseManager parentMenu;
    public SettingsManager setMngr;

    public Toggle fpsToggle;
    public Slider fovSlider;

    public void OnEnable()
    {
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), .1f).setIgnoreTimeScale(true);
    }
    
    public void Start()
    {
        SettingsToUI();
    }
    
    public void SettingsToUI()
    {
        fpsToggle.isOn = setMngr.showFPS;
        fovSlider.value = setMngr.cameraFOV;
    }

    public void onFPSToggled()
    {
        setMngr.showFPS = fpsToggle.isOn;
    }

    public void onFOVChanged()
    {
        setMngr.cameraFOV = fovSlider.value;
    }

    public void OnApplyClick()
    {
        setMngr.ApplyValues();
        CloseMenu();
    }

    public void OnCancelClick()
    {
        setMngr.ResetEdits();
        CloseMenu();
    }

    public void OnResetClick()
    {
        setMngr.ResetToDefaults();
        CloseMenu();
    }

    public void CloseMenu()
    {
        LeanTween.scale(gameObject, new Vector3(1, 0, 1), .1f).setIgnoreTimeScale(true).setOnComplete(() =>
        {
            SettingsToUI();
            gameObject.SetActive(false);
            parentMenu.onOptionsMenuClosed();
        });
    }

    public void Update()
    {
        if (gameObject.activeSelf && Input.GetButtonDown("Cancel"))
        {
            CloseMenu();
        }
    }
}
