using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    private GameObject platform;

    public float spawnTime = 2;
    private float t;

    public Vector3 startPos;

    void Start()
    {
        SpawnPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        Debug.Log(t);
        if (t >= spawnTime)
        {
            t = 0;
            SpawnPlatform();
        }
    }
    private void SpawnPlatform()
    {
        //instantiate
        platform = Instantiate(platformPrefab, startPos, transform.rotation);
    }
}
