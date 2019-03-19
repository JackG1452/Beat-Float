using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    public static ScoreKeeper instance;

    public int score;
	void Awake () {
        instance = this;
	}
	

	public void AddScore (int s) {
        score = score + s;
	}
    public int GetScore()
    {
        return score;
    }
}
