using Michsky.UI.Zone;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

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


    public HorizontalSelector LanguageSelector;

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

        UpdateQualitySettingsText();

        LanguageSelector.defaultIndex = SaveLoadManager.slm.astroRunData.language; //Load in the correct index of the dropdown menu, so the last selected language is selected
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
        if (SaveLoadManager.slm.astroRunData.qualitySettings)
        {
            Quality.text = LocalizeString("Low Quality");
            SaveLoadManager.slm.astroRunData.qualitySettings = false;
        }

        else if (!SaveLoadManager.slm.astroRunData.qualitySettings)
        {
            Quality.text = LocalizeString("High Quality");
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

    public void LanguageSelector_Dropdown_ValueChanged()
    {
        //English - 0, Chinese - 1, Spanish - 2, Portuguese - 3, Russian - 4, Japanese - 5, Turkish - 6, French - 7, German - 8, Dutch - 9, Estonian - 10

        SaveLoadManager.slm.astroRunData.language = LanguageSelector.index; //Get the index of the selected value in the dropdown menu. The first element of the dropdown menu is 0, and the first language in our locales is also 0 (being English)
        SaveLoadManager.slm.SaveJSONToDisk();
        
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[LanguageSelector.index]; //Load in the selected language
                                                                                                                     //To ensure that 0 is indeed English, 1 is Chinese etc. The order of the languages in the dropdown menu should be the same as the languages listed under Project settings > Localization > Available locales

        LocalizationSettings.InitializationOperation.WaitForCompletion(); //Wait until the language/local has been changed
        UpdateQualitySettingsText(); //After changing the language, we should update the text displayed in the quality section of the main menu. 
    }

    private void UpdateQualitySettingsText()
    {
        if (SaveLoadManager.slm.astroRunData.qualitySettings)//If true, it means we want to use high quality settings AKA use post processing
        {
            Quality.text = LocalizeString("High Quality");
        }

        else if (!SaveLoadManager.slm.astroRunData.qualitySettings)//If false, it means we dont want to use high quality settings AKA use post processing
        {
            Quality.text = LocalizeString("Low Quality");
        }
    }

    private string LocalizeString(string key)
    {//https://forum.unity.com/threads/localizating-strings-on-script.847000/
        var op = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("UI Text", key);
        if (op.IsDone)
            return op.Result;
        else
            op.Completed += (op) => Debug.LogWarning(op.Result);
        return "Couldn't get translation for key: " + key;
    }
}