using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpObject : MonoBehaviour {

    public static bool MoveStdBullet = false;

    private float STDBulletSpeedX = .05f;//speed of bullet xaxis
    private float STDBulletSpeedY = -.05f;//speed of bullet yaxis

    Vector2 PointOutSideScreen = new Vector2(10, 10);

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (MainDirectorScript.IsGamePaused == false && MainDirectorScript.boolLeveleStart == true)
        {
            if (MoveStdBullet == true)
            {
                MakeSTDBulletMove();
            }
        }
           
    }

    void MakeSTDBulletMove()
    {
        float XposSTDBall = transform.position.x + STDBulletSpeedX;
        float YposSTDBall = transform.position.y + STDBulletSpeedY;
        transform.position = new Vector2(XposSTDBall, YposSTDBall);

        Vector2 STDBulletSize = StdPongPlayScript.STDBulletsText[1].transform.localScale;//size of Bullet
        StdPongPlayScript.STDBulletsText[1].transform.position = new Vector2(XposSTDBall + STDBulletSize.x , YposSTDBall); //transform blinking text

    }

    //Bullet colitions
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Sidelines mySideline = otherCollider.gameObject.GetComponent<Sidelines>();//get the sidelines
        BottomLine myBottomline = otherCollider.gameObject.GetComponent<BottomLine>();//get the Bottomline
        PlayerScript myPlayer = otherCollider.gameObject.GetComponent<PlayerScript>();//get the Player
        EnemyScript myEnemy = otherCollider.gameObject.GetComponent<EnemyScript>();//get the STD


        //if the collliding object is any sideline
        if (mySideline != null)
        {
            STDBulletSpeedX *= -1;
        }
        //if the collliding object is bottomline
        else if (myBottomline != null)
        {
            transform.position = PointOutSideScreen;//bullet disappears
            MoveStdBullet = false; //StopBulletMovement


            StdPongPlayScript.STDBulletsText[1].transform.position = new Vector2(12, 12); //transform blinking text
        }
        else if (myPlayer != null)
        {
            MoveStdBullet = false; //StopBulletMovement
            transform.position = PointOutSideScreen;//bullet disappears

            //do stuff
            myPlayer.transform.localScale = new Vector2(PlayerScript.PlayerObjectSize.x / 2f, PlayerScript.PlayerObjectSize.y / 2f);//reduce player size by 50%
            PlayerScript.SharpCondomsPlayerSizeCounter = 1;//initiate the playersize counter
            StdPongPlayScript.intCurrentPlayerScore -= 3; //reduce player points 


            StdPongPlayScript.STDBulletsText[1].transform.position = new Vector2(12, 12); //transform blinking text
        }


    }
}
