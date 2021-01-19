using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSLabel : MonoBehaviour
{
    private Text txt;
    private float refreshRate = .5f;
    private float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.unscaledTime > timer)
        {
            int current = (int)(1f / Time.unscaledDeltaTime);
            txt.text = "FPS: " + current.ToString();
            timer = Time.unscaledTime + refreshRate;
        }
    }
}
