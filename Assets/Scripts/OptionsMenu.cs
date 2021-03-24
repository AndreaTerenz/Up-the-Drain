using System;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public PauseManager parentMngr;
    public SettingsManager setMngr;

    public Toggle fpsToggle;
    public Slider fovSlider;

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
        SettingsToUI();
        gameObject.SetActive(false);
        parentMngr.onOptionsMenuClosed();
    }
}
