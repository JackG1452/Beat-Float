using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDisplay : MonoBehaviour
{
    public GameObject[] stars;
    private float timePass = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreKeeper.instance.GetScore() >= 20)
        {
            if (timePass <= 5)
            {
                stars[0].SetActive(true);
                timePass += Time.deltaTime;

            }
            else
                stars[0].SetActive(false);
        }

        if (ScoreKeeper.instance.GetScore() >= 40)
        {
            if (timePass <= 10)
            {
                stars[1].SetActive(true);
                timePass += Time.deltaTime;

            }
            else
                stars[1].SetActive(false);
        }

        if (ScoreKeeper.instance.GetScore() >= 80)
        {
            if (timePass <= 15)
            {
                stars[2].SetActive(true);
                timePass += Time.deltaTime;

            }
            else
                stars[2].SetActive(false);
        }
    }
}
