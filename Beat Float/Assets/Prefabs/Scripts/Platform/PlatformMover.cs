using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [Range(0,20)]
    public float speed = 1f;
    
    public int endPosZ;

    private bool hitEnd = false;

    void Awake()
    {
        //create random position (always same z position
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(-Vector3.forward * Time.deltaTime * speed);

        if(gameObject.transform.position.z < endPosZ)
        {
            Destroy(gameObject);
        }
    }
}
