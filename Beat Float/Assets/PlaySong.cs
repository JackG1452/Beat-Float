using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour
{
    private float timeElapsed;
    private AudioSource song;
    private bool play = false;
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        song = GetComponent<AudioSource>();
       // song.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= 5.0f && !play)
        {
            song.Play();
            play = true;
        }
    }
}
