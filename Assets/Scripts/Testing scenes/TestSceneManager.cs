using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneManager : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 120;
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
    }
}
