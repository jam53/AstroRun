using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    //public Image Display;
    //public TextMeshProUGUI Price;

    //public Sprite[] SkinThumbnail;
    //public string[] SkinPrice;

    //public GameObject Coins;
    //public GameObject Owned_Text;

    //private int CurrentItem;

    //public bool Owned;

    // Start is called before the first frame update
    void Start()
    {
        //CurrentItem = 0;
        //Display.sprite = SkinThumbnail[CurrentItem];
        //Price.text = SkinPrice[CurrentItem];

        DefaultColor = CharacterThumbnails[0].color;//Save the original color of the image/button

        //int Counter = 0;
        //foreach (var item in Buttons)
        //{
        //    item.GetComponentInChildren<Image>().sprite = CharacterThumbnails[Counter].sprite;
        //    Counter++;
        //}

        CharacterThumbnails[0].color = Color.white;//Make the color of the image/button white so it makes it clear that it is clicked/selected

        SelectedCharacter.sprite = CharacterThumbnails[0].sprite;//Change the picture's sprite, to the first image/button in the array
        SelectedCharacter.transform.localScale = CharacterThumbnails[0].transform.localScale;//Choose the correct scale, according to the first image/button in the array

        Vector3 TempPosition = SelectedCharacter.rectTransform.anchoredPosition;
        TempPosition.y = YposSelectedCharacterImage[0];
        SelectedCharacter.rectTransform.anchoredPosition = TempPosition;//Put it on the correct height, according to the first image/button in the array

        Price.text = Prices[0];//Put the correct price from the first image/button in the array
        PriceHighLighted.text = Prices[0];//Put the correct price from the first image/button in the array
        Description.text = Descriptions[0];//Put the correct description from the first image/button in the array

        buyStuffInShop.buttonIndex = 0; //Update the currently selected buttons
    }

    //public void GoRight()
    //{
    //    if (CurrentItem == SkinThumbnail.Length - 1)
    //    {
    //        CurrentItem = 0;
    //        Display.sprite = SkinThumbnail[CurrentItem];
    //        Price.text = SkinPrice[CurrentItem];
    //    }

    //    else
    //    {
    //        CurrentItem++;
    //        Display.sprite = SkinThumbnail[CurrentItem];
    //        Price.text = SkinPrice[CurrentItem];
    //    }

    //    if (Owned)
    //    {
    //        Coins.SetActive(false);
    //        Owned_Text.SetActive(true);
    //    }

    //    else
    //    {
    //        Coins.SetActive(true);
    //        Owned_Text.SetActive(false);
    //    }
    //}

    //public void GoLeft()
    //{
    //    if (CurrentItem == 0)
    //    {
    //        CurrentItem = SkinThumbnail.Length - 1;
    //        Display.sprite = SkinThumbnail[CurrentItem];
    //        Price.text = SkinPrice[CurrentItem];
    //    }

    //    else
    //    {
    //        CurrentItem--;
    //        Display.sprite = SkinThumbnail[CurrentItem];
    //        Price.text = SkinPrice[CurrentItem];
    //    }

    //    if (Owned)
    //    {
    //        Coins.SetActive(false);
    //        Owned_Text.SetActive(true);
    //    }

    //    else
    //    {
    //        Coins.SetActive(true);
    //        Owned_Text.SetActive(false);
    //    }
    //}

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

        Price.text = Prices[buttonIndex].ToString();//Put the correct price
        PriceHighLighted.text = Prices[buttonIndex].ToString();//Put the correct price
        BuyButton.SetActive(false);//We doen het eens aan en uit, zodat de grootte van de button wordt aangepast,
        BuyButton.SetActive(true); //Anders verandert de tekst, maar is de button zelf soms te klein

        Description.text = Descriptions[buttonIndex];//Put the correct description
    }
}
