using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkersScript : MonoBehaviour {

    int MyCounter=0;

    public GameObject BlinkerTextObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

        if (MyCounter < 300)
        {
            MyCounter += 1;
        }
        else
        {
            MyCounter = 0;
        }

        if (MyCounter > 150)
        {
            BlinkerTextObject.GetComponent<Renderer>().enabled = false;
        }
        else if (MyCounter < 150)
        {
            BlinkerTextObject.GetComponent<Renderer>().enabled = true;
        }

        //Debug.Log(MyCounter);
    }
}
