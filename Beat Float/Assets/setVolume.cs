using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
