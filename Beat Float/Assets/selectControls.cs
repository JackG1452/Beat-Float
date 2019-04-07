using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectControls : MonoBehaviour
{
    public Slider Controls;

    // Start is called before the first frame update
    void Start()
    {
        Controls.value = PlayerPrefs.GetInt("controls", 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("controls", (int)Controls.value);
    }
}
