using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    public TextMeshProUGUI ListPlayers;

    public GameObject ContinueBtnObject;
    public GameObject ContinueBtnDisabledObject;

    public TextMeshProUGUI QuickVictoryText;
    public TextMeshProUGUI FlawlessVictoryText;
    public TextMeshProUGUI CollectorText;
    public TextMeshProUGUI STDPantoMathText;
    public TextMeshProUGUI STDPolyMathText;
    public TextMeshProUGUI GrandMasterText;

    // Use this for initialization
    void Start () {

        if (PlayerPrefs.GetInt("ScabiesPlayed") > 0) //if scabies has not been played disable continue
        {
            ContinueBtnObject.SetActive(true);
            ContinueBtnDisabledObject.SetActive(false);
        }
        else
        {
            ContinueBtnObject.SetActive(false);
            ContinueBtnDisabledObject.SetActive(true);
        }

        if (MainDirectorScript.intLevel > 10)
        {
            ContinueBtnObject.SetActive(false);
            ContinueBtnDisabledObject.SetActive(true);
        }


        //for QuickVictory
        int intQuickVictory = PlayerPrefs.GetInt("ScabiesQuickVictory") +
            PlayerPrefs.GetInt("Genital WartsQuickVictory") +
            PlayerPrefs.GetInt("HerpesQuickVictory") +
            PlayerPrefs.GetInt("TrichomoniasisQuickVictory") +
            PlayerPrefs.GetInt("Hepatitis BQuickVictory") +
            PlayerPrefs.GetInt("ChlamydiaQuickVictory") +
            PlayerPrefs.GetInt("SyphilisQuickVictory") +
            PlayerPrefs.GetInt("GonorrheaQuickVictory") +
            PlayerPrefs.GetInt("HIVQuickVictory") +
            PlayerPrefs.GetInt("AIDSQuickVictory");

            QuickVictoryText.text = intQuickVictory.ToString();

    //for Flawless Victory
    int intFlawlessVictory = PlayerPrefs.GetInt("ScabiesFlawlessVictory") +
            PlayerPrefs.GetInt("Genital WartsFlawlessVictory") +
            PlayerPrefs.GetInt("HerpesFlawlessVictory") +
            PlayerPrefs.GetInt("TrichomoniasisFlawlessVictory") +
            PlayerPrefs.GetInt("Hepatitis BFlawlessVictory") +
            PlayerPrefs.GetInt("ChlamydiaFlawlessVictory") +
            PlayerPrefs.GetInt("SyphilisFlawlessVictory") +
            PlayerPrefs.GetInt("GonorrheaFlawlessVictory") +
            PlayerPrefs.GetInt("HIVFlawlessVictory") +
            PlayerPrefs.GetInt("AIDSFlawlessVictory");

            FlawlessVictoryText.text = intFlawlessVictory.ToString();
                
        //for collector
        CollectorText.text = PlayerPrefs.GetInt("TheCollector").ToString();
        //for PantoMath
        STDPantoMathText.text =   PlayerPrefs.GetInt("TheSTDPantoMath").ToString();
        //for PolyMath
         STDPolyMathText.text =  PlayerPrefs.GetInt("TheSTDPolyMath").ToString();
        //For grandmaster
         GrandMasterText.text = PlayerPrefs.GetInt("TheGrandMaster").ToString();

    }
	



	// Update is called once per frame
	void Update () {
		
	}

    public void StoryModeNew()
    {
        PlayerPrefs.SetString("SelectedMode", "StoryMode");
        SceneManager.LoadScene("StoryAnimation");

        PlayerPrefs.SetFloat("MyEnemyHealth", 1f); //normalize enemy health
    }

    public void StoryModeContinue()
    {
        PlayerPrefs.SetString("SelectedMode", "StoryMode");
        SceneManager.LoadScene("PreQuizScene"); //checks if pretest has been done or not

        PlayerPrefs.SetFloat("MyEnemyHealth", 1f); //normalize enemy health
    }

    public void ArcadeMode()
    {
        PlayerPrefs.SetString("SelectedMode", "ArcadeMode");
        SceneManager.LoadScene("ArcadeMode");

        PlayerPrefs.SetFloat("MyEnemyHealth", 1f); //normalize enemy health
    }

    public void ScrollCollected()
    {
        PlayerPrefs.SetString("SelectedMode", "ScrollCollected");//intentifies the mode in the scroll scene
        SceneManager.LoadScene("ScrollGotten");
        
    }


}
