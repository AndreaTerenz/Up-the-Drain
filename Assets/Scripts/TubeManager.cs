using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeManager : MonoBehaviour
{
    public GameObject sectorPF;
    public int sectorsCount = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sectorsCount; i++)
        {
            Vector3 sectorDelta = new Vector3(0, i * SectorManager.height + SectorManager.height/2, 0);
            Quaternion sectorRot = Quaternion.Euler(-90, 0, 0);
            Instantiate(sectorPF, transform.position + sectorDelta, sectorRot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
