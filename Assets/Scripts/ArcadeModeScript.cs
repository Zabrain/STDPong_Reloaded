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

    int CurrentLevel;

    public GameObject LoadingPane;
    public GameObject SelectSTDPane;

    // Start is called before the first frame update
    void Start()
    {
        if (CurrentLevel == 1)
        {

        }
        else if (CurrentLevel == 2)
        {
            ScabiesButton.enabled = true;
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
        PlayerPrefs.SetInt("ArcadeLevel", 1);//set the Arcade level
        LoadTheSTDPongPlay();
    }
    public void GenitalWartsSTD()
    {
        PlayerPrefs.SetInt("ArcadeLevel", 2);//set the Arcade level
        LoadTheSTDPongPlay();
    }
    public void HerpesSTD(){
        PlayerPrefs.SetInt("ArcadeLevel", 3);//set the Arcade level
        LoadTheSTDPongPlay();
    }
    public void TrichomoniasisSTD(){
        PlayerPrefs.SetInt("ArcadeLevel", 4);//set the Arcade level
        LoadTheSTDPongPlay();
    }
    public void HepatitsBSTD(){
        PlayerPrefs.SetInt("ArcadeLevel", 5);//set the Arcade level
        LoadTheSTDPongPlay();
    }
    public void ChlamydiaSTD(){
        PlayerPrefs.SetInt("ArcadeLevel", 6);//set the Arcade level
        LoadTheSTDPongPlay();
    }
    public void SyphilisSTD(){
        PlayerPrefs.SetInt("ArcadeLevel", 7);//set the Arcade level
        SceneManager.LoadScene("StoryAnimation");
    }
    public void GonorrheaSTD(){
        PlayerPrefs.SetInt("ArcadeLevel", 8);//set the Arcade level
        SceneManager.LoadScene("StoryAnimation");
    }
    public void HIVSTD(){
        PlayerPrefs.SetInt("ArcadeLevel", 9);//set the Arcade level
        LoadTheSTDPongPlay();
    }
    public void AIDSSTD()
    {
        PlayerPrefs.SetInt("ArcadeLevel", 10);//set the Arcade level
        LoadTheSTDPongPlay();
    }
}
