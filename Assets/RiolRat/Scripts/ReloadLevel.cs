﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    public bool ReloadScene;
    public bool PutPlayerBackToSpawnPoint;

    public Transform SpawnPoint;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ReloadScene == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        else if (true)
        {
            Player.transform.position = SpawnPoint.position;
        }
    }
}