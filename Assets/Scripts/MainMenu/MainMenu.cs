using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    public TextMeshProUGUI ListPlayers;

    public GameObject ContinueBtnObject;
    public GameObject ContinueBtnDisabledObject;

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

    public void ListThePlayers()
    {
        ListPlayers.text = PlayerPrefs.GetString("AllUsers");
    }

    
}
