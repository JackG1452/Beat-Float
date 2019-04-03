using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public float bpm = 120f;
    private float lastTime, deltaTime, timer;


    public GameObject platformPrefab;
    private GameObject platform;

    public float spawnTime = 2;
    private float t;

    public Vector3 startPos;
    

    void Start()
    {
        lastTime = 0f;
        deltaTime = 0f;
        timer = 0f;
        //SpawnPlatform();
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime = GetComponent<AudioSource>().time - lastTime;
        timer += deltaTime;

        if(timer>= (60f/bpm))
        {
            SpawnPlatform();
            timer = 0;
        }

        lastTime = GetComponent<AudioSource>().time;
        //t += Time.deltaTime;
        //Debug.Log(t);
        //if (t >= spawnTime)
        //{
        //    t = 0;
        //    SpawnPlatform();
        //}
        
    }
    private void SpawnPlatform()
    {
        //instantiate
        platform = Instantiate(platformPrefab, startPos, transform.rotation);
        float randomX = Random.Range(-5, 5);
        startPos = new Vector3(randomX, startPos.y, startPos.z);
    }
}
