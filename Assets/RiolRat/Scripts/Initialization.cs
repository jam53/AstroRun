using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Initialization : MonoBehaviour
{
    public int GameFPS;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = GameFPS;

        LocalizationSettings.InitializationOperation.WaitForCompletion();
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[SaveLoadManager.slm.astroRunData.language]; //Load in the last selected language
    }
}
