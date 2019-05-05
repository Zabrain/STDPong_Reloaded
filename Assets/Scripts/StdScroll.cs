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


    public GameObject LoadingPane;
    public GameObject ContentPane;

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
            ContentPane.SetActive(false);
            LoadingPane.SetActive(true);
            LoadingPane.GetComponent<LoaderSceneScript>().LoadSceneQuizGame(); //call the loader
            //SceneManager.LoadScene("QuizGame");
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
        else if (MainDirectorScript.strLevel == "Genital Warts")
        {
            AboutDetail.text = "Genital warts are one of the most common types of sexually transmitted infections caused by the human papillomavirus (HPV). Women are somewhat more likely than men to develop genital warts. As the name suggests, genital warts affect the moist tissues of the genital area. Genital warts may look like small, flesh-colored bumps or have a cauliflower - like appearance.In many cases, the warts are too small to be visible.";//about
            SymptomsDetail.text = "The signs and symptoms of genital warts include: Small, flesh - colored or gray swellings in your genital area. Several warts close together that take on a cauliflower-like shape. Itching or discomfort in your genital area, Bleeding with intercourse. Genital warts may be so small and flat that they can not be seen with the naked eye. Sometimes, however, genital warts may multiply into large clusters."; //symptoms
            TreatmentDetail.text = "Because it's often difficult to detect genital warts, your doctor may apply a mild acetic acid solution to your genitals to whiten any warts. Then, he or she may view them through a special magnifying instrument, a colposcope.";
            TestDetail.text = "If your warts aren't causing discomfort, you may not need treatment. But if your symptoms include itching, burning and pain, or if visible warts are causing emotional distress, your doctor can help you clear an outbreak with medications or surgery. However, the lesions are likely to come back after treatment. There is no treatment for the virus itself.";
        }
        else if (MainDirectorScript.strLevel == "Trichomoniasis")
        {
            AboutDetail.text = "Trichomoniasis is a sexually transmitted infection (STI) caused by the parasite Trichomonas vaginalis. Transmission includes penis-to-vagina, intercourse, or vulva-to-vulva contact. The parasite cannot survive in the mouth or rectum.";//about
            SymptomsDetail.text = "About half of all women experience no trichomoniasis symptoms.  Sometimes, frothy/yellow-green and unpleasant discharge, itching in and around the vagina, swelling in the groin, the urge to urinate frequently, pain during intercourse or urination"; //symptoms
            TreatmentDetail.text = "Medicine prescribed by a Medical Doctor";
            TestDetail.text = "Examination of the Pelvic region or a laboratory test of a sample of dischange from the private part";
        }
        else if (MainDirectorScript.strLevel == "Herpes")
        {
            AboutDetail.text = "Genital herpes is a common sexually transmitted infection caused by the herpes simplex virus (HSV). Sexual contact is the primary way that the virus spreads. After the initial infection, the virus lies dormant in your body and can reactivate several times a year.";//about
            SymptomsDetail.text = "Most people with genital herpes have little or no symptoms and they can go unnoticed. The most common herpes symptom is a cluster of blistery sores — usually on the vagina region, penis, buttocks, or anus. Symptoms may last several weeks and go away and may return in weeks, months, or years."; //symptoms
            TreatmentDetail.text = "There is no known cure but it can be managed with medicine at the hospital.";
            TestDetail.text = "The sores can be examined and fluids from the sores can be tested for the virus. Blood Sample can also be tested too.";
        }
        else if (MainDirectorScript.strLevel == "Chlamydia")
        {
            AboutDetail.text = " Chlamydia is a disease caused by the bacteria Chlamydia trachomatis. It is most commonly sexually transmitted.";//about
            SymptomsDetail.text = "Usually none!  Sometimes abdominal pain, abnormal discharge, fever, bleeding between periods, swollen or tender testicles, swelling around the anus, pain or burning while urinating, etc.  Can infect the eyes and throat as well."; //symptoms
            TreatmentDetail.text = "Oral antibiotics as prescribed by doctor, usually azithromycin (Zithromax) or doxycycline. ";
            TestDetail.text = "Cell samples or urine test can be used to test for Chlamydia.";
        }
        else if (MainDirectorScript.strLevel == "Syphilis")
        {
            AboutDetail.text = "Syphilis is a sexually transmitted infection (STI) caused by the bacterium Treponema pallidum.";//about
            SymptomsDetail.text = "Often, syphilis has no symptoms or has such mild symptoms that a person doesn’t notice them.  Primary Stage — A painless sore or open, wet ulcer, which is called a chancre, appears. Chancres can appear on the genitals, in the vagina, on the cervix, lips, mouth, breasts, or anus. Swollen glands may also occur during the primary phase.  Secondary Stage —Body rashes that last 2–6 weeks — often on the palms of the hands and the soles of the feet. There are many other symptoms, including mild fever, fatigue, sore throat, hair loss, weight loss, swollen glands, headache, and muscle pains.  Late Stage — One out of three people who have syphilis that is not treated suffer serious damage to the nervous system, heart, brain, or other organs, and death may result."; //symptoms
            TreatmentDetail.text = "When diagnosed and treated in its early stages, syphilis is easy to cure. The preferred treatment at all stages is penicillin, an antibiotic medication that can kill the organism that causes syphilis. If you're allergic to penicillin, your doctor will suggest another antibiotic.";
            TestDetail.text = "Test fluid from open sores or blood test";
        }
        else if (MainDirectorScript.strLevel == "Gonorrhea")
        {
            AboutDetail.text = "Gonorrhea (‘The Clap’) is caused by the bacteria Neisseria gonorrhoeae. The infection can be spread by contact with the mouth, vagina, penis, or anus.";//about
            SymptomsDetail.text = "Usually none!  Sometimes, abdominal pain, bleeding between periods, fever, painful intercourse, painful urination, pus-like discharge, throwing-up, swelling or tenderness of the vulva, anal itching, painful bowel movements.  Sometimes itching or soreness in the throat"; //symptoms
            TreatmentDetail.text = "Adults with gonorrhea are treated with antibiotics prescribed by a Doctor";
            TestDetail.text = "Cell samples, discharge samples, or urine samples";
        }
        else if (MainDirectorScript.strLevel == "Hepatitis B")
        {
            AboutDetail.text = "Hepatitis B is a serious liver infection caused by the hepatitis B virus (HBV). For some people, hepatitis B infection becomes chronic, meaning it lasts more than six months. Having chronic hepatitis B increases your risk of developing liver failure, liver cancer or cirrhosis — a condition that permanently scars of the liver..";//about
            SymptomsDetail.text = "Signs and symptoms of hepatitis B range from mild to severe. They usually appear about one to four months after you've been infected, although you could see them as early as two weeks post-infection. Some people, usually young children, may not have any symptoms. Hepatitis B signs and symptoms may include: Abdominal pain, Dark urine, Fever, Joint pain, Loss of appetite, Nausea and vomiting, Weakness and fatigue and Yellowing of your skin and the whites of your eyes(jaundice)"; //symptoms
            TreatmentDetail.text = "An injection of immunoglobulin (an antibody) given within 12 hours of exposure to the virus may help protect you from getting sick with hepatitis B. Because this treatment only provides short-term protection, you also should get the hepatitis B vaccine at the same time, if you never received it.";
            TestDetail.text = "Your doctor will examine you and look for signs of liver damage, such as yellowing skin or belly pain. Tests that can help diagnose hepatitis B or its complications are: Blood tests, Liver ultrasound, Liver biopsy.";
        }

        else if (MainDirectorScript.strLevel == "HIV")
        {
            AboutDetail.text = "HIV infection is a condition caused by the human immunodeficiency virus (HIV).";//about
            SymptomsDetail.text = "Some people develop HIV symptoms shortly after being infected, but it usually takes more than 10 years.  There are several stages of HIV disease. The first HIV symptoms may include swollen glands in the throat, armpit, or groin. Other early HIV symptoms include slight fever, headaches, fatigue, and muscle aches. These symptoms may last for only a few weeks. Then there are usually no HIV symptoms for many years. "; //symptoms
            TreatmentDetail.text = "There is no cure but it can be managed with medicine";
            TestDetail.text = "Blood test, oral swabs";
        }
        else if (MainDirectorScript.strLevel == "AIDS")
        {
            AboutDetail.text = "AIDS infection is a condition caused by the human immunodeficiency virus (HIV).";//about
            SymptomsDetail.text = "AIDS symptoms appear in the most advanced stage of HIV disease.  In addition to a badly damaged immune system, a person with AIDS may also have thrush, severe or recurring vaginal yeast infections, chronic pelvic inflammatory disease, tiredness, dizziness, headaches, rapid weight loss, bruising, severe and frequent infections, rashes, growths, shortness of breath and dry coughing, to name a few."; //symptoms
            TreatmentDetail.text = "There is no cure but it can be managed with medicine";
            TestDetail.text = "Blood test, oral swabs";
        }
        // { "Zero", "Scabies//", "Genital Warts","Herpes//","Trichomoniasis//","Hepatits B//", "Chlamydia//","Syphilis//", "Gonorrhea//", "HIV//", "AIDS//"};


    }

}
