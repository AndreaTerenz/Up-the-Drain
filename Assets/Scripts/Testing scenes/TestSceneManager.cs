using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneManager : BaseManager
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;
        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;
    }
}
