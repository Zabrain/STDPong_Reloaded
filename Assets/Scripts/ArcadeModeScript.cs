using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArcadeModeScript : MonoBehaviour
{
    //buttons to STD
    public Button ScabiesButton;
    public Button GenitalWartsButton;
    public Button HerpesButton;
    public Button TrichomoniasisButton;
    public Button HepatitsBButton;
    public Button ChlamydiaButton;
    public Button SyphilisButton;
    public Button GonorrheaButton;
    public Button HIVButton;
    public Button AIDSButton;

    public GameObject ScabiesCover;
    public GameObject GenitalWartsCover;
    public GameObject HerpesCover;
    public GameObject TrichomoniasisCover;
    public GameObject HepatitsBCover;
    public GameObject ChlamydiaCover;
    public GameObject SyphilisCover;
    public GameObject GonorrheaCover;
    public GameObject HIVCover;
    public GameObject AIDSCover;
    
    public GameObject BlockPlay;

    int HighestLevel;//set reward state;

    public GameObject LoadingPane;
    public GameObject SelectSTDPane;

    private void Awake()
    {
        HighestLevel = PlayerPrefs.GetInt("HighestLevel");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (HighestLevel == 1)
        {
            ScabiesCover.SetActive(false);
        }
        else if (HighestLevel == 2)
        {
            ScabiesCover.SetActive(false);
            GenitalWartsCover.SetActive(false);
        }
        else if (HighestLevel == 3)
        {
            ScabiesCover.SetActive(false);
            GenitalWartsCover.SetActive(false);
            HerpesCover.SetActive(false);
        }
        else if (HighestLevel == 4)
        {
            ScabiesCover.SetActive(false);
            GenitalWartsCover.SetActive(false);
            HerpesCover.SetActive(false);
            TrichomoniasisCover.SetActive(false);
        }
        else if (HighestLevel == 5)
        {
            ScabiesCover.SetActive(false);
            GenitalWartsCover.SetActive(false);
            HerpesCover.SetActive(false);
            TrichomoniasisCover.SetActive(false);
            HepatitsBCover.SetActive(false);
        }
        else if (HighestLevel == 6)
        {
            ScabiesCover.SetActive(false);
            GenitalWartsCover.SetActive(false);
            HerpesCover.SetActive(false);
            TrichomoniasisCover.SetActive(false);
            HepatitsBCover.SetActive(false);
            ChlamydiaCover.SetActive(false);
        }
        else if (HighestLevel == 7)
        {
            ScabiesCover.SetActive(false);
            GenitalWartsCover.SetActive(false);
            HerpesCover.SetActive(false);
            TrichomoniasisCover.SetActive(false);
            HepatitsBCover.SetActive(false);
            ChlamydiaCover.SetActive(false);
            SyphilisCover.SetActive(false);
        }
        else if (HighestLevel == 8)
        {
            ScabiesCover.SetActive(false);
            GenitalWartsCover.SetActive(false);
            HerpesCover.SetActive(false);
            TrichomoniasisCover.SetActive(false);
            HepatitsBCover.SetActive(false);
            ChlamydiaCover.SetActive(false);
            SyphilisCover.SetActive(false);
            GonorrheaCover.SetActive(false);
        }
        else if (HighestLevel == 9)
        {
            ScabiesCover.SetActive(false);
            GenitalWartsCover.SetActive(false);
            HerpesCover.SetActive(false);
            TrichomoniasisCover.SetActive(false);
            HepatitsBCover.SetActive(false);
            ChlamydiaCover.SetActive(false);
            SyphilisCover.SetActive(false);
            GonorrheaCover.SetActive(false);
            HIVCover.SetActive(false);
        }
        else if (HighestLevel >= 10)
        {
            ScabiesCover.SetActive(false);
            GenitalWartsCover.SetActive(false);
            HerpesCover.SetActive(false);
            TrichomoniasisCover.SetActive(false);
            HepatitsBCover.SetActive(false);
            ChlamydiaCover.SetActive(false);
            SyphilisCover.SetActive(false);
            GonorrheaCover.SetActive(false);
            HIVCover.SetActive(false);
            AIDSCover.SetActive(false);
        }
}

    // Update is called once per frame
    void Update()
    {

    }

    void LoadTheSTDPongPlay()
    {
        SelectSTDPane.SetActive(false);
        LoadingPane.SetActive(true);
        LoadingPane.GetComponent<LoaderSceneScript>().LoadStartingAnimation(); //call the loader
    }

    public void ScabiesSTD()
    {
        if (HighestLevel > 1)
        {
            PlayerPrefs.SetInt("ArcadeLevel", 1);//set the Arcade level
            LoadTheSTDPongPlay();
        }
        else
        {
            BlockPlay.SetActive(true);
        }
    }
    public void GenitalWartsSTD()
    {
        if (HighestLevel > 2) {
            PlayerPrefs.SetInt("ArcadeLevel", 2);//set the Arcade level
            LoadTheSTDPongPlay();
        }
        else
        {
            BlockPlay.SetActive(true);
        }
    }
    public void HerpesSTD(){
        if (HighestLevel > 3)
        {
            PlayerPrefs.SetInt("ArcadeLevel", 3);//set the Arcade level
            LoadTheSTDPongPlay();
        }
        else
        {
            BlockPlay.SetActive(true);
        }
    }
    public void TrichomoniasisSTD(){
        if (HighestLevel > 4)
        {
            PlayerPrefs.SetInt("ArcadeLevel", 4);//set the Arcade level
            LoadTheSTDPongPlay();
        }
        else
        {
            BlockPlay.SetActive(true);
        }
    }
    public void HepatitsBSTD(){
        if (HighestLevel > 5)
        {
            PlayerPrefs.SetInt("ArcadeLevel", 5);//set the Arcade level
            LoadTheSTDPongPlay();
        }
        else
        {
            BlockPlay.SetActive(true);
        }
    }
    public void ChlamydiaSTD(){
        if (HighestLevel > 6)
        {
            PlayerPrefs.SetInt("ArcadeLevel", 6);//set the Arcade level
            LoadTheSTDPongPlay();
        }
        else
        {
            BlockPlay.SetActive(true);
        }

    }
    public void SyphilisSTD(){
        if (HighestLevel > 7)
        {
            PlayerPrefs.SetInt("ArcadeLevel", 7);//set the Arcade level
            SceneManager.LoadScene("StoryAnimation");
        }
        else
        {
            BlockPlay.SetActive(true);
        }

    }
    public void GonorrheaSTD(){
        if (HighestLevel > 8)
        {
            PlayerPrefs.SetInt("ArcadeLevel", 8);//set the Arcade level
            SceneManager.LoadScene("StoryAnimation");
        }
        else
        {
            BlockPlay.SetActive(true);
        }

    }
    public void HIVSTD(){
        if (HighestLevel > 9)
        {
            PlayerPrefs.SetInt("ArcadeLevel", 9);//set the Arcade level
            LoadTheSTDPongPlay();
        }
        else
        {
            BlockPlay.SetActive(true);
        }

    }
    public void AIDSSTD()
    {
        if (HighestLevel > 10)
        {
            PlayerPrefs.SetInt("ArcadeLevel", 10);//set the Arcade level
            LoadTheSTDPongPlay();
        }
        else
        {
            BlockPlay.SetActive(true);
        }

    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu"); //Goto Main Menu
    }
}
