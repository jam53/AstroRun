using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    public Animator BlackLevelFadeAnimator;
    public string NameSceneToLoad;

    public int LevelToUnlock;

    private Collider2D colllider;

    private bool levelCompleted;

    // Start is called before the first frame update
    void Start()
    {
        colllider = this.GetComponent<Collider2D>();
    }

    public void FadeToLevel ()
    {
        BlackLevelFadeAnimator.SetTrigger("FadeOut");
        StartCoroutine(OnFadeComplete());

    }
    IEnumerator OnFadeComplete()
    {
        //yield on a new YieldInstruction that waits for 1 seconds.
        yield return new WaitForSeconds(1);
        //we wachten 1 sec, omdat de animatie 1 sec duurt, we wachten dus totdat hij gedaan is

        SceneManager.LoadScene(NameSceneToLoad);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            levelCompleted = true;
            if (LevelToUnlock > SaveLoadManager.slm.astroRunData.highestUnlockedLevel)
            {
                SaveLoadManager.slm.astroRunData.highestUnlockedLevel = LevelToUnlock;
                SaveLoadManager.slm.SaveJSONToDisk();
            }
            colllider.enabled = false; // anders kan je blijven springen op de collider, en ga je mega hoog
            FadeToLevel();
        }
    }

    public bool getLevelCompleted()
    {
        return levelCompleted;
    }
}
