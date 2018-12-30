using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryAnimaScript : MonoBehaviour {

    public Transform TextInPosition;
    public Transform TextOutPosition;

    public Transform ImageInPosition;
    public Transform ImageOutPosition;

    public GameObject[] StoryTexts;
    public GameObject[] StoryImages;
    public GameObject NextButton;

    bool boolNextText;
    int intStoryFrameIndex = 0;

    // Use this for initialization
    void Start () {
		
        //Moving all text to the out position
        for (int i=1; i < StoryTexts.Length; i++)
        {
            StoryTexts[i].transform.position = TextOutPosition.position;
        }

        

    }
	
	// Update is called once per frame
	void Update () {

        if(boolNextText == true)
        {
            if (intStoryFrameIndex < 4)
            {
                StoryTexts[intStoryFrameIndex].transform.position = Vector2.MoveTowards(StoryTexts[intStoryFrameIndex].transform.position, TextOutPosition.position, 7 * Time.deltaTime);
                StoryImages[intStoryFrameIndex].transform.position = Vector2.MoveTowards(StoryImages[intStoryFrameIndex].transform.position, ImageOutPosition.position, 15 * Time.deltaTime);

                StoryTexts[intStoryFrameIndex + 1].transform.position = Vector2.MoveTowards(StoryTexts[intStoryFrameIndex + 1].transform.position, TextInPosition.position, 7 * Time.deltaTime);
                StoryImages[intStoryFrameIndex + 1].transform.position = Vector2.MoveTowards(StoryImages[intStoryFrameIndex + 1].transform.position, ImageInPosition.position, 15 * Time.deltaTime);
                //check if texts and images have reached their positions
                if (StoryTexts[intStoryFrameIndex].transform.position.y.ToString() == TextOutPosition.position.y.ToString() && 
                    StoryTexts[intStoryFrameIndex + 1].transform.position.y.ToString() == TextInPosition.position.y.ToString() &&
                    StoryImages[intStoryFrameIndex].transform.position.x.ToString() == ImageOutPosition.position.x.ToString() &&
                    StoryImages[intStoryFrameIndex + 1].transform.position.x.ToString() == ImageInPosition.position.x.ToString())
                {
                    NextButton.SetActive(true);
                    boolNextText = false;

                    intStoryFrameIndex += 1;


                }
            }
               
        }

       Debug.Log(StoryImages[0].transform.position.x + "   " + ImageOutPosition.position.x + boolNextText ); 
            

    }

    public void NextStoryFrame()
    {

        boolNextText = true;
        NextButton.SetActive(false);
    }

    public void SkipStoryAnimation()
    {
        SceneManager.LoadScene("StartingAnimation");
    }
}
