using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour {

    public TextMeshProUGUI No1;
    public TextMeshProUGUI No2;
    public TextMeshProUGUI No3;
    public TextMeshProUGUI No4;
    public TextMeshProUGUI No5;
    public TextMeshProUGUI No1Name;
    public TextMeshProUGUI No2Name;
    public TextMeshProUGUI No3Name;
    public TextMeshProUGUI No4Name;
    public TextMeshProUGUI No5Name;


    public TextMeshProUGUI YourName;
    public TextMeshProUGUI YourScore;


    // Use this for initialization
    void Start () {

        //HighScores
        No1Name.text ="1. " + PlayerPrefs.GetString("HighScoreName1").ToString()+": ";//player score
        No1.text=PlayerPrefs.GetInt("HighScore1").ToString();//player score
        No2Name.text = "2. " + PlayerPrefs.GetString("HighScoreName2").ToString() + ": ";//player score
        No2.text = PlayerPrefs.GetInt("HighScore2").ToString();//player score
        No3Name.text = "3. " + PlayerPrefs.GetString("HighScoreName3").ToString() + ": ";//player score
        No3.text = PlayerPrefs.GetInt("HighScore3").ToString();//player score
        No4Name.text = "4. " + PlayerPrefs.GetString("HighScoreName4").ToString() + ": ";//player score
        No4.text = PlayerPrefs.GetInt("HighScore4").ToString();//player score
        No5Name.text = "5. " + PlayerPrefs.GetString("HighScoreName5").ToString() + ": ";//player score
        No5.text = PlayerPrefs.GetInt("HighScore5").ToString();//player score




        YourName.text = PlayerPrefs.GetString("NickName").ToString() + ": ";//player score
        YourScore.text = PlayerPrefs.GetInt("CurrentScore").ToString();//player score
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
