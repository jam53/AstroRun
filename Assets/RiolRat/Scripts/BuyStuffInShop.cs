using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class BuyStuffInShop : MonoBehaviour
{
    [Header("Buying new level")]
    public int AmountOfLevels;//The amount of levels that are currently in the game
    public int PricePerLevel;
    public TextMeshProUGUI TotalCoins;//Displayed at the right upper corner of the screen, how many coins the user has
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
            dialogue.title = LocalizeString("All levels unlocked");
            sentences[0] = LocalizeString("All Levels Already Unlocked");
            dialogue.sentences = sentences;

            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();//Find the dialogue in the scene
            dialogueManager.StartDialogue(dialogue);//Show the dialogue
        }

        else if (HighestUnlockedLevel < AmountOfLevels && UserBalance < PricePerLevel)
        {
            dialogue.title = LocalizeString("Balance too low");
            sentences[0] = LocalizeString("Not Enough Coins") + PricePerLevel.ToString() + " " + LocalizeString("coins");
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



            #region Logic to show a dialogue to inform user about the purchase

            dialogue.title = LocalizeString("DialogueUnlockedLevel") + (HighestUnlockedLevel + 1).ToString();
            sentences[0] = LocalizeString("DialogueYouHaveNowUnlockedLevel") + (HighestUnlockedLevel + 1).ToString();
            dialogue.sentences = sentences;

            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();//Find the dialogue in the scene
            dialogueManager.StartDialogue(dialogue);//Show the dialogue
            #endregion
        }
    }

    private string LocalizeString(string key)
    {//https://forum.unity.com/threads/localizating-strings-on-script.847000/
        var op = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("UI Text", key);
        if (op.IsDone)
            return op.Result;
        else
            op.Completed += (op) => Debug.LogWarning(op.Result);
        return "Couldn't get translation for key: " + key;
    }
}
