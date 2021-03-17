using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public PauseManager parentMngr;
    private SettingsManager setMngr = new SettingsManager();

    public void onFPSToggled()
    {
        setMngr.showFPS = !setMngr.showFPS;
    }

    public void onFOVChanged(float newVal)
    {
        setMngr.fov = newVal;
    }

    public void ApplyAndClose()
    {
        setMngr.ApplyValues();
    }

    public void CloseMenu()
    {
        parentMngr.onOptionsMenuClosed();
    }
}
