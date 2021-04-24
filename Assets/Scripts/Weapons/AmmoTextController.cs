using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface AmmunitionStatusListener
{
    void OnNewStatus(int shots, int mags);
}

public class AmmoTextController : MonoBehaviour, AmmunitionStatusListener
{
    public TextMeshPro ammoText;

    void Start()
    {
        GetComponent<AmmunitionManager>().AddAmmoListener(this);
    }

    public void OnNewStatus(int shots, int mags)
    {
        ammoText.SetText("{0}\n-\n{1}", shots, mags);
    }
}
