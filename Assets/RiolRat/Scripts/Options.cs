using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Options : MonoBehaviour
{
    public TextMeshProUGUI Music;
    public TextMeshProUGUI SFX;

    private int Stand;
    // Start is called before the first frame update
    void Start()
    {
        Stand = Convert.ToInt32(GPGSAutenthicator.GPGSZelf.LoadString(11));

        if (Stand == 0)
        {
            Music.text = "Music: On";
            SFX.text = "Sound Effects: On";
        }

        else if (Stand == 1)
        {
            Music.text = "Music: Off";
            SFX.text = "Sound Effects: On";
        }

        else
        {
            Music.text = "Music: Off";
            SFX.text = "Sound Effects: Off";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Musicc()
    {
        if (Music.text == "Music: On")
        {
            Music.text = "Music: Off";
        }

        else if (Music.text == "Music: Off")
        {
            Music.text = "Music: On";
        }

        if (Music.text == "Music: On" && SFX.text == "Sound Effects: Off")
        {
            SFX.text = "Sound Effects: On";
        }
        Save();
    }

    public void SFXX()
    {
        if (SFX.text == "Sound Effects: On")
        {
            SFX.text = "Sound Effects: Off";
        }

        else if (SFX.text == "Sound Effects: Off")
        {
            SFX.text = "Sound Effects: On";
        }

        if (Music.text == "Music: On" && SFX.text == "Sound Effects: Off")
        {
            Music.text = "Music: Off";
        }
        Save();
    }

    private void Save()
    {
        if (Music.text == "Music: On" && SFX.text == "Sound Effects: On")
        {
            GPGSAutenthicator.GPGSZelf.SaveString(11, "0");
        }

        else if (Music.text == "Music: Off" && SFX.text == "Sound Effects: On")
        {
            GPGSAutenthicator.GPGSZelf.SaveString(11, "1");
        }

        else
        {
            GPGSAutenthicator.GPGSZelf.SaveString(11, "2");
        }
    }
}
