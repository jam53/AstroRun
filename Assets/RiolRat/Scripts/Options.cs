using Michsky.UI.Zone;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Options : MonoBehaviour
{
    public AudioSource BackgroundMusic;
    public GameObject SFXs;

    public TextMeshProUGUI Quality;
    public SwitchManager Music;
    public SwitchManager SFX;

    public AudioSource[] SourcesInOptions;

    private int Stand;

    private bool Startup;

    // Start is called before the first frame update
    void Start()
    {
        #region Music & SFX settings
        Stand = SaveLoadManager.slm.astroRunData.audioSettings;


        if (Stand == 0)
        {
            //Music.isOn = true;
            //Music.AnimateSwitch();

            //SFX.isOn = true;
            //SFX.AnimateSwitch();

            StartCoroutine(LateAnimate(false, false));

            BackgroundMusic.Play();
            SFXs.SetActive(true);

            foreach (AudioSource source in SourcesInOptions)
            {
                source.enabled = true;
            }
        }

        else if (Stand == 1)
        {
            //Music.isOn = false;
            //Music.AnimateSwitch();
            StartCoroutine(LateAnimate(true, false));

            //SFX.isOn = true;
            //SFX.AnimateSwitch();

            BackgroundMusic.Stop();
            SFXs.SetActive(true);

            foreach (AudioSource source in SourcesInOptions)
            {
                source.enabled = true;
            }
        }

        else
        {
            //Music.isOn = false;
            //Music.AnimateSwitch();

            //SFX.isOn = false;
            //SFX.AnimateSwitch();
            StartCoroutine(LateAnimate(true, true));

            BackgroundMusic.Stop();
            SFXs.SetActive(false);

            foreach (AudioSource source in SourcesInOptions)
            {
                source.enabled = false;
            }
        }
        #endregion

        #region Quality Settings
        if (SaveLoadManager.slm.astroRunData.qualitySettings)//If true, it means we want to use high quality settings AKA use post processing
        {
            Quality.text = "High Quality";
        }

        else if (!SaveLoadManager.slm.astroRunData.qualitySettings)//If false, it means we dont want to use high quality settings AKA use post processing
        {
            Quality.text = "Performance";
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Musicc()
    {
        if (Music.isOn)
        {
            //Music.isOn = false;
            //Music.AnimateSwitch();

            BackgroundMusic.Stop();
        }

        else if (!Music.isOn)
        {
            //Music.isOn = true;
            //Music.AnimateSwitch();

            BackgroundMusic.Play();
        }

        if (!Music.isOn && !SFX.isOn)
        {
            //SFX.isOn = true;
            SFX.AnimateSwitch();

            SFXs.SetActive(true);

            foreach (AudioSource source in SourcesInOptions)
            {
                source.enabled = true;
            }
        }
        StartCoroutine(Save());
    }

    public void SFXX()
    {
        if (SFX.isOn)
        {
            //SFX.isOn = false;
            //SFX.AnimateSwitch();

            SFXs.SetActive(false);

            foreach (AudioSource source in SourcesInOptions)
            {
                source.enabled = false;
            }

            
        }

        else if (!SFX.isOn)
        {
            //SFX.isOn = true;
            //SFX.AnimateSwitch();

            SFXs.SetActive(true);

            foreach (AudioSource source in SourcesInOptions)
            {
                source.enabled = true;
            }
        }

        if (Music.isOn && SFX.isOn)
        {
            //Music.isOn = false;
            Music.AnimateSwitch();

            BackgroundMusic.Stop();
        }

        

        StartCoroutine(Save());
    }

    public void Qualityy()
    {
        if (Quality.text == "High Quality")
        {
            Quality.text = "Performance";
            SaveLoadManager.slm.astroRunData.qualitySettings = false;
        }

        else if (Quality.text == "Performance")
        {
            Quality.text = "High Quality";
            SaveLoadManager.slm.astroRunData.qualitySettings = true;
        }

        SaveLoadManager.slm.SaveJSONToDisk();
    }

    private bool OptionsMenuOpen()
    {
        return Music.gameObject.activeInHierarchy;
    }

    IEnumerator LateAnimate(bool AnimateMusic, bool AnimateSFX)
    {
        //yield return new WaitForSeconds(5);

        yield return new WaitUntil(OptionsMenuOpen);

        if (AnimateMusic)
        {
            Music.AnimateSwitch();
        }

        if (AnimateSFX)
        {
            SFX.AnimateSwitch();
        }

        if (!Startup && !AnimateMusic)
        {
            Startup = true;
            print("hit");
            Music.AnimateSwitch();
            
            SFX.AnimateSwitch();
            SFX.AnimateSwitch();

            Music.AnimateSwitch();
        }

        else if (!Startup)
        {
            Startup = true;
            SFX.AnimateSwitch();

            SFX.AnimateSwitch();
        }

    }

    IEnumerator Save()
    {
        yield return new WaitForSeconds(1);

        if (Music.isOn && SFX.isOn)
        {
            SaveLoadManager.slm.astroRunData.audioSettings = 0;
        }

        else if (!Music.isOn && SFX.isOn)
        {
            SaveLoadManager.slm.astroRunData.audioSettings = 1;
        }

        else
        {
            SaveLoadManager.slm.astroRunData.audioSettings = 2;
        }

        SaveLoadManager.slm.SaveJSONToDisk();
    }
}