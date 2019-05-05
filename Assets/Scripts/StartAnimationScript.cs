using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text;
using System.Text.RegularExpressions;

public class StartAnimationScript : MonoBehaviour {
    public GameObject BackgroundObject; //the object that holds the background sprites

    public Sprite BackgroundSprite; //arrays of all the background sprites

    public GameObject Go_Button_Object;

    string PlayerClicked = "None";

    public GameObject myWarning_Object;

    public Transform[] SelectorPositions;
    public GameObject SelectorImage;

    public GameObject LoadingPane;
    public GameObject SelectPane;
    public GameObject NicknamePane;

    public TextMeshProUGUI NickName;
    public TextMeshProUGUI NickNameWarning;
    public TextMeshProUGUI NationalityDll;
    public TextMeshProUGUI SexDll;
    public TextMeshProUGUI EmailAddressText;

    bool NickNameTyping=false;
    string  NickNameRand;

    public const string MatchEmailPattern =
           @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
           + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
             + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
           + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

    public static bool myIsEmail(string email)
    {
        if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
        else return false;
    }
    // Use this for initialization
    void Start () {

        //PlayerPrefs.SetInt("NickNameIndex", PlayerPrefs.GetInt("NickNameIndex") + 1);//Increase NicknameIndex

        NickNameRand = Random.Range(0, 999).ToString();

        RenderTheBackground();

        Go_Button_Object.SetActive(false);//disable the go button until a player is selected

        //skip NickName pane if mode is Arcade
        if (PlayerPrefs.GetString("SelectedMode") == "ArcadeMode")
        {
             SelectPane.SetActive(true);
             NicknamePane.SetActive(false);
        }

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

        if (NickNameTyping)
        {
            NickNameWarning.text = NickName.text.Trim() + NickNameRand;
        }
        

    }

    public void ClickObi()
    {
        MyAudioManager.myAudioClipsSFXs[5].Play();
        PlayerClicked = "Obi";
        myWarning_Object.SetActive(false);//Clear Warning to select a player
        SelectorImage.SetActive(true);//Show selector border
        Go_Button_Object.SetActive(true);//Show the go button
    }

    public void ClickAda()
    {
        MyAudioManager.myAudioClipsSFXs[5].Play();
        PlayerClicked = "Ada";
        myWarning_Object.SetActive(false);//Clear Warning to select a player
        SelectorImage.SetActive(true);//Show selector border
        Go_Button_Object.SetActive(true);//Show the go button
    }

    public void GoOnSelectPlayer()
    {
        
        if (PlayerClicked == "Obi")
        {
            PlayerPrefs.SetString("CurrentScene", "StdPongPlay");//sets the next scene
            PlayerPrefs.SetString("SelectedPlayer", "Obi");//Player Selected (Ada or Obi)
            //SceneManager.LoadScene("StdPongPlay");
            SelectorImage.SetActive(false);
            SelectPane.SetActive(false);
            LoadingPane.SetActive(true);
            LoadingPane.GetComponent<LoaderSceneScript>().LoadPretest(); //call the loader


            //Debug.Log(PlayerPrefs.GetString("Nationality") + "   " + PlayerPrefs.GetString("PlayerSex"));
        }
        else if (PlayerClicked == "Ada")
        {
            PlayerPrefs.SetString("CurrentScene", "StdPongPlay");//sets the next scene
            PlayerPrefs.SetString("SelectedPlayer", "Ada");//Player Selected (Ada or Obi)
           
            SelectorImage.SetActive(false);
            SelectPane.SetActive(false);
            LoadingPane.SetActive(true);
            LoadingPane.GetComponent<LoaderSceneScript>().LoadPretest(); //call the loader
        }
        else
        {
            myWarning_Object.SetActive(true);//Warn to select a player
        }
    }


    public void GoOnNickName() //also resets score and level
    {

        if(NickName.text.Trim() != "" && myIsEmail(EmailAddressText.text.Trim()) != false && SexDll.text.Trim() != "Select Your Gender")
        {
            //try to store nickname in DataBase
            //pick a random Powerup
            PlayerPrefs.SetString("NickName", NickName.text.Trim() + NickNameRand);
            PlayerPrefs.SetString("EmailAddress", EmailAddressText.text.Trim());
            //PlayerPrefs.SetString("Nationality", NationalityDll.text.Trim());
            if (SexDll.text.Trim() == "Male")   
            {
                PlayerPrefs.SetString("PlayerSex", "M");
            }
            else if (SexDll.text.Trim() == "Female")
            {
                PlayerPrefs.SetString("PlayerSex", "F");
            }
            else if (SexDll.text.Trim() == "Other")
            {
                PlayerPrefs.SetString("PlayerSex", "O");
            }
            PlayerPrefs.SetInt("CurrentScore", 0);//reset scores
            PlayerPrefs.SetInt("CurrentLevel", 1);//reset level

            gameObject.GetComponent<GrabHighScoresScript>().PutInAllData(); //store nickname and sex

            NicknamePane.SetActive(false);
            SelectPane.SetActive(true);
        }
        else
        {
            NickNameWarning.text= "Please, Enter a Nickname, Email Address and Gender!";
            NickNameTyping = false;
        }
               
    }

    public void NickTextChange()
    {
        NickNameTyping = true;
    }


    void RenderTheBackground()
    {
        SpriteRenderer spriteRenderer = BackgroundObject.GetComponent<SpriteRenderer>(); //grab the background's sprite renderer

        spriteRenderer.sprite = BackgroundSprite; //assign the appropriate sprite

        //SpriteRenderer sr = GetComponent<SpriteRenderer>();

        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        Vector2 scale = BackgroundObject.transform.localScale;
        if (cameraSize.x >= cameraSize.y)
        { // Landscape (or equal)
            scale *= cameraSize.x / spriteSize.x;
        }
        else
        { // Portrait
            scale *= cameraSize.y / spriteSize.y;
        }

        BackgroundObject.transform.position = Vector2.zero; // Optional
        BackgroundObject.transform.localScale = scale;
    }

    
}
