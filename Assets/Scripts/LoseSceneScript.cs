using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoseSceneScript : MonoBehaviour {

    public Sprite[] PlayerIntro;
    public Image PlayerImage;

    public TextMeshProUGUI ScoreShow;

    // Use this for initialization
    void Start () {
        //select the selected player
        if (PlayerPrefs.GetString("SelectedPlayer") == "Obi")
        {
            PlayerImage.overrideSprite = PlayerIntro[0];
        }
        else if (PlayerPrefs.GetString("SelectedPlayer") == "Ada")
        {
            PlayerImage.overrideSprite = PlayerIntro[1];
        }

        ScoreShow.text = PlayerPrefs.GetInt("CurrentScore").ToString();

        CheckForHighScore();

        PlayerPrefs.SetString("AllUsers", PlayerPrefs.GetString("AllUsers") + " " + PlayerPrefs.GetString("NickName") + ": " + PlayerPrefs.GetInt("CurrentScore").ToString() + ",");

    }

    public static void CheckForHighScore()
    {
        //if (PlayerPrefs.GetInt("CurrentScore") >= PlayerPrefs.GetInt("HighScore1")) //HI1
        //{
        //    PlayerPrefs.SetString("HighScoreName5", PlayerPrefs.GetString("HighScoreName4"));//player score
        //    PlayerPrefs.SetInt("HighScore5", PlayerPrefs.GetInt("HighScore4"));//player score
        //    PlayerPrefs.SetString("HighScoreName4", PlayerPrefs.GetString("HighScoreName3"));//player score
        //    PlayerPrefs.SetInt("HighScore4", PlayerPrefs.GetInt("HighScore3"));//player score
        //    PlayerPrefs.SetString("HighScoreName3", PlayerPrefs.GetString("HighScoreName2"));//player score
        //    PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("HighScore2"));//player score

        //    if (PlayerPrefs.GetInt("CurrentScore") == PlayerPrefs.GetInt("HighScore1"))
        //    {
        //        PlayerPrefs.SetString("HighScoreName2", PlayerPrefs.GetString("NickName"));//player score
        //        PlayerPrefs.SetInt("HighScore2", PlayerPrefs.GetInt("CurrentScore"));//player score

        //    }
        //    else
        //    {
        //        PlayerPrefs.SetString("HighScoreName2", PlayerPrefs.GetString("HighScoreName1"));//player score
        //        PlayerPrefs.SetInt("HighScore2", PlayerPrefs.GetInt("HighScore1"));//player score

        //        PlayerPrefs.SetString("HighScoreName1", PlayerPrefs.GetString("NickName"));//player score
        //        PlayerPrefs.SetInt("HighScore1", PlayerPrefs.GetInt("CurrentScore"));//player score
        //    }
           
            
        //}
        //else if (PlayerPrefs.GetInt("CurrentScore") >= PlayerPrefs.GetInt("HighScore2")) //HI2
        //{
        //    PlayerPrefs.SetString("HighScoreName5", PlayerPrefs.GetString("HighScoreName4"));//player score
        //    PlayerPrefs.SetInt("HighScore5", PlayerPrefs.GetInt("HighScore4"));//player score
        //    PlayerPrefs.SetString("HighScoreName4", PlayerPrefs.GetString("HighScoreName3"));//player score
        //    PlayerPrefs.SetInt("HighScore4", PlayerPrefs.GetInt("HighScore3"));//player score

        //    if (PlayerPrefs.GetInt("CurrentScore") == PlayerPrefs.GetInt("HighScore2"))
        //    {
        //        PlayerPrefs.SetString("HighScoreName3", PlayerPrefs.GetString("NickName"));//player score
        //        PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("CurrentScore"));//player score

        //    }
        //    else
        //    {
        //        PlayerPrefs.SetString("HighScoreName3", PlayerPrefs.GetString("HighScoreName2"));//player score
        //        PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("HighScore2"));//player score

        //        PlayerPrefs.SetString("HighScoreName2", PlayerPrefs.GetString("NickName"));//player score
        //        PlayerPrefs.SetInt("HighScore2", PlayerPrefs.GetInt("CurrentScore"));//player score
        //    }


        //}

        //else if (PlayerPrefs.GetInt("CurrentScore") >= PlayerPrefs.GetInt("HighScore3")) //HI3
        //{
        //    PlayerPrefs.SetString("HighScoreName5", PlayerPrefs.GetString("HighScoreName4"));//player score
        //    PlayerPrefs.SetInt("HighScore5", PlayerPrefs.GetInt("HighScore4"));//player score

        //    if (PlayerPrefs.GetInt("CurrentScore") == PlayerPrefs.GetInt("HighScore3"))
        //    {
        //        PlayerPrefs.SetString("HighScoreName4", PlayerPrefs.GetString("NickName"));//player score
        //        PlayerPrefs.SetInt("HighScore4", PlayerPrefs.GetInt("CurrentScore"));//player score

        //    }
        //    else
        //    {
        //        PlayerPrefs.SetString("HighScoreName4", PlayerPrefs.GetString("HighScoreName3"));//player score
        //        PlayerPrefs.SetInt("HighScore4", PlayerPrefs.GetInt("HighScore3"));//player score

        //        PlayerPrefs.SetString("HighScoreName3", PlayerPrefs.GetString("NickName"));//player score
        //        PlayerPrefs.SetInt("HighScore3", PlayerPrefs.GetInt("CurrentScore"));//player score
        //    }


        //}

        //else if (PlayerPrefs.GetInt("CurrentScore") >= PlayerPrefs.GetInt("HighScore4")) //HI4
        //{
            
        //    if (PlayerPrefs.GetInt("CurrentScore") == PlayerPrefs.GetInt("HighScore4"))
        //    {
        //        PlayerPrefs.SetString("HighScoreName5", PlayerPrefs.GetString("NickName"));//player score
        //        PlayerPrefs.SetInt("HighScore5", PlayerPrefs.GetInt("CurrentScore"));//player score

        //    }
        //    else
        //    {
        //        PlayerPrefs.SetString("HighScoreName5", PlayerPrefs.GetString("HighScoreName4"));//player score
        //        PlayerPrefs.SetInt("HighScore5", PlayerPrefs.GetInt("HighScore4"));//player score

        //        PlayerPrefs.SetString("HighScoreName4", PlayerPrefs.GetString("NickName"));//player score
        //        PlayerPrefs.SetInt("HighScore4", PlayerPrefs.GetInt("CurrentScore"));//player score
        //    }


        //}

        //else if (PlayerPrefs.GetInt("CurrentScore") >= PlayerPrefs.GetInt("HighScore5")) //HI5
        //{
        //        PlayerPrefs.SetString("HighScoreName5", PlayerPrefs.GetString("NickName"));//player score
        //        PlayerPrefs.SetInt("HighScore5", PlayerPrefs.GetInt("CurrentScore"));//player score
        //}


    }

    // Update is called once per frame
    void Update () {
		
	}

    public void RetryLevel()
    {
        PlayerPrefs.SetFloat("MyEnemyHealth", 1f); //reset enemy health
        SceneManager.LoadScene("StdPongPlay");
    }

    public void MainMenu()
    {
        PlayerPrefs.SetFloat("MyEnemyHealth", 1f); //reset enemy health
        SceneManager.LoadScene("MainMenu");
    }

    public void GotoLeaderBoard()
    {
        PlayerPrefs.SetFloat("MyEnemyHealth", 1f); //reset enemy health
        SceneManager.LoadScene("Leaderboards");
    }
    



}
