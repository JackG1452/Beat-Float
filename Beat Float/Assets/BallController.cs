using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
public class BallController : MonoBehaviour
{
    Rigidbody ball;
    
    public float force = 2f;
    public float movement = 10f;
    public float gyroSpeed = 10f;
    private float firstX = 0;
    private int movingPoints = 30;
    public bool PlatformHere = false;
    [SerializeField] private float thresholdSpeed = 30f;
    bool allowControls = false;
    private ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        Input.gyro.enabled = false;

        if (ballSelect.instance.getBallSelected() != null)
        {
            Instantiate(ballSelect.instance.getBallSelected(), gameObject.transform);
        }
        else
        {
            gameObject.transform.Find("Electric Ball").gameObject.SetActive(true);
        }

    }
    // Update is called once per frame
    void Update()
    {
        // float rot = Input.gyro.attitude.eulerAngles.magnitude;
        if (allowControls)
        {
            if (PlayerPrefs.GetInt("controls", 0) == 1)
            {
                float hor = Input.acceleration.x;
                //ball.velocity = new Vector3(hor * movement, ball.velocity.y, ball.velocity.z);
                Vector3 gyromov = new Vector3(hor, 0, 0);

                ball.transform.Translate(gyromov * gyroSpeed * Time.deltaTime);

            }
            if (PlayerPrefs.GetInt("controls", 0) == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    firstX = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)).x;
                }
                else if (Input.GetMouseButton(0))
                {
                    float currentX = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)).x;
                    float amount = Mathf.Abs(Mathf.Abs(currentX) - Mathf.Abs(firstX));

                    if (currentX > firstX)
                    {
                        transform.position += new Vector3(amount * thresholdSpeed * Time.deltaTime, 0, 0);
                    }
                    else
                    {
                        transform.position -= new Vector3(amount * thresholdSpeed * Time.deltaTime, 0, 0);
                    }

                    firstX = currentX;
                }
            }
        }

        RaycastHit hit;
        Ray ray = new Ray(ball.position, Vector3.down);
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.tag == "Platform")
            {
                Input.gyro.enabled = true;
                ball.isKinematic = false;
                allowControls = true;

            }


        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //       if (collision.gameObject.tag == "Platform")
        //       {
       ball.AddForce(Vector3.up * force);
        ScoreKeeper.instance.AddScore(1);

        //       }
        if (collision.gameObject.tag == "Restart")
        {
            
            if(PlayerPrefs.GetInt("score", 0) < ScoreKeeper.instance.score)
            {
                PlayerPrefs.SetInt("score", ScoreKeeper.instance.score);
            }
            SceneManager.LoadScene("GameOver");

        }


    }

    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 from, Vector3 middle, Vector3 to)
    {
        return Mathf.Pow((1 - t), 2) * transform.position + 2 * (1 - t) * t * middle + Mathf.Pow(t, 2) * to;
    }


}
