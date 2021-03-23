using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    public GameObject platformPF;
    public int platsCount = 10;
    public int minimumElements = 2;
    public static float descentSpeed = 1.0f;
    public static float height = 6.0f;
    public static float radius = 10.0f;

    private float resetY;
    private List<GameObject> platforms;

    public Level()
    {
        this.platforms = new List<GameObject>();
    }

    public void Setup(int id)
    {
        resetY = transform.position.y;
        
        foreach (GameObject elemen in platforms) {
            Destroy(elemen);
        }
        
        bool[] spawn = new bool[platsCount];

        for (int i = 0; i < platsCount; i++) {
            spawn[i] = (i < minimumElements) || (Random.value > 0.85f);
        }

        shuffle(spawn);

        for (int i = 0; i < platsCount; i++)
        {
            if (spawn[i])
            {
                float angle = i * Mathf.PI * 2 / platsCount;
                float x = Mathf.Cos(angle) * radius;
                float z = Mathf.Sin(angle) * radius;
                Vector3 pos = transform.position + new Vector3(x, 0, z);
                float angleDegrees = -angle*Mathf.Rad2Deg;
                Quaternion rot = Quaternion.Euler(0, angleDegrees + 180 + 27, 0);
                GameObject platform = Instantiate(platformPF, pos, rot);
                platform.GetComponent<Platform>().levelID = id;
                platform.transform.parent = transform;
                platforms.Add(platform);
            }
        }
    }

    public void SetPlatformsID(int id)
    {
        foreach (var p in platforms)
        {
            if (p != null)
            {
                p.GetComponent<Platform>().levelID = id;
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
