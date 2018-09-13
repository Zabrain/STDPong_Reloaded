using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSceneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RetryLevel()
    {
        SceneManager.LoadScene("StdPongPlay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
