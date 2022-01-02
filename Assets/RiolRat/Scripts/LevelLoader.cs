using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string NameSceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(NameSceneToLoad);
    }

    public void Play()
    {
        
        SceneManager.LoadScene("Level" + SaveLoadManager.slm.astroRunData.highestUnlockedLevel);
    }
}
