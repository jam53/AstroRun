using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public AudioSource BackgroundSource;
    public AudioClip EndMusic;

    private bool AchtergrondMuziekSpeelt = false;

    private Collider2D colllider;
    // Start is called before the first frame update
    void Start()
    {
        colllider = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !AchtergrondMuziekSpeelt)
        {
            BackgroundSource.clip = EndMusic;
            BackgroundSource.Play();
            AchtergrondMuziekSpeelt = true;
            colllider.enabled = false; // anders kan je blijven springen op de collider, en ga je mega hoog
        }
    }

}
