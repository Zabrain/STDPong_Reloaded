using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StdPongPlayScript : MonoBehaviour {
    
    public GameObject BackgroundObject; //the object that holds the background sprites

    public Sprite[] BackgroundSprite; //arrays of all the background sprites


    public TextMeshProUGUI CurrentPlayerScore;
    public static int intCurrentPlayerScore; //the player score holder
    int lastScore=0;

    public Transform MyEnemyPosition;
    public Transform MyPlayerPosition;
    public Transform MySTDBallPosition;
    public Transform MyPowerupsPosition;
    public Transform MySTDBulletsPosition;
    
    //holders from design
    public GameObject[] MyPlayer;//array of player objects
    public GameObject[] MyEnemies;//array of Enemy objects
    public GameObject[] MySTDBall;//array of STDBall objects
    public GameObject[] MyPowerups;//array of PowerUp objects
    public GameObject[] MySTDBullets;//array of STDBullet objects

    //the actual objects
    GameObject ThePlayer;
    GameObject TheEnemy;
    GameObject TheSTDBall;
    GameObject[] ThePowerups = new GameObject[3];//array of PowerUp objects
    GameObject[] TheSTDBullets = new GameObject[2];
    

    public GameObject LoadingPane;

    int intLevel;//current level

    int intStdBulletDelayTime;//delay time before STDBullet fire
    int intStdBulletCountDownTimer=0;//Countdown to delay time

    int intPowerupDelayTime;//delay time before Powerup appears
    int intPowerupCountDownTimer =0;//Countdown to delay time

    public Slider MyPlayerImmuneSlider;
    public Slider MyEnemyImmuneSlider;

    public static float MyPlayerHealth;
    public static float MyEnemyHealth;

    public TextMeshProUGUI STDName;
    public TextMeshProUGUI LevelNumber;

    public GameObject WinPanel_Object; //the panel the pops up when player wins pong play

    public GameObject MainGamePane;
    public GameObject AllCanvasExceptLoadPane;


    float GameTimer;


    private void Awake()
    {
        intLevel = MainDirectorScript.intLevel; //get level values
        STDName.text = MainDirectorScript.strLevel;

        LevelNumber.text = "LEVEL " + intLevel.ToString();

        RenderTheBackground();//creates the background

        STDBallPicker();
        EnemyPicker(); //picks the right enemy for level
        PlayerPicker(); //picks the right player selected by Player

        CreatePowerUps(); //instantiate all powerups
        CreateSTDBullets(); //instantiate all STD Bullets

        //intStdBulletDelayTime = 500 / intLevel;//set std bullet delay time
        //intPowerupDelayTime = 250 * intLevel; //set powerup delay time

        intStdBulletDelayTime = (int) (200/intLevel)+150;//set std bullet delay time
        intPowerupDelayTime = 700; //set powerup delay time


        MyPlayerHealth = PlayerPrefs.GetFloat("MyPlayerHealth"); ;//initialize player health
        MyEnemyHealth = PlayerPrefs.GetFloat("MyEnemyHealth"); ;//initialize enemy health

       // MyEnemyHealth = .1f;

       MyPlayerImmuneSlider.value = MyPlayerHealth;
        MyEnemyImmuneSlider.value = MyEnemyHealth;

        intCurrentPlayerScore = PlayerPrefs.GetInt("CurrentScore"); //get current player score


        
    }

    // Use this for initialization
    void Start () {

        //check for level and Increase times played
        CheckForTimesPlayed();
        
    }
	
	// Update is called once per frame
	void Update () {

        if (MainDirectorScript.IsGamePaused == false && MainDirectorScript.boolLeveleStart == true)
        {
            GameTimer += Time.deltaTime; //game timer

            CheckForFiringBullet(); //starts the std bullet counter and check for delay time
            CheckForFiringPowerup(); // starts the powerup counter and check for delay time

            RegulatePlayerHealth();//make the health no exceed 1 or decrease below 0

            //update the immunity bars
            MyPlayerImmuneSlider.value = MyPlayerHealth; //work on this
            MyEnemyImmuneSlider.value = MyEnemyHealth;

            UpdateScores(); //updates the score

            PlayerLoses(); //when lost
            CPULoses();//When win
        }
        
    }

    void RegulatePlayerHealth()
    {
        if (MyPlayerHealth>1)
        {
            MyPlayerHealth = 1;
        }
        else if (MyPlayerHealth <0)
        {
            MyPlayerHealth = 0;
        }
    }

    void UpdateScores()
    {
        //update score
        if (intCurrentPlayerScore < 0)
        {
            intCurrentPlayerScore = 0;
            CurrentPlayerScore.text = intCurrentPlayerScore.ToString();
        }
        else
        {
            if (lastScore > intCurrentPlayerScore)
            {
                lastScore -= 1;
                CurrentPlayerScore.text = lastScore.ToString();

            }
            else if (lastScore < intCurrentPlayerScore)
            {
                lastScore += 1;
                CurrentPlayerScore.text = lastScore.ToString();
            }
        }
    }

    void CheckForRewards() //data!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        if (GameTimer < 61) //save the appropriate Quick Victory
        {
            PlayerPrefs.SetInt(MainDirectorScript.strLevel + "QuickVictory", PlayerPrefs.GetInt(MainDirectorScript.strLevel+"QuickVictory") + 1);

        }

        if (MyPlayerHealth >= 1f)
        {
            PlayerPrefs.SetInt(MainDirectorScript.strLevel + "FlawlessVictory", PlayerPrefs.GetInt(MainDirectorScript.strLevel + "FlawlessVictory") + 1);
        }
        
    }

    //The two functions below handles the Powerups fire
    void CheckForFiringPowerup()
    {
        if (Abstinence.MovePowerUp == false || BloodTest.MovePowerUp == false || Condom.MovePowerUp == false) //checks if either of the bullets stopped moving
        {
            intPowerupCountDownTimer += 1; //countdown for std bullet
        }

        if (intPowerupCountDownTimer == intPowerupDelayTime) //checks if delay time elapsed
        {
            FirePowerup(); //fire a random bullet
            intPowerupCountDownTimer = 0; //reset countdown timer
        }
    }

    void FirePowerup()
    {
        //pick a random Powerup
        int RandomBulletIndex = Random.Range(0, ThePowerups.Length); //exclusive range
        ThePowerups[RandomBulletIndex].transform.position = new Vector2(Random.Range(-2.5f, 2.5f), TheEnemy.transform.position.y+1f);
        if (RandomBulletIndex == 0)
        {
            Abstinence.MovePowerUp = true;
        }
        else if (RandomBulletIndex == 1)
        {
            BloodTest.MovePowerUp = true;
        }
        else if (RandomBulletIndex == 2)
        {
            Condom.MovePowerUp = true;
        }
        

    }
    //Powerups fire ends//////////////////////////////

    //The two functions below handles the std bullet firing
    void CheckForFiringBullet()
    {
        if (UnProtectedSex.MoveStdBullet == false || SharpObject.MoveStdBullet == false) //checks if either of the bullets stopped moving
        {
            intStdBulletCountDownTimer += 1; //countdown for std bullet
        }

        if (intStdBulletCountDownTimer == intStdBulletDelayTime) //checks if delay time elapsed
        {
            FireSTDBullet(); //fire a random bullet
            intStdBulletCountDownTimer = 0; //reset countdown timer
        }
    }

    void FireSTDBullet()
    {
        //pick a random bullet
        int RandomBulletIndex = Random.Range(0, TheSTDBullets.Length); //exclusive range
        TheSTDBullets[RandomBulletIndex].transform.position = TheEnemy.transform.position;
        if (RandomBulletIndex==0)
        {
            UnProtectedSex.MoveStdBullet = true;
        }
        else if (RandomBulletIndex == 1)
        {
            SharpObject.MoveStdBullet = true;
        }
        

    }
    //Std bullet firer ends//////////////////////////////

    //when players loses
    void PlayerLoses()
    {
        if (MyPlayerHealth <= 0f)
        {
            MainDirectorScript.boolLeveleStart = false;//pause the game
            WinPanel_Object.SetActive(true);//open win panel

            StoreHighScore();

            PlayerPrefs.GetInt("WinForReward", 0);//set reward state

            SceneManager.LoadScene("GLossSceneForGlobal");            
        }
    }

   
    void GotoLossScene()
    {
        SceneManager.LoadScene("GLossSceneForGlobal");
    }


    //when CPU loses
    void CPULoses()
    {
        if (MyEnemyHealth <= 0f)
        {
            CheckForRewards();//checks if player has quick victory

            MainDirectorScript.boolLeveleStart = false;//pause the game
            WinPanel_Object.SetActive(true);//open win panel

            StoreHighScore();

            PlayerPrefs.GetInt("WinForReward", 1);//set reward state

            MyAudioManager.myAudioClipsSFXs[3].Play();

        }
    }

    //stores the highscore
    void StoreHighScore() 
    {
        PlayerPrefs.SetInt("CurrentScore", intCurrentPlayerScore); //local storage

        //try to store highscore online
        gameObject.GetComponent<GrabHighScoresScript>().AddHighScore(PlayerPrefs.GetString("NickName"), intCurrentPlayerScore);
    }

    public void GotoSTDScroll()
    {
        
        MainGamePane.SetActive(false);
        AllCanvasExceptLoadPane.SetActive(false);
        LoadingPane.SetActive(true);
        LoadingPane.GetComponent<LoaderSceneScript>().LoadSceneSTDScroll(); //call the loader
        //SceneManager.LoadScene("STDScroll");
    }

    void RenderTheBackground()
    {
        SpriteRenderer spriteRenderer = BackgroundObject.GetComponent<SpriteRenderer>(); //grab the background's sprite renderer

        spriteRenderer.sprite = BackgroundSprite[intLevel]; //assign the appropriate sprite

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


    void EnemyPicker()
    {
        TheEnemy=Instantiate(MyEnemies[intLevel], MyEnemyPosition.position, MyEnemyPosition.rotation);//place the level's enemy at transform position
        
    }

    void PlayerPicker()
    {
        int PlayerIndex = 1;
        if (PlayerPrefs.GetString("SelectedPlayer")=="Obi")
        {
            PlayerIndex = 0;
        }
        else if (PlayerPrefs.GetString("SelectedPlayer") == "Ada")
        {
            PlayerIndex = 1;
        }

        ThePlayer =Instantiate(MyPlayer[PlayerIndex], MyPlayerPosition.position, MyPlayerPosition.rotation);//place the selected player at transform position 
    }

    void STDBallPicker()
    {
        TheSTDBall= Instantiate(MySTDBall[intLevel], MySTDBallPosition.position, MySTDBallPosition.rotation);//place the level's ball at transform position
    }

    void CreatePowerUps() //instantiate all powerups
    {
        ThePowerups[0]=Instantiate(MyPowerups[0], MyPowerupsPosition.position, MyPowerupsPosition.rotation);//place the level's powerups at transform position
        ThePowerups[1]=Instantiate(MyPowerups[1], MyPowerupsPosition.position, MyPowerupsPosition.rotation);//place the level's powerups at transform position
        ThePowerups[2]=Instantiate(MyPowerups[2], MyPowerupsPosition.position, MyPowerupsPosition.rotation);//place the level's powerups at transform position
        
    }

    void CreateSTDBullets() //instantiate all STD Bullets
    {
        TheSTDBullets[0] = Instantiate(MySTDBullets[0], MySTDBulletsPosition.position, MySTDBulletsPosition.rotation);//place the level's std bullets at transform position
        TheSTDBullets[1]= Instantiate(MySTDBullets[1], MySTDBulletsPosition.position, MySTDBulletsPosition.rotation);//place the level's std bullets at transform position
        

    }

    void CheckForTimesPlayed() //ckecking times plyed
    {
        if (intLevel ==1)
        {
            PlayerPrefs.SetInt("ScabiesPlayed", PlayerPrefs.GetInt("ScabiesPlayed") + 1);
        }
        else if (intLevel == 2)
        {
            PlayerPrefs.SetInt("GenitalWartsPlayed", PlayerPrefs.GetInt("GenitalWartsPlayed") + 1);
        }
        else if (intLevel == 3)
        {
            PlayerPrefs.SetInt("HerpesPlayed", PlayerPrefs.GetInt("HerpesPlayed") + 1);
        }
        else if (intLevel == 4)
        {
            PlayerPrefs.SetInt("TrichomoniasisPlayed", PlayerPrefs.GetInt("TrichomoniasisPlayed") + 1);
        }
        else if (intLevel == 5)
        {
            PlayerPrefs.SetInt("HepatitsbPlayed", PlayerPrefs.GetInt("HepatitsbPlayed") + 1);
        }
        else if (intLevel == 6)
        {
            PlayerPrefs.SetInt("ChlamydiaPlayed", PlayerPrefs.GetInt("ChlamydiaPlayed") + 1);
        }
        else if (intLevel == 7)
        {
            PlayerPrefs.SetInt("SyphilisPlayed", PlayerPrefs.GetInt("SyphilisPlayed") + 1);
        }
        else if (intLevel == 8)
        {
            PlayerPrefs.SetInt("GonorrheaPlayed", PlayerPrefs.GetInt("GonorrheaPlayed") + 1);
        }
        else if (intLevel == 9)
        {
            PlayerPrefs.SetInt("HIVPlayed", PlayerPrefs.GetInt("HIVPlayed") + 1);
        }
        else if (intLevel == 10)
        {
            PlayerPrefs.SetInt("AIDSPlayed", PlayerPrefs.GetInt("AIDSPlayed") + 1);
        }
        
    }
    
}
