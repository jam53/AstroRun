using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public string ActivatorTag;

    public bool DeactivateOnExit;

    public GameObject[] Objects;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in Objects)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ActivatorTag)
        {
            foreach (var item in Objects)
            {
                item.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ActivatorTag && DeactivateOnExit)
        {
            foreach (var item in Objects)
            {
                item.SetActive(false);
            }
        }
    }
}
