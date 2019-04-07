using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectSnap : MonoBehaviour
{

    //Public Variables
    public RectTransform panel; //Hold ScrollPanel
    public Button[] bttn;
    public RectTransform center; //center to compare distance of each button

    //Private Variables
    public float[] distance; //All buttons distnace to center
    public float[] distReposition;
    private bool dragging = false; //will be true, while dragging panel
    private int bttnDistance; //will hold the distance between buttons
    private int minButtonNum; //to hold the number of the button, with smallest distance to center
    private int bttnLength;

    // Start is called before the first frame update
    void Start()
    {
        bttnLength = bttn.Length;
        distance = new float[bttnLength];
        distReposition = new float[bttnLength];

        //Get distance between buttons
        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < bttn.Length; i++)
        {
            distReposition[i] = center.GetComponent<RectTransform>().position.x - bttn[i].GetComponent<RectTransform>().position.x;
            distance[i] = Mathf.Abs(distReposition[i]);

            if(distReposition[i]>200)
            {
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchoredPos = new Vector2(curX + (bttnLength * bttnDistance), curY);
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            }
            if(distReposition[i]<-200)
            {
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchoredPos = new Vector2(curX - (bttnLength * bttnDistance), curY);
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            }
        }

        float minDistance = Mathf.Min(distance); //get min Distance

        for (int a = 0; a < bttn.Length; a++)
        {
            if (minDistance == distance[a])
            {
                minButtonNum = a;
            }
        }
        if (!dragging)
        {
            //LerpToBtnn(minButtonNum * -bttnDistance);
            LerpToBtnn(-bttn[minButtonNum].GetComponent<RectTransform>().anchoredPosition.x);
        }
    }
    void LerpToBtnn(float position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 10f);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }
}
