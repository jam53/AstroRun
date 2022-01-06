using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ApplyImageColorToText : MonoBehaviour
{//The default button in Unity only allows us to change the color of one gameobject when hovered, pressed etc.
    //But if you have a button with both an image & text, only one of those can change color
    //This script then applies the color changes from the button, to both the image gameobject and to the text gameobject

    public Button button;
    public Image image;
    public TextMeshProUGUI text;

    public void applyPressedColor()
    {
        image.color = button.colors.pressedColor;
        text.color = button.colors.pressedColor;
    }

    public void applyNormalColor()
    {
        image.color = button.colors.normalColor;
        text.color = button.colors.normalColor;
    }
}
