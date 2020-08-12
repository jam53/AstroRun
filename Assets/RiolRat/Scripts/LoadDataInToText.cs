using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadDataInToText : MonoBehaviour
{
    public TextMeshProUGUI TextObject;
    public string AdittionalText;
    public int KeyIndex;

    public bool LevelTimeButton;

    // Start is called before the first frame update
    void Start()
    {
        if (AdittionalText == null)
        {
            AdittionalText = "";
        }
        TextObject.text = GPGSAutenthicator.GPGSZelf.LoadString(KeyIndex) + AdittionalText;

        if (LevelTimeButton && GPGSAutenthicator.GPGSZelf.LoadString(KeyIndex) == "99:99:99")
        {
            TextObject.text = "No Time";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
