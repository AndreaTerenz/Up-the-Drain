using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Tube : MonoBehaviour
{
    public GameObject sectorPF;
    [FormerlySerializedAs("sectorsCount")] public int levelCount = 15;
    private float totalHeight;
    private List<GameObject> levels;

    public Tube()
    {
        totalHeight = levelCount * Level.height;
        levels = new List<GameObject>(levelCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < levelCount; i++)
        {
            Vector3 levelDelta = new Vector3(0, i * Level.height + Level.height/2, 0);
            Quaternion levelRot = Quaternion.Euler(-90, 0, 0);
            GameObject level = Instantiate(sectorPF, transform.position + levelDelta, levelRot);
            level.transform.parent = this.transform;
            levels.Add(level);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levels[0].transform.position.y <= -Level.height / 2)
        {
            GameObject lev = levels[0];
            
            lev.transform.position = levels[levelCount - 1].transform.position + new Vector3(0, Level.height, 0);
            lev.GetComponent<Level>().Setup();
            
            levels.RemoveAt(0);
            levels.Add(lev);
        }
    }

    public void ResetLevels()
    {
        foreach (var lv  in levels)
        {
            lv.GetComponent<Level>().ResetHeight();
        }
    }
}
