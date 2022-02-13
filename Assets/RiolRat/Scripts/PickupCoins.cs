using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class PickupCoins : MonoBehaviour
{
    public string keyName;
    public string keyNameWorld;

    public TextMeshProUGUI CoinsText;

    private int Coins;

    public AudioClip CoinGeluid;
    public AudioSource Source;

    public GameObject CoinsHolder;
    private int amountOfCoins;

    private void Start()
    {
        amountOfCoins = CoinsHolder.transform.childCount;
        
        for (int i = 0; i < (int)typeof(AstroRunData).GetField(keyName).GetValue(SaveLoadManager.slm.astroRunData) ; i++)
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

        Coins = (int)typeof(AstroRunData).GetField(keyName).GetValue(SaveLoadManager.slm.astroRunData);
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
            CoinsText.text = Convert.ToString(Coins) +"/" + amountOfCoins.ToString();

            SaveLoadManager.slm.astroRunData.totalCoins += 1; //Total coins +1

            switch (keyName)
            {//Increase the coins for this level by one
                case "coinsLevel1_1":
                    SaveLoadManager.slm.astroRunData.coinsLevel1_1 += 1;
                    break;

                case "coinsLevel1_2":
                    SaveLoadManager.slm.astroRunData.coinsLevel1_2 += 1;
                    break;

                case "coinsLevel1_3":
                    SaveLoadManager.slm.astroRunData.coinsLevel1_3 += 1;
                    break;

                case "coinsLevel1_4":
                    SaveLoadManager.slm.astroRunData.coinsLevel1_4 += 1;
                    break;

                case "coinsLevel1_5":
                    SaveLoadManager.slm.astroRunData.coinsLevel1_5 += 1;
                    break;

                case "coinsLevel1_6":
                    SaveLoadManager.slm.astroRunData.coinsLevel1_6 += 1;
                    break;

                case "coinsLevel1_7":
                    SaveLoadManager.slm.astroRunData.coinsLevel1_7 += 1;
                    break;

                case "coinsLevel1_8":
                    SaveLoadManager.slm.astroRunData.coinsLevel1_8 += 1;
                    break;

                case "coinsLevel1_9":
                    SaveLoadManager.slm.astroRunData.coinsLevel1_9 += 1;
                    break;

                case "coinsLevel10":
                    SaveLoadManager.slm.astroRunData.coinsLevel10 += 1;
                    break;

                default:
                    Debug.LogWarning("Couldn't increment amount of coins collected for level: " + keyName);
                    break;
            }

            switch (keyNameWorld)
            {//Increase the coins for this world by one
                case "coinsWorld1":
                    SaveLoadManager.slm.astroRunData.coinsWorld1 += 1;
                    break;

                default:
                    Debug.LogWarning("Couldn't increment amount of coins collected for world: " + keyNameWorld);
                    break;
            }

            SaveLoadManager.slm.SaveJSONToDisk();
        }
        
    }

    public int getAmountOfCoins()
    {
        return Coins;
    }
}