using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //for prequiz
        string strPreQuiz = "PreQuiz_" + PlayerPrefs.GetInt("ScabiesPretest").ToString() + 
            "_" + PlayerPrefs.GetInt("Genital WartsPretest").ToString() + 
            "_" + PlayerPrefs.GetInt("HerpesPretest").ToString() +
            "_" + PlayerPrefs.GetInt("TrichomoniasisPretest").ToString() +
            "_" + PlayerPrefs.GetInt("Hepatits Bpretest").ToString() +
            "_" + PlayerPrefs.GetInt("ChlamydiaPretest").ToString() +
            "_" + PlayerPrefs.GetInt("SyphilisPretest").ToString() +
            "_" + PlayerPrefs.GetInt("GonorrheaPretest").ToString() +
            "_" + PlayerPrefs.GetInt("HIVPretest").ToString() +
            "_" + PlayerPrefs.GetInt("AIDSPretest").ToString();

        //for post quiz
        string strPostQuiz = "PostQuiz_" + PlayerPrefs.GetInt("ScabiesPostTest").ToString() +
            "_" + PlayerPrefs.GetInt("Genital WartsPostTest").ToString() +
            "_" + PlayerPrefs.GetInt("HerpesPostTest").ToString() +
            "_" + PlayerPrefs.GetInt("TrichomoniasisPostTest").ToString() +
            "_" + PlayerPrefs.GetInt("Hepatits BPostTest").ToString() +
            "_" + PlayerPrefs.GetInt("ChlamydiaPostTest").ToString() +
            "_" + PlayerPrefs.GetInt("SyphilisPostTest").ToString() +
            "_" + PlayerPrefs.GetInt("GonorrheaPostTest").ToString() +
            "_" + PlayerPrefs.GetInt("HIVPostTest").ToString() +
            "_" + PlayerPrefs.GetInt("AIDSPostTest").ToString();

        //for post quiz
        string LevelPlayed = "LevelPlayed_" + PlayerPrefs.GetInt("ScabiesPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("GenitalWartsPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("HerpesPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("TrichomoniasisPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("HepatitsbPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("ChlamydiaPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("SyphilisPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("GonorrheaPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("HIVPlayed").ToString() +
            "_" + PlayerPrefs.GetInt("AIDSPlayed").ToString(); 


        string strOtherData = strPreQuiz + " "+ strPostQuiz + " "+ LevelPlayed;

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
