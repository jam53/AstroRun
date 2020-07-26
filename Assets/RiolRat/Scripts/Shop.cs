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

    private int CurrentItem;

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
        CurrentItem++;
        Display.sprite = SkinThumbnail[CurrentItem];
        Price.text = SkinPrice[CurrentItem];
    }

    public void GoLeft()
    {
        CurrentItem--;
        Display.sprite = SkinThumbnail[CurrentItem];
        Price.text = SkinPrice[CurrentItem];
    }
}
