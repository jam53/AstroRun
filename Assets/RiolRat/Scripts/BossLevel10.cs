using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel10 : MonoBehaviour
{
    public GameObject upDownSpikesHolder;
    private Transform[] upDownSpikes;

    // Start is called before the first frame update
    void OnEnable()
        //Note: Keep in mind that Domain reloading is disabled in project settings > play mode. This was done to enter play mode inside the editor.
        //This does however cause scripts that use LeanTween to have some issues. Objects will only be affected by LeanTween (in the editor )
        // by activating domain reloading under project settings. Or by making a change to a script and recompiling 
    {
        upDownSpikes = upDownSpikesHolder.GetComponentsInChildren<Transform>();

        for (int i = 1; i < upDownSpikes.Length; i += 4)
        {//We beginnen op 1, want het eerste element (0) in de array is de spike holder, en dus niet een spike
            LeanTween.moveY(upDownSpikes[i].gameObject, -4.77f, 1f).setLoopPingPong().setEase(LeanTweenType.easeInOutExpo);
            LeanTween.moveY(upDownSpikes[i+1].gameObject, -4.77f, 1f).setLoopPingPong().setEase(LeanTweenType.easeInOutExpo);
        }
        for (int i = 3; i < upDownSpikes.Length; i += 4)
        {
            LeanTween.moveY(upDownSpikes[i ].gameObject, -6.784f, 1).setLoopPingPong().setEase(LeanTweenType.easeInOutExpo);
            LeanTween.moveY(upDownSpikes[i + 1].gameObject, -6.784f, 1).setLoopPingPong().setEase(LeanTweenType.easeInOutExpo);
        }



    }

    public void upDownSpikesStage2()
    {
        //Wanneer de speler op de plek komt waar die ene coin staat, faze 2.
        //Met LeanTween of Unity animatie de spikes roteren naar onder toe
        //Dan met een van deze twee:
        //easeType = LeanTweenType.punch;
        //easeType = LeanTweenType.easeInOutElastic;
        //De spikes naar beneden laten gaan
        //De spikes gaan naar beneden als de speler langer dan een seconde stil staat/een spike gaat naar beneden als de speler er 1 seconde geleden onder stond
        //De rest van het pdf doc
        //Timeline gebruiken/zelf een gwn in script de camera moven. Best een apparte camera maken, en de camera die de speler volgt even uitschakelen
    }
}
