using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;

public class InAppUpdates : MonoBehaviour
{

    public struct userAttributes { }

    public struct appAttributes { }

    public bool LevelCanBeLoaded = false;

    private void Awake()
    {
        ConfigManager.FetchCompleted += CheckForUpdates;
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    void CheckForUpdates (ConfigResponse response)
    {
        if (ConfigManager.appConfig.GetString("ApplicationVersion") != Application.version)
        {
            Application.OpenURL("https://play.app.goo.gl/?link=https://play.google.com/store/apps/details?id=com.jam54.AstroRun");
        }

        else
        {
            LevelCanBeLoaded = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
