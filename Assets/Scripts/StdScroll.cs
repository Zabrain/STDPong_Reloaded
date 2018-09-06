using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StdScroll : MonoBehaviour {

    public Image AboutPane;
    public TextMeshProUGUI AboutDetail;
    public Image SymptomsPane;
    public TextMeshProUGUI SymptomsDetail;
    public Image TreatmentPane;
    public TextMeshProUGUI TreatmentDetail;
    public Image TestPane;
    public TextMeshProUGUI TestDetail;

    public Transform OuttaPagePoint;//Point to transform panes to
    public Transform DefaultPoint;//Point to transform back to

    //public TextMeshProUGUI SubDetailHeader;

    string[] STDScrollDetails = new string [5];

    int intLevel=1;

    string NextToMove = ""; //become the moved page of scroll
    string[] PaneNames = new string[5];//names of the different std scroll panes
    int CurrentPane=0; //Pane index to move
    string BackOrPrevious = "None";

    // Use this for initialization
    void Start () {

        intLevel=PlayerPrefs.GetInt("PlayedBefore");

        //assign the pane names to the Pane Names Array
        PaneNames[0] = "None"; PaneNames[1] = "About"; PaneNames[2] = "Symptoms"; PaneNames[3] = "Test"; PaneNames[4] = "Treatment";
        NextToMove = PaneNames[CurrentPane]; //instantiate the moved pane holder
    }
	
	// Update is called once per frame
	void Update () {
		
        if (BackOrPrevious == "Back")
        {
            if (NextToMove == "About")
            {
                AboutPane.transform.position = Vector3.Lerp(AboutPane.transform.position, OuttaPagePoint.position, 5 * Time.deltaTime);
                //NextClicked = "";
            }
            else if (NextToMove == "Symptoms")
            {
                SymptomsPane.transform.position = Vector3.Lerp(SymptomsPane.transform.position, OuttaPagePoint.position, 5 * Time.deltaTime);
            }
            else if (NextToMove == "Test")
            {
                TestPane.transform.position = Vector3.Lerp(TestPane.transform.position, OuttaPagePoint.position, 5 * Time.deltaTime);
            }
            else if (NextToMove == "Treatment")
            {
                TreatmentPane.transform.position = Vector3.Lerp(TreatmentPane.transform.position, OuttaPagePoint.position, 5 * Time.deltaTime);
            }
        }
        else if (BackOrPrevious == "Previous")
        {
            if (NextToMove == "About")
            {
                AboutPane.transform.position = Vector3.Lerp(AboutPane.transform.position, DefaultPoint.position, 5 * Time.deltaTime);
                //NextClicked = "";
            }
            else if (NextToMove == "Symptoms")
            {
                SymptomsPane.transform.position = Vector3.Lerp(SymptomsPane.transform.position, DefaultPoint.position, 5 * Time.deltaTime);
            }
            else if (NextToMove == "Test")
            {
                TestPane.transform.position = Vector3.Lerp(TestPane.transform.position, DefaultPoint.position, 5 * Time.deltaTime);
            }
            else if (NextToMove == "Treatment")
            {
                TreatmentPane.transform.position = Vector3.Lerp(TreatmentPane.transform.position, DefaultPoint.position, 5 * Time.deltaTime);
            }
        }



    }

    void LoadStdScroll()
    {
        if (intLevel == 1)
        {
            STDScrollDetails[0] = "About!!!!!";


            //QuizQuestions[0, 0] = "What a Gwan?";
            //QuizQuestions[0, 1] = "No";
            //QuizQuestions[1, 0] = "What 2 Gwan?";
            //QuizQuestions[1, 1] = "Yes";
            //QuizQuestions[2, 0] = "What 3 Gwan?";
            //QuizQuestions[2, 1] = "No";
            //QuizQuestions[3, 0] = "What 4 Gwan?";
            //QuizQuestions[3, 1] = "No";
            //QuizQuestions[4, 0] = "What 5 Gwan?";
            //QuizQuestions[4, 1] = "Yes";
        }
    }


    public void TheNextButton()
    {
        if (CurrentPane >5)
        {
            CurrentPane += 1; //Get index of pane to move
            NextToMove = PaneNames[CurrentPane]; //assign the pane name
        }
        BackOrPrevious = "Back"; //Tell Update that back was clicked
    }

    public void ThePrevButton()
    {
        if (CurrentPane > -1)
        {
            NextToMove = PaneNames[CurrentPane]; //assign the pane name
            CurrentPane -= 1; //Get index of pane to move
        }
        BackOrPrevious = "Previous"; //Tell Update that back was clicked
    }

}
