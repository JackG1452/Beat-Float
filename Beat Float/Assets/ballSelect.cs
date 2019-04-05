using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSelect : MonoBehaviour
{
    public static ballSelect instance;
    // Start is called before the first frame update

      
    public  GameObject[] balls;
    private int currentBall = 0;

    private void Start()
    {
        currentBall = PlayerPrefs.GetInt("ball", 0);
    }
    public void Ball1()
    {
        PlayerPrefs.SetInt("ball", 0);
        currentBall = 0;
    }

    public void Ball2()
    {
        PlayerPrefs.SetInt("ball", 1);
        currentBall = 1;
    }

    public GameObject getBallSelected()
    {
        return balls[currentBall];
    }
}
