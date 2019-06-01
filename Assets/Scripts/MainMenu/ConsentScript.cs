using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConsentScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        if (PlayerPrefs.GetString("Consented") == "Yes")
        {
            SceneManager.LoadScene("Mainmenu");
        }
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AgreeButton() //consent given
    {
        PlayerPrefs.SetString("Consented", "Yes");

        SceneManager.LoadScene("Mainmenu");

    }

    public void DisagreeButton() //consent given
    {
        PlayerPrefs.SetString("Consented", "No");

        Application.Quit();

    }

   
    

}
