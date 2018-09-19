using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodTest : MonoBehaviour {


    Vector2 PointOutSideScreen = new Vector2(10, 10);

    public static bool MovePowerUp = false;

    private float PowerUpSpeedX = .05f;//speed of bullet xaxis
    private float PowerUpSpeedY = -.05f;//speed of bullet yaxis

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (MainDirectorScript.IsGamePaused == false && MainDirectorScript.boolLeveleStart == true)
        {
            if (MovePowerUp == true)
            {
                MakePoweupMove();
            }
        }         


    }

    void MakePoweupMove()
    {
        float XposSTDBall = transform.position.x + PowerUpSpeedX;
        float YposSTDBall = transform.position.y + PowerUpSpeedY;
        transform.position = new Vector2(XposSTDBall, YposSTDBall);

        Vector2 PowerUpSize = StdPongPlayScript.PowerupsText[1].transform.localScale;//size of powerup
        StdPongPlayScript.PowerupsText[1].transform.position = new Vector2(XposSTDBall + PowerUpSize.x, YposSTDBall); //transform condom blinking text

    }

    //Bullet colitions
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Sidelines mySideline = otherCollider.gameObject.GetComponent<Sidelines>();//get the sidelines
        BottomLine myBottomline = otherCollider.gameObject.GetComponent<BottomLine>();//get the Bottomline
        PlayerScript myPlayer = otherCollider.gameObject.GetComponent<PlayerScript>();//get the Player
        EnemyScript myEnemy = otherCollider.gameObject.GetComponent<EnemyScript>();//get the STD

        //BigRock BigRockObject = otherCollider.gameObject.GetComponent<BigRock>();
        //PowerUps PowerUpObject = otherCollider.gameObject.GetComponent<PowerUps>();

        //if the collliding object is any sideline
        if (mySideline != null)
        {
            PowerUpSpeedX *= -1;
        }
        //if the collliding object is bottomline
        else if (myBottomline != null)
        {
            transform.position = PointOutSideScreen;//bullet disappears
            MovePowerUp = false; //StopBulletMovement

            StdPongPlayScript.PowerupsText[1].transform.position = new Vector2(12, 12); //transform condom blinking text
        }
        else if (myPlayer != null)
        {
            MovePowerUp = false; //StopBulletMovement
            transform.position = PointOutSideScreen;//bullet disappears

            //do stuff
            StdPongPlayScript.MyPlayerHealth += 0.05f;//increace player immune by 5%
            StdPongPlayScript.intCurrentPlayerScore += 3; //reduce player points 


            StdPongPlayScript.PowerupsText[1].transform.position = new Vector2(12, 12); //transform condom blinking text
        }


    }
}
