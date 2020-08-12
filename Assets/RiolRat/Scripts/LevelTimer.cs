using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public int KeyIndex;
    private float milliseconds, seconds, minutes;

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

        GPGSAutenthicator.GPGSZelf.SaveString(KeyIndex, minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00"));
    }

}
