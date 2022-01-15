using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class AchievementsHandler : MonoBehaviour
{
    [Header("Achievement: At Full Speed")]
    public bool AtFullSpeed; //These are the name of the achievements, if it's set to true, this script will execute the logic to submit that achievement to google play
    public LevelTimer levelTimer;
    public NextLevelLoader nextLevelLoader;

    [Header("Achievement: Never Give Up")]
    public bool NeverGiveUp;
    public KillAndRespawn killAndRespawn;

    [Header("Achievement: HippityHop")]
    public bool HippityHop;
    public PlatformerCharacter2D platformerCharacter2D;
    public NextLevelLoader nextLevelLoader2;

    [Header("Achievement: Immortal")]
    public bool Immortal;
    public NextLevelLoader nextLevelLoader3;
    public KillAndRespawn killAndRespawn3;

    [Header("Achievement: MrMoneyBags")]
    public bool MrMoneyBags;
    public NextLevelLoader nextLevelLoader4;
    public PickupCoins pickupCoins;

    [Header("Achievement: Fashionista")]
    public bool Fashionista;


    // Update is called once per frame
    void Update()
    {
        if (AtFullSpeed && nextLevelLoader.getLevelCompleted() && levelTimer.getTimeCompleted() <= 35)
        {//If we are checking for the achievement 'AtFullSpeed' && the level has been completed && and the level was completed in less than 35 seconds
            GPGSAutenthicator.GPGSZelf.UnlockAtFullSpeed();
            AtFullSpeed = false;
        }

        if (NeverGiveUp && killAndRespawn.getAmountOfDeaths() >= 20)
        {//If we are checking for the achievement 'NeverGiveUp' && we died more than 20 times in the current level
            GPGSAutenthicator.GPGSZelf.UnlockNeverGiveUp();
            NeverGiveUp = false;
        }

        if (HippityHop && nextLevelLoader2.getLevelCompleted() && platformerCharacter2D.getTimesJumped() <= 8)
        {//If we are checking for the achievement 'HippityHop' && the level has been completed && and the level was completed using less than 9 jumps
            GPGSAutenthicator.GPGSZelf.UnlockHippityHop();
            HippityHop = false;
        }

        if (Immortal && nextLevelLoader3.getLevelCompleted() && killAndRespawn3.getAmountOfDeaths() <= 0)
        {//If we are checking for the achievement 'Immortal' && the level has been completed && and the level was completed with less than 8 deaths
            GPGSAutenthicator.GPGSZelf.UnlockImmortal();
            Immortal = false;
        }

        if (MrMoneyBags && nextLevelLoader4.getLevelCompleted())
        {//If we are checking for the achievement 'MrMoneyBags' && the level has been completed
            GPGSAutenthicator.GPGSZelf.IncrementMrMoneyBags(pickupCoins.getAmountOfCoins());
            MrMoneyBags = false;
        }
    }
}
