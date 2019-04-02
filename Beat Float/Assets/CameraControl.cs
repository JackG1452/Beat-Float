using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject ball;
    private Vector3 CameraPosition;
    public Vector3 Offset;
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Look = new Vector3(ball.transform.position.x + Offset.x, transform.position.y + Offset.y, -(ball.transform.position.z + Offset.z));
        CameraPosition = Vector3.Lerp(transform.position, new Vector3(ball.transform.position.x, transform.position.y, transform.position.z), 5.0f * Time.deltaTime);
        camera.transform.LookAt(Look);
        camera.transform.position = CameraPosition;
    }
}
