using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public Image Display;
    public TextMeshProUGUI Price;

    public Sprite[] SkinThumbnail;
    public string[] SkinPrice;

    public GameObject Coins;
    public GameObject Owned_Text;

    private int CurrentItem;

    public bool Owned;

    // Start is called before the first frame update
    void Start()
    {
        CurrentItem = 0;
        Display.sprite = SkinThumbnail[CurrentItem];
        Price.text = SkinPrice[CurrentItem];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoRight()
    {
        if (CurrentItem == SkinThumbnail.Length - 1)
        {
            CurrentItem = 0;
            Display.sprite = SkinThumbnail[CurrentItem];
            Price.text = SkinPrice[CurrentItem];
        }

        else
        {
            CurrentItem++;
            Display.sprite = SkinThumbnail[CurrentItem];
            Price.text = SkinPrice[CurrentItem];
        }

        if (Owned)
        {
            Coins.SetActive(false);
            Owned_Text.SetActive(true);
        }

        else
        {
            Coins.SetActive(true);
            Owned_Text.SetActive(false);
        }
    }

    public void GoLeft()
    {
        if (CurrentItem == 0)
        {
            CurrentItem = SkinThumbnail.Length - 1;
            Display.sprite = SkinThumbnail[CurrentItem];
            Price.text = SkinPrice[CurrentItem];
        }

        else
        {
            CurrentItem--;
            Display.sprite = SkinThumbnail[CurrentItem];
            Price.text = SkinPrice[CurrentItem];
        }

        if (Owned)
        {
            Coins.SetActive(false);
            Owned_Text.SetActive(true);
        }

        else
        {
            Coins.SetActive(true);
            Owned_Text.SetActive(false);
        }
    }
}
