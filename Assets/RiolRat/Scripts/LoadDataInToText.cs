using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadDataInToText : MonoBehaviour
{
    public TextMeshProUGUI TextObject;
    public string AdittionalText;
    public int KeyIndex;

    public bool LevelTimeButton;

    // Start is called before the first frame update
    void Start()
    {
        if (AdittionalText == null)
        {
            AdittionalText = "";
        }

        TextObject.text = GPGSAutenthicator.GPGSZelf.LoadString(KeyIndex) + AdittionalText;



        if (LevelTimeButton && GPGSAutenthicator.GPGSZelf.LoadString(KeyIndex) == "99:99:99")
        {
            TextObject.text = "No Time";
        }



        if (GPGSAutenthicator.GPGSZelf.LoadString(12) != "0")
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel1(long.Parse(GPGSAutenthicator.GPGSZelf.LoadString(12)));
            GPGSAutenthicator.GPGSZelf.SaveString(12, "0");
        }

        if (GPGSAutenthicator.GPGSZelf.LoadString(13) != "0")
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel2(long.Parse(GPGSAutenthicator.GPGSZelf.LoadString(13)));
            GPGSAutenthicator.GPGSZelf.SaveString(13, "0");
        }

        if (GPGSAutenthicator.GPGSZelf.LoadString(14) != "0")
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel3(long.Parse(GPGSAutenthicator.GPGSZelf.LoadString(14)));
            GPGSAutenthicator.GPGSZelf.SaveString(14, "0");
        }

        if (GPGSAutenthicator.GPGSZelf.LoadString(15) != "0")
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel4(long.Parse(GPGSAutenthicator.GPGSZelf.LoadString(15)));
            GPGSAutenthicator.GPGSZelf.SaveString(15, "0");
        }

        if (GPGSAutenthicator.GPGSZelf.LoadString(17) != "0")
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel5(long.Parse(GPGSAutenthicator.GPGSZelf.LoadString(17)));
            GPGSAutenthicator.GPGSZelf.SaveString(17, "0");
        }

        if (GPGSAutenthicator.GPGSZelf.LoadString(20) != "0")
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel6(long.Parse(GPGSAutenthicator.GPGSZelf.LoadString(20)));
            GPGSAutenthicator.GPGSZelf.SaveString(20, "0");
        }

        if (GPGSAutenthicator.GPGSZelf.LoadString(24) != "0")
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel7(long.Parse(GPGSAutenthicator.GPGSZelf.LoadString(24)));
            GPGSAutenthicator.GPGSZelf.SaveString(24, "0");
        }

        if (GPGSAutenthicator.GPGSZelf.LoadString(27) != "0")
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel8(long.Parse(GPGSAutenthicator.GPGSZelf.LoadString(27)));
            GPGSAutenthicator.GPGSZelf.SaveString(27, "0");
        }

        if (GPGSAutenthicator.GPGSZelf.LoadString(30) != "0")
        {
            GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel9(long.Parse(GPGSAutenthicator.GPGSZelf.LoadString(30)));
            GPGSAutenthicator.GPGSZelf.SaveString(30, "0");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
