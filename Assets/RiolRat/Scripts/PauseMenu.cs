using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseButton;
    public GameObject Background;
    public GameObject PauseMenuMain;
    public Image GeluidButton;
    public Sprite[] GeluidStanden = new Sprite[3];
    public AudioSource BackgroundMusic;
    private int HoeveelsteFoto;
    public string SceneToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        HoeveelsteFoto = 0;
        GeluidButton.sprite = GeluidStanden[HoeveelsteFoto];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        PauseButton.SetActive(false);
        Background.SetActive(true);
        PauseMenuMain.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        PauseButton.SetActive(true);
        Background.SetActive(false);
        PauseMenuMain.SetActive(false);
        Time.timeScale = 1;
    }

    public void Geluid()
    {
        HoeveelsteFoto++;
        if (HoeveelsteFoto + 1> GeluidStanden.Length)
        {
            HoeveelsteFoto = 0;
        }
        switch (HoeveelsteFoto)
        {
            case 0:
                BackgroundMusic.mute = false;
                break;
            case 1:
                BackgroundMusic.mute = true;
                break;
            case 2:
                BackgroundMusic.mute = true;
                Debug.Log("Geluidseffecten uitzetten");
                break;
        }
        GeluidButton.sprite = GeluidStanden[HoeveelsteFoto];
    }

    public void SaveAndQuit()
    {
        Time.timeScale = 1f; // anders freest ons menu, omdat we het in het pause menu op 0 hebben gezet. Zorgen op trage pcs, als het menu nog aan het laden is, dat ze niet kunnen verder spelen ofz. Mss menu scene al in achtergrond loaden? Load scene async ofz iets
        SceneManager.LoadScene(SceneToLoad);//gwn dit of die met het loaden en achtergrond enz
        Debug.Log("Saving and quitting");
    }

}
