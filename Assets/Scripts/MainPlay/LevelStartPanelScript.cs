using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStartPanelScript : MonoBehaviour {
    public Sprite[] PlayerIntro;
    public Sprite[] EnemyIntro;
    public Image PlayerImage;
    public Image EnemyImage;

    // Use this for initialization
    void Start () {

        //select the selected player
        if(PlayerPrefs.GetString("SelectedPlayer") == "Obi")
        {
            PlayerImage.overrideSprite = PlayerIntro[0];
        }
        else if (PlayerPrefs.GetString("SelectedPlayer") == "Ada")
        {
            PlayerImage.overrideSprite = PlayerIntro[1];
        }


        //select the level enemy
        EnemyImage.overrideSprite = EnemyIntro[MainDirectorScript.intLevel];
        
    }
	
	// Update is called once per frame
	void Update () {
		


	}

    //startbutton
    public void StartButton()
    {
        MainDirectorScript.boolLeveleStart = true;
    }
}
