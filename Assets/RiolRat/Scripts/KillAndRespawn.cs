using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class KillAndRespawn : MonoBehaviour
{
    public bool ReloadScene;
    public bool PutPlayerBackToSpawnPoint;

    public float DeathTime;//The amount of time the player is unable to move, and is put in the death animation
    //----------------------------public AudioClip DeathSound;

    public Transform SpawnPoint;
    public Transform CheckPoint;

    private Animator PlayerAnimator;
    private Rigidbody2D rigidbodyy;

    public TextMeshProUGUI DeathCounter;
    public GameObject VirtualCamera;

    private bool ReachedCheckpoint = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = this.GetComponent<Animator>();
        rigidbodyy = this.GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Flag")
        {
            ReachedCheckpoint = true;
        }

        if (collision.tag == "DoesDamage" && PlayerAnimator.GetBool("Alive"))
        {
            StartCoroutine(FreezePlayer());
        }
    }

    public void RespawnPauseMenu ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //if (ReloadScene == true)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}

        //else if (PutPlayerBackToSpawnPoint == true && !ReachedCheckpoint)
        //{
        //    this.transform.position = SpawnPoint.position + new Vector3(0, 1, 0);
        //    VirtualCamera.gameObject.SetActive(false);
        //    VirtualCamera.gameObject.SetActive(true);
        //}

        //else if (PutPlayerBackToSpawnPoint == true && ReachedCheckpoint)
        //{
        //    this.transform.position = CheckPoint.position + new Vector3(0, 1, 0);
        //    VirtualCamera.gameObject.SetActive(false);
        //    VirtualCamera.gameObject.SetActive(true);
        //}
    }

    private IEnumerator FreezePlayer()
    {
        PlayerAnimator.SetTrigger("Died"); //This will enable the entire death animation
        PlayerAnimator.SetBool("Alive", false); //Until this is set to true, we will stay on the last frame of the death animation

        this.GetComponent<Platformer2DUserControl>().enabled = false;//disable the abilty to receive input from the user
                                                                     //This however isn't enough. We also need to freeze the location, other wise the player keeps moving, if it died while moving.

        rigidbodyy.constraints = RigidbodyConstraints2D.FreezePositionX; //Freeze the player's position
        //.................................................................We don't freeze the Y, since other wise the player would get stuck in the air, if he/she dies mid air

        //----------------------------this.GetComponent<AudioSource>().clip = DeathSound;
        //----------------------------this.GetComponent<AudioSource>().Play();

        //Wait until the death animation is complete, before continuing to the next part of code
        yield return new WaitForSeconds(DeathTime);

        RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        if (ReloadScene == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        else if (PutPlayerBackToSpawnPoint == true && !ReachedCheckpoint)
        {
            this.transform.position = SpawnPoint.position + new Vector3(0, 1, 0);
            VirtualCamera.gameObject.SetActive(false);
            VirtualCamera.gameObject.SetActive(true);
            DeathCounter.text = (Convert.ToInt32(DeathCounter.text) + 1).ToString();
        }

        else if (PutPlayerBackToSpawnPoint == true && ReachedCheckpoint)
        {
            this.transform.position = CheckPoint.position + new Vector3(0, 1, 0);
            VirtualCamera.gameObject.SetActive(false);
            VirtualCamera.gameObject.SetActive(true);
            DeathCounter.text = (Convert.ToInt32(DeathCounter.text) + 1).ToString();
        }

        UnFreezePlayer();
    }

    private void UnFreezePlayer()
    {
        PlayerAnimator.SetBool("Alive", true); //If this gets set to true, we go back to the idle animation

        this.GetComponent<Platformer2DUserControl>().enabled = true;//enable the abilty to receive input from the user

        rigidbodyy.constraints = RigidbodyConstraints2D.None; //Unfreeze the player, but also unfreezes the rotation
        rigidbodyy.constraints = RigidbodyConstraints2D.FreezeRotation; //ReFreeze the rotation

        this.transform.rotation = Quaternion.identity;//During the death animation, the rotation of the character changes, because we fall onto the surface. But if we respawn we want to stand straight up, so we put the rotation to x=y=z=0 here
    }
}
