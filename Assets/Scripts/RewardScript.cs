using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScript : MonoBehaviour
{
    public Sprite[] QuickVictoryBadges;
    public Sprite[] FlawlessVictoryBadges;

    public GameObject QuickVictoryObject;
    public GameObject FlawlessVictoryObject;
    public GameObject CollectorObject;
    public GameObject STDPantoMathObject;
    public GameObject STDPolyMathObject;
    public GameObject GrandMasterObject;
    public GameObject ContinueObject;
    public GameObject NextObject;

    public GameObject LoadingPane;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("QuickVictoryCurrent", 1);
        PlayerPrefs.SetInt("FlawlessVictoryCurrent", 1);
        PlayerPrefs.SetInt("CollectorCurrent", 1);
        PlayerPrefs.SetInt("STDPantoMathCurrent", 1);
        PlayerPrefs.SetInt("STDPolyMathCurrent", 1);
        PlayerPrefs.SetInt("GrandMasterCurrent", 1);


        if (PlayerPrefs.GetInt("QuickVictoryCurrent") == 1) //check for first reward
        {
            QuickVictoryObject.SetActive(true);
            PlayerPrefs.SetInt("QuickVictoryCurrent", 0);
        }
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
        STDPantoMathObject.SetActive(false);
        STDPolyMathObject.SetActive(false);
        GrandMasterObject.SetActive(false);

        //first one was done on start
        if (PlayerPrefs.GetInt("FlawlessVictoryCurrent") == 1) //check for reward
        {
            FlawlessVictoryObject.SetActive(true);
            PlayerPrefs.SetInt("FlawlessVictoryCurrent", 0);
        }
        else if (PlayerPrefs.GetInt("CollectorCurrent") == 1) //check for reward
        {
            CollectorObject.SetActive(true);
            PlayerPrefs.SetInt("CollectorCurrent", 0);
        }
        else if (PlayerPrefs.GetInt("STDPantoMathCurrent") == 1) //check for reward
        {
            STDPantoMathObject.SetActive(true);
            PlayerPrefs.SetInt("STDPantoMathCurrent", 0);
        }
        else if (PlayerPrefs.GetInt("STDPolyMathCurrent") == 1) //check for reward
        {
            STDPolyMathObject.SetActive(true);
            PlayerPrefs.SetInt("STDPolyMathCurrent", 0);
        }
        else if (PlayerPrefs.GetInt("GrandMasterCurrent") == 1) //check for reward
        {
            GrandMasterObject.SetActive(true);
            PlayerPrefs.SetInt("GrandMasterCurrent", 0);
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

        if (PlayerPrefs.GetInt("WinForReward") == 0)
        {
            LoadingPane.GetComponent<LoaderSceneScript>().LoadSceneSTDLose(); //call the loader
        }
        else if (PlayerPrefs.GetInt("WinForReward") == 1)
        {
            LoadingPane.GetComponent<LoaderSceneScript>().LoadSceneSTDPlay(); //call the loader
        }
        else if (PlayerPrefs.GetInt("WinForReward") == 2)
        {
            LoadingPane.GetComponent<LoaderSceneScript>().LoadSceneFinishStoryMode(); //call the loader
        }
    }

}
