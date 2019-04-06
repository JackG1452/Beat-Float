using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionBoot : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        gameObject.transform.Find("CharacterSelect").gameObject.SetActive(true);
        gameObject.transform.Find("Settings").gameObject.SetActive(true);

    }

    void Start()
    {
        gameObject.transform.Find("CharacterSelect").gameObject.SetActive(false);
        gameObject.transform.Find("Settings").gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
