using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public static int scoreValue = 0;
    private Text score;

    // Use this for initialization
    void Start()
    {
        score = GetComponent<Text>();

    }

    private void GetScore()
    {
        scoreValue = ScoreKeeper.instance.GetScore();
    }
    void Update()
    {
        GetScore();
        score.text = scoreValue.ToString();

    }
}
