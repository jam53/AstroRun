using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public string ActivatorTag;

    public GameObject[] Objects;

    private bool activated;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject gameObject in Objects)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == ActivatorTag && !activated)
        {
            foreach (var item in Objects)
            {
                item.SetActive(true);
            }

            activated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ActivatorTag)
        {
            foreach (var item in Objects)
            {
                item.SetActive(false);
            }

            activated = false;
        }
    }
}
