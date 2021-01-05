using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    public GameObject sectorPF;
    public int sectorsCount = 10;
    private float totalHeight;
    private List<GameObject> sectors;

    public Tube()
    {
        totalHeight = sectorsCount * Sector.height;
        sectors = new List<GameObject>(sectorsCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < sectorsCount; i++)
        {
            Vector3 sectorDelta = new Vector3(0, i * Sector.height + Sector.height/2, 0);
            Quaternion sectorRot = Quaternion.Euler(-90, 0, 0);
            GameObject sector = Instantiate(sectorPF, transform.position + sectorDelta, sectorRot);
            sector.transform.parent = this.transform;
            sectors.Add(sector);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sectors[0].transform.position.y <= -Sector.height / 2)
        {
            GameObject sec = sectors[0];
            
            sec.transform.position = sectors[sectorsCount - 1].transform.position + new Vector3(0, Sector.height, 0);
            sec.GetComponent<Sector>().Setup();
            
            sectors.RemoveAt(0);
            sectors.Add(sec);
        }
    }
}
