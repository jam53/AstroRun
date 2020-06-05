using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Trampoline : MonoBehaviour
{
    public int speed;
    public Animator animator;
    public AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("PlayerTouched");
        audioSource.Play();
    }

    // We hebben een oncollision en een ontrigger. 
    // Want als we enkel oncollision doen, en de player sprint tussen 2 springs, dan gaat hij dubbel zo hoog
    // Dus één spring als enige heeft een collider is trigger false heeft staan.
    // Deze geeft de boost, hij heeft ook nog een collider met istrigger zoals alle anderen
    // En dat zorgt voor de animatie

}