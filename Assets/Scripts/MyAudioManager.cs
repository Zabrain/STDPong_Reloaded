using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAudioManager : MonoBehaviour {

    public AudioSource MainThemeMusic; //Index 0 Theme
    public AudioSource ClickButtonSFX; //Index 0 SFX
    public AudioSource BounceSoundSFX; //Index 1 SFX
    public AudioSource LoseSoundSFX; //Index 2 SFX
    public AudioSource LongApplauseSFX; //Index 3 SFX
    public AudioSource ShortApplauseSFX; //Index 4 SFX
    public AudioSource SelectSFX; //Index 5 SFX

    public static AudioSource[] myAudioClipsThemes = new AudioSource[2];
    public static AudioSource[] myAudioClipsSFXs = new AudioSource[9];

    public Slider myMusicSlider;
    public Slider mySFXSlider;

    public string stageName;

    // Use this for initialization
    void Start () {

        //Check if audio has been set before
        if (PlayerPrefs.GetInt("IsVolumeMusicSet") != 1)
        {
            PlayerPrefs.SetFloat("MusicVolume", 0.5f);
            PlayerPrefs.SetInt("IsVolumeMusicSet", 1);
        }
        if (PlayerPrefs.GetInt("IsVolumeSFXSet") != 1)
        {
            PlayerPrefs.SetFloat("SFXVolume", 0.5f);
            PlayerPrefs.SetInt("IsVolumeSFXSet", 1);
        }


        //check level and assigns music and sfxs
        if (stageName == "MainMenu")
        {
            MainMenuSoundInst();
            Debug.Log("1");
        }
        else
        {
            PrimaryInst();
        }
        

        if (stageName == "SecondAnimation" || stageName == "FirstAnimation")
        {
            //MovieSoundLogic();
        }

    }
	

    void MainMenuSoundInst()
    {

        Debug.Log("1");
        myAudioClipsThemes[0]= Instantiate(MainThemeMusic);//Instantiate Main theme music
        myAudioClipsThemes[0].Play();//play theme music
        myAudioClipsThemes[0].loop = true;

        myAudioClipsSFXs[0] = Instantiate(ClickButtonSFX);//Instantiate button click


        Debug.Log("1");

        //adjust the volumes of all the music and SFX if they exist(themes)
        SetVolumeOfThemesGeneral();
        SetVolumeOfSFXGeneral();


        //Assign slider value
        if (myMusicSlider)
        {
            myMusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        if (mySFXSlider)
        {
            mySFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
    }

    void PrimaryInst()
    {
        myAudioClipsThemes[0] = Instantiate(MainThemeMusic);//Instantiate Main theme music
        myAudioClipsThemes[0].Play();//play theme music
        myAudioClipsThemes[0].loop = true;

        myAudioClipsSFXs[0] = Instantiate(ClickButtonSFX);//Instantiate button click
        myAudioClipsSFXs[1] = Instantiate(BounceSoundSFX);//Instantiate button click
        myAudioClipsSFXs[2] = Instantiate(LoseSoundSFX);//Instantiate button click
        myAudioClipsSFXs[3] = Instantiate(ShortApplauseSFX);//Instantiate button click
        myAudioClipsSFXs[4] = Instantiate(LongApplauseSFX);//Instantiate button click
        myAudioClipsSFXs[5] = Instantiate(SelectSFX);//Instantiate button click
        


        // Debug.Log("1");

        //adjust the volumes of all the music and SFX if they exist(themes)
        SetVolumeOfThemesGeneral();
        SetVolumeOfSFXGeneral();


        //Assign slider value
        if (myMusicSlider)
        {
            myMusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        if (mySFXSlider)
        {
            mySFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
    }


    //Play Click
    public void ClickSound()
    {
        if (myAudioClipsSFXs[0])
        {
            myAudioClipsSFXs[0].Play();
        }
    }
    //Play Click
    public static void BallBounce()
    {
        if (myAudioClipsSFXs[1])
        {
            myAudioClipsSFXs[1].Play();
        }
    }
    
    public static void LoseSoundPlay()
    {
        if (myAudioClipsSFXs[2])
        {
            myAudioClipsSFXs[2].Play();
        }
    }


    //for slider music
    public void ChangeVolumeOfThemes()
    {
        PlayerPrefs.SetFloat("MusicVolume", myMusicSlider.value);

        SetVolumeOfThemesGeneral();
    }

    //for slider SFX
    public void ChangeVolumeOfSFX()
    {
        PlayerPrefs.SetFloat("SFXVolume", mySFXSlider.value);

        SetVolumeOfSFXGeneral();
    }

    //change all volumes of SFX
    public void SetVolumeOfSFXGeneral()
    {
        //adjust the volumes of all the music (themes)
        for (int i = 0; i < myAudioClipsSFXs.Length; i++)
        {
            //check if instantiated
            if (myAudioClipsSFXs[i])
            {
                myAudioClipsSFXs[i].volume = PlayerPrefs.GetFloat("SFXVolume");
            }
        }
    }
    //change all volumes of Themes
    public void SetVolumeOfThemesGeneral()
    {
        //adjust the volumes of all the music (themes)
        for (int i = 0; i < myAudioClipsThemes.Length; i++)
        {
            //check if instantiated
            if (myAudioClipsThemes[i])
            {
                myAudioClipsThemes[i].volume = PlayerPrefs.GetFloat("MusicVolume");
            }
        }
    }
}
