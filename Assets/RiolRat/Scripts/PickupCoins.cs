using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class PickupCoins : MonoBehaviour
{
    public int KeyIndex;
    public int KeyIndexWorld;

    public TextMeshProUGUI CoinsText;

    private int Coins;

    public AudioClip CoinGeluid;
    public AudioSource Source;

    public GameObject CoinsHolder;
    private int amountOfCoins;

    private void Start()
    {
        amountOfCoins = CoinsHolder.transform.childCount;

        for (int i = 0; i < Convert.ToInt32(GPGSAutenthicator.GPGSZelf.LoadString(KeyIndex)); i++)
        {
            int randomChildIdx = UnityEngine.Random.Range(0, CoinsHolder.transform.childCount);
            Transform randomChild = CoinsHolder.transform.GetChild(randomChildIdx);
            //Destroy(randomChild.gameObject);
            if (randomChild.gameObject.activeInHierarchy == true)
            {
                randomChild.gameObject.SetActive(false);

            }

            else
            {
                i--;
            }
        }

        Coins = Convert.ToInt32(GPGSAutenthicator.GPGSZelf.LoadString(KeyIndex));
        CoinsText.text = Convert.ToString(Coins) + "/" + amountOfCoins.ToString();
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
            GPGSAutenthicator.GPGSZelf.SaveString(4, Convert.ToString(Convert.ToInt32(GPGSAutenthicator.GPGSZelf.LoadString(4)) + 1));// Total coins +1
            GPGSAutenthicator.GPGSZelf.SaveString(KeyIndex, Convert.ToString(Convert.ToInt32(GPGSAutenthicator.GPGSZelf.LoadString(KeyIndex)) + 1));// Level coins +1
            GPGSAutenthicator.GPGSZelf.SaveString(KeyIndexWorld, Convert.ToString(Convert.ToInt32(GPGSAutenthicator.GPGSZelf.LoadString(KeyIndexWorld)) + 1));// World coins +1
        }
        
    }
}