using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlinController : MonoBehaviour
{
    [HideInInspector]
    public bool spin = false;

    // Update is called once per frame
    void Update()
    {
        if (spin)
        {
            gameObject.transform.Rotate(Vector3.up, Constants.TURRENT_GUN_ROT_SPEED * Time.deltaTime);
        }
    }
}
