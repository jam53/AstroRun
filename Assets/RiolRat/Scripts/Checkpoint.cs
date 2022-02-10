using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Animator animator;

    public AudioClip clip;
    public AudioSource source;

    private Collider2D colllider;
    // Start is called before the first frame update
    void Start()
    {
        colllider = this.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetBool("CheckPointBereikt", true);
            colllider.enabled = false; // anders kan je blijven springen op de collider, en ga je mega hoog

            source.clip = clip;
            source.Play();
        }
    }
}
