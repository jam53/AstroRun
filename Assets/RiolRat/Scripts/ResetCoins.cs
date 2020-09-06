using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResetCoins : MonoBehaviour
{
    private DateTime _lastAdTime;

    private float seconds, minutes, houres;

    private string LevelTime;

    public TextMeshProUGUI TimeUntillResetWorld;
    public TextMeshProUGUI TimeUntillResetLevel;

    // Start is called before the first frame update
    void Start()
    {
        _lastAdTime = Convert.ToDateTime(GPGSAutenthicator.GPGSZelf.LoadString(19)); // Load the last reset
    }

    // Update is called once per frame
    void Update()
    {
        ResettCoins();

        houres = (int)(_lastAdTime.AddDays(1).Subtract(DateTime.Now).TotalSeconds / 3600f) % 60;
        minutes = (int)(_lastAdTime.AddDays(1).Subtract(DateTime.Now).TotalSeconds / 60f) % 60;
        seconds = (int)(_lastAdTime.AddDays(1).Subtract(DateTime.Now).TotalSeconds % 60f);

        LevelTime = houres.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");

        TimeUntillResetWorld.text = LevelTime;
        TimeUntillResetLevel.text = LevelTime;

    }

    //Reset the coins collected from all levels. So they can be collected again
    public void ResettCoins()
    {
        if (_lastAdTime.AddDays(1) < DateTime.Now) //if 24 houres passed
        {
            _lastAdTime = DateTime.Now; //Reset the countdown
            GPGSAutenthicator.GPGSZelf.SaveString(19, Convert.ToString(DateTime.Now));

            // Reset the collected coins

            GPGSAutenthicator.GPGSZelf.SaveString(5, "0");//Level 1
            GPGSAutenthicator.GPGSZelf.SaveString(6, "0");//Level 2
            GPGSAutenthicator.GPGSZelf.SaveString(7, "0");//Level 3
            GPGSAutenthicator.GPGSZelf.SaveString(8, "0");//Level 4
            GPGSAutenthicator.GPGSZelf.SaveString(18, "0");//Level 5
        }
    }
}