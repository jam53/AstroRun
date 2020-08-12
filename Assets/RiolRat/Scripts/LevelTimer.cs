using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public int KeyIndex;
    private float milliseconds, seconds, minutes;

    private string LevelTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        minutes = (int)(Time.timeSinceLevelLoad / 60f) % 60;
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        milliseconds = (int)(Time.timeSinceLevelLoad * 1000f) % 1000;

        LevelTime = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        string[] NewTime = LevelTime.Split(':');
        string[] OldTime = GPGSAutenthicator.GPGSZelf.LoadString(KeyIndex).Split(':');
        if (int.Parse(NewTime[0]) < int.Parse(OldTime[0]) || int.Parse(NewTime[0]) <= int.Parse(OldTime[0]) && int.Parse(NewTime[1]) < int.Parse(OldTime[1]) || int.Parse(NewTime[0]) <= int.Parse(OldTime[0]) && int.Parse(NewTime[1]) <= int.Parse(OldTime[1]) && int.Parse(NewTime[2]) < int.Parse(OldTime[2])) 
        {
            GPGSAutenthicator.GPGSZelf.SaveString(KeyIndex, LevelTime);
        }
    }

}
