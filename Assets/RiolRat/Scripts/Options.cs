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
    private bool AnimatedMusicOnce;

    // Start is called before the first frame update
    void Start()
    {
        #region Music & SFX settings
        Stand = Convert.ToInt32(GPGSAutenthicator.GPGSZelf.LoadString(11));


        if (Stand == 0)
        {
            //Music.isOn = true;
            //Music.AnimateSwitch();

            //SFX.isOn = true;
            //SFX.AnimateSwitch();

            print("called");

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
            print("called");

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

            print("called");
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
        if (GPGSAutenthicator.GPGSZelf.LoadBool(31))//If true, it means we want to use high quality settings AKA use post processing
        {
            Quality.text = "High Quality";
        }

        else if (!GPGSAutenthicator.GPGSZelf.LoadBool(31))//If false, it means we dont want to use high quality settings AKA use post processing
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

            if (AnimatedMusicOnce)
            {
                BackgroundMusic.Stop();
            }
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

        if (!AnimatedMusicOnce && Convert.ToInt32(GPGSAutenthicator.GPGSZelf.LoadString(11)) == 1 || !AnimatedMusicOnce && Convert.ToInt32(GPGSAutenthicator.GPGSZelf.LoadString(11)) == 2)
        {
            StartCoroutine(LateAnimate(true, false));
        }
        AnimatedMusicOnce = true;

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

        if (!Startup)//runt de eerste keer
        {
            Startup = true;
            SFX.AnimateSwitch();
            SFX.AnimateSwitch();
        }

    

        StartCoroutine(Save());
    }

    public void Qualityy ()
    {
        if (Quality.text == "High Quality")
        {
            Quality.text = "Performance";
            GPGSAutenthicator.GPGSZelf.Save(31, false);
        }

        else if (Quality.text == "Performance")
        {
            Quality.text = "High Quality";
            GPGSAutenthicator.GPGSZelf.Save(31, true);
        }
    }

    IEnumerator LateAnimate(bool AnimateMusic, bool AnimateSFX)
    {
        yield return new WaitForSeconds(1);

        if (AnimateMusic)
        {
            Music.AnimateSwitch();
        }

        if (AnimateSFX)
        {
            SFX.AnimateSwitch();
        }

        Debug.Log("aniamte musc" + AnimateMusic);
        Debug.Log("aniamte sfx" + AnimateSFX);
        
    }

    IEnumerator Save()
    {
        yield return new WaitForSeconds(1);

        if (Music.isOn && SFX.isOn)
        {
            GPGSAutenthicator.GPGSZelf.SaveString(11, "0");
        }

        else if (!Music.isOn && SFX.isOn)
        {
            GPGSAutenthicator.GPGSZelf.SaveString(11, "1");
        }

        else
        {
            GPGSAutenthicator.GPGSZelf.SaveString(11, "2");
        }
    }
}
