using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadDataInToText : MonoBehaviour
{
    public TextMeshProUGUI TextObject;
    public string AdittionalText;
    public string keyName;

    public bool LevelTimeButton;

    // Start is called before the first frame update
    void Start()
    {
        if (AdittionalText == null)
        {
            AdittionalText = "";
        }
        
        TextObject.text = "" + typeof(AstroRunData).GetField(keyName).GetValue(SaveLoadManager.slm.astroRunData);


        if ("" + typeof(AstroRunData).GetField(keyName).GetValue(SaveLoadManager.slm.astroRunData) == "99:99:99")
        {
            TextObject.text = "No Time";
        }


        
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
