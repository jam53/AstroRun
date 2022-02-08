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

    private int amountOfDeaths;

    public TextMeshProUGUI DeathCounter;
    public GameObject VirtualCamera;

    private bool ReachedCheckpoint = false;

    //This list doesn't need to be public
    //But if we put it to private it doesn't work on line 'ActivationCircleColliders.Add(objectActivator.gameObject.GetComponent<CircleCollider2D>());'
    public List<CircleCollider2D> ActivationCircleColliders;//This is a list of all the CircleCollider2D objects in the scene, that are used for detecting
    //Whether or not the player is in the range of that object. If the player isn't in range, that object gets disabled to save on resources.
    //This however, leads to a bug. If the player dies and respanws within the radius of one of those CircleCollider2Ds.
    //Then the object will get deactivated when the player dies, cuz the script sees that the player left the detection area AKA the CircleCollider2D
    //But because the player immediately gets respawned within that CircleCollider2D, it doesn't detect that the player has entered the detection area.
    //And therefore doesn't enable the object.
    //---
    //To solve this, we will quickly enable and disable only all of the CircleCollider2Ds that are used for detecting and enabling/disabeling an object depending
    //on whether or not the player is near. This quick enable/disable will make it so that the player does get detected, and therefore the object in question
    //gets activated



    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimator = this.GetComponent<Animator>();
        rigidbodyy = this.GetComponent<Rigidbody2D>();



        ObjectActivator[] temp = FindObjectsOfType<ObjectActivator>();
        foreach (ObjectActivator objectActivator in temp)
        {
            ActivationCircleColliders.Add(objectActivator.gameObject.GetComponent<CircleCollider2D>());
        }
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

        //If we enable/disable the CircleCollider2Ds to quick, it still wont detect the player. And therefore still wont enable the object
        yield return new WaitForSeconds(0.1f);
        EnableDisableActivationColliders();
    }

    private void RespawnPlayer()
    {
        if (ReloadScene == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        else if (PutPlayerBackToSpawnPoint == true && !ReachedCheckpoint)
        {
            rigidbodyy.velocity = Vector2.zero;

            this.transform.position = SpawnPoint.position + new Vector3(0, 1, 0);
            VirtualCamera.gameObject.SetActive(false);
            VirtualCamera.gameObject.SetActive(true);
            amountOfDeaths++;
            DeathCounter.text = "" + amountOfDeaths;
        }

        else if (PutPlayerBackToSpawnPoint == true && ReachedCheckpoint)
        {
            rigidbodyy.velocity = Vector2.zero;

            this.transform.position = CheckPoint.position + new Vector3(0, 1, 0);
            VirtualCamera.gameObject.SetActive(false);
            VirtualCamera.gameObject.SetActive(true);
            amountOfDeaths++;
            DeathCounter.text = "" + amountOfDeaths;
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

    private void EnableDisableActivationColliders()
    {
        //Used to fix the bug
        for (int i = 0; i < ActivationCircleColliders.Count; i++)
        {
            if (ActivationCircleColliders[i] == null)//If the player for example has collected a coin, which does have an object activator/deactivator
                                                     //script on it, and therefor also a CircleCollider2D. The coin will get deleted after the player has picked it up. But if we then
                                                     //try to enable and disable the CircleCollider2D on that object, we will get an error because it no longer exists. So in order to 
                                                     //prevent that, we remove that particulair (no longer existing object) from the list
            {
                ActivationCircleColliders.RemoveAt(i);
            }

            else
            {
                ActivationCircleColliders[i].enabled = false;//This is done to fix a bug, in which the object wouldn't get reactivated,
                ActivationCircleColliders[i].enabled = true;//If the player respawned within the radious of this object
            }
        }
    }

    public int getAmountOfDeaths()
    {
        return amountOfDeaths;
    }
}
