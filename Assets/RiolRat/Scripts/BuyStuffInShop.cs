using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuyStuffInShop : MonoBehaviour
{
    [Header("Buying new level")]
    public int AmountOfLevels;//The amount of levels that are currently in the game
    public int PricePerLevel;
    public TextMeshProUGUI TotalCoins;//Displayed at the right upper corner of the screen, how many coins the user has
    public LevelSelection LevelSelectionWorld1;//Used to update the buttons on the level selection screen, after a new level has been purchased
    public int buttonIndex;//This gets updated through ShopVierkant. This way we will know what button the user clicked, and  
    //what action we should perform. e.g. show an ad, or unlock a new level, ..

    public void CheckWhatBuyActionToPerform()//This gets called from the buy button. This way we know what image/action was selected that we want to buy
    {
        switch (buttonIndex)
        {
            case 0:
                //Perfrom an action to watch an ad
                Debug.Log("Watch an ad");
                break;

            case 1:
                //Perform an action in order to pay x coins to refill your hearts
                Debug.Log("Pay x coins to refill your hearts");
                break;

            case 2:
                //Perform an action in order to pay 0.99 euros to receive unlimited hearts
                Debug.Log("Pay 0.99 euros to recieve unlimited hearts");
                break;

            case 3: //Unlock one new level
                UnlockOneLevel();
                break;
        }
    }

    private void UnlockOneLevel()
    {
        int HighestUnlockedLevel = SaveLoadManager.slm.astroRunData.highestUnlockedLevel;//The highest unlocked level by the user
        int UserBalance = SaveLoadManager.slm.astroRunData.totalCoins;//The amount of coins the user has

        Dialogue dialogue = new Dialogue();//Create a new dialogue to display information to the user
        string[] sentences = new string[1];


        if (HighestUnlockedLevel >= AmountOfLevels)//Check if the user already has unlocked all the levels
        {
            dialogue.title = "All levels unlocked";
            sentences[0] = "You have already unlocked every single level, more levels are coming soon!";
            dialogue.sentences = sentences;

            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();//Find the dialogue in the scene
            dialogueManager.StartDialogue(dialogue);//Show the dialogue
        }

        else if (HighestUnlockedLevel < AmountOfLevels && UserBalance < PricePerLevel)
        {
            dialogue.title = "Balance too low";
            sentences[0] = "You don't have enough coins, come back later when you have " + PricePerLevel.ToString() + " coins or more.";
            dialogue.sentences = sentences;

            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();//Find the dialogue in the scene
            dialogueManager.StartDialogue(dialogue);//Show the dialogue
        }

        else if (HighestUnlockedLevel < AmountOfLevels && UserBalance >= PricePerLevel)
        {
            SaveLoadManager.slm.astroRunData.highestUnlockedLevel = HighestUnlockedLevel + 1; //Unlock one level
            SaveLoadManager.slm.astroRunData.totalCoins = UserBalance - PricePerLevel; //Deducted x coins from the users balance
            SaveLoadManager.slm.SaveJSONToDisk();

            TotalCoins.text = "" + SaveLoadManager.slm.astroRunData.totalCoins; //Update the User's coins in the UI

            LevelSelectionWorld1.EnableHighestUnlockedLevel();//Update the level selection screen, so that the new level is unlocked


            #region Logic to show a dialogue to inform user about the purchase

            dialogue.title = "Unlocked level " + (HighestUnlockedLevel + 1).ToString();
            sentences[0] = "You have now unlocked level " + (HighestUnlockedLevel + 1).ToString() + " for " + PricePerLevel.ToString() + " coins.";
            dialogue.sentences = sentences;

            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();//Find the dialogue in the scene
            dialogueManager.StartDialogue(dialogue);//Show the dialogue
            #endregion
        }
    }
}
