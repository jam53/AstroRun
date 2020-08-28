using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicIntroAndLoop : MonoBehaviour
{
    public AudioSource source;

    public AudioClip Intro;
    public AudioClip Loop;

    // Start is called before the first frame update
    void Start()
    {
        source.clip = Intro;
        source.loop = false;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            source.clip = Loop;
            source.loop = true;
            source.Play();
        }
    }
}
