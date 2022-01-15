using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public string keyName;
    private float milliseconds, seconds, minutes;

    private string LevelTime;

    private float timeCompleted;

    public float getTimeCompleted()
    {
        return timeCompleted;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timeCompleted = Time.timeSinceLevelLoad;



        minutes = (int)(Time.timeSinceLevelLoad / 60f) % 60;
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        milliseconds = (int)(Time.timeSinceLevelLoad * 1000f) % 1000;

        LevelTime = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        string[] NewTime = LevelTime.Split(':');

        string oldTimeString;
        switch (keyName)
        {//Load the best time for this level
            case "bestTimeLevel1_1":
                oldTimeString = SaveLoadManager.slm.astroRunData.bestTimeLevel1_1;
                break;

            case "bestTimeLevel1_2":
                oldTimeString = SaveLoadManager.slm.astroRunData.bestTimeLevel1_2;
                break;

            case "bestTimeLevel1_3":
                oldTimeString = SaveLoadManager.slm.astroRunData.bestTimeLevel1_3;
                break;

            case "bestTimeLevel1_4":
                oldTimeString = SaveLoadManager.slm.astroRunData.bestTimeLevel1_4;
                break;

            case "bestTimeLevel1_5":
                oldTimeString = SaveLoadManager.slm.astroRunData.bestTimeLevel1_5;
                break;

            case "bestTimeLevel1_6":
                oldTimeString = SaveLoadManager.slm.astroRunData.bestTimeLevel1_6;
                break;

            case "bestTimeLevel1_7":
                oldTimeString = SaveLoadManager.slm.astroRunData.bestTimeLevel1_7;
                break;

            case "bestTimeLevel1_8":
                oldTimeString = SaveLoadManager.slm.astroRunData.bestTimeLevel1_8;
                break;

            case "bestTimeLevel1_9":
                oldTimeString = SaveLoadManager.slm.astroRunData.bestTimeLevel1_9;
                break;

            default:
                oldTimeString = "";
                Debug.LogWarning("Couldn't load best time for level: " + keyName);
                break;
        }
        string[] OldTime = oldTimeString.Split(':');

        if (int.Parse(NewTime[0]) < int.Parse(OldTime[0]) || int.Parse(NewTime[0]) <= int.Parse(OldTime[0]) && int.Parse(NewTime[1]) < int.Parse(OldTime[1]) || int.Parse(NewTime[0]) <= int.Parse(OldTime[0]) && int.Parse(NewTime[1]) <= int.Parse(OldTime[1]) && int.Parse(NewTime[2]) < int.Parse(OldTime[2])) 
        {
            switch (keyName)
            {//Load the best time for this level
                case "bestTimeLevel1_1":
                    SaveLoadManager.slm.astroRunData.bestTimeLevel1_1 = LevelTime;
                    break;

                case "bestTimeLevel1_2":
                    SaveLoadManager.slm.astroRunData.bestTimeLevel1_2 = LevelTime;
                    break;

                case "bestTimeLevel1_3":
                    SaveLoadManager.slm.astroRunData.bestTimeLevel1_3 = LevelTime;
                    break;

                case "bestTimeLevel1_4":
                    SaveLoadManager.slm.astroRunData.bestTimeLevel1_4 = LevelTime;
                    break;

                case "bestTimeLevel1_5":
                    SaveLoadManager.slm.astroRunData.bestTimeLevel1_5 = LevelTime;
                    break;

                case "bestTimeLevel1_6":
                    SaveLoadManager.slm.astroRunData.bestTimeLevel1_6 = LevelTime;
                    break;

                case "bestTimeLevel1_7":
                    SaveLoadManager.slm.astroRunData.bestTimeLevel1_7 = LevelTime;
                    break;

                case "bestTimeLevel1_8":
                    SaveLoadManager.slm.astroRunData.bestTimeLevel1_8 = LevelTime;
                    break;

                case "bestTimeLevel1_9":
                    SaveLoadManager.slm.astroRunData.bestTimeLevel1_9 = LevelTime;
                    break;

                default:
                    Debug.LogWarning("Couldn't save best time for level: " + keyName);
                    break;
            }
            SaveLoadManager.slm.SaveJSONToDisk();

            // ---

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level1")
            {
                GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel1((long)(Time.timeSinceLevelLoad * 1000f));
            }

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level2")
            {
                GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel2((long)(Time.timeSinceLevelLoad * 1000f));
            }

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level3")
            {
                GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel3((long)(Time.timeSinceLevelLoad * 1000f));
            }

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level4")
            {
                GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel4((long)(Time.timeSinceLevelLoad * 1000f));
            }

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level5")
            {
                GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel5((long)(Time.timeSinceLevelLoad * 1000f));
            }

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level6")
            {
                GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel6((long)(Time.timeSinceLevelLoad * 1000f));
            }

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level7")
            {
                GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel7((long)(Time.timeSinceLevelLoad * 1000f));
            }

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level8")
            {
                GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel8((long)(Time.timeSinceLevelLoad * 1000f));
            }

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Level9")
            {
                GPGSAutenthicator.GPGSZelf.UpdateLeaderboardScoreLevel9((long)(Time.timeSinceLevelLoad * 1000f));
            }
        }
    }

}
