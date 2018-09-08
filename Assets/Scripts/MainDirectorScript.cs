using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDirectorScript : MonoBehaviour {
    

    public static bool boolLeveleStart = false;

    public static string GameMode; //Arcade or Story Mode

    public static int intLevel;
    public static string strLevel;

    public static string[] LevelNames=new string[2] { "Zero", "Scabies" };

    // Use this for initialization
    void Start () {

        //check if game has been played before
        if (PlayerPrefs.GetInt("PlayedBefore") != 1) //if not played before, instantiate all playerprefs
        {
            //add all playerprefs to instantiate
            PlayerPrefs.SetInt("CurrentLevel",1);

            //end all playerprefs to instantiate

            PlayerPrefs.SetInt("PlayedBefore",1); //make played
        }

        intLevel = PlayerPrefs.GetInt("CurrentLevel");//get the current level

        strLevel = LevelNames[intLevel];


    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
