using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abstinence : MonoBehaviour {

    int MyBlinkerCounter = 0;

    public GameObject BlinkerTextObject;
    GameObject myBlinkerTextObject;

    public static bool MovePowerUp = false;

    //private float STDBulletSpeedX = .05f;//speed of bullet xaxis
    //private float STDBulletSpeedY = -.05f;//speed of bullet yaxis


    Rigidbody2D MovingStuffRB;
    Vector2 MovingStuffVelocity = new Vector2(-4f, -4f);


    Vector2 PointOutSideScreen = new Vector2(10, 10);


    // Use this for initialization
    void Start()
    {
        myBlinkerTextObject = Instantiate(BlinkerTextObject);
        myBlinkerTextObject.transform.position = PointOutSideScreen;
        
        MovingStuffRB = GetComponent<Rigidbody2D>();//get rigid body of ball
        MovingStuffRB.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {

        if (MainDirectorScript.IsGamePaused == false && MainDirectorScript.boolLeveleStart == true)
        {
            if (MovePowerUp == true)
            {
                MakePoweupMove();
                MakeTextBlink();
            }
            else
            {
                MyBlinkerCounter = 0;
                MovingStuffRB.velocity = Vector2.zero;
            }
        }
        else
        {
            MovingStuffRB.velocity = Vector2.zero;
        }
    }

    void MakePoweupMove()
    {
        if (MainDirectorScript.IsGamePaused == false && MainDirectorScript.boolLeveleStart == true)
        {
            MovingStuffRB.velocity = MovingStuffVelocity;
            //STDBall_Object.transform.rotation = Quaternion.LookRotation(STDBallRB.velocity);
        }
        else
        {
            MovingStuffRB.velocity = Vector2.zero;
        }


        myBlinkerTextObject.transform.position = new Vector2(transform.position.x, transform.position.y + .5f); //transform condom blinking text
    }

    void MakeTextBlink()
    {
        //Debug.Log(MyBlinkerCounter);
        if (MyBlinkerCounter < 200)
        {
            MyBlinkerCounter += 1;
        }
        else
        {
            MyBlinkerCounter = 0;
        }

        if (MyBlinkerCounter > 70)
        {
            myBlinkerTextObject.GetComponent<Renderer>().enabled = false;
        }
        else if (MyBlinkerCounter < 70)
        {
            myBlinkerTextObject.GetComponent<Renderer>().enabled = true;
        }

    }

    //Bullet colitions
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        LeftLine myLeftLine = otherCollider.gameObject.GetComponent<LeftLine>();//get the 

        RightLine myRightLine = otherCollider.gameObject.GetComponent<RightLine>();//get the sidelines
        BottomLine myBottomline = otherCollider.gameObject.GetComponent<BottomLine>();//get the Bottomline
        PlayerScript myPlayer = otherCollider.gameObject.GetComponent<PlayerScript>();//get the Player
        EnemyScript myEnemy = otherCollider.gameObject.GetComponent<EnemyScript>();//get the STD


        //if the collliding object is any sideline
        //if the collliding object is any sideline
        if (myRightLine != null)
        {
            MyAudioManager.BallBounce();

            if (MovingStuffVelocity.x > 0) { MovingStuffVelocity.x *= -1; }
            MovingStuffVelocity = new Vector2(MovingStuffVelocity.x, MovingStuffVelocity.y);
            MovingStuffRB.velocity = MovingStuffVelocity;
            //STDBallSpeedX *= -1;

        }
        //if the collliding object is bottomline
        if (myLeftLine != null)
        {
            MyAudioManager.BallBounce();

            if (MovingStuffVelocity.x < 0) { MovingStuffVelocity.x *= -1; }
            MovingStuffVelocity = new Vector2(MovingStuffVelocity.x, MovingStuffVelocity.y);
            MovingStuffRB.velocity = MovingStuffVelocity;
            //STDBallSpeedX *= -1;
        }
        //if the collliding object is bottomline
        else if (myBottomline != null)
        {
            transform.position = PointOutSideScreen;//bullet disappears
            MovePowerUp = false; //StopBulletMovement


            myBlinkerTextObject.transform.position = PointOutSideScreen; //transform condom blinking text
            MyBlinkerCounter = 0;
        }
        else if (myPlayer != null)
        {
            MovePowerUp = false; //StopBulletMovement
            transform.position = PointOutSideScreen;//bullet disappears

            //do action
            StdPongPlayScript.MyPlayerHealth += 0.10f;//increace player immune by 5%
            StdPongPlayScript.intCurrentPlayerScore += 5; //reduce player points 

            myBlinkerTextObject.transform.position = PointOutSideScreen; //transform condom blinking text
            MyBlinkerCounter = 0;

            PlayerPrefs.SetInt("PowerupCount", PlayerPrefs.GetInt("PowerupCount") + 1); //increase the overall count of powerups
        }


    }
}
