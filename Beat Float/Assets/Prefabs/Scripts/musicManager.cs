using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicManager : MonoBehaviour
{


    public Slider Volume;
    public AudioSource myMusic;

    private void Start()
    {
        Volume.value = PlayerPrefs.GetFloat("volume", 0.5f);
    }

    void Update()
    {
        myMusic.volume = Volume.value;
        PlayerPrefs.SetFloat("volume", Volume.value);
    }
}
