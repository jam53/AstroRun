using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillAndRespawn : MonoBehaviour
{
    public bool ReloadScene;
    public bool PutPlayerBackToSpawnPoint;

    public Transform SpawnPoint;
    public Transform CheckPoint;

    public TextMeshProUGUI DeathCounter;
    public GameObject VirtualCamera;

    private bool ReachedCheckpoint = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Flag")
        {
            ReachedCheckpoint = true;
        }

        if (collision.tag == "DoesDamage")
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
}
