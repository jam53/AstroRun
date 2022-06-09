using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public Image display;
    public GameObject unOwned_Text;
    public GameObject owned_Text;

    public Sprite[] skinThumbnail;
    public int pricePerSkin;

    public TextMeshProUGUI totalCoins_Text; //The amount of coins the user has, in the right upper corner of the screen
    public TextMeshProUGUI totalCoinsShop_Text; //The amount of coins the user has, in the right upper corner of the screen
    
    private int selectedSkin;

    // Start is called before the first frame update
    void Start()
    {
        unOwned_Text.GetComponentInChildren<TextMeshProUGUI>().text = "" + pricePerSkin;

        loadSkin(SaveLoadManager.slm.astroRunData.selectedSkin);
    }

    /**
     * This method will show the thumbnail of the skin and a buy button/equip button depending on whether or not the skin is owned by the player
     */
    private void loadSkin(int idSkinToLoad)
    {
        selectedSkin = idSkinToLoad;

        display.sprite = skinThumbnail[idSkinToLoad];

        List<int> ownedSkins = SaveLoadManager.slm.astroRunData.ownedSkins;
        unOwned_Text.SetActive(!ownedSkins.Contains(idSkinToLoad));
        owned_Text.SetActive(ownedSkins.Contains(idSkinToLoad));

        owned_Text.GetComponentInChildren<TextMeshProUGUI>().text =
            idSkinToLoad == SaveLoadManager.slm.astroRunData.selectedSkin ? LocalizeString("Equipped") : LocalizeString("Equip");
    }

    /**
     * This method gets called, when the user clicks on the buy button under a skin.
     * This deducts the price of the skin, from the player's coin balance. And adds the skin to their account
     */
    public void buySkin()
    {
        int userBalance = SaveLoadManager.slm.astroRunData.totalCoins; //The amount of coins the user has

        Dialogue dialogue = new Dialogue(); //Create a new dialogue to display information to the user
        string[] sentences = new string[1];


        if (userBalance < pricePerSkin)
        {
            dialogue.title = LocalizeString("Balance too low");
            sentences[0] = LocalizeString("Not Enough Coins") + pricePerSkin + " " + LocalizeString("coins");
            dialogue.sentences = sentences;

            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
            dialogueManager.StartDialogue(dialogue); //Show the dialogue
        }

        else if (userBalance >= pricePerSkin)
        {
            SaveLoadManager.slm.astroRunData.totalCoins -= pricePerSkin;
            SaveLoadManager.slm.astroRunData.ownedSkins.Add(selectedSkin);
            SaveLoadManager.slm.SaveJSONToDisk();

            totalCoins_Text.text = "" + SaveLoadManager.slm.astroRunData.totalCoins; //Update the User's coins in the UI
            totalCoinsShop_Text.text = "" + SaveLoadManager.slm.astroRunData.totalCoins; //Update the User's coins in the UI

            loadSkin(selectedSkin);
        }
    }

    /**
     * This method gets called when the user clicks on the equip button of a skin they own.
     */
    public void equipSkin()
    {
        SaveLoadManager.slm.astroRunData.selectedSkin = selectedSkin;
        SaveLoadManager.slm.SaveJSONToDisk();
        
        loadSkin(selectedSkin);
    }

    /**
     * This method will preview the skin that is `changeDifference` indexes further/back in the array of skins
     */
    public void changePreviewedSkin(int changeDifference)
    {
        int skinToPreview = mod(selectedSkin + changeDifference, skinThumbnail.Length);
        
        loadSkin(skinToPreview);
    }
    
    /*
     * An implementation of %, that works correctly with negative numbers
     */
    private int mod(int x, int m) 
    {
        return (x%m + m)%m;
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
