using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class PickupCoins : MonoBehaviour
{
    public TextMeshProUGUI CoinsText;

    private int Coins;

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters the trigger zone...
        if (other.tag == "Coin")
        {
            // Destroy the crate.
            Destroy(other.gameObject);
            Coins++;
            Debug.Log("Player has: " + Coins + " coins.");
            CoinsText.text = Convert.ToString(Coins);
        }
        
    }

}