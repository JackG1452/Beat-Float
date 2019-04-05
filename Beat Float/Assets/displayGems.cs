using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class displayGems : MonoBehaviour
{
    public Text gem;
    // Start is called before the first frame update
    void Start()
    {
        gem.text = PlayerPrefs.GetInt("gems", 0).ToString();
    }


}
