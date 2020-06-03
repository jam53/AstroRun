using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    public Animator animator;
    public string NameSceneToLoad;

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

    public void FadeToLevel ()
    {
        animator.SetTrigger("FadeOut");
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
            colllider.enabled = false; // anders kan je blijven springen op de collider, en ga je mega hoogs
            FadeToLevel();
        }
    }
}
