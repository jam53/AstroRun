﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class ShopVierkant : MonoBehaviour
{
    public BuyStuffInShop buyStuffInShop;//We access this script in order to change the value of what button the player clicked on.
    //This way we can know if the user wants to unlock a new lever, or watch an ad,etc.

    public Image SelectedCharacter;
    public TextMeshProUGUI Price;
    public TextMeshProUGUI PriceHighLighted;
    public TextMeshProUGUI Description;

    public GameObject BuyButton;

    public float[] YposSelectedCharacterImage;

    public GameObject[] Buttons;

    public Image[] CharacterThumbnails;
    private Color DefaultColor;

    public string[] Prices;
    public string[] Descriptions;


    // OnEnable is called every time the object gets enabled in the hierarchy
    void OnEnable()
    {
        DefaultColor = CharacterThumbnails[0].color;//Save the original color of the image/button

        CharacterThumbnails[0].color = Color.white;//Make the color of the image/button white so it makes it clear that it is clicked/selected

        SelectedCharacter.sprite = CharacterThumbnails[0].sprite;//Change the picture's sprite, to the first image/button in the array
        SelectedCharacter.transform.localScale = CharacterThumbnails[0].transform.localScale;//Choose the correct scale, according to the first image/button in the array

        Vector3 TempPosition = SelectedCharacter.rectTransform.anchoredPosition;
        TempPosition.y = YposSelectedCharacterImage[0];
        SelectedCharacter.rectTransform.anchoredPosition = TempPosition;//Put it on the correct height, according to the first image/button in the array

        Price.text = LocalizeString(Prices[0]);//Put the correct price from the first image/button in the array
        PriceHighLighted.text = LocalizeString(Prices[0]);//Put the correct price from the first image/button in the array
        Description.text = LocalizeString(Descriptions[0]);//Put the correct description from the first image/button in the array

        buyStuffInShop.buttonIndex = 0; //Update the currently selected buttons
    }


    public void ChangeCharacter (int buttonIndex)//Change the main image
    {
        buyStuffInShop.buttonIndex = buttonIndex;//Update what button the user has clicked on, in the BuyStuffInShop script. That way that script 
        //knows what action it should perform. AKA what the user wants to buy, an ad, a new level, etc.

        foreach (var sprite in CharacterThumbnails)
        {
            sprite.color = DefaultColor;//Change the images back to their original color
        }

        CharacterThumbnails[buttonIndex].color = Color.white;//Change the clicked image/button to a white color

        SelectedCharacter.sprite = CharacterThumbnails[buttonIndex].sprite;//Change the pic pictures sprite, to corespond to the selected image/button
        SelectedCharacter.transform.localScale = CharacterThumbnails[buttonIndex].transform.localScale;//Choose the correct scale

        Vector3 TempPosition = SelectedCharacter.rectTransform.anchoredPosition;
        TempPosition.y = YposSelectedCharacterImage[buttonIndex];
        SelectedCharacter.rectTransform.anchoredPosition = TempPosition;//Put it on the correct height, as not all images are the same size

        Price.text = LocalizeString(Prices[buttonIndex].ToString());//Put the correct price
        PriceHighLighted.text = LocalizeString(Prices[buttonIndex].ToString());//Put the correct price
        BuyButton.SetActive(false);//We doen het eens aan en uit, zodat de grootte van de button wordt aangepast,
        BuyButton.SetActive(true); //Anders verandert de tekst, maar is de button zelf soms te klein

        Description.text = LocalizeString(Descriptions[buttonIndex]);//Put the correct description
    }

    private string LocalizeString(string key)
    {//https://forum.unity.com/threads/localizating-strings-on-script.847000/

        if(key[0] != '#')
        {//We only want to translate certain strings, strings that don't start with a '#', don't need to be translated
            return key;
        }

        var op = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("UI Text", key);
        if (op.IsDone)
            return op.Result;
        else
            op.Completed += (op) => Debug.LogWarning(op.Result);
        return "Couldn't get translation for key: " + key;
    }
}
