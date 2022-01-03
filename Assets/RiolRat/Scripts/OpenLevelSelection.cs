using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OpenLevelSelection : MonoBehaviour
{
    public GameObject[] Level_Buttons;
    public LevelsInfo[] LevelsInfo;


    public void LoadInData()
    {
        for (int i = 0; i < Level_Buttons.Length; i++)
        {
            Level_Buttons[i].transform.Find("Text_Play").GetComponent<TextMeshProUGUI>().text = LevelsInfo[i].displayName;

            Level_Buttons[i].transform.Find("Coins").transform.Find("Text_Coins").GetComponent<TextMeshProUGUI>().text = LoadText(LevelsInfo[i].coinsKeyName, "/100");

            Level_Buttons[i].transform.Find("Time").transform.Find("Text_Time").GetComponent<TextMeshProUGUI>().text = LoadText(LevelsInfo[i].timeKeyName, "");
        
            if(LevelsInfo[i].sceneIndex <= SaveLoadManager.slm.astroRunData.highestUnlockedLevel )
            {//Only display the thumbnail of this level, if the user has unlocked it. Other wise it will display the default lock icon
                Level_Buttons[i].transform.Find("Background_Image").GetComponent<Image>().sprite = LevelsInfo[i].ImageUnlocked;
            }

            Level_Buttons[i].GetComponent<LevelLoader>().NameSceneToLoad = LevelsInfo[i].nameSceneToLoad;
        }

        SubmitTimes();
    }

    private string LoadText(string keyName, string additionalText)
    {
        if ("" + typeof(AstroRunData).GetField(keyName).GetValue(SaveLoadManager.slm.astroRunData) == "99:99:99")
        {
            return "No Time";
        }

        return typeof(AstroRunData).GetField(keyName).GetValue(SaveLoadManager.slm.astroRunData) + additionalText;
    }

    private void SubmitTimes()
    {//This submits times to the leaderboards, that weren't able to be uploaded and the time of completing the level.
        if (SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_1 != 0)
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel1(SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_1);
            SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_1 = 0;
        }

        if (SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_2 != 0)
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel2(SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_2);
            SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_2 = 0;
        }

        if (SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_3 != 0)
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel3(SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_3);
            SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_3 = 0;
        }

        if (SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_4 != 0)
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel4(SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_4);
            SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_4 = 0;
        }

        if (SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_5 != 0)
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel5(SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_5);
            SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_5 = 0;
        }

        if (SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_6 != 0)
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel6(SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_6);
            SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_6 = 0;
        }

        if (SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_7 != 0)
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel7(SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_7);
            SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_7 = 0;
        }

        if (SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_8 != 0)
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel8(SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_8);
            SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_8 = 0;
        }

        if (SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_9 != 0)
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel9(SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_9);
            SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_9 = 0;
        }

        SaveLoadManager.slm.SaveJSONToDisk();
    }
}
