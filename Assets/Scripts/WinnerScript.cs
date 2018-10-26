using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerScript : MonoBehaviour {

    public Sprite[] PlayerCharacter;
    public Image PlayerImage; 

	// Use this for initialization
	void Start () {


        if (PlayerPrefs.GetString("SelectedPlayer") == "Obi")
        {
            PlayerImage.sprite = PlayerCharacter[0];
        }
        else
        {
            PlayerImage.sprite = PlayerCharacter[1];
        }



	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
