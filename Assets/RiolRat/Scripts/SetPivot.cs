using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPivot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<RectTransform>().pivot = new Vector2(-0.39f, 0.5f);
        //Zodat de tekst gecentreerd komt te staan
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
