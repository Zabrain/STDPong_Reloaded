using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartAnimationScript : MonoBehaviour {

    string PlayerClicked = "None";

    public GameObject myWarning_Object;

    public Transform[] SelectorPositions;
    public GameObject SelectorImage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerClicked == "Obi")
        {
            SelectorImage.transform.position = Vector3.Lerp(SelectorImage.transform.position, SelectorPositions[0].position, 10 * Time.deltaTime);
        }
        else if (PlayerClicked == "Ada")
        {
            SelectorImage.transform.position = Vector3.Lerp(SelectorImage.transform.position, SelectorPositions[1].position, 10 * Time.deltaTime);
        }
	}

    public void ClickObi()
    {
        PlayerClicked = "Obi";
        myWarning_Object.SetActive(false);//Clear Warning to select a player
    }

    public void ClickAda()
    {
        PlayerClicked = "Ada";
        myWarning_Object.SetActive(false);//Clear Warning to select a player
    }

    public void ClickGo()
    {
        if (PlayerClicked == "Obi")
        {
            PlayerPrefs.SetString("SelectedPlayer", "Obi");//Player Selected (Ada or Obi)
            SceneManager.LoadScene("StdPongPlay");
        }
        else if (PlayerClicked == "Ada")
        {
            PlayerPrefs.SetString("SelectedPlayer", "Ada");//Player Selected (Ada or Obi)
            SceneManager.LoadScene("StdPongPlay");
        }
        else 
        {
            myWarning_Object.SetActive(true);//Warn to select a player
        }
    }
}
