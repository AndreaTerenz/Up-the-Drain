using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI deathsLabel;

    public void SetDeaths(int newVal)
    {
        deathsLabel.SetText("{0}", newVal);
    }

    public void UpdateDeaths()
    {
        int current = int.Parse(deathsLabel.GetParsedText());
        SetDeaths(current+1);
    }
}
