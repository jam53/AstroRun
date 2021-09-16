using System.Collections;
using GooglePlayGames;
using System.Collections.Generic;
using UnityEngine;

public class GPGSAchievements : MonoBehaviour
{
    public void OpenAchievementPanel()
    {
        Social.ShowAchievementsUI();
    }
    //wss handelen van achievements en pushen ook best op GPGSAuthenticator, aangezien dat altijd aanwezig is in elke scene
    // Gwn showachievements kan hier wel blijven
    public void UpdateIncremental()
    {
        //PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.NameOfAchievementIncrementalWillBeHere, 1 (increase by 1), null);
    }

    public void UnlockRegular()
    {
        //Social.ReportProgress(GPGSIds.NameOfRegularAchievementWillBeHere, 100f(=Unlock this achievenemnt), null);
    }
}
