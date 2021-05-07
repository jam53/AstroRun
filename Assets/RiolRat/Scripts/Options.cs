using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Options : MonoBehaviour
{
    public AudioSource BackgroundMusic;
    public GameObject SFXs;

    public TextMeshProUGUI Music;
    public TextMeshProUGUI SFX;

    private int Stand;


    public TextMeshProUGUI Quality;
    // Start is called before the first frame update
    void Start()
    {
        #region Music & SFX settings
        Stand = Convert.ToInt32(GPGSAutenthicator.GPGSZelf.LoadString(11));

        if (Stand == 0)
        {
            Music.text = "Music: On";
            SFX.text = "Sound Effects: On";
            BackgroundMusic.Play();
            SFXs.SetActive(true);
        }

        else if (Stand == 1)
        {
            Music.text = "Music: Off";
            SFX.text = "Sound Effects: On";
            BackgroundMusic.Stop();
            SFXs.SetActive(true);
        }

        else
        {
            Music.text = "Music: Off";
            SFX.text = "Sound Effects: Off";
            BackgroundMusic.Stop();
            SFXs.SetActive(false);
        }
        #endregion

        #region Quality Settings
        if (GPGSAutenthicator.GPGSZelf.LoadBool(31))//If true, it means we want to use high quality settings AKA use post processing
        {
            Quality.text = "Graphics: High Quality";
        }

        else if (!GPGSAutenthicator.GPGSZelf.LoadBool(31))//If false, it means we dont want to use high quality settings AKA use post processing
        {
            Quality.text = "Graphics: Performance";
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Musicc()
    {
        if (Music.text == "Music: On")
        {
            Music.text = "Music: Off";
            BackgroundMusic.Stop();
        }

        else if (Music.text == "Music: Off")
        {
            Music.text = "Music: On";
            BackgroundMusic.Play();
        }

        if (Music.text == "Music: On" && SFX.text == "Sound Effects: Off")
        {
            SFX.text = "Sound Effects: On";
            SFXs.SetActive(true);
        }
        Save();
    }

    public void SFXX()
    {
        if (SFX.text == "Sound Effects: On")
        {
            SFX.text = "Sound Effects: Off";
            SFXs.SetActive(false);
        }

        else if (SFX.text == "Sound Effects: Off")
        {
            SFX.text = "Sound Effects: On";
            SFXs.SetActive(true);
        }

        if (Music.text == "Music: On" && SFX.text == "Sound Effects: Off")
        {
            Music.text = "Music: Off";
            BackgroundMusic.Stop();
        }
        Save();
    }

    public void Qualityy ()
    {
        if (Quality.text == "Graphics: High Quality")
        {
            Quality.text = "Graphics: Performance";
            GPGSAutenthicator.GPGSZelf.Save(31, false);
        }

        else if (Quality.text == "Graphics: Performance")
        {
            Quality.text = "Graphics: High Quality";
            GPGSAutenthicator.GPGSZelf.Save(31, true);
        }
    }

    private void Save()
    {
        if (Music.text == "Music: On" && SFX.text == "Sound Effects: On")
        {
            GPGSAutenthicator.GPGSZelf.SaveString(11, "0");
        }

        else if (Music.text == "Music: Off" && SFX.text == "Sound Effects: On")
        {
            GPGSAutenthicator.GPGSZelf.SaveString(11, "1");
        }

        else
        {
            GPGSAutenthicator.GPGSZelf.SaveString(11, "2");
        }
    }
}
