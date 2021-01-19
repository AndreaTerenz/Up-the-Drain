using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    public GameObject platformPF;
    public int elementsCount = 10;
    public int minimumElements = 3;
    public static float descentSpeed = 1.0f;
    public static float height = 6.0f;
    public static float radius = 13.0f;

    private float resetY;
    private List<GameObject> elements;

    public Level()
    {
        this.elements = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    public void Setup()
    {
        resetY = transform.position.y;
        
        foreach (GameObject elemen in elements) {
            Destroy(elemen);
        }
        
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
                GameObject element = Instantiate(platformPF, pos, rot);
                element.transform.parent = this.transform;
                elements.Add(element);
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y % (height + height/2) == 0)
        {
            resetY = transform.position.y;
        }
        
        transform.Translate(Vector3.down * (descentSpeed * Time.deltaTime), Space.World);
    }

    public void ResetHeight()
    {
        transform.position = new Vector3(0, resetY, 0);
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
