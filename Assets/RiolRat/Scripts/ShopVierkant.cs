using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopVierkant : MonoBehaviour
{
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

        DefaultColor = CharacterThumbnails[0].color;

        //int Counter = 0;
        //foreach (var item in Buttons)
        //{
        //    item.GetComponentInChildren<Image>().sprite = CharacterThumbnails[Counter].sprite;
        //    Counter++;
        //}

        CharacterThumbnails[0].color = Color.white;

        SelectedCharacter.sprite = CharacterThumbnails[0].sprite;
        SelectedCharacter.transform.localScale = CharacterThumbnails[0].transform.localScale;

        Vector3 TempPosition = SelectedCharacter.rectTransform.anchoredPosition;
        TempPosition.y = YposSelectedCharacterImage[0];
        SelectedCharacter.rectTransform.anchoredPosition = TempPosition;

        Price.text = Prices[0];
        PriceHighLighted.text = Prices[0];
        Description.text = Descriptions[0];
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void ChangeCharacter (int buttonIndex)
    {
        foreach (var sprite in CharacterThumbnails)
        {
            sprite.color = DefaultColor;
        }

        CharacterThumbnails[buttonIndex].color = Color.white;

        SelectedCharacter.sprite = CharacterThumbnails[buttonIndex].sprite;
        SelectedCharacter.transform.localScale = CharacterThumbnails[buttonIndex].transform.localScale;

        Vector3 TempPosition = SelectedCharacter.rectTransform.anchoredPosition;
        TempPosition.y = YposSelectedCharacterImage[buttonIndex];
        SelectedCharacter.rectTransform.anchoredPosition = TempPosition;
            
        Price.text = Prices[buttonIndex].ToString();
        PriceHighLighted.text = Prices[buttonIndex].ToString();
        BuyButton.SetActive(false);//We doen het eens aan en uit, zodat de grootte van de button wordt aangepast,
        BuyButton.SetActive(true); //Anders verandert de tekst, maar is de button zelf soms te klein

        Description.text = Descriptions[buttonIndex];
    }
}
