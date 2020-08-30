using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCoins : MonoBehaviour
{
    private DateTime _lastAdTime = DateTime.MinValue;

    // Start is called before the first frame update
    void Start()
    {
        _lastAdTime.AddDays(1);
        Debug.Log(_lastAdTime);
        Debug.Log(_lastAdTime = DateTime.Now);
        Debug.Log(_lastAdTime.AddDays(1));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SellMeStuff()
    {
        if (_lastAdTime.AddDays(1) > DateTime.Now)
        {
            Debug.Log("Buy from me, please?");
            // Store for next time
            _lastAdTime = DateTime.Now;
        }
    }
}
