using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    
    public GameObject myEnemy;

    GameObject mySTDBallObject;

    float StepsForEnemy;//determines how fast the enemy would move

    // Use this for initialization
    void Start () {

        StepsForEnemy = 0.5f * MainDirectorScript.intLevel;


    }
	
	// Update is called once per frame
	void Update () {
        if (MainDirectorScript.IsGamePaused == false && MainDirectorScript.boolLeveleStart == true)
        {
            MoveEnemy();
        }
            

    }

    void MoveEnemy()
    {

        mySTDBallObject = STDBall.STDBall_Static; //get the std ball

        Vector2 EmemyMovePoint = new Vector2(mySTDBallObject.transform.position.x, myEnemy.transform.position.y); //movement per update

        // The step size is equal to speed times frame time.
        float step = StepsForEnemy * Time.deltaTime;

        myEnemy.transform.position = Vector2.MoveTowards(myEnemy.transform.position, EmemyMovePoint, step);


    }
}
