using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCounter : MonoBehaviour
{
    public static GemCounter instance;

    public int gems;
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    public void AddGem(int s)
    {
        

        PlayerPrefs.SetInt("gems", PlayerPrefs.GetInt("gems", 0) + s);
    }
    public int GetGem()
    {
        return PlayerPrefs.GetInt("gems", 0);
    }
}
