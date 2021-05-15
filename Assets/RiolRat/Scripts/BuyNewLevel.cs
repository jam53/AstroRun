using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuyNewLevel : MonoBehaviour
{
    public int AmountOfLevels;

    public int PricePerLevel;

    public TextMeshProUGUI TotalCoins;

    public LevelSelection LevelSelection;

    public Image SlechteTijdelijkeOplossing;//We kijken als de kleur van de "buy a level up ding" wit is en niet deels transparant.
    //als het wit is, wil dat zeggen dat de speler dat geselcteerd heeft
    //en alleen als de speler de level up button ding heeft geselecteerd
    //mag er een nieuw level unlocked worden, anders kan de speler op bijvoorbeeld, "bekijk een advertentie" klikken
    //en toch nog een level kopen, omdat dezelfde button gebruikt wordt voor de 4 items

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UnlockOneLevel()
    {
        int HighestUnlockedLevel = GPGSAutenthicator.GPGSZelf.LoadInt(10);//The highest unlocked level by the user
        int UserBalance = GPGSAutenthicator.GPGSZelf.LoadInt(4);//The amount of coins the user has

        if (HighestUnlockedLevel >= AmountOfLevels)//Check if the user already has unlocked all the levels
        {
            
        }

        else if (HighestUnlockedLevel < AmountOfLevels && UserBalance < PricePerLevel)
        {
            
        }

        else if (HighestUnlockedLevel < AmountOfLevels && UserBalance >= PricePerLevel && SlechteTijdelijkeOplossing.color == Color.white)
        {
            GPGSAutenthicator.GPGSZelf.Save(10, HighestUnlockedLevel + 1);//Unlock one level
            GPGSAutenthicator.GPGSZelf.Save(4, UserBalance - PricePerLevel);//Deducted x coins from the users balance

            TotalCoins.text = GPGSAutenthicator.GPGSZelf.LoadString(4);//Update the User's coins in the UI

            LevelSelection.EnableHighestUnlockedLevel();//Update the level selection screen, so that the new level is unlocked
        }
    }
}
