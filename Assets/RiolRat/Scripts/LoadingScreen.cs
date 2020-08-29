using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public string SceneToLoad;
    public Slider slider;

    private bool Started = false;

    public InAppUpdates InAppUpdates;

    public int GameFPS;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = GameFPS;
    }

    // Update is called once per frame
    void Update()
    {
        if (InAppUpdates.LevelCanBeLoaded)
        {
            if (Time.time > 1 && !Started)
            {
                Debug.Log("Started scene loading");
                StartCoroutine(LoadYourAsyncScene());
                Started = true;
            }
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneToLoad);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            slider.value = progress;

            yield return null;
        }
        Debug.Log("Loading done");
        Resources.UnloadUnusedAssets();
    }
}