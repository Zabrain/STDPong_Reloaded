using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizScript : MonoBehaviour {

    public Slider QuestionMeterSlider;
    float QuestionMeterValue;
    public Button TheYesButton;
    public Button TheNoButton;
    public Button ThePrevButton;
    public Text TheQuestion;
    public Text TheQuestionNumber;


    string[,] AIDSQuestions = new string [5,2];
    string[,] HIVQuestions = new string[5, 2];
    string[,] GonoQuestions = new string[5, 2];
    string[,] SyphilisQuestions = new string[5, 2];
    string[,] ChlamydiaQuestions = new string[5, 2];
    string[,] HerpesQuestions = new string[5, 2];
    string[,] TrichomoniasisQuestions = new string[5, 2];
    string[,] ScabiesQuestions = new string[5, 2];

    // Use this for initialization
    void Start () {
        QuestionMeterValue = 1;
        QuestionMeterSlider.value = QuestionMeterValue;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
