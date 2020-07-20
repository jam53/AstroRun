using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class PickupCoins : MonoBehaviour
{
    public TextMeshProUGUI CoinsText;

    private int Coins;

    public AudioClip CoinGeluid;
    public AudioSource Source;

    public GameObject CoinsHolder;
    private int amountOfCoins;

    private void Start()
    {
        amountOfCoins = CoinsHolder.transform.childCount;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters the trigger zone...
        if (other.tag == "Coin")
        {
            Destroy(other.transform.parent.gameObject);
            // Destroy the crate.
            Source.clip = CoinGeluid;
            Source.Play();
            Coins++;
            Debug.Log("Player has: " + Coins + " coins.");
            CoinsText.text = Convert.ToString(Coins) +"/" + amountOfCoins.ToString();
        }
        
    }

}