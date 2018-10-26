using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STDBall : MonoBehaviour
{

    Vector2 myScreen;

    public GameObject STDBall_Object;

    Rigidbody2D STDBallRB;
    Vector2 STDBallVelocity= new Vector2 (5f,6f);

    public static GameObject STDBall_Static;
    
    // Use this for initialization
    void Start()
    {
        //full screen dimension
        myScreen = new Vector2(Screen.width, Screen.height);
        myScreen = Camera.main.ScreenToWorldPoint(myScreen);

        STDBallRB = STDBall_Object.GetComponent<Rigidbody2D>();//get rigid body of ball
        STDBallRB.velocity = STDBallVelocity;

        STDBall_Static = STDBall_Object;//to be targeted by texts
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    { 

        if (MainDirectorScript.IsGamePaused == false && MainDirectorScript.boolLeveleStart == true)
        {
            STDBallRB.velocity = STDBallVelocity;
            //STDBall_Object.transform.rotation = Quaternion.LookRotation(STDBallRB.velocity);
        }
        else
        {
            STDBallRB.velocity = Vector2.zero;
        }
            
    }

    void MakeBallMove()
    {
        

    }
    

    //Ball colitions
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
       // Sidelines mySideline = otherCollider.gameObject.GetComponent<Sidelines>();//get the sidelines
        LeftLine myLeftLine = otherCollider.gameObject.GetComponent<LeftLine>();//get the sidelines
        RightLine myRightLine = otherCollider.gameObject.GetComponent<RightLine>();//get the sidelines
        TopLine myTopLine = otherCollider.gameObject.GetComponent<TopLine>();//get the Topline
        BottomLine myBottomline = otherCollider.gameObject.GetComponent<BottomLine>();//get the Bottomline
        PlayerScript myPlayer = otherCollider.gameObject.GetComponent<PlayerScript>();//get the Player
        EnemyScript myEnemy = otherCollider.gameObject.GetComponent<EnemyScript>();//get the STD


        //if the collliding object is any sideline
        if (myRightLine != null)
        {
            MyAudioManager.BallBounce();

            if (STDBallVelocity.x > 0) { STDBallVelocity.x *= -1; }
            STDBallVelocity = new Vector2(STDBallVelocity.x, STDBallVelocity.y);
            STDBallRB.velocity = STDBallVelocity;
            //STDBallSpeedX *= -1;
            
        }
        if (myLeftLine != null)
        {
            MyAudioManager.BallBounce();

            if (STDBallVelocity.x < 0) { STDBallVelocity.x *= -1; }
            STDBallVelocity = new Vector2(STDBallVelocity.x, STDBallVelocity.y);
            STDBallRB.velocity = STDBallVelocity;
            //STDBallSpeedX *= -1;
        }
        //if the collliding object is topline
        else if (myTopLine != null)
        {

            MyAudioManager.BallBounce();

            if (STDBallVelocity.y > 0) { STDBallVelocity.y *= -1; }
            STDBallVelocity = new Vector2(STDBallVelocity.x, STDBallVelocity.y);
            STDBallRB.velocity = STDBallVelocity;

            StdPongPlayScript.MyEnemyHealth -= .10f;//reduce the enemy health

            StdPongPlayScript.intCurrentPlayerScore += 10; //increase player points 
            
        }
        //if the collliding object is bottomline
        else if (myBottomline != null)
        {
            MyAudioManager.BallBounce();

            if (STDBallVelocity.y < 0) { STDBallVelocity.y *= -1; } 
            STDBallVelocity = new Vector2(STDBallVelocity.x, STDBallVelocity.y);
            STDBallRB.velocity = STDBallVelocity;
            

            StdPongPlayScript.MyPlayerHealth -= .05f;//reduce the player health

            StdPongPlayScript.intCurrentPlayerScore -= 10; //reduce player points 
            

        }
        else if (myPlayer != null)
        {
            MyAudioManager.BallBounce();

            int RandomDirection = Random.Range(1, 3);
            int RandomSlantX = Random.Range(5, 8);
            int RandomSlantY = Random.Range(6, 10);

            if (RandomDirection == 1)
            {
                STDBallVelocity = new Vector2(RandomSlantX * -1f, RandomSlantY * 1f);
            }
            else
            {
                STDBallVelocity = new Vector2(RandomSlantX*1f, RandomSlantY * 1f);
            }

            STDBallRB.velocity = STDBallVelocity;
            


        }
        else if (myEnemy != null)
        {
            MyAudioManager.BallBounce();

            int RandomDirection = Random.Range(1, 3);
            int RandomSlantX = Random.Range(5, 8);
            int RandomSlantY = Random.Range(6, 10);

            if (RandomDirection == 1)
            {
                STDBallVelocity = new Vector2(RandomSlantX * -1f, RandomSlantY * -1f);
            }
            else
            {
                STDBallVelocity = new Vector2(RandomSlantX*1f, RandomSlantY * -1f);
            }

            STDBallRB.velocity = STDBallVelocity;


        }

    }

}
