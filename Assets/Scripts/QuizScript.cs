using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizScript : MonoBehaviour {

    public Slider QuestionMeterSlider;
    float QuestionMeterValue;
    public Button TheYesButton;
    public Button TheNoButton;
    public TextMeshProUGUI TheQuestionNumber;
    public TextMeshProUGUI TheQuestion;

    int CurrentQuestion;

    string[,] QuizQuestions = new string[5, 2];
    //string[,] AIDSQuestions = new string [5,2];
    //string[,] HIVQuestions = new string[5, 2];
    //string[,] GonoQuestions = new string[5, 2];
    //string[,] SyphilisQuestions = new string[5, 2];
    //string[,] ChlamydiaQuestions = new string[5, 2];
    //string[,] HerpesQuestions = new string[5, 2];
    //string[,] TrichomoniasisQuestions = new string[5, 2];
    //string[,] ScabiesQuestions = new string[5, 2];

    int intLevel = 1;//current level

    // Use this for initialization
    void Start () {
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

    public void YesButton_Click()
    {
        AnswerChecker("Yes"); //Check if yes is correct
        CurrentQuestion += 1;
        AttachQuestionAndNumber(); //attach question
    }

    public void NoButton_Click()
    {
        AnswerChecker("No"); //Check if No is correct
        CurrentQuestion += 1; //increase the question number
        AttachQuestionAndNumber(); //attach question
    }

    void AttachQuestionAndNumber() //attaches the question and its number to the text objects
    {
        if (CurrentQuestion < 5)
        {
            TheQuestionNumber.text = "Question " + (CurrentQuestion + 1).ToString() + " of 5"; //Load the question number
            TheQuestion.text = QuizQuestions[CurrentQuestion, 0].ToString();//Load the question
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

    void LoadQuestionArrays()
    {
        if (intLevel == 1)
        {
            QuizQuestions[0, 0] = "What a Gwan?";
            QuizQuestions[0, 1] = "No";
            QuizQuestions[1, 0] = "What 2 Gwan?";
            QuizQuestions[1, 1] = "Yes";
            QuizQuestions[2, 0] = "What 3 Gwan?";
            QuizQuestions[2, 1] = "No";
            QuizQuestions[3, 0] = "What 4 Gwan?";
            QuizQuestions[3, 1] = "No";
            QuizQuestions[4, 0] = "What 5 Gwan?";
            QuizQuestions[4, 1] = "Yes";
        }
        
    }

}
