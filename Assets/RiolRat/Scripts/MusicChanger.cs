using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public AudioSource BackgroundSource;
    public AudioClip EndMusic;
    public Rigidbody2D Player;

    private bool AchtergrondMuziekSpeelt = false;

    // Start is called before the first frame update
    void Start()
    {

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
        }
    }

}
