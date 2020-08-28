using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoIntroAndLoop : MonoBehaviour
{
    public VideoPlayer player1;
    public VideoPlayer player2;

    public VideoClip Intro;
    public VideoClip Loop;

    // Start is called before the first frame update
    void Start()
    {
        player1.clip = Intro;
        player1.isLooping = false;
        //player1.Play(); Already plays in awake, set in inspector

        player2.clip = Loop;
        player2.isLooping = true;
        player2.Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player1.isPlaying && Time.timeSinceLevelLoad > 2)
        {
            player2.Play();
            player2.renderMode = VideoRenderMode.CameraNearPlane;
        }
    }
}
