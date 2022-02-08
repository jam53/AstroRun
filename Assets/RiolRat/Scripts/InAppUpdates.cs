using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;

public class InAppUpdates : MonoBehaviour
{

    public struct userAttributes { }

    public struct appAttributes { }

    public bool LevelCanBeLoaded = false;

    public GameObject NewUpdateAvaible;
    public GameObject VideoPlayer; // We doen dit omdat die loading animatie anders gewoon blijft doorgaan op de achtergrond.

    private void Awake()
    {
        ConfigManager.FetchCompleted += CheckForUpdates; // Als de lijn hieronder voltooid is, wordt de functie "CheckForUpdates" opgeroepen
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    void CheckForUpdates (ConfigResponse response)
    {
        if (ConfigManager.appConfig.GetString("ApplicationVersion") != Application.version)
        {
            NewUpdateAvaible.SetActive(true);
            VideoPlayer.SetActive(false);
        }

        else
        {
            LevelCanBeLoaded = true;
        }

    }

    public void UpdateGame()
    {
        Application.OpenURL("https://play.app.goo.gl/?link=https://play.google.com/store/apps/details?id=com.jam54.AstroRun");
    }

    public void SkipUpdate()
    {
        VideoPlayer.SetActive(true);
        NewUpdateAvaible.SetActive(false);
        LevelCanBeLoaded = true;
    }
}
