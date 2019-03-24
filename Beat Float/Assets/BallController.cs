using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody ball;
    public float force = 2f;
    public float movement = 10f;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        float rot = Input.gyro.attitude.eulerAngles.magnitude;

        ball.velocity = new Vector3(rot * movement, ball.velocity.y, ball.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ball.AddForce(Vector3.up * force);
    }
}
