using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorManager : MonoBehaviour
{
    public GameObject platformPF;
    public int elementsCount = 10;
    public int minimumElements = 4;

    public static float height = 4.0f;
    public static float radius = 13.0f;
    
    private int actualElements = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        bool[] spawn = new bool[elementsCount];

        for (int i = 0; i < elementsCount; i++) {
            spawn[i] = (Random.value > 0.75f) || (i < minimumElements);
        }

        shuffle(spawn);

        for (int i = 0; i < elementsCount; i++)
        {
            if (spawn[i])
            {
                float angle = i * Mathf.PI * 2 / elementsCount;
                float x = Mathf.Cos(angle) * radius;
                float z = Mathf.Sin(angle) * radius;
                Vector3 pos = transform.position + new Vector3(x, 0, z);
                float angleDegrees = -angle*Mathf.Rad2Deg;
                Quaternion rot = Quaternion.Euler(-90, angleDegrees + 90, 0);
                Instantiate(platformPF, pos, rot);

                actualElements++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void shuffle<T>(T[] array)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < array.Length; t++ )
        {
            T tmp = array[t];
            int r = Random.Range(t, array.Length);
            array[t] = array[r];
            array[r] = tmp;
        }
    }
}
