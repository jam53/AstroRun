using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpikeIfPlayerDetected : MonoBehaviour
{
    private Vector3 originalPositionParent;

    public Vector3 dropPositionParent;
    public bool ignoreX, ignoreY, ignoreZ; //The position entered for that axis will be ignored, and the value of the original position will be used
    
    public float dropDelay;
    public float dropTime;

    private bool moving;

    // Start is called before the first frame update
    void Start()
    {
        originalPositionParent = this.transform.parent.position;

        if (ignoreX)
        {
            dropPositionParent.x = originalPositionParent.x;
        }

        if (ignoreY)
        {
            dropPositionParent.y = originalPositionParent.y;
        }

        if (ignoreZ)
        {
            dropPositionParent.z = originalPositionParent.z;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(drop(dropDelay));
        }
    }

    private IEnumerator drop (float delay)
    {
        yield return new WaitForSeconds(delay);

        LeanTween.move(this.transform.parent.gameObject, dropPositionParent, dropTime).setLoopPingPong(1).setEase(LeanTweenType.easeInOutElastic);
    }
}
