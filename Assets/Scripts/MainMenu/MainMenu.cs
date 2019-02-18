using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    public TextMeshProUGUI ListPlayers;

	// Use this for initialization
	void Start () {
		
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
        SceneManager.LoadScene("StdPongPlay");

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
