using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResetCoins : MonoBehaviour
{
    private DateTime lastCoinReset;

    private float seconds, minutes, hours;

    private string LevelTime;

    public TextMeshProUGUI TimeUntillResetWorld;
    public TextMeshProUGUI TimeUntillResetLevel;

    // Start is called before the first frame update
    void Start()
    {
        lastCoinReset = Convert.ToDateTime(SaveLoadManager.slm.astroRunData.CoinsResetTime); // Load the last reset
    }

    // Update is called once per frame
    void Update()
    {
        ResettCoins();

        hours = (int)(lastCoinReset.AddDays(1).Subtract(DateTime.Now).TotalSeconds / 3600f) % 60;
        minutes = (int)(lastCoinReset.AddDays(1).Subtract(DateTime.Now).TotalSeconds / 60f) % 60;
        seconds = (int)(lastCoinReset.AddDays(1).Subtract(DateTime.Now).TotalSeconds % 60f);

        LevelTime = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");

        TimeUntillResetWorld.text = LevelTime;
        TimeUntillResetLevel.text = LevelTime;

    }

    //Reset the coins collected from all levels. So they can be collected again
    public void ResettCoins()
    {
        if (lastCoinReset.AddDays(1) < DateTime.Now || lastCoinReset > (DateTime.Now).AddDays(2)) //if 24 hours passed since last coin reset || last coin reset is in the future
        {
            lastCoinReset = DateTime.Now; //Reset the countdown
            SaveLoadManager.slm.astroRunData.CoinsResetTime = Convert.ToString(DateTime.Now);

            // Reset the collected coins
            SaveLoadManager.slm.astroRunData.coinsLevel1_1 = 0; //Level 1 coins
            SaveLoadManager.slm.astroRunData.coinsLevel1_2 = 0; //Level 2 coins
            SaveLoadManager.slm.astroRunData.coinsLevel1_3 = 0; //Level 3 coins
            SaveLoadManager.slm.astroRunData.coinsLevel1_4 = 0; //Level 4 coins
            SaveLoadManager.slm.astroRunData.coinsLevel1_5 = 0; //Level 5 coins
            SaveLoadManager.slm.astroRunData.coinsLevel1_6 = 0; //Level 6 coins
            SaveLoadManager.slm.astroRunData.coinsLevel1_7 = 0; //Level 7 coins
            SaveLoadManager.slm.astroRunData.coinsLevel1_8 = 0; //Level 8 coins
            SaveLoadManager.slm.astroRunData.coinsLevel1_9 = 0; //Level 9 coins
            SaveLoadManager.slm.astroRunData.coinsLevel10 = 0; //Level 10 coins

            SaveLoadManager.slm.astroRunData.coinsWorld1 = 0; //World 1 coins

            SaveLoadManager.slm.SaveJSONToDisk();
        }
    }

}