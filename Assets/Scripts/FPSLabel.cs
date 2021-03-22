using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSLabel : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private float refreshRate = .5f;
    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.unscaledTime > timer)
        {
            int current = (int)(1f / Time.unscaledDeltaTime);
            txt.SetText("FPS: {0}", current);
            timer = Time.unscaledTime + refreshRate;
        }
    }
}
