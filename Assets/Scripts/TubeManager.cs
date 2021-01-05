using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeManager : MonoBehaviour
{
    public GameObject platformPF;
    private float radius = 9.0f;
    private int sectors = -1;
    private float sectorHeight = 4.0f;
    private float tubeHeight = 50.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        sectors = (int) (tubeHeight / sectorHeight);
        
        for (int i = 0; i < sectors; i++)
        {
            float angle = i * Mathf.PI * 2 / sectors;
            float r = radius + Random.Range(-4.0f, .5f);
            
            float x = Mathf.Cos(angle) * r;
            float z = Mathf.Sin(angle) * r;
            Vector3 pos = new Vector3(x, sectorHeight*i - sectorHeight*2/3, z);
            float angleDegrees = -angle*Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            Instantiate(platformPF, pos, rot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
