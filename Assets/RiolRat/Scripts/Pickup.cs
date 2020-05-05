using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player enters the trigger zone...
        if (other.tag == "Player")
        {
            // Destroy the crate.
            Destroy(gameObject);
            Debug.Log("You got 1 coin!");
        }
        
    }

}