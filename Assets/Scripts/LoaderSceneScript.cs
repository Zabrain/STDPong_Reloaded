using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoaderSceneScript : MonoBehaviour {

    public Slider LoadingSlider;
    public TextMeshProUGUI LoadingPercent;
    

    public void LoadSceneSTDPlay() //load mainplay
    {
        StartCoroutine(LoadSceneAsynchronously("StdPongPlay"));
    }

    public void LoadSceneQuizGame() //load quiz game
    {
        StartCoroutine(LoadSceneAsynchronously("QuizGame"));
    }
    public void LoadSceneSTDLose() //load quiz game
    {
        StartCoroutine(LoadSceneAsynchronously("GLossSceneForGlobal"));
    }
    public void LoadSceneSTDScroll() //load quiz game
    {
        StartCoroutine(LoadSceneAsynchronously("STDScroll"));
    }
    public void LoadSceneFinishStoryMode()
    {
        StartCoroutine(LoadSceneAsynchronously("Winner"));
    }
    public void LoadSceneLeaderBoard()
    {
        StartCoroutine(LoadSceneAsynchronously("Leaderboards"));
    }
    public void LoadStartingAnimation()
    {
        StartCoroutine(LoadSceneAsynchronously("StartingAnimation"));
    }
    public void LoadSceneRewards() //load mainplay
    {
        StartCoroutine(LoadSceneAsynchronously("RewardsScene"));
    }
    public void LoadPretest() //load prerest
    {
        StartCoroutine(LoadSceneAsynchronously("PreQuizScene"));
    }
    public void LoadScrollGotten() //load prerest
    {
        StartCoroutine(LoadSceneAsynchronously("ScrollGotten"));
    }

    IEnumerator LoadSceneAsynchronously(string SceneToLoad)
    {
        AsyncOperation MyOperation = SceneManager.LoadSceneAsync(SceneToLoad);

        while (!MyOperation.isDone)
        {
            float progress = Mathf.Clamp01(MyOperation.progress/.9f);

            LoadingSlider.value = progress;
            LoadingPercent.text = (progress * 100).ToString("F2") + "%"; 

            yield return null;
        }

    }
}
