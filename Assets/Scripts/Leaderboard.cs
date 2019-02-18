using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour {

    GrabHighScoresScript HighscoreManager;
    public TextMeshProUGUI[] HighScoreTexts;
    public TextMeshProUGUI[] HighScoreNames;

    //public TextMeshProUGUI No1;
    //public TextMeshProUGUI No2;
    //public TextMeshProUGUI No3;
    //public TextMeshProUGUI No4;
    //public TextMeshProUGUI No5;
    //public TextMeshProUGUI No1Name;
    //public TextMeshProUGUI No2Name;
    //public TextMeshProUGUI No3Name;
    //public TextMeshProUGUI No4Name;
    //public TextMeshProUGUI No5Name;


    public TextMeshProUGUI YourName;
    public TextMeshProUGUI YourScore;


    // Use this for initialization
    void Start () {



        for (int i=0; i < HighScoreTexts.Length; i++)
        {
            HighScoreNames[i].text = i + 1 + ". Fetching...";
        }

        HighscoreManager = GetComponent<GrabHighScoresScript>();
        StartCoroutine("RefreshTheHighScores");
        

        //HighScores
        //No1Name.text ="1. " + PlayerPrefs.GetString("HighScoreName1").ToString()+": ";//player score
        //No1.text=PlayerPrefs.GetInt("HighScore1").ToString();//player score
        //No2Name.text = "2. " + PlayerPrefs.GetString("HighScoreName2").ToString() + ": ";//player score
        //No2.text = PlayerPrefs.GetInt("HighScore2").ToString();//player score
        //No3Name.text = "3. " + PlayerPrefs.GetString("HighScoreName3").ToString() + ": ";//player score
        //No3.text = PlayerPrefs.GetInt("HighScore3").ToString();//player score
        //No4Name.text = "4. " + PlayerPrefs.GetString("HighScoreName4").ToString() + ": ";//player score
        //No4.text = PlayerPrefs.GetInt("HighScore4").ToString();//player score
        //No5Name.text = "5. " + PlayerPrefs.GetString("HighScoreName5").ToString() + ": ";//player score
        //No5.text = PlayerPrefs.GetInt("HighScore5").ToString();//player score
        
        YourName.text = PlayerPrefs.GetString("NickName").ToString() + ": ";//player score
        YourScore.text = PlayerPrefs.GetInt("CurrentScore").ToString();//player score
    }
	
    public void WhenHighScoreDownloads (Highscore[] highscoreList)
    {
        for (int i=0; i<HighScoreNames.Length; i++)
        {
            HighScoreNames[i].text = i + 1 + ".  ";
            if (highscoreList.Length > i)
            {
                HighScoreNames[i].text += highscoreList[i].uname + " : ";
                HighScoreTexts[i].text = highscoreList[i].playerscore.ToString();
            }
        }
    }

    IEnumerator RefreshTheHighScores()
    {
        while (true)
        {
            HighscoreManager.DownloadHighScoreFromDB();
            yield return new WaitForSeconds(30);
        }
    }
}
