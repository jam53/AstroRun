using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AudioIntroAndLoop : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip Intro;
    public AudioClip Loop;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = Intro;
        audioSource.loop = false;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && Time.timeSinceLevelLoad > 2)
        {
            audioSource.clip = Loop;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
