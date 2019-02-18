using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidelines : MonoBehaviour {

    public GameObject leftSideLine;
    public GameObject rightSideLine;
    

    Vector2 myScreen;
    float rightSidePointX;
    float leftSidePointX;

    // Use this for initialization
    void Start () {
        

        ////full screen dimension
        //myScreen = new Vector2(Screen.width, Screen.height);
        //myScreen = Camera.main.ScreenToWorldPoint(myScreen);

        //rightSidePointX  = myScreen.x*0.8f;
        //leftSidePointX = -(myScreen.x*0.8f);


        //rightSideLine.transform.position = new Vector2(rightSidePointX, rightSideLine.transform.position.y);
        //leftSideLine.transform.position = new Vector2(leftSidePointX, leftSideLine.transform.position.y);

        
    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log("left Right" + leftSideLine.transform.position + (rightSideLine.transform.position) + " right" + rightSidePointX + "  Left " + rightSidePointX);

    }
}
