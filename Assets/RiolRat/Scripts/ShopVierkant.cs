using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopVierkant : MonoBehaviour
{
    public Image SelectedCharacter;
    public TextMeshProUGUI Price;
    public TextMeshProUGUI Description;

    public GameObject[] Buttons;

    public Sprite[] CharacterThumbnails;
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
        int Counter = 0;
        foreach (var item in Buttons)
        {
            item.GetComponentInChildren<Image>().sprite = CharacterThumbnails[Counter];
            Counter++;
        }

        SelectedCharacter.sprite = CharacterThumbnails[0];
        Price.text = Prices[0];
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
        SelectedCharacter.sprite = CharacterThumbnails[buttonIndex];
        Price.text = Prices[buttonIndex].ToString();
        Description.text = Descriptions[buttonIndex];
    }
}
