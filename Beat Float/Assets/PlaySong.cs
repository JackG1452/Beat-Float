using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySong : MonoBehaviour
{
    private float timeElapsed;
    private AudioSource song;
    private bool play = false;
    public Rigidbody ball;
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
        RaycastHit hit;
        Ray ray = new Ray(ball.position, Vector3.down);
        if(Physics.Raycast(ray, out hit, 100))
        {
            if(hit.collider.tag == "Platform")
            ball.isKinematic = false;

        }
        Debug.DrawRay(ball.position + (Vector3.down * 2), Vector3.down*100, Color.blue);
    }
}
