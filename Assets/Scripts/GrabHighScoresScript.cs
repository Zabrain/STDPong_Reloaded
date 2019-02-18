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

    public void AddHighScore(string Uname, int playerScore)
    {
        StartCoroutine(UploadTheHighScore(Uname, playerScore));
    }
    
    IEnumerator UploadTheHighScore(string Uname, int playerScore)
    {
        WWW www = new WWW(webURLSTDPong + privateCodeSTDPong + "/add/" + WWW.EscapeURL(Uname) + "/" + playerScore);

        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            UploadResult = "Success!";
            Debug.Log(UploadResult);
            DownloadHighScoreFromDB(); //dowload it again
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
            Debug.Log(www.text);
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
            MyHighScoreList[i] = new Highscore(uname, playerscore);

            Debug.Log(MyHighScoreList[i].uname +":  "+ MyHighScoreList[i].playerscore);
        }
    }


}

public struct Highscore
{
    public string uname;
    public int playerscore;

    public Highscore(string _uname, int _playerscore)
    {
        uname = _uname;
        playerscore = _playerscore;
    }
}
