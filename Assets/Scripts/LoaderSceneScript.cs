using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoaderSceneScript : MonoBehaviour {

    public Slider LoadingSlider;
    public TextMeshProUGUI LoadingPercent;

    public void LoadSceneSTDPlay()
    {
        StartCoroutine(LoadSceneAsynchronously("StdPongPlay"));
    }

    IEnumerator LoadSceneAsynchronously(string SceneToLoad)
    {
        AsyncOperation MyOperation = SceneManager.LoadSceneAsync(SceneToLoad);

        while (!MyOperation.isDone)
        {
            float progress = Mathf.Clamp01(MyOperation.progress/.9f);

            LoadingSlider.value = progress;
            LoadingPercent.text = (progress * 100).ToString() + "%"; 

            yield return null;
        }

    }
}
