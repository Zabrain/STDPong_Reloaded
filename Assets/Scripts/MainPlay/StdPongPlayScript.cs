using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StdPongPlayScript : MonoBehaviour {

    public GameObject BackgroundObject; //the object that holds the background sprites

    public Sprite[] BackgroundSprite; //arrays of all the background sprites
    
    public Transform MyEnemyPosition;
    public Transform MyPlayerPosition;
    public Transform MySTDBallPosition;
    public Transform MyPowerupsPosition;
    public Transform MySTDBulletsPosition;

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

    int intLevel = 1;//current level

    int intStdBulletDelayTime = 100;
    int intStdBulletCountDownTimer = 0;

    private void Awake()
    {
        RenderTheBackground();//creates the background

        STDBallPicker();
        EnemyPicker(); //picks the right enemy for level
        PlayerPicker(); //picks the right player selected by Player

        CreatePowerUps(); //instantiate all powerups
        CreateSTDBullets(); //instantiate all STD Bullets

        intStdBulletDelayTime = 10 * intLevel;//set std bullet delay time

    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        intStdBulletCountDownTimer += 1; //countdown for std bullet
        if (intStdBulletCountDownTimer==intStdBulletDelayTime)
        {
            FireSTDBullet();
        }

        Debug.Log(intStdBulletCountDownTimer);

        Debug.Log("Bullet " + MySTDBullets[0].transform.position);
        Debug.Log("Enemy " + TheEnemy.transform.position);
    }

    void FireSTDBullet()
    {
        int RandomBulletIndex = Random.Range(0, TheSTDBullets.Length-1);

        TheSTDBullets[0].transform.position = TheEnemy.transform.position;
        UnProtectedSex.MoveStdBullet = true;
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
        ThePlayer=Instantiate(MyPlayer[1], MyPlayerPosition.position, MyPlayerPosition.rotation);//place the selected player at transform position 
    }

    void STDBallPicker()
    {
        TheSTDBall= Instantiate(MySTDBall[intLevel], MySTDBallPosition.position, MySTDBallPosition.rotation);//place the level's ball at transform position
    }

    void CreatePowerUps() //instantiate all powerups
    {
        ThePowerups[0]=Instantiate(MyPowerups[0], MyPowerupsPosition.position, MyPowerupsPosition.rotation);//place the level's powerups at transform position
        ThePowerups[1]=Instantiate(MyPowerups[1], MyPowerupsPosition.position*1.2f, MyPowerupsPosition.rotation);//place the level's powerups at transform position
        ThePowerups[2]=Instantiate(MyPowerups[2], MyPowerupsPosition.position*.7f, MyPowerupsPosition.rotation);//place the level's powerups at transform position
    }

    void CreateSTDBullets() //instantiate all STD Bullets
    {
        TheSTDBullets[0] = Instantiate(MySTDBullets[0], MySTDBulletsPosition.position, MySTDBulletsPosition.rotation);//place the level's std bullets at transform position
        TheSTDBullets[1]= Instantiate(MySTDBullets[1], MySTDBulletsPosition.position, MySTDBulletsPosition.rotation);//place the level's std bullets at transform position
    }

   
}
