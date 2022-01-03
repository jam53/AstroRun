using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadDataInToText : MonoBehaviour
{
    public TextMeshProUGUI TextObject;
    public string additionalText;
    public string keyName;

    
    // Start is called before the first frame update
    void Start()
    {
        if (additionalText == null)
        {
            additionalText = "";
        }
        
        TextObject.text = typeof(AstroRunData).GetField(keyName).GetValue(SaveLoadManager.slm.astroRunData) + additionalText;
    }
}
