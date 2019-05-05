using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrabHighScoresScript : MonoBehaviour
{
    public GameObject ErrorPane;

    const string privateCodeSTDPong = "h25gfFc5aE-gL3NIDyIOdAkU_nTotofUq-we5e3cYBdw";
    const string publicCodeSTDPong = "5c365291b6397e0c2408e09d";
    const string webURLSTDPong = "http://dreamlo.com/lb/";

    string UploadResult="";

    public Highscore[] MyHighScoreList;
    Leaderboard highscoresDisplay;

    private void Awake()
    {
        highscoresDisplay = GetComponent<Leaderboard>(); //call the leaderboard component

    }

    public void AddHighScore(string Uname, int playerScore, string AllOtherData)
    {
        StartCoroutine(UploadTheHighScore(Uname, playerScore, AllOtherData));
    }
    
    IEnumerator UploadTheHighScore(string Uname, int playerScore,  string AllOtherData)
    {
        http://dreamlo.com/lb/h25gfFc5aE-gL3NIDyIOdAkU_nTotofUq-we5e3cYBdw/delete/Carmine
        
        WWW www = new WWW(webURLSTDPong + privateCodeSTDPong + "/add/" + WWW.EscapeURL(Uname) + "/" + playerScore + "/0/"+ AllOtherData );

        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            UploadResult = "Success!";
            Debug.Log(UploadResult);
            //DownloadHighScoreFromDB(); //dowload it again
        }
        else
        {
            UploadResult = www.error;
            Debug.Log(UploadResult);
        }
    }


    public void DownloadHighScoreFromDB()
    {
        StartCoroutine("DownloadTheHighScore");
    }


    IEnumerator DownloadTheHighScore()
    {
        WWW www = new WWW(webURLSTDPong + publicCodeSTDPong + "/pipe/");

        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            UploadResult = "Success!";
            //Debug.Log(www.text);
            FormatTHeHighScores(www.text); //grab the text to format
            highscoresDisplay.WhenHighScoreDownloads(MyHighScoreList);
        }
        else
        {
            UploadResult = www.error;
            Debug.Log(UploadResult);

            ErrorPane.SetActive(true);
        }
    }

    void FormatTHeHighScores(string textStream)
    {
        string[] theEntries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries); //split the text at new line
        MyHighScoreList = new Highscore[theEntries.Length];

        for (int i=0; i<theEntries.Length; i++)
        {
            string[] entryInfo = theEntries[i].Split(new char[] {'|'});
            string uname = entryInfo[0];
            int playerscore = int.Parse(entryInfo[1]);
            string OtherData = entryInfo[3];
            MyHighScoreList[i] = new Highscore(uname, playerscore, OtherData);

           // Debug.Log(MyHighScoreList[i].uname +":  "+ MyHighScoreList[i].playerscore);
        }
    }

    public void PutInAllData()
    {
        string strEmailNatSex = PlayerPrefs.GetString("EmailAddress") + "_" + PlayerPrefs.GetString("PlayerSex");

        //for prequiz
        string strPreQuiz = "PrQ_" + PlayerPrefs.GetInt("ScabiesPretest").ToString() + 
             PlayerPrefs.GetInt("Genital WartsPretest").ToString() + 
             PlayerPrefs.GetInt("HerpesPretest").ToString() +
             PlayerPrefs.GetInt("TrichomoniasisPretest").ToString() +
             PlayerPrefs.GetInt("Hepatitis BPretest").ToString() +
             PlayerPrefs.GetInt("ChlamydiaPretest").ToString() +
             PlayerPrefs.GetInt("SyphilisPretest").ToString() +
             PlayerPrefs.GetInt("GonorrheaPretest").ToString() +
             PlayerPrefs.GetInt("HIVPretest").ToString() +
             PlayerPrefs.GetInt("AIDSPretest").ToString();

        //for post quiz
        string strPostQuiz = "PoQ_" + PlayerPrefs.GetInt("ScabiesPostTest").ToString() +
             PlayerPrefs.GetInt("Genital WartsPostTest").ToString() +
             PlayerPrefs.GetInt("HerpesPostTest").ToString() +
             PlayerPrefs.GetInt("TrichomoniasisPostTest").ToString() +
             PlayerPrefs.GetInt("Hepatitis BPostTest").ToString() +
             PlayerPrefs.GetInt("ChlamydiaPostTest").ToString() +
             PlayerPrefs.GetInt("SyphilisPostTest").ToString() +
             PlayerPrefs.GetInt("GonorrheaPostTest").ToString() +
             PlayerPrefs.GetInt("HIVPostTest").ToString() +
             PlayerPrefs.GetInt("AIDSPostTest").ToString();

        //for post quiz
        string LevelPlayed = "LP_" + PlayerPrefs.GetInt("ScabiesPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("GenitalWartsPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("HerpesPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("TrichomoniasisPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("HepatitisbPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("ChlamydiaPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("SyphilisPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("GonorrheaPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("HIVPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("AIDSPlayed").ToString();


        //for general timer
        var totalSeconds = PlayerPrefs.GetFloat("GeneralTimer");
        var ss = Convert.ToInt32(totalSeconds % 60).ToString("00");
        var mm = (Math.Floor(totalSeconds / 60) % 60).ToString("00");
        var hh = Math.Floor(totalSeconds / 60 / 60).ToString("00");

        string strGeneralTimer = "GT" + hh + "_" + mm + "_" + ss;


        //for QuickVictory
        string strQuickVictory = "QV_" + PlayerPrefs.GetInt("ScabiesQuickVictory").ToString() +
            "_" + PlayerPrefs.GetInt("Genital WartsQuickVictory").ToString() +
            "_" + PlayerPrefs.GetInt("HerpesQuickVictory").ToString() +
            "_" + PlayerPrefs.GetInt("TrichomoniasisQuickVictory").ToString() +
            "_" + PlayerPrefs.GetInt("Hepatitis BQuickVictory").ToString() +
            "_" + PlayerPrefs.GetInt("ChlamydiaQuickVictory").ToString() +
            "_" + PlayerPrefs.GetInt("SyphilisQuickVictory").ToString() +
            "_" + PlayerPrefs.GetInt("GonorrheaQuickVictory").ToString() +
            "_" + PlayerPrefs.GetInt("HIVQuickVictory").ToString() +
            "_" + PlayerPrefs.GetInt("AIDSQuickVictory").ToString();

        //for Flawless Victory
        string strFlawlessVictory = "FV_" + PlayerPrefs.GetInt("ScabiesFlawlessVictory").ToString() +
            "_" + PlayerPrefs.GetInt("Genital WartsFlawlessVictory").ToString() +
            "_" + PlayerPrefs.GetInt("HerpesFlawlessVictory").ToString() +
            "_" + PlayerPrefs.GetInt("TrichomoniasisFlawlessVictory").ToString() +
            "_" + PlayerPrefs.GetInt("Hepatitis BFlawlessVictory").ToString() +
            "_" + PlayerPrefs.GetInt("ChlamydiaFlawlessVictory").ToString() +
            "_" + PlayerPrefs.GetInt("SyphilisFlawlessVictory").ToString() +
            "_" + PlayerPrefs.GetInt("GonorrheaFlawlessVictory").ToString() +
            "_" + PlayerPrefs.GetInt("HIVFlawlessVictory").ToString() +
            "_" + PlayerPrefs.GetInt("AIDSFlawlessVictory").ToString();

        //for collector
        string strCollector = "CL"+PlayerPrefs.GetInt("TheCollector").ToString();

        //for PantoMath
        string strPantoMath = "PA"+PlayerPrefs.GetInt("TheSTDPantoMath").ToString();
        //for PolyMath
        string strSTDPolyMath = "PO"+PlayerPrefs.GetInt("TheSTDPolyMath").ToString();
        //For grandmaster
        string strGrandMaster = "GM"+PlayerPrefs.GetInt("TheGrandMaster").ToString();

        //total initial quests answered
        string strTotalIntAnswered = "TA"+PlayerPrefs.GetInt("Total Questions Answered").ToString();

        
        string strOtherData = strEmailNatSex + " " + strPreQuiz + strPostQuiz + LevelPlayed+ strGeneralTimer+ strQuickVictory + 
            strFlawlessVictory + strCollector + strPantoMath + strSTDPolyMath + strGrandMaster + strTotalIntAnswered;

        PlayerPrefs.SetString("AllOtherData", strOtherData);
        //try to store highscore online
        AddHighScore(PlayerPrefs.GetString("NickName"), PlayerPrefs.GetInt("CurrentScore"), PlayerPrefs.GetString("AllOtherData"));
    }
    

}

public struct Highscore
{
    public string uname;
    public int playerscore;
    public string OtherData;

    public Highscore(string _uname, int _playerscore, string _OtherData)
    {
        uname = _uname;
        playerscore = _playerscore;
        OtherData = _OtherData;
    }
}
