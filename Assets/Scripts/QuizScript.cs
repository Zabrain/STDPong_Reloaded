using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizScript : MonoBehaviour {

    public GameObject EnemyDyingObject;
    public Sprite[] EnemySprites;
    public Transform EnemyDyingPosition;

    public Slider QuestionMeterSlider;
    float QuestionMeterValue;
    public Button TheAButton;
    public TextMeshProUGUI TheAText;
    public Button TheBButton;
    public TextMeshProUGUI TheBText;
    public Button TheCButton;
    public TextMeshProUGUI TheCText;
    public TextMeshProUGUI TheQuestionNumber;
    public TextMeshProUGUI TheQuestion;

    public GameObject QuestAndAnswerPanel;
    public bool MoveQuestOut = false;


    int CurrentQuestion;

    string[,] QuizQuestions = new string[5, 5];
    //string[,] AIDSQuestions = new string [5,2];
    //string[,] HIVQuestions = new string[5, 2];
    //string[,] GonoQuestions = new string[5, 2];
    //string[,] SyphilisQuestions = new string[5, 2];
    //string[,] ChlamydiaQuestions = new string[5, 2];
    //string[,] HerpesQuestions = new string[5, 2];
    //string[,] TrichomoniasisQuestions = new string[5, 2];
    //string[,] ScabiesQuestions = new string[5, 2];

    int intLevel;//current level

    // Use this for initialization
    void Start () {

        RenderTheEnemySprite();
        

        intLevel = MainDirectorScript.intLevel;//get the current level

        QuestionMeterValue = 1;
        QuestionMeterSlider.value = QuestionMeterValue; //value of the std meter

        CurrentQuestion = 0; //buffer for the current question

        LoadQuestionArrays(); //load the appropriate questions
        AttachQuestionAndNumber(); //attach question
    }
	
	// Update is called once per frame
	void Update () {
        

        QuestionMeterSlider.value = QuestionMeterValue; //value of the std meter
        

    }

    public void AButton_Click()
    {
        QuestAndAnswerPanel.GetComponent<Animator>().Play(0);//play animation of movement

        AnswerChecker(TheAText.text.Trim()); //Check if yes is correct
        CurrentQuestion += 1;
        AttachQuestionAndNumber(); //attach question
    }

    public void BButton_Click()
    {
        QuestAndAnswerPanel.GetComponent<Animator>().Play(0);//play animation of movement

        AnswerChecker(TheBText.text.Trim()); //Check if No is correct
        CurrentQuestion += 1; //increase the question number
        AttachQuestionAndNumber(); //attach question
    }

    public void CButton_Click()
    {
        QuestAndAnswerPanel.GetComponent<Animator>().Play(0);//play animation of movement

        AnswerChecker(TheCText.text.Trim()); //Check if No is correct
        CurrentQuestion += 1; //increase the question number
        AttachQuestionAndNumber(); //attach question
    }

    void AttachQuestionAndNumber() //attaches the question and its number to the text objects
    {
        if (CurrentQuestion < 5)
        {
            TheQuestionNumber.text = "Question " + (CurrentQuestion + 1).ToString() + " of 5"; //Load the question number
            TheQuestion.text = QuizQuestions[CurrentQuestion, 0].ToString();//Load the question
            TheAText.text = QuizQuestions[CurrentQuestion, 2].ToString();//Load the Options
            TheBText.text = QuizQuestions[CurrentQuestion, 3].ToString();//Load the Options
            TheCText.text = QuizQuestions[CurrentQuestion, 4].ToString();//Load the Options
        }
    }

    void AnswerChecker(string myAnswer) //check if answer is correct
    {
        if (CurrentQuestion < 5)
        {
            if (myAnswer == QuizQuestions[CurrentQuestion, 1])
            {
                QuestionMeterValue -= .20f; //if answer is correct reduce bar
            }
        }
          
    }

   

    void RenderTheEnemySprite()
    {
        SpriteRenderer EnemySpriteRenderer = EnemyDyingObject.GetComponent<SpriteRenderer>(); //grab the background's sprite renderer

        EnemySpriteRenderer.sprite = EnemySprites[intLevel]; //assign the appropriate sprite

        //SpriteRenderer sr = GetComponent<SpriteRenderer>();
        

        Vector2 scale = EnemyDyingObject.transform.localScale;
        EnemyDyingObject.transform.localScale = scale;
        EnemyDyingObject.transform.position = new Vector2(EnemyDyingPosition.position.x, EnemyDyingPosition.position.y);
        //EnemyDyingPosition.position; 
    }


    void LoadQuestionArrays()
    {
        if (MainDirectorScript.strLevel == "Scabies")
        {
            QuizQuestions[0, 0] = "Symptoms of scabies are most often found on body parts such as:";//Question 1
            QuizQuestions[0, 1] = "The elbow, armpit and genital region.";//Answer
            QuizQuestions[0, 2] = "The navel, forehead and back.";//Option
            QuizQuestions[0, 3] = "The elbow, armpit and genital region.";//Option
            QuizQuestions[0, 4] = "The knees, ears and nose.";//Option

            QuizQuestions[1, 0] = "Some sufferers of scabies will develop scabies rashes.";//Question 2
            QuizQuestions[1, 1] = "TRUE";//Answer
            QuizQuestions[1, 2] = "RARELY";//Option
            QuizQuestions[1, 3] = "FALSE";//Option
            QuizQuestions[1, 4] = "TRUE";//Option

            QuizQuestions[2, 0] = "Scabies typically develop within a week of infestation.";//Question 3
            QuizQuestions[2, 1] = "2 to 6 weeks";//Answer
            QuizQuestions[2, 2] = "2 to 6 weeks";//Option
            QuizQuestions[2, 3] = "1-3 days";//Option
            QuizQuestions[2, 4] = "Immediately";//Option

            QuizQuestions[3, 0] = "Is it possible to see Scabies mites?";//Question 4
            QuizQuestions[3, 1] = "Yes. With a microscope";//Answer
            QuizQuestions[3, 2] = "Yes. With my naked eyes";//Option
            QuizQuestions[3, 3] = "No. Impossible";//Option
            QuizQuestions[3, 4] = "Yes. With a microscope";//Option

            QuizQuestions[4, 0] = "Scabies can not be contracted by";//Question 4
            QuizQuestions[4, 1] = "Breathing the same air";//Answer
            QuizQuestions[4, 2] = "Hugging, close body contact and sharing clothing";//Option
            QuizQuestions[4, 3] = "Breathing the same air";//Option
            QuizQuestions[4, 4] = "Sexual Intercourse";//Option

        }

  //{  "Genital Warts", "Herpes", "Trichomoniasis", "Hepatits B", "Chlamydia", "Syphilis", "Gonorrhea", "HIV", "AIDS" };

    }

}
