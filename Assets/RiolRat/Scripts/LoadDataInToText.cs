using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadDataInToText : MonoBehaviour
{
    public TextMeshProUGUI TextObject;
    public string AdittionalText;
    public int KeyIndex;

    // Start is called before the first frame update
    void Start()
    {
        if (AdittionalText == null)
        {
            AdittionalText = "";
        }
        TextObject.text = GPGSAutenthicator.GPGSZelf.LoadString(KeyIndex) + AdittionalText;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
