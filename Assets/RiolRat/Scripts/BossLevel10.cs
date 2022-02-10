using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel10 : MonoBehaviour
{
    [Header("Stage 1: Moving spikes")]
    public GameObject upDownSpikesHolder;
    private List<GameObject> upDownSpikes;


    [Header("Stage 2: Moving acid")]
    public GameObject acidMoving;
    public Vector3 acidMoveUnitsPerSecond;

    private Vector3 acidMovingStartPosition;
    private bool resetAcidPosition;

    // Start is called before the first frame update
    void OnEnable()
        //Note: Keep in mind that Domain reloading is disabled in project settings > play mode. This was done to enter play mode inside the editor.
        //This does however cause scripts that use LeanTween to have some issues. Objects will only be affected by LeanTween (in the editor )
        // by activating domain reloading under project settings. Or by making a change to a script and recompiling 
    {
        foreach (Transform transform in upDownSpikesHolder.GetComponentInChildren<Transform>())
        {//Get all the child gameobjects
            if (transform != this.gameObject.transform)
            {
                upDownSpikes.Add(transform.gameObject);
            }
        }

        for (int i = 0; i < upDownSpikes.Count; i += 4)
        {//We beginnen op 1, want het eerste element (0) in de array is de spike holder, en dus niet een spike
            LeanTween.moveY(upDownSpikes[i], -4.77f, 1f).setLoopPingPong().setEase(LeanTweenType.easeInOutExpo);
            LeanTween.moveY(upDownSpikes[i+1], -4.77f, 1f).setLoopPingPong().setEase(LeanTweenType.easeInOutExpo);
        }
        for (int i = 2; i < upDownSpikes.Count; i += 4)
        {
            LeanTween.moveY(upDownSpikes[i ], -6.784f, 1).setLoopPingPong().setEase(LeanTweenType.easeInOutExpo);
            LeanTween.moveY(upDownSpikes[i + 1], -6.784f, 1).setLoopPingPong().setEase(LeanTweenType.easeInOutExpo);
        }

    }

    private void Start()
    {
        acidMovingStartPosition = acidMoving.transform.position;
    }

    private void Update()
    {
        if (resetAcidPosition)
        {
            acidMoving.transform.position = acidMovingStartPosition;
            resetAcidPosition = false;
        }
        else if (acidMoving.transform.position.y <= -3.2)
        {
            acidMoving.transform.Translate(acidMoveUnitsPerSecond * Time.deltaTime, Space.World);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.position.y <= -6 && collision.gameObject.transform.position.y >= - 11 && collision.CompareTag("Player"))
        {//Check if this is the collider that is used for the spikes' movement && if it's the player touching the collider
            LeanTween.cancelAll(); //Stop the spikes from going up and down
            
            foreach (GameObject spike in upDownSpikes)
            {
                LeanTween.moveY(spike, -6.6f, 0.5f); //Move the spikes to the correct height, just under the ground
                LeanTween.rotateZ(spike, 180f, 0.5f).setDelay(0.5f); //Flip the spike, so it faces down
                LeanTween.moveY(spike, -5.45f, 0.5f).setDelay(1f); //Move the spikes a bit up, so they are under the ground
                StartCoroutine(enableDropSpike(spike));
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.transform.position.y < -25 && collision.CompareTag("Player"))
        {//Check if this is the collider that is used for the acidMoving gameobject's movement && if it's the player touching the collider
            resetAcidPosition = true;
        }
    }

    private IEnumerator enableDropSpike(GameObject spike)
    {
        yield return new WaitForSeconds(1);

        spike.GetComponentInChildren<DropSpikeIfPlayerDetected>().enabled = true;
        spike.GetComponentInChildren<BoxCollider2D>().enabled = true;
    }
}
