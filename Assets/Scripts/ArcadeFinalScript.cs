using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArcadeFinalScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreFromArcade;

    // Start is called before the first frame update
    void Start()
    {
        ScoreFromArcade.text = PlayerPrefs.GetInt("ArcadeScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
