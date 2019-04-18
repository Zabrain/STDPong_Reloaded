using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreQuizScreen : MonoBehaviour
{
    public TextMeshProUGUI FirstlyLetsText;
    public GameObject AnswerAll5QuestObject;
    public Transform TransformIntroPositn;
    bool MoveIntro=false;


    public Sprite[] EnemySprites;
    public Image EnemyImage;
    
    int QuestionsAnswered;
    public Button TheAButton;
    public TextMeshProUGUI TheAText;
    public Button TheBButton;
    public TextMeshProUGUI TheBText;
    public Button TheCButton;
    public TextMeshProUGUI TheCText;
    public TextMeshProUGUI TheQuestionNumber;
    public TextMeshProUGUI TheQuestion;
    public TextMeshProUGUI STDNameText;

    public GameObject QuestAndAnswerPanel;
    public bool MoveQuestOut = false;

    public GameObject WinQuizPanel;
    public GameObject LoseQuizPanel;

    public GameObject LoadingPane;
    public GameObject MainQuizPane;

    int CurrentQuestion;

    string[,] QuizQuestions = new string[5, 6];
    //string[,] AIDSQuestions = new string [5,2];
    //string[,] HIVQuestions = new string[5, 2];
    //string[,] GonoQuestions = new string[5, 2];
    //string[,] SyphilisQuestions = new string[5, 2];
    //string[,] ChlamydiaQuestions = new string[5, 2];
    //string[,] HerpesQuestions = new string[5, 2];
    //string[,] TrichomoniasisQuestions = new string[5, 2];
    //string[,] ScabiesQuestions = new string[5, 2];

    int intLevel;//current level

    void Awake()
    {
        intLevel = MainDirectorScript.intLevel;//get the current level

        if (PlayerPrefs.GetInt(MainDirectorScript.LevelNames[intLevel] + "Pretest") != -1) //if pretest is done already
        {
            SceneManager.LoadScene("StdPongPlay");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        FirstlyLetsText.text = "Firstly, Let's Test Your Knowledge of "+ MainDirectorScript.strLevel; // on intro


        STDNameText.text = MainDirectorScript.strLevel;//load the name of the current std
          
        RenderTheEnemySprite();

        QuestionsAnswered = 0;

        CurrentQuestion = 0; //buffer for the current question

        LoadQuestionArrays(); //load the appropriate questions

        AttachQuestionAndNumber(); //attach question

        Debug.Log(PlayerPrefs.GetInt("ScabiesPretest"));
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveIntro == true) //move intro screen away
        {
            AnswerAll5QuestObject.transform.position = Vector2.Lerp(AnswerAll5QuestObject.transform.position, TransformIntroPositn.position, 5 * Time.deltaTime);
        }
    }

    public void NextTranspButton() //Changes boolen that moves the intro screen away
    {
        MoveIntro = true;
    }



    public void AButton_Click()
    {
        QuestAndAnswerPanel.GetComponent<Animator>().Play(0);//play animation of movement

        AnswerChecker(TheAText.text.Trim()); //Check if yes is correct
    }

    public void BButton_Click()
    {
        QuestAndAnswerPanel.GetComponent<Animator>().Play(0);//play animation of movement

        AnswerChecker(TheBText.text.Trim()); //Check if No is correct
    }

    public void CButton_Click()
    {
        QuestAndAnswerPanel.GetComponent<Animator>().Play(0);//play animation of movement

        AnswerChecker(TheCText.text.Trim()); //Check if No is correct
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
        if (CurrentQuestion < 4)
        {
            if (myAnswer == QuizQuestions[CurrentQuestion, 1]) //if answer is correct 
            {
                QuestionsAnswered += 1;
            }
            CurrentQuestion += 1; //Increase question number
            AttachQuestionAndNumber(); //Attache new question
        }
        else //Pretest Finish (Store value in database) !!!!!!!!!!!!!!!!DATA
        {
            PlayerPrefs.SetInt(MainDirectorScript.strLevel+"Pretest", QuestionsAnswered);
            SceneManager.LoadScene("StdPongPlay");
        }

    }
    
    void RenderTheEnemySprite()
    {
        EnemyImage.sprite = EnemySprites[intLevel];
    }

    
    void LoadQuestionArrays() //Make the changes in prequiz also
    {
        if (MainDirectorScript.strLevel == "Scabies")
        {
            QuizQuestions[0, 0] = "Symptoms of scabies are most often found on body parts such as:";//Question 1
            QuizQuestions[0, 1] = "The elbow, armpit and genital region.";//Answer
            QuizQuestions[0, 2] = "The navel, forehead and back.";//Option
            QuizQuestions[0, 3] = "The elbow, armpit and genital region.";//Option
            QuizQuestions[0, 4] = "The knees, ears and nose.";//Option
            QuizQuestions[0, 5] = "The symptoms can affect nearly any part of the body but are most common on the wrist, elbow, armpit, penis, nipple, waist, buttocks and between the fingers.";//Explained Answer

            QuizQuestions[1, 0] = "Some sufferers of scabies will develop rashes.";//Question 2
            QuizQuestions[1, 1] = "TRUE";//Answer
            QuizQuestions[1, 2] = "RARELY";//Option
            QuizQuestions[1, 3] = "FALSE";//Option
            QuizQuestions[1, 4] = "TRUE";//Option
            QuizQuestions[1, 5] = "Rash: infected skin becomes itchy, irritated, warm, reddened and blistered. Skin irritation is more likely to be seen in the webbing between the fingers and toes, in the folds of the elbow, armpit, belt-line, abdomen, groin and in the genital area.";//Explained Answer

            QuizQuestions[2, 0] = "Scabies typically develop within a week of infestation.";//Question 3
            QuizQuestions[2, 1] = "2 to 6 weeks";//Answer
            QuizQuestions[2, 2] = "2 to 6 weeks";//Option
            QuizQuestions[2, 3] = "1-3 days";//Option
            QuizQuestions[2, 4] = "Immediately";//Option
            QuizQuestions[2, 5] = "Scabies don't develop for several weeks which often causes the symptoms to be severe by the time they're treated.";//Explained Answer

            QuizQuestions[3, 0] = "Is it possible to see Scabies mites?";//Question 4
            QuizQuestions[3, 1] = "Yes. With a microscope";//Answer
            QuizQuestions[3, 2] = "Yes. With my naked eyes";//Option
            QuizQuestions[3, 3] = "No. Impossible";//Option
            QuizQuestions[3, 4] = "Yes. With a microscope";//Option
            QuizQuestions[3, 5] = "To get scabies you have to have prolonged, physical contact with someone who is already infected but that can include sharing articles of clothing or bedding.";//Explained Answer

            QuizQuestions[4, 0] = "Scabies can not be contracted by";//Question 4
            QuizQuestions[4, 1] = "Breathing the same air";//Answer
            QuizQuestions[4, 2] = "Hugging, close body contact and sharing clothing";//Option
            QuizQuestions[4, 3] = "Breathing the same air";//Option
            QuizQuestions[4, 4] = "Sexual Intercourse";//Option
            QuizQuestions[4, 5] = "Direct, prolonged skin-to-skin or close bodily contact. Infestation may also occur by contact with infested clothing, bedding etc.";//Explained Answer

        }

        else if (MainDirectorScript.strLevel == "Genital Warts")
        {
            QuizQuestions[0, 0] = "Which of these ailments is not associated with Genital Warts?";//Question 1
            QuizQuestions[0, 1] = "Chicken Pox";//Answer
            QuizQuestions[0, 2] = "Cervical cancer";//Option
            QuizQuestions[0, 3] = "Chicken Pox";//Option
            QuizQuestions[0, 4] = "Penis cancer";//Option
            QuizQuestions[0, 5] = "In women, the cancer most closely associated with genital warts and HPV is cervical cancer while The type of cancer most closely associated with genital warts and HPV among men is cancer of the penis. This is a very rare form of cancer.";//Explained Answer

            QuizQuestions[1, 0] = "Genital warts cannot be spread by:";//Question 2
            QuizQuestions[1, 1] = "Sharing a toilet seat";//Answer
            QuizQuestions[1, 2] = "Sexual contact";//Option
            QuizQuestions[1, 3] = "Genital rubbing";//Option
            QuizQuestions[1, 4] = "Sharing a toilet seat";//Option
            QuizQuestions[1, 5] = "Genital warts or the HPV virus cannot be spread by sharing a toilet seat.";//Explained Answer

            QuizQuestions[2, 0] = "Which of these tests is recommended to find Genital Warts in women:";//Question 3
            QuizQuestions[2, 1] = "Pap test";//Answer
            QuizQuestions[2, 2] = "Menstrual test";//Option
            QuizQuestions[2, 3] = "Pregnancy test";//Option
            QuizQuestions[2, 4] = "Pap test";//Option
            QuizQuestions[2, 5] = "The test used to determine if a woman has genital warts or the HPV virus in the cervical area is the Pap test. In this test, the doctor or nurse, takes a small sample of the cervix (opening to the womb) and sends it to a lab. This test can help find cervical cancer early so it can be treated. A pap test should be done regularly, once or twice a year.";//Explained Answer

            QuizQuestions[3, 0] = "Which of these cannot cause the infection of Genital Warts?";//Question 4
            QuizQuestions[3, 1] = "Kissing";//Answer
            QuizQuestions[3, 2] = "Kissing";//Option
            QuizQuestions[3, 3] = "Vaginal sex, oral sex";//Option
            QuizQuestions[3, 4] = "Anal sex";//Option
            QuizQuestions[3, 5] = "HPV is spread through any kind of genital contact. That means vaginal sex, oral sex, anal sex, or genital-on-genital touching. HPV also can be spread through opposite-sex or same-sex partners.";//Explained Answer

            QuizQuestions[4, 0] = "Which of these does not reduce your chances of contracting Genital Warts?";//Question 4
            QuizQuestions[4, 1] = "Washing genital after sex";//Answer
            QuizQuestions[4, 2] = "Abstinence from Sex";//Option
            QuizQuestions[4, 3] = "The use of condoms";//Option
            QuizQuestions[4, 4] = "Washing genital after sex";//Option
            QuizQuestions[4, 5] = "Latex condoms may lower your chances of getting or spreading HPV if you use them correctly during every sex act from beginning to end. You also can protect yourself by limiting the number of sex partners you have. And the HPV vaccine can help prevent some types of HPV that lead to cervical cancer and genital warts.";//Explained Answer

        }

        else if (MainDirectorScript.strLevel == "Herpes")
        {
            QuizQuestions[0, 0] = "Which of the following is not a symptom of Genital herpes?";//Question 1
            QuizQuestions[0, 1] = "Red eyes and nose bleeding";//Answer
            QuizQuestions[0, 2] = "Red eyes and nose bleeding";//Option
            QuizQuestions[0, 3] = "Pain or itching in genital area";//Option
            QuizQuestions[0, 4] = "Small red bumps or tiny white blisters in genital area";//Option
            QuizQuestions[0, 5] = "The infection is more easily transmitted from men to women than from women to men. For example, About one in five women in the US have genital herpes caused by HSV-2, while about one in nine men are infected.";//Explained Answer

            QuizQuestions[1, 0] = "Herpes can be cured by taking antibiotics";//Question 2
            QuizQuestions[1, 1] = "False";//Answer
            QuizQuestions[1, 2] = "True, only at the early stages";//Option
            QuizQuestions[1, 3] = "False";//Option
            QuizQuestions[1, 4] = "True";//Option
            QuizQuestions[1, 5] = "Genital herpes is caused by a virus, so antibiotics will not help resolve the infection. There is no cure for herpes, but treatment is available to reduce and prevent outbreaks and decrease the risk of transmission to a partner.";//Explained Answer

            QuizQuestions[2, 0] = "Washing the genital area before and after sex can help prevent the transmission of genital herpes.";//Question 3
            QuizQuestions[2, 1] = "False";//Answer
            QuizQuestions[2, 2] = "False";//Option
            QuizQuestions[2, 3] = "True";//Option
            QuizQuestions[2, 4] = "Only if it is washed well with disinfectants";//Option
            QuizQuestions[2, 5] = "Washing the genital area doesn’t help prevent any sexually transmitted disease (STD), including genital herpes. The best way to prevent any STD is to abstain from sex or engage in sex only with someone you know is not infected. Condoms are not guaranteed to prevent infection, but research has shown that they provide some protection.";//Explained Answer

            QuizQuestions[3, 0] = "A pregnant woman can give herpes to her unborn baby.";//Question 4
            QuizQuestions[3, 1] = "True";//Answer
            QuizQuestions[3, 2] = "I don’t know";//Option
            QuizQuestions[3, 3] = "False";//Option
            QuizQuestions[3, 4] = "True";//Option
            QuizQuestions[3, 5] = "If a woman had genital herpes before getting pregnant, her baby may be infected but the chance is very low -- less than 1%. However, the risk of infecting the baby is much higher (25% to 50%) when a woman is newly infected late in pregnancy.";//Explained Answer

            QuizQuestions[4, 0] = "Which of the following ways can be used to determine if a person has Herpes?";//Question 4
            QuizQuestions[4, 1] = "Blood Test";//Answer
            QuizQuestions[4, 2] = "Urine Test";//Option
            QuizQuestions[4, 3] = "Blood Test";//Option
            QuizQuestions[4, 4] = "Sweat test";//Option
            QuizQuestions[4, 5] = "To find out if you have genital herpes, a doctor can take a sample from a sore and test it in the laboratory. There is also a blood test that looks for antibodies to the virus that your immune system would have made. HSV-2 almost always infects the genitals, so if antibodies to HSV-2 are detected in your blood, you probably have genital herpes.";//Explained Answer

        }

        else if (MainDirectorScript.strLevel == "Trichomoniasis")
        {
            QuizQuestions[0, 0] = "Which of these is a symptom of Trichomoniasis?";//Question 1
            QuizQuestions[0, 1] = "Foul-smelling vaginal discharge and genital burning or itching";//Answer
            QuizQuestions[0, 2] = "Rashes in armpit";//Option
            QuizQuestions[0, 3] = "Foul-smelling vaginal discharge and genital burning or itching";//Option
            QuizQuestions[0, 4] = "Sores behind the ear";//Option
            QuizQuestions[0, 5] = "Women usually experience frothy and foul-smelling vaginal discharge, genital burning or itching, genital redness or swelling, vaginal spotting or bleeding, discomfort during urination or sexual intercourse and an increased urge to urinate.";//Explained Answer

            QuizQuestions[1, 0] = "Trichomoniasis can be transferred through the following except:";//Question 2
            QuizQuestions[1, 1] = "Saliva and Sweat";//Answer
            QuizQuestions[1, 2] = "Vaginal Sex";//Option
            QuizQuestions[1, 3] = "Anal Sex";//Option
            QuizQuestions[1, 4] = "Saliva and Sweat";//Option
            QuizQuestions[1, 5] = "You cannot get trichomoniasis without having sex, since this is the only way the trichomoniasis parasite is spread from one person to another.";//Explained Answer

            QuizQuestions[2, 0] = "Is Trichimoniasis a Curable disease?";//Question 3
            QuizQuestions[2, 1] = "Yes";//Answer
            QuizQuestions[2, 2] = "I don’t know";//Option
            QuizQuestions[2, 3] = "No";//Option
            QuizQuestions[2, 4] = "Yes";//Option
            QuizQuestions[2, 5] = "Yes. However, antibiotics are typically prescribed to trichomoniasis patients, which could spell disaster for your long-term health. If you or someone you know is diagnosed with trichomoniasis, it’s best to utilize natural treatments such as tea tree oil, garlic and turmeric.";//Explained Answer

            QuizQuestions[3, 0] = "Can you get trichomoniasis from oral sex?";//Question 4
            QuizQuestions[3, 1] = "No";//Answer
            QuizQuestions[3, 2] = "I don’t know";//Option
            QuizQuestions[3, 3] = "No";//Option
            QuizQuestions[3, 4] = "Yes";//Option
            QuizQuestions[3, 5] = "No. You cannot be infected with trichomoniasis if you have oral or anal sex, as the parasite is spread by genital contact from a vagina to a penis (and vice versa) or from a vagina to another vagina.";//Explained Answer

            QuizQuestions[4, 0] = "Trichomoniasis makes it easier to contract HIV";//Question 4
            QuizQuestions[4, 1] = "Yes";//Answer
            QuizQuestions[4, 2] = "Yes";//Option
            QuizQuestions[4, 3] = "No";//Option
            QuizQuestions[4, 4] = "I don’t know";//Option
            QuizQuestions[4, 5] = "Trichomoniasis can increase the risk of getting or spreading other sexually transmitted infections. For example, trichomoniasis can cause genital inflammation that makes it easier to get infected with the HIV virus, or to pass the HIV virus on to a sex partner.";//Explained Answer

        }

        else if (MainDirectorScript.strLevel == "Hepatits B")
        {
            QuizQuestions[0, 0] = "Hepatitis B can be transmitted from mother to baby at birth?";//Question 1
            QuizQuestions[0, 1] = "Yes. It can be transferred.";//Answer
            QuizQuestions[0, 2] = "Yes. It can be transferred.";//Option
            QuizQuestions[0, 3] = "Impossible";//Option
            QuizQuestions[0, 4] = "Only, If the baby drinks an infected mother’s breast milk";//Option
            QuizQuestions[0, 5] = "Hepatitis B is most commonly spread from mother to child at birth (perinatal transmission), or through horizontal transmission (exposure to infected blood), especially from an infected child to an uninfected child during the first 5 years of life.";//Explained Answer

            QuizQuestions[1, 0] = "Which of these cannot cause a hepatitis B virus infection?";//Question 2
            QuizQuestions[1, 1] = "Through contact with sweat of an infected person.";//Answer
            QuizQuestions[1, 2] = "Through contact with saliva, vaginal or menstrual fluid of an infected person.";//Option
            QuizQuestions[1, 3] = "Through contact with sweat of an infected person.";//Option
            QuizQuestions[1, 4] = "Through contact with blood of an infected person";//Option
            QuizQuestions[1, 5] = "Hepatitis B is also spread by exposure to infected blood and various body fluids, as well as through saliva, menstrual, vaginal, and seminal fluids.";//Explained Answer

            QuizQuestions[2, 0] = "Which of these actions can protect one against Hepatitis B?";//Question 3
            QuizQuestions[2, 1] = "Hepatitis B vaccination";//Answer
            QuizQuestions[2, 2] = "Hepatitis B vaccination";//Option
            QuizQuestions[2, 3] = "Drinking local roadside herbs";//Option
            QuizQuestions[2, 4] = "Eating vegetables";//Option
            QuizQuestions[2, 5] = "The hepatitis B vaccine stimulates your natural immune system to protect against the hepatitis B virus. After the vaccine is given, your body makes antibodies that protect you against the virus. An antibody is a substance found in the blood that is produced in response to a virus invading the body. These antibodies will fight off the infection if a person is exposed to the hepatitis B virus in the future.";//Explained Answer

            QuizQuestions[3, 0] = "Which of the following is/are symptoms of Hepatitis B?";//Question 4
            QuizQuestions[3, 1] = "Yellowing of the skin and eyes, dark urine, extreme fatigue";//Answer
            QuizQuestions[3, 2] = "Yellowing of the skin and eyes, dark urine, extreme fatigue";//Option
            QuizQuestions[3, 3] = "Swollen stomach and fingers";//Option
            QuizQuestions[3, 4] = "Rashes on the private part and armpits";//Option
            QuizQuestions[3, 5] = "Most people do not experience any symptoms during the acute infection phase. However, some people have acute illness with symptoms that last several weeks, including yellowing of the skin and eyes (jaundice), dark urine, extreme fatigue, nausea, vomiting and abdominal pain. A small subset of persons with acute hepatitis can develop acute liver failure, which can lead to death.";//Explained Answer

            QuizQuestions[4, 0] = "What is the recommended full dose of hepatitis B vaccine?";//Question 4
            QuizQuestions[4, 1] = "3 or more doses";//Answer
            QuizQuestions[4, 2] = "1 dose";//Option
            QuizQuestions[4, 3] = "3 or more doses";//Option
            QuizQuestions[4, 4] = "2 doses";//Option
            QuizQuestions[4, 5] = "Transmission of the virus may also occur through the reuse of needles and syringes either in health-care settings or among persons who inject drugs. In addition, infection can occur during medical, surgical and dental procedures, through tattooing, or using razors and similar objects that are contaminated with infected blood.";//Explained Answer

        }

        else if (MainDirectorScript.strLevel == "Chlamydia")
        {
            QuizQuestions[0, 0] = "The most effective way to avoid getting chlamydia is:";//Question 1
            QuizQuestions[0, 1] = "Abstinence";//Answer
            QuizQuestions[0, 2] = "Condoms";//Option
            QuizQuestions[0, 3] = "Abstinence";//Option
            QuizQuestions[0, 4] = "Douching or washing genitals after sex";//Option
            QuizQuestions[0, 5] = "Abstinence (not having sex) is the best way to avoid getting chlamydia or any STD. Having sex with only one partner who you know is uninfected and who only has sex with you is also safe as long as you both are faithful. Latex condoms can reduce the risk of getting chlamydia, although they are not perfect. Douching after sex can be harmful; it is certainly not a good method for preventing disease. Finally, 'knowing your partner really well' doesn't help you avoid disease. He or she might not even be aware of having chlamydia or another STD, because the diseases often have no symptoms. Your partner may be very honest in saying he or she believes to be free from disease. Unless you know that he or she has had medical tests showing no diseases, he or she is not guaranteed to be a safe partner.";//Explained Answer

            QuizQuestions[1, 0] = "Chlamydia can cause one of the following";//Question 2
            QuizQuestions[1, 1] = "Blindness";//Answer
            QuizQuestions[1, 2] = "AIDS";//Option
            QuizQuestions[1, 3] = "Tuberculosis";//Option
            QuizQuestions[1, 4] = "Blindness";//Option
            QuizQuestions[1, 5] = "Chlamydia is a known cause of blindness among humans";//Explained Answer

            QuizQuestions[2, 0] = "Chlamydia can be tested by:";//Question 3
            QuizQuestions[2, 1] = "Urine Test";//Answer
            QuizQuestions[2, 2] = "Thorough Skin test, like the test for tuberculosis";//Option
            QuizQuestions[2, 3] = "Urine Test";//Option
            QuizQuestions[2, 4] = "There is no test available for chlamydia";//Option
            QuizQuestions[2, 5] = "Urine tests may be used to determine the presence of a chlamydia infection; these tests typically take several days before results are ready from a laboratory. The other method of screening for chlamydia involves swabbing a cell sample from the vagina and sending the sample to a laboratory for examination.";//Explained Answer

            QuizQuestions[3, 0] = "Chlamydia often has no symptoms. If symptoms exist at all, which of these is not likely to occur?";//Question 4
            QuizQuestions[3, 1] = "Sores in the genital area";//Answer
            QuizQuestions[3, 2] = "Abnormal discharge from vagina or penis";//Option
            QuizQuestions[3, 3] = "Pain when urinating";//Option
            QuizQuestions[3, 4] = "Sores in the genital area";//Option
            QuizQuestions[3, 5] = "Chlamydia does not cause any sores in the genital area or anywhere else. When chlamydia has any symptoms, they can include pain when urinating, abnormal discharge from vagina or penis, and tenderness in the testicles. More advanced cases of chlamydia in women may also cause lower abdominal pain, bleeding between menstrual periods (spotting), pain during sex, fever and chills, and nausea. More advanced cases of chlamydia in men may also cause swelling of one or both testicles..";//Explained Answer

            QuizQuestions[4, 0] = "The use of condoms reduces the risk of Chlamydia infection.";//Question 4
            QuizQuestions[4, 1] = "Yes";//Answer
            QuizQuestions[4, 2] = "No. It can be gotten by sharing the same plate and cups.";//Option
            QuizQuestions[4, 3] = "Yes";//Option
            QuizQuestions[4, 4] = "No. It can also be gotten through touch.";//Option
            QuizQuestions[4, 5] = "As with most STDs, the use of condoms during sex can reduce the risk of HIV transfer.";//Explained Answer

        }

        else if (MainDirectorScript.strLevel == "Syphilis")
        {
            QuizQuestions[0, 0] = "Which of the following may be a sign of a primary Syphilis infection?";//Question 1
            QuizQuestions[0, 1] = "A Painless sore in the genital area";//Answer
            QuizQuestions[0, 2] = "Painful sore on the back of the neck.";//Option
            QuizQuestions[0, 3] = "A painful sore on the genital area.";//Option
            QuizQuestions[0, 4] = "A Painless sore in the genital area";//Option
            QuizQuestions[0, 5] = "The early stages of Syphilis infection is characterised with a Painless sore in the genital area";//Explained Answer

            QuizQuestions[1, 0] = "How is a person tested for Syphilis?";//Question 2
            QuizQuestions[1, 1] = "A blood test.";//Answer
            QuizQuestions[1, 2] = "A urine test.";//Option
            QuizQuestions[1, 3] = "A blood test";//Option
            QuizQuestions[1, 4] = "There is no test; a doctor needs to visibly see a sore or rash to diagnose Syphilis.";//Option
            QuizQuestions[1, 5] = "Syphilis is tested through a simple blood test.";//Explained Answer

            QuizQuestions[2, 0] = "Syphilis can be gotten through Anal Sex?";//Question 3
            QuizQuestions[2, 1] = "True";//Answer
            QuizQuestions[2, 2] = "False";//Option
            QuizQuestions[2, 3] = "I don’t know.";//Option
            QuizQuestions[2, 4] = "True";//Option
            QuizQuestions[2, 5] = "Syphilis is a highly contagious disease spread primarily by sexual activity, including oral and anal sex.";//Explained Answer

            QuizQuestions[3, 0] = "Using condoms/dental dams/gloves during intercourse guarantees that Syphilis will not be transmitted?";//Question 4
            QuizQuestions[3, 1] = "No. They don’t completely reduce the risks.";//Answer
            QuizQuestions[3, 2] = "Yes. The completely guarantee protectionfrom Syphilis";//Option
            QuizQuestions[3, 3] = "No. They don’t completely reduce the risks.";//Option
            QuizQuestions[3, 4] = "I don’t know.";//Option
            QuizQuestions[3, 5] = "Using these tools does significantly reduce the risks involved, but because syphilis sores can be located on the outside of the body, the skin-skin contact that may occur even with these tools creates a situation where it is still possible for Syphilis to be transmitted.";//Explained Answer

            QuizQuestions[4, 0] = "Can syphilis be transferred to a baby during pregnancy?";//Question 4
            QuizQuestions[4, 1] = "Yes. It can.";//Answer
            QuizQuestions[4, 2] = "I do not know";//Option
            QuizQuestions[4, 3] = "Yes. It can.";//Option
            QuizQuestions[4, 4] = "Impossible";//Option
            QuizQuestions[4, 5] = "Yes. Congenital syphilis (CS) is a disease that occurs when a mother with syphilis passes the infection on to her baby during pregnancy.";//Explained Answer

        }

        else if (MainDirectorScript.strLevel == "Gonorrhea")
        {
            QuizQuestions[0, 0] = "Which of these signs is not experienced by people infected with Gonorrhea?";//Question 1
            QuizQuestions[0, 1] = "Chancre or sores";//Answer
            QuizQuestions[0, 2] = "Chancre or sores";//Option
            QuizQuestions[0, 3] = "Pain or burning sensation during urination";//Option
            QuizQuestions[0, 4] = "Creamy or green (similar to pus) discharge from penis, and pain in testicles";//Option
            QuizQuestions[0, 5] = "Chancre or sores. - Chancre or sores experienced by a person infected with syphilis. Symptoms due to gonorrhea experienced by men are: pain or burning sensation during urination, creamy or green (similar to pus) discharge from penis, and pain in testicles.";//Explained Answer

            QuizQuestions[1, 0] = "Gonorrhea cannot be spread by:";//Question 2
            QuizQuestions[1, 1] = "Kissing and sharing a toilet";//Answer
            QuizQuestions[1, 2] = "Anal sexual contact.";//Option
            QuizQuestions[1, 3] = "Vaginal sexual contact";//Option
            QuizQuestions[1, 4] = "Kissing and sharing a toilet";//Option
            QuizQuestions[1, 5] = "Gonorrhea can only be spread through sexual contact";//Explained Answer

            QuizQuestions[2, 0] = "If a person is diagnosed with gonorrhea, he or she might be at-risk of:";//Question 3
            QuizQuestions[2, 1] = "HIV";//Answer
            QuizQuestions[2, 2] = "Herpes";//Option
            QuizQuestions[2, 3] = "HIV.";//Option
            QuizQuestions[2, 4] = "Syphilis";//Option
            QuizQuestions[2, 5] = "HIV/AIDS - Persons infected with gonorrhea are at increased risk of HIV.";//Explained Answer

            QuizQuestions[3, 0] = "Which of these practices does not reduce the risk of contacting Gonorrhea?";//Question 4
            QuizQuestions[3, 1] = "Washing genitals after sex";//Answer
            QuizQuestions[3, 2] = "Washing genitals after sex";//Option
            QuizQuestions[3, 3] = "The use of condoms";//Option
            QuizQuestions[3, 4] = "Abstinence";//Option
            QuizQuestions[3, 5] = "The 100% surest way to avoid getting a sexually transmitted disease. - Abstinence the 100% surest way to avoid getting a sexually transmitted disease by sexual contact.";//Explained Answer

            QuizQuestions[4, 0] = " The common name used for gonorrhea is:";//Question 4
            QuizQuestions[4, 1] = "The Clap";//Answer
            QuizQuestions[4, 2] = "The clam";//Option
            QuizQuestions[4, 3] = "The clan";//Option
            QuizQuestions[4, 4] = "The Clap";//Option
            QuizQuestions[4, 5] = "The clap - The common name used to refer to gonorrhea is the clap.";//Explained Answer

        }

        else if (MainDirectorScript.strLevel == "HIV")
        {
            QuizQuestions[0, 0] = "What is the full Meaning of HIV?";//Question 1
            QuizQuestions[0, 1] = "Human Immunodeficiency Virus";//Answer
            QuizQuestions[0, 2] = "Human Infection Virus";//Option
            QuizQuestions[0, 3] = "Human Immunodeficiency Virus";//Option
            QuizQuestions[0, 4] = "Human Intravenous Virus";//Option
            QuizQuestions[0, 5] = "HIV = Human Immunodeficiency Virus";//Explained Answer

            QuizQuestions[1, 0] = "Which of these is a reliable way of knowing if you have HIV?";//Question 2
            QuizQuestions[1, 1] = "Taking an HIV test";//Answer
            QuizQuestions[1, 2] = "Taking an HIV test";//Option
            QuizQuestions[1, 3] = "Researching the symptoms online to see if you have any of them";//Option
            QuizQuestions[1, 4] = "Asking the people you have sex with if they have HIV";//Option
            QuizQuestions[1, 5] = "Well done - testing for HIV is the only way to know for sure if you have it. Feeling sick or having had unprotected sex with someone living with HIV are both good reasons to go for a test, but neither is a way of knowing your status for sure. Not everyone will get symptoms, and if you wait around for them you might damage your immune system.";//Explained Answer

            QuizQuestions[2, 0] = "If you have taken an HIV test already, then you don't need to do it ever again.";//Question 3
            QuizQuestions[2, 1] = "False";//Answer
            QuizQuestions[2, 2] = "Take it only when you notice a symptom";//Option
            QuizQuestions[2, 3] = "True.";//Option
            QuizQuestions[2, 4] = "False";//Option
            QuizQuestions[2, 5] = "False. It is important that you keep your test results up to date. This means getting tested regularly, especially if you have had unprotected sex.";//Explained Answer

            QuizQuestions[3, 0] = "When you get a test, the healthcare professional will share your result with:";//Question 4
            QuizQuestions[3, 1] = "Nobody, your results will remain a secret";//Answer
            QuizQuestions[3, 2] = "Your family/friends, so that they can look after you";//Option
            QuizQuestions[3, 3] = "Your sexual partners, so that they can get tested too.";//Option
            QuizQuestions[3, 4] = "Nobody, your results will remain a secret";//Option
            QuizQuestions[3, 5] = "HIV tests are confidential. No-one will know your results unless YOU decide to tell them.";//Explained Answer

            QuizQuestions[4, 0] = "Which of the following doesn't contain HIV?";//Question 4
            QuizQuestions[4, 1] = "Sweat";//Answer
            QuizQuestions[4, 2] = "Blood";//Option
            QuizQuestions[4, 3] = "Sweat";//Option
            QuizQuestions[4, 4] = "Breastmilk";//Option
            QuizQuestions[4, 5] = "HIV is not present in sweat. So the virus cannot be transmitted through skin to skin contact - for example by touching or hugging.";//Explained Answer

        }


        else if (MainDirectorScript.strLevel == "AIDS")
        {
            QuizQuestions[0, 0] = "What is the full Meaning of AIDS?";//Question 1
            QuizQuestions[0, 1] = "Acquired Immune Deficiency Syndrome";//Answer
            QuizQuestions[0, 2] = "Acquired Immune Deficiency Syndrome";//Option
            QuizQuestions[0, 3] = "Assisted Induced Development Syndrome";//Option
            QuizQuestions[0, 4] = "Acquired Intravenous Decreasing Syndrome";//Option
            QuizQuestions[0, 5] = "AIDS = Acquired Immune Deficiency Syndrome";//Explained Answer

            QuizQuestions[1, 0] = "What does HIV/AIDS treatment do?";//Question 2
            QuizQuestions[1, 1] = "Enable you to live just as long and as well as people who don't have HIV";//Answer
            QuizQuestions[1, 2] = "Cure HIV";//Option
            QuizQuestions[1, 3] = "Improve but not lengthen your life";//Option
            QuizQuestions[1, 4] = "Enable you to live just as long and as well as people who don't have HIV";//Option
            QuizQuestions[1, 5] = "Treatment these days is so effective that people living with HIV can live just as long as everyone else. It also keeps you healthy so that you can carry on living your life as normal. However, it still isn't a cure, as antiretroviral medicines aren't able to completely remove the virus from your body.";//Explained Answer

            QuizQuestions[2, 0] = "Do all people with HIV have AIDS?";//Question 3
            QuizQuestions[2, 1] = "No";//Answer
            QuizQuestions[2, 2] = "Yes";//Option
            QuizQuestions[2, 3] = "No";//Option
            QuizQuestions[2, 4] = "I do not know";//Option
            QuizQuestions[2, 5] = "HIV is the Human Immunodeficiency Virus. AIDS, which stands for Acquired Immunodeficiency Syndrome, is a condition that occurs when HIV comprises the immune system. With proper medical treatment, a person living with HIV can prevent the development of AIDS.";//Explained Answer

            QuizQuestions[3, 0] = "Only gay and bisexual men contract HIV through sex.";//Question 4
            QuizQuestions[3, 1] = "False";//Answer
            QuizQuestions[3, 2] = "False";//Option
            QuizQuestions[3, 3] = "True";//Option
            QuizQuestions[3, 4] = "Only Gay men";//Option
            QuizQuestions[3, 5] = "Absolutely anyone can contract HIV through unprotected sexual activity. Millions of women and straight males have contracted HIV through sexual activity. Everyone has a responsibility to protect themselves";//Explained Answer

            QuizQuestions[4, 0] = "Is there a known cure for AIDS?";//Question 4
            QuizQuestions[4, 1] = "No. But it can be controlled with anti-retroviral drugs";//Answer
            QuizQuestions[4, 2] = "Yes, It can leave the body on it’s own.";//Option
            QuizQuestions[4, 3] = "Yes. With herbs and fruit.";//Option
            QuizQuestions[4, 4] = "No. But it can be controlled with anti-retroviral drugs";//Option
            QuizQuestions[4, 5] = "There is no cure for HIV and AIDS yet. However, treatment can control HIV and enable people to live a long and healthy life. If you think you’ve been at risk of HIV, it's important to get tested to find out your HIV status. Testing is the only way to know if you have the virus. If you’ve already been for a test and your result came back positive, you will be advised to start treatment straight away.";//Explained Answer

        }
        //{  "Genital Warts//", "Herpes//", "Trichomoniasis//", "Hepatits B//", "Chlamydia//", "Syphilis//", "Gonorrhea//", "HIV//", "AIDS//" };

    }

}
