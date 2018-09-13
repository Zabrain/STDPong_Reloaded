using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STDBall : MonoBehaviour
{

    public GameObject STDBall_Object;

    private float STDBallSpeedX=.05f;//speed of ball xaxis
    private float STDBallSpeedY = .05f;//speed of ball xaxis


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        
        STDBallSpeedX *= 1.002f;
        STDBallSpeedY *= 1.002f;
        MakeBallMove();
    }

    void MakeBallMove()
    {
        float XposSTDBall = STDBall_Object.transform.position.x + STDBallSpeedX;
        float YposSTDBall = STDBall_Object.transform.position.y + STDBallSpeedY;
        STDBall_Object.transform.position = new Vector2(XposSTDBall, YposSTDBall);
    }

    //Ball colitions
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Sidelines mySideline = otherCollider.gameObject.GetComponent<Sidelines>();//get the sidelines
        TopLine myTopLine = otherCollider.gameObject.GetComponent<TopLine>();//get the Topline
        BottomLine myBottomline = otherCollider.gameObject.GetComponent<BottomLine>();//get the Bottomline
        PlayerScript myPlayer = otherCollider.gameObject.GetComponent<PlayerScript>();//get the Player
        EnemyScript myEnemy = otherCollider.gameObject.GetComponent<EnemyScript>();//get the STD

        //BigRock BigRockObject = otherCollider.gameObject.GetComponent<BigRock>();
        //PowerUps PowerUpObject = otherCollider.gameObject.GetComponent<PowerUps>();

        //if the collliding object is any sideline
        if (mySideline != null)
        {
            STDBallSpeedX *= -1;
        }
        //if the collliding object is topline
        else if (myTopLine != null)
        {
            StdPongPlayScript.MyEnemyHealth -= .10f;//reduce the enemy health
            STDBallSpeedY *= -1;

            StdPongPlayScript.intCurrentPlayerScore += 10; //increase player points 
        }
        //if the collliding object is bottomline
        else if (myBottomline != null)
        {
            StdPongPlayScript.MyPlayerHealth -= .10f;//reduce the player health
            STDBallSpeedY *= -1;

            StdPongPlayScript.intCurrentPlayerScore -= 5; //reduce player points 

        }
        else if (myPlayer != null)
        {

            STDBallSpeedX *= -1;
            STDBallSpeedY *= -1;

            STDBallSpeedX *= 1.05f;
            STDBallSpeedY *= 1.05f;

        }
        else if (myEnemy != null)
        {
            STDBallSpeedX *= -1;
            STDBallSpeedY *= -1;
        }

    }

}
