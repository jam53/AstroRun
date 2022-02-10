using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AstroRunData
{//Create a class that holds all the data/variables + sets the default values for these variables

    public string bestTimeLevel1_1 = "99:99:99"; //The users' fastest time on level 1, world 1
    public string bestTimeLevel1_2 = "99:99:99";
    public string bestTimeLevel1_3 = "99:99:99";
    public string bestTimeLevel1_4 = "99:99:99";
    public string bestTimeLevel1_5 = "99:99:99";
    public string bestTimeLevel1_6 = "99:99:99";
    public string bestTimeLevel1_7 = "99:99:99";
    public string bestTimeLevel1_8 = "99:99:99";
    public string bestTimeLevel1_9 = "99:99:99";
    public string bestTimeLevel10 = "99:99:99";

    public int totalCoins = 0; //Total coins collected across all levels

    public int coinsLevel1_1 = 0; //Coins collected in level 1, world 1
    public int coinsLevel1_2 = 0; 
    public int coinsLevel1_3 = 0; 
    public int coinsLevel1_4 = 0; 
    public int coinsLevel1_5 = 0; 
    public int coinsLevel1_6 = 0; 
    public int coinsLevel1_7 = 0; 
    public int coinsLevel1_8 = 0; 
    public int coinsLevel1_9 = 0;
    public int coinsLevel10 = 0;

    public int coinsWorld1 = 0; //Coins collected in world 1

    public int highestUnlockedLevel = 1;

    public int audioSettings = 0; //Music and SFX(0), Only SFX(1), or no Sound option(2)

    public long timeToSubmitLevel1_1 = 0; //TimeInMiliseconds for Level 1 that still need to be submitted to the leaderboards
    public long timeToSubmitLevel1_2 = 0;
    public long timeToSubmitLevel1_3 = 0;
    public long timeToSubmitLevel1_4 = 0;
    public long timeToSubmitLevel1_5 = 0;
    public long timeToSubmitLevel1_6 = 0;
    public long timeToSubmitLevel1_7 = 0;
    public long timeToSubmitLevel1_8 = 0;
    public long timeToSubmitLevel1_9 = 0;
    public long timeToSubmitLevel10 = 0;

    public bool qualitySettings = true; //Quality settings true = high quality, false = low quality

    public bool dialogueBoxCoinsResetTimer = false; //Has this dialogue box(Coin's reset timer) been shown to the player? false = no | true = yes

    public bool dialogueBuyingNewLevels = false; //Has this dialogue box(Coin's reset timer) been shown to the player? false = no | true = yes

    public int language = 0; //This index represents a language in which the UI is displayed. English - 0, Chinese - 1, Spanish - 2, Portuguese - 3, Russian - 4, Japanese - 5, Turkish - 6, French - 7, German - 8, Dutch - 9, Estonian - 10
    //To ensure that 0 is indeed English, 1 is Chinese etc. The order of the languages should be the same as the languages listed under Project settings > Localization > Available locales
}
