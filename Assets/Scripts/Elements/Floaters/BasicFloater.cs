using System;
using UnityEngine;

public abstract class BasicFloater : MonoBehaviour
{
    private void Update()
    {
        transform.localEulerAngles += Vector3.up * (120f * Time.deltaTime);
    }
}