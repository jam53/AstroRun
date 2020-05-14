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
        animator.SetTrigger("PlayerTouched");
        audioSource.Play();
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }

}