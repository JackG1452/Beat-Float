using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public float bpm = 120f;
    private float lastTime, deltaTime, timer;
    public float randomRange = 5;

    public GameObject platformPrefab;
    private GameObject platform;
    private GameObject coin;
    public GameObject coinPrefab;
    public float spawnTime = 2;
    private float t;

    public Vector3 startPos;
    public static PlatformSpawner instance;
    bool spawnCoin = false;

    float timeElapsed = 0;
    float waitTimeForCoin = 0;

    public float minWaitTime, maxWaitTime;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        lastTime = 0f;
        deltaTime = 0f;
        timer = 0f;
        waitTimeForCoin = Random.Range(minWaitTime, maxWaitTime);
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

        RandomCoinSpawner();
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
        if(spawnCoin)
        {
            coin = Instantiate(coinPrefab, startPos+(Vector3.up*0.4f), transform.rotation);
            coin.transform.parent = platform.transform;
            waitTimeForCoin = Random.Range(minWaitTime, maxWaitTime);
            spawnCoin = false;

        }
        float randomX = Random.Range(-randomRange, randomRange);
        startPos = new Vector3(randomX, startPos.y, startPos.z);
    }

    private void RandomCoinSpawner()
    {


        timeElapsed += Time.deltaTime;

        if(timeElapsed >= waitTimeForCoin)
        {
            spawnCoin = true;
            timeElapsed = 0;

        }

    }
}
