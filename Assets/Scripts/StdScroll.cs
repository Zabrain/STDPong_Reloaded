using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StdScroll : MonoBehaviour {

    public TextMeshProUGUI PageHeaderSTD;

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

    string NextToMove = ""; //become the moved page of scroll
    string[] PaneNames = new string[5];//names of the different std scroll panes
    int CurrentPane=0; //Pane index to move
    string BackOrPrevious = "None";

    // Use this for initialization
    void Start () {

        MainDirectorScript.intLevel = PlayerPrefs.GetInt("PlayedBefore");

        LoadStdScroll();

        //assign the pane names to the Pane Names Array
        PaneNames[0] = "None"; PaneNames[1] = "About"; PaneNames[2] = "Symptoms"; PaneNames[3] = "Test"; PaneNames[4] = "Treatment";
        NextToMove = PaneNames[CurrentPane]; //instantiate the moved pane holder

        PageHeaderSTD.text=MainDirectorScript.strLevel +" Scroll";

        //GetComponent<StdBUllets>().enabled = false;
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
        if (MainDirectorScript.strLevel == "Scabies")
        {
            AboutDetail.text = "Scabies is a skin disease caused by a very small species of mite. Scabies is spread easily by skin-to-skin contact and unprotected sex.";//about
            SymptomsDetail.text = "Small bumps or rashes appearing in dirty-looking, small curling lines especially on the penis, breasts, the buttocks, thighs, around the belly button, wrists and in between the fingers."; //symptoms
            TreatmentDetail.text = "Medications such as Nix, Elimite, or Scabene.";
            TestDetail.text = "Your health care provider can examine a scraping from your skin with a microscope to see if you have scabies. Sometimes a biopsy, or skin sample, may be necessary";
        }
    }

    public void TheNextButton()
    {
        if (CurrentPane <=3)
        {
            CurrentPane += 1; //Get index of pane to move
            NextToMove = PaneNames[CurrentPane]; //assign the pane name
        }
        else
        {
            CurrentPane = 4;
        }
        BackOrPrevious = "Back"; //Tell Update that back was clicked
    }

    public void ThePrevButton()
    {
        if (CurrentPane >= 0)
        {
            NextToMove = PaneNames[CurrentPane]; //assign the pane name
            CurrentPane -= 1; //Get index of pane to move
        }
        else
        {
            CurrentPane = 0;
        }
        BackOrPrevious = "Previous"; //Tell Update that back was clicked
    }


    public void Continue_CLick()
    {
        SceneManager.LoadScene("QuizGame");
    }
}
