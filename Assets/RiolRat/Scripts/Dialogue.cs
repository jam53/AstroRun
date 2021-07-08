using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string title; //Title of the dialogue box

    [TextArea(3, 10)]
    public string[] sentences; //Content of the dialogue box


}
