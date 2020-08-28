using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountRecovery : MonoBehaviour
{
    public Button Continue;

    private float TimeStarted;
    private bool Reset;
    // Start is called before the first frame update
    void Start()
    {
        Reset = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Reset && (Time.timeSinceLevelLoad - TimeStarted) > 20)
        {
            Application.Quit();
            Debug.Log("Quitting for Account Recovery");
        }
    }

    public void Recover()
    {
        Continue.interactable = false;
        Reset = true;
        PlayerPrefs.DeleteAll();
        GPGSAutenthicator.GPGSZelf.OnStartUp();
        TimeStarted = Time.timeSinceLevelLoad;
    }
}
