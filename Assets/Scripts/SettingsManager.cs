using UnityEngine;

public class SettingsManager
{
    private const string fpsTag = "FPS";
    private const string fovTag = "FOV";

    public bool showFPS;
    public float fov;

    public SettingsManager()
    {
        showFPS = (PlayerPrefs.GetInt(fpsTag, 1) != 0);
        fov = PlayerPrefs.GetFloat(fovTag, 60.0f);
    }

    public void ApplyValues()
    {
        PlayerPrefs.SetInt(fpsTag, (showFPS) ? 1 : 0);
        PlayerPrefs.SetFloat(fovTag, fov);
    }
}
