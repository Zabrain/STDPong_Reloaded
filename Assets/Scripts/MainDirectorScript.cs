﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainDirectorScript : MonoBehaviour {
    
    public static bool IsGamePaused=false;

    public static bool boolLeveleStart = false;

    public static string GameMode; //Arcade or Story Mode

    public static int intLevel;
    public static string strLevel;

    public static string[] LevelNames=new string[11] { "Zero", "Scabies", "Genital Warts","Herpes","Trichomoniasis","Hepatitis B", "Chlamydia","Syphilis", "Gonorrhea", "HIV", "AIDS"};

    public static float GeneralTimer;
    // Use this for initialization
    void Awake () {

        //check if game has never been played before
        if (PlayerPrefs.GetInt("PlayedBefore") != 1) //if not played before, instantiate all playerprefs
        {
            //HighScore Database Upload marker
            PlayerPrefs.SetInt("DBUpload", 0);

            PlayerPrefs.SetInt("HighestLevel", 0);//Level For Arcade

            PlayerPrefs.SetString("AllOtherData", "Fresh");

            //add all playerprefs to instantiate
            PlayerPrefs.SetString("SelectedMode", "Something"); //Arcade or Story

            PlayerPrefs.SetInt("CurrentLevel",1);

            PlayerPrefs.SetInt("CurrentScore", 0);//player score

            PlayerPrefs.SetString("SelectedPlayer", "Obi");//Player Selected (Ada or Obi)

            //PlayerPrefs.SetString("STDScrollFrom", "StoryMode");//This identifies where an STD scroll is being opened from 

            PlayerPrefs.SetFloat("MyPlayerHealth", 1f);
            PlayerPrefs.SetFloat("MyEnemyHealth", 1f);
                        

            PlayerPrefs.SetInt("NickNameIndex", 1);//NicknameIndex
            

            //end all playerprefs to instantiate

            PlayerPrefs.SetInt("PlayedBefore",1); //make played

            //Instantiate all pretest and posttest prefabs
            for (int i=1; i<11; i++)
            {
                PlayerPrefs.SetInt(LevelNames[i] + "Pretest", 9);
                PlayerPrefs.SetInt(LevelNames[i] + "PostTest", -1);
            }



            //Data to be stored
            //For how may times level played
            PlayerPrefs.SetInt("ScabiesPlayed", 0);
            PlayerPrefs.SetInt("GenitalWartsPlayed", 0);
            PlayerPrefs.SetInt("HerpesPlayed", 0);
            PlayerPrefs.SetInt("TrichomoniasisPlayed", 0);
            PlayerPrefs.SetInt("HepatitisbPlayed", 0);
            PlayerPrefs.SetInt("ChlamydiaPlayed", 0);
            PlayerPrefs.SetInt("SyphilisPlayed", 0);
            PlayerPrefs.SetInt("GonorrheaPlayed", 0);
            PlayerPrefs.SetInt("HIVPlayed", 0);
            PlayerPrefs.SetInt("AIDSPlayed", 0);
            
        }

        
        //PlayerPrefs.SetInt("CurrentLevel", 10);
        // PlayerPrefs.SetString("CurrentScene", "StdPongPlay");//sets the current scene




        //select the scene based on the selected mode
        if (PlayerPrefs.GetString("SelectedMode")=="StoryMode")
        {
            intLevel = PlayerPrefs.GetInt("CurrentLevel");//get the current level

            strLevel = LevelNames[intLevel];
        }
        else if (PlayerPrefs.GetString("SelectedMode") == "ArcadeMode")
        {
            intLevel = PlayerPrefs.GetInt("ArcadeLevel");//get the Arcade level

            strLevel = LevelNames[intLevel];
        }
        else if (PlayerPrefs.GetString("SelectedMode") == "ScrollCollected")
        {
            intLevel = PlayerPrefs.GetInt("ScrollToSee");//get the Scroll level

            strLevel = LevelNames[intLevel];
        }



    }

    void Start()
    {
        //check what the current scene is
        if (PlayerPrefs.GetString("CurrentScene") == "StdPongPlay")
        {
            boolLeveleStart = false;
            IsGamePaused = false;
        }
        
    }


    // Update is called once per frame
    void Update () {

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{

        //}
        GeneralTimer += Time.deltaTime;
        //Debug.Log(GeneralTimer);
    }

    public void PauseGame() //pauses the game
    {
        IsGamePaused=true;
    }

    public void ResumeGame() //pauses the game
    {
        IsGamePaused = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Leaderboard()
    {
        SceneManager.LoadScene("Leaderboards");
    }


    public void HelpGame() //pauses the game
    {
        IsGamePaused = true;
    }

    public void PrivaryPolicyButton() //consent given
    {
        Application.OpenURL("https://zabrain.wordpress.com/2019/05/20/std-pong-privacy-policy/");

    }


    private void OnDestroy()
    {
       PlayerPrefs.SetFloat("GeneralTimer", PlayerPrefs.GetFloat("GeneralTimer")+GeneralTimer);
    }
}
