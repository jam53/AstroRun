using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    public int avgFrameRate;
    public TextMeshProUGUI display_TextFPS;
    public TextMeshProUGUI display_TextMaxFPS;

    private int MaxFPS = 0;

    public void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        display_TextFPS.text = avgFrameRate.ToString() + " FPS";
        if (MaxFPS < avgFrameRate)
        {
            MaxFPS = avgFrameRate;
            display_TextMaxFPS.text = "MAX " + MaxFPS.ToString() + " FPS";
        }
    }
}