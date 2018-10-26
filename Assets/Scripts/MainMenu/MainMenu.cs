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

    public void StoryMode()
    {
        PlayerPrefs.SetString("STDScrollFrom", "StoryMode");
        SceneManager.LoadScene("StartingAnimation");

        PlayerPrefs.SetFloat("MyEnemyHealth", 1f); //normalize enemy health
    }

    public void ArcadeMode()
    {
        PlayerPrefs.SetString("STDScrollFrom", "ArcadeMode");
        SceneManager.LoadScene("StdPongPlay");
    }

    public void ListThePlayers()
    {
        ListPlayers.text = PlayerPrefs.GetString("AllUsers");
    }

}
