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

    private Sprite[] OriginalSprites;
    // Start is called before the first frame update
    void Start()
    {
        OriginalSprites = new Sprite[LevelButtons.Length];
        for (int i = 0; i < OriginalSprites.Length; i++)
        {
            OriginalSprites[i] = LevelButtons[i].image.sprite;
        }


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

    public void EnableHighestUnlockedLevel()
    {
        LevelAt = Convert.ToInt32(GPGSAutenthicator.GPGSZelf.LoadString(10)) - 1;
        Debug.Log(GPGSAutenthicator.GPGSZelf.LoadString(10));

        LevelButtons[LevelAt].interactable = true;
        LevelButtons[LevelAt].image.sprite = OriginalSprites[LevelAt];
    }
}
