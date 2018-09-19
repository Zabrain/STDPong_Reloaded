using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDirectorScript : MonoBehaviour {
    
    public static bool IsGamePaused=false;

    public static bool boolLeveleStart = false;

    public static string GameMode; //Arcade or Story Mode

    public static int intLevel;
    public static string strLevel;

    public static string[] LevelNames=new string[11] { "Zero", "Scabies", "Genital Warts","Herpes","Trichomoniasis","Hepatits B", "Chlamydia","Syphilis", "Gonorrhea", "HIV", "AIDS"};

    // Use this for initialization
    void Awake () {

        //check if game has never been played before
        if (PlayerPrefs.GetInt("PlayedBefore") != 1) //if not played before, instantiate all playerprefs
        {
            //add all playerprefs to instantiate
            PlayerPrefs.SetInt("CurrentLevel",1);

            PlayerPrefs.SetInt("CurrentScore", 0);//player score

            PlayerPrefs.SetString("SelectedPlayer", "Obi");//Player Selected (Ada or Obi)

            PlayerPrefs.SetString("STDScrollFrom", "StoryMode");//This identifies where an STD scroll is being opened from 

            //end all playerprefs to instantiate

            PlayerPrefs.SetInt("PlayedBefore",1); //make played
        }


        //delete this
        PlayerPrefs.SetString("CurrentScene", "StdPongPlay");//sets the current scene

        intLevel = PlayerPrefs.GetInt("CurrentLevel");//get the current level

        strLevel = LevelNames[intLevel];
    }

    void Start()
    {
        //check what the current scene is
        if (PlayerPrefs.GetString("CurrentScene") == "StdPongPlay")
        {
            boolLeveleStart = true;
        }
        
    }


    // Update is called once per frame
    void Update () {

        


    }

    public void PauseGame() //pauses the game
    {
        IsGamePaused=true;
    }
    public void ResumeGame() //pauses the game
    {
        IsGamePaused = false;
    }


}
