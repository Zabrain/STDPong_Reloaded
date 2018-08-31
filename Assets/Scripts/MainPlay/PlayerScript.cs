using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position

    public GameObject myPlayer;


                          // Use this for initialization
    void Start () {


        Debug.Log(myPlayer.transform.position.x);
        Debug.Log(myPlayer.transform.position.x);

    }
	
	// Update is called once per frame
	void Update () {

        PlayerControl();//controls player movement

    }



    public void PlayerControl()
    {
        //for Drag

        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {

            Touch touch = Input.GetTouch(0); // get the touch
           if (touch.phase== TouchPhase.Moved)
            {
                Vector2 MyScreenTouch = Camera.main.ScreenToWorldPoint(touch.position); //convert touch
                myPlayer.transform.position = new Vector2(MyScreenTouch.x, myPlayer.transform.position.y);//move player
            }
            //if (touch.phase == TouchPhase.Began) //check for the first touch
            //{
            //    fp = touch.position;
            //    lp = touch.position;

            //}
            //else

        }
    }


}
