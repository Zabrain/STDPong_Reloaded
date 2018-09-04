using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abstinence : MonoBehaviour {

    public GameObject Abstinence_Object;


    public static bool MovePowerUp= false;

    private float PowerUpSpeedX= .05f;//speed of bullet xaxis
    private float PowerUpSpeedY = -.05f;//speed of bullet yaxis

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (MovePowerUp == true)
        {
            MakeSTDBulletMove();
        }


    }

    void MakeSTDBulletMove()
    {
        float XposSTDBall = transform.position.x + PowerUpSpeedX;
        float YposSTDBall = transform.position.y + PowerUpSpeedY;
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
            PowerUpSpeedY *= -1;
        }
        else if (myPlayer != null)
        {
        }


    }
}
