using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Tube : MonoBehaviour
{
    public GameObject sectorPF;
    [FormerlySerializedAs("sectorsCount")] public int levelCount = 15;
    private float totalHeight;
    private List<Level> levels;

    public Tube()
    {
        totalHeight = levelCount * Level.height;
        levels = new List<Level>(levelCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levelCount; i++)
        {
            Vector3 levelDelta = new Vector3(0, i * Level.height + Level.height/2, 0);
            Quaternion levelRot = Quaternion.Euler(-90, 0, 0);
            GameObject lev = Instantiate(sectorPF, transform.position + levelDelta, levelRot);
            lev.transform.parent = this.transform;
            levels.Add(lev.GetComponent<Level>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levels[0].transform.position.y <= -Level.height / 2)
        {
            Level lev = levels[0];
            
            lev.transform.position = levels[levelCount - 1].transform.position + new Vector3(0, Level.height, 0);
            lev.Setup();
            
            levels.RemoveAt(0);
            levels.Add(lev);
        }
    }
}
