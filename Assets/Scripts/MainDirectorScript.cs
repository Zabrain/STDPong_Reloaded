using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            PlayerPrefs.SetFloat("MyPlayerHealth", 1f);
            PlayerPrefs.SetFloat("MyEnemyHealth", 1f);

            //HighScores
            PlayerPrefs.SetString("HighScoreName1", "---");//player score
            PlayerPrefs.SetInt("HighScore1", 0);//player score
            PlayerPrefs.SetString("HighScoreName2", "---");//player score
            PlayerPrefs.SetInt("HighScore2", 0);//player score
            PlayerPrefs.SetString("HighScoreName3", "---");//player score
            PlayerPrefs.SetInt("HighScore3", 0);//player score
            PlayerPrefs.SetString("HighScoreName4", "---");//player score
            PlayerPrefs.SetInt("HighScore4", 0);//player score
            PlayerPrefs.SetString("HighScoreName5", "---");//player score
            PlayerPrefs.SetInt("HighScore5", 0);//player score

            PlayerPrefs.SetInt("NickNameIndex", 1);//NicknameIndex
            

            //end all playerprefs to instantiate

            PlayerPrefs.SetInt("PlayedBefore",1); //make played
        }

       // PlayerPrefs.SetInt("CurrentLevel", 5);

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
            boolLeveleStart = false;
            IsGamePaused = false;
        }
        
    }


    // Update is called once per frame
    void Update () {

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
                
        //}


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

}
