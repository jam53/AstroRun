using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] LevelButtons;

    public Sprite LockedIcon;

    private int LevelAt;
    // Start is called before the first frame update
    void Start()
    {
        LevelAt = Convert.ToInt32(GPGSAutenthicator.GPGSZelf.LoadString(10));
        Debug.Log(GPGSAutenthicator.GPGSZelf.LoadString(10));

        for (int i = LevelAt; i < LevelButtons.Length; i++)
        {
            LevelButtons[i].interactable = false;
            LevelButtons[i].image.sprite = LockedIcon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
