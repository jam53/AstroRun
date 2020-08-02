using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class _Test : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Saveee()
    {
        GPGSAutenthicator.GPGSZelf.SaveString("TestKKeyyy", text.text);
    }

    public void loaoaad()
    {
        text.text = GPGSAutenthicator.GPGSZelf.LoadString("TestKKeyyy");
    }

    public void INcrememennt()
    {
        text.text = (Convert.ToInt32(text.text)+ 1).ToString();
    }
}
