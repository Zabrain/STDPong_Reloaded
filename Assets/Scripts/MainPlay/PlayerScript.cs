using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position

    public GameObject myPlayer;

    Vector2 myScreen;

    public static int SharpCondomsPlayerSizeCounter;

    public static Vector2 PlayerObjectSize;

    // Use this for initialization
    void Start () {

        //full screen dimension
        myScreen = new Vector2(Screen.width, Screen.height);
        myScreen = Camera.main.ScreenToWorldPoint(myScreen);

        //store player object size
        PlayerObjectSize = myPlayer.transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {

        PlayerControl();//controls player movement
        KeyBoardControl();//for keyboard controls

        //checks for player size as a result of powerup
        if (SharpCondomsPlayerSizeCounter > 0)
        {
            SharpCondomsPlayerSizeCounter += 1;
        }
        if (SharpCondomsPlayerSizeCounter > 200)
        {
            myPlayer.transform.localScale = new Vector2(PlayerObjectSize.x, PlayerObjectSize.y );//reduce player size to normal size       
            SharpCondomsPlayerSizeCounter = 0;

        }
    }


    //Player Collisions
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        PlayerScript myPlayer = otherCollider.gameObject.GetComponent<PlayerScript>();//get the Player
        StdBUllets mySTDBall = otherCollider.gameObject.GetComponent<StdBUllets>();//get the Player
        //EnemyScript myEnemy = otherCollider.gameObject.GetComponent<EnemyScript>();//get the STD


        //if the collliding object is any sideline
        //if (mySTDBall.gameObject != StdBUllets.UnProSex_Object)
        //{
        //    Destroy(myPlayer);
        //}


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


    void KeyBoardControl()
    {
        //for dirrection buttons///////////////////////////////
        if (Input.GetKey(KeyCode.A))
        {
            myPlayer.transform.Translate(Vector2.left * 5 * 2 * Time.deltaTime); //make is move smooth
            myPlayer.transform.position = new Vector2(Mathf.Clamp(myPlayer.transform.position.x, -myScreen.x, myScreen.x), myPlayer.transform.position.y);//ensure it stays on screen
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myPlayer.transform.Translate(Vector2.right * 5 * 2 * Time.deltaTime);
            myPlayer.transform.position = new Vector2(Mathf.Clamp(myPlayer.transform.position.x, -myScreen.x, myScreen.x), myPlayer.transform.position.y);//ensure it stays on screen

        }
    }

    
}
