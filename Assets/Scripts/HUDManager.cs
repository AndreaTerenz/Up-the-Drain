using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI deathsLabel;
    public TextMeshProUGUI bestLvlLabel;
    public TextMeshProUGUI currentLvlLabel;
    
    public void SetDeaths(int newVal)
    {
        deathsLabel.SetText("{0}", newVal);
    }

    public void UpdateDeaths()
    {
        try
        {
            int current = int.Parse(deathsLabel.GetParsedText());
            SetDeaths(current+1);
        }
        catch (FormatException e)
        {
            SetDeaths(0);
        }
    }

    public void SetCurrentLevel(int lvl)
    {
        int best = -1;

        try
        {
            best = Math.Max(int.Parse(bestLvlLabel.GetParsedText()), lvl);
        }
        catch (FormatException e)
        {
            best = lvl;
        }
        
        currentLvlLabel.SetText("{0}", lvl);
        bestLvlLabel.SetText("{0}", best);
    }
}
