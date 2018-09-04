using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnProtectedSex : MonoBehaviour {
    

    public static bool MoveStdBullet = false;

    private float STDBulletSpeedX = .05f;//speed of bullet xaxis
    private float STDBulletSpeedY = -.05f;//speed of bullet yaxis

    Vector2 PointOutSideScreen = new Vector2 (10,10);

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (MoveStdBullet == true)
        {
            MakeSTDBulletMove();
        }


    }

    void MakeSTDBulletMove()
    {
        float XposSTDBall = transform.position.x + STDBulletSpeedX;
        float YposSTDBall = transform.position.y + STDBulletSpeedY;
        transform.position = new Vector2(XposSTDBall, YposSTDBall);
    }

    //Bullet colitions
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Sidelines mySideline = otherCollider.gameObject.GetComponent<Sidelines>();//get the sidelines
        TopLine myTopLine = otherCollider.gameObject.GetComponent<TopLine>();//get the Topline
        BottomLine myBottomline = otherCollider.gameObject.GetComponent<BottomLine>();//get the Bottomline
        PlayerScript myPlayer = otherCollider.gameObject.GetComponent<PlayerScript>();//get the Player
        EnemyScript myEnemy = otherCollider.gameObject.GetComponent<EnemyScript>();//get the STD
        

        //if the collliding object is any sideline
        if (mySideline != null)
        {
            STDBulletSpeedX *= -1;
        }
        //if the collliding object is topline
        else if (myTopLine != null)
        {
            STDBulletSpeedY *= -1;
        }
        //if the collliding object is bottomline
        else if (myBottomline != null)
        {
            transform.position = PointOutSideScreen;//bullet disappears
            MoveStdBullet = false; //StopBulletMovement
        }
        else if (myPlayer != null)
        {
            MoveStdBullet = false; //StopBulletMovement
            transform.position = PointOutSideScreen;//bullet disappears
            Destroy(myPlayer.gameObject);

        }


    }
}
