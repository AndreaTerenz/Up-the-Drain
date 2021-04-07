using System;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private class Setting<T>
    {
        private string tag;
        private T defaultVal;   //the original default value
        private T value;        //the currently used value
        private T tmpVal;       //the edited and yet unapplied value
        private Action<T> applyAction;
        private Action<T> saveAction;

        public Setting(string t, T val, T defVal, Action<T> appAct, Action<T> saveAct)
        {
            tag = t;
            defaultVal = defVal;
            value = val;
            tmpVal = val;
            applyAction = appAct;
            saveAction = saveAct;
        }

        public T GetCurrentValue()
        {
            return tmpVal;
        }

        public void NewValue(T v)
        {
            tmpVal = v;
        }

        public void Cancel()
        {
            tmpVal = value;
        }

        public void Reset()
        {
            value = defaultVal;
            tmpVal = defaultVal;
            Apply();
        }

        public void Apply(bool saveToPrefs = true)
        {
            value = tmpVal;
            applyAction(value);

            if (saveToPrefs)
            {
                saveAction(value);
            }
        }
    }
    
    public Camera cam;
    public GameObject fpsLbl;

    private Setting<bool> _fpsSetting;
    public bool showFPS
    {
        get => _fpsSetting.GetCurrentValue();
        set => _fpsSetting.NewValue(value);
    }
    
    private Setting<float> _fovSetting;
    public float cameraFOV
    {
        get => _fovSetting.GetCurrentValue();
        set => _fovSetting.NewValue(value);
    }
    
    public void Start()
    {
        string fpsTag = "FPS";
        _fpsSetting = new Setting<bool>(fpsTag, (PlayerPrefs.GetInt(fpsTag, 1) != 0), true,
                                    v => fpsLbl.SetActive(v),
                                    v => PlayerPrefs.SetInt(fpsTag, (v) ? 1 : 0));
        
        string fovTag = "FOV";
        _fovSetting = new Setting<float>(fovTag, PlayerPrefs.GetFloat(fovTag, 60.0f), 60.0f,
                                        v => cam.fieldOfView = v,
                                        v => PlayerPrefs.SetFloat(fovTag, v));
        
        ApplyValues(false);
    }

    public void ResetToDefaults()
    {
        _fpsSetting.Reset();
        _fovSetting.Reset();
    }

    public void ResetEdits()
    {
        _fpsSetting.Cancel();
        _fovSetting.Cancel();
    }

    public void ApplyValues(bool saveToPrefs = true)
    {
        _fpsSetting.Apply(saveToPrefs);
        _fovSetting.Apply(saveToPrefs);
    }
}
