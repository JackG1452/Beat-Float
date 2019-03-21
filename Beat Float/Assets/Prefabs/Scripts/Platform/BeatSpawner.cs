using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{
    private bool beated = false;
    public AudioSource song;
    public GameObject platformPrefab;
    private GameObject platform;
    public Vector3 startPos;

    float[] historyBuffer = new float[43];

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float randomX = Random.Range(-5, 5);
        //compute instant sound energy
        float[] channelRight = new float[256]; //= song.GetSpectrumData(1024, 1, FFTWindow.Hamming);
       // float[] channelLeft = new float[256]; //= song.GetSpectrumData(1024, 2, FFTWindow.Hamming);

        song.GetSpectrumData(channelRight, 0, FFTWindow.Hamming);
       // song.GetSpectrumData(channelLeft, 0, FFTWindow.Hamming);
        float e = sumStereo(channelRight);

        //compute local average sound evergy
        float E = sumLocalEnergy() / historyBuffer.Length; // E being the average local sound energy

        //calculate variance
        float sumV = 0;
        for (int i = 0; i < 43; i++)
            sumV += (historyBuffer[i] - E) * (historyBuffer[i] - E);

        float V = sumV / historyBuffer.Length;
        float constant = (float)((-0.0025714 * V) + 1.5142857);

        float[] shiftingHistoryBuffer = new float[historyBuffer.Length]; // make a new array and copy all the values to it

        for (int i = 0; i < (historyBuffer.Length - 1); i++)
        { // now we shift the array one slot to the right
            shiftingHistoryBuffer[i + 1] = historyBuffer[i]; // and fill the empty slot with the new instant sound energy
        }

        shiftingHistoryBuffer[0] = e;

        for (int i = 0; i < historyBuffer.Length; i++)
        {
            historyBuffer[i] = shiftingHistoryBuffer[i]; //then we return the values to the original array
        }

        //float constant = 1.5f;

        if (e > (constant * E))
        { // now we check if we have a beat
            if (!beated)
            {
                platform = Instantiate(platformPrefab, new Vector3(randomX, startPos.y, startPos.z), transform.rotation);
                beated = true;
            } 
        }else if(beated)
            {
                beated = false;
            }


        Debug.Log("Avg local: " + E);
        Debug.Log("Instant: " + e);
        Debug.Log("History Buffer: " + historybuffer());

        Debug.Log("sum Variance: " + sumV);
        Debug.Log("Variance: " + V);

        Debug.Log("Constant: " + constant);
        Debug.Log("--------");
    }

    float sumStereo(float[] channel1)
    {
        float e = 0;
        for (int i = 0; i < channel1.Length; i++)
        {
            e += ((channel1[i] * channel1[i]));
        }

        return e;
    }

    float sumLocalEnergy()
    {
        float E = 0;

        for (int i = 0; i < historyBuffer.Length; i++)
        {
            E += historyBuffer[i] * historyBuffer[i];
        }

        return E;
    }

    string historybuffer()
    {
        string s = "";
        for (int i = 0; i < historyBuffer.Length; i++)
        {
            s += (historyBuffer[i] + ",");
        }
        return s;
    }
}