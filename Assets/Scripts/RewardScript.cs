using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardScript : MonoBehaviour
{

    public GameObject QuickVictoryObject;
    public GameObject FlawlessVictoryObject;
    public GameObject CollectorObject;
    public GameObject STDPantoMathObject;
    public GameObject STDPolyMathObject;
    public GameObject GrandMasterObject;
    public GameObject ContinueObject;
    public GameObject NextObject;

    int QuickVictoryCurrent;
    int FlawlessVictoryCurrent;
    int CollectorCurrent;
    int STDPantoMathCurrent;
    int STDPolyMathCurrent;
    int GrandMasterCurrent;

    public GameObject LoadingPane;

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(MainDirectorScript.intLevel);

        //PlayerPrefs.SetInt("QuickVictoryCurrent", 1);
        //PlayerPrefs.SetInt("FlawlessVictoryCurrent", 1);

        QuickVictoryCurrent = PlayerPrefs.GetInt("QuickVictoryCurrent");
        FlawlessVictoryCurrent = PlayerPrefs.GetInt("FlawlessVictoryCurrent");
        CollectorCurrent = PlayerPrefs.GetInt("CollectorCurrent");
        STDPantoMathCurrent = PlayerPrefs.GetInt("STDPantoMathCurrent"); 
        STDPolyMathCurrent = PlayerPrefs.GetInt("STDPolyMathCurrent");
        GrandMasterCurrent= PlayerPrefs.GetInt("GrandMasterCurrent");

        NextReward(); //ckeck for reward

        PlayerPrefs.SetInt("QuickVictoryCurrent", 0);
        PlayerPrefs.SetInt("FlawlessVictoryCurrent", 0);
        PlayerPrefs.SetInt("CollectorCurrent", 0);
        PlayerPrefs.SetInt("STDPolyMathCurrent", 0);
        PlayerPrefs.SetInt("STDPantoMathCurrent", 0);
        PlayerPrefs.SetInt("GrandMasterCurrent", 0);

        // Debug.Log(PlayerPrefs.GetInt("WinForReward") + "  Win for reward");


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void NextReward()
    {
        //set all rewards inactive
        QuickVictoryObject.SetActive(false);
        FlawlessVictoryObject.SetActive(false);
        CollectorObject.SetActive(false);
        STDPolyMathObject.SetActive(false);
        STDPantoMathObject.SetActive(false);
        GrandMasterObject.SetActive(false);

        if (QuickVictoryCurrent == 1) //check for first reward
        {
            QuickVictoryObject.SetActive(true);
            QuickVictoryCurrent = 0;
        }
        else if (FlawlessVictoryCurrent == 1) //check for reward
        {
            FlawlessVictoryObject.SetActive(true);
            FlawlessVictoryCurrent = 0;
        }
        else if (CollectorCurrent == 1) //check for reward
        {
            CollectorObject.SetActive(true);
            CollectorCurrent = 0;
        }
        else if (STDPantoMathCurrent == 1) //check for reward
        {
            STDPantoMathObject.SetActive(true);
            STDPantoMathCurrent = 0;
        }
        else if (STDPolyMathCurrent == 1) //check for reward
        {
            STDPolyMathObject.SetActive(true);
            STDPolyMathCurrent = 0;
        }
        else if (GrandMasterCurrent == 1) //check for reward
        {
            GrandMasterObject.SetActive(true);
            GrandMasterCurrent = 0;
        }
        else //if all reward shown, continue
        {
            ContinueObject.SetActive(true);
            NextObject.SetActive(false);
        }
        

        
    }

    public void ContinueFronReward()
    {
        LoadingPane.SetActive(true);

        if (PlayerPrefs.GetInt("WinForReward") == 0) //Lose
        {
            LoadingPane.GetComponent<LoaderSceneScript>().LoadSceneSTDLose(); //call the loader
        }
        else if (PlayerPrefs.GetInt("WinForReward") == 1) //win
        {
            LoadingPane.GetComponent<LoaderSceneScript>().LoadPretest(); //Goto to pretest for next level
        } //game finished
        else if (PlayerPrefs.GetInt("WinForReward") == 2)
        {
            LoadingPane.GetComponent<LoaderSceneScript>().LoadSceneFinishStoryMode(); //call the loader
        }
    }

}
