using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class highScore : MonoBehaviour
{
    // Start is called before the first frame update
    public Text highscore;
    void Start()
    {
        highscore.text += " " + PlayerPrefs.GetInt("score", 0);
    }


}
