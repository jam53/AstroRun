using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel10 : MonoBehaviour
{
    [Header("Stage 1: Moving spikes")]
    public GameObject upDownSpikesHolder;
    private List<GameObject> upDownSpikes = new List<GameObject>();


    [Header("Stage 2: Moving acid")]
    public GameObject acidMoving;
    public Vector3 acidMoveUnitsPerSecond;

    private Vector3 acidMovingStartPosition;
    private bool resetAcidPosition;

    void OnEnable()
    {
        LeanTween.reset();

        foreach (Transform transform in upDownSpikesHolder.GetComponentInChildren<Transform>())
        {//Get all the child gameobjects
            if (transform != this.gameObject.transform)
            {
                upDownSpikes.Add(transform.gameObject);
            }
        }

        for (int i = 0; i < upDownSpikes.Count; i += 4)
        {
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
