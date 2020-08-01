using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System;

public class GPGSAutenthicator : MonoBehaviour
{
    public static PlayGamesPlatform platform;

    public static GPGSAutenthicator GPGSZelf;

    private void Awake()
    {
        if (GPGSZelf == null)
        {
            DontDestroyOnLoad(gameObject);
            GPGSZelf = this;
        }
        else
        {
            if (GPGSZelf != this)
            {
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            platform = PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("Loged in successfully");
            }

            else
            {
                Debug.Log("FAILED TO LOG IN");
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string DataToSave;
    string DataToLoad;
    public void SaveString(string KeyName, string DataTooSave)
    {
        if (Social.localUser.authenticated)
        {
            OpenSave(true, KeyName);
            DataToSave = DataTooSave;
        }

        else
        {
            PlayerPrefs.SetString(KeyName, DataTooSave);
        }

    }

    public string LoadString(string KeyName)
    {
        if (Social.localUser.authenticated)
        {
            OpenSave(false, KeyName);
            return DataToLoad;
        }

        else
        {
            return PlayerPrefs.GetString(KeyName);
        }
    }

    //Cloud Saving
    private bool isSaving = false;
    public void OpenSave(bool saving, string SaveName)
    {
        Debug.Log("Open Save");

        if (Social.localUser.authenticated)
        {
            isSaving = saving;
            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution(SaveName/*Save name*/, GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseMostRecentlySaved/* how to resolve conflict */, SaveGameOpened);
        }

        else
        {
            Debug.LogWarning("Dit stukje code zou in principe nooit bereikt mogen worden. Aangezien we in Savestring en Loadstring al kijken als we connectie hebben.");
                //we zijn niet // online dus met player prefs. en als we weer online zijn, checken als er nog iets is in playerprefs, zo ja,
                //da eerst opslaan
                // mss zo bool van saved playerprefs = false;
                // en als we het dan hebben gesaved naar cloud, kunnen we het op true zetten
        }
    }

    private void SaveGameOpened(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        Debug.Log("SaveGameOpened");

        if (status ==  SavedGameRequestStatus.Success)
        {
            if (isSaving) // If true, that means we are writing
            {
                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(DataToSave);
                // Zie een beetje lager voor welke data op welke plek van de array staat
                SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().WithUpdatedDescription("Saved at " + DateTime.Now.ToString()).Build();

                ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta, update, data, SaveUpdate);
                // Hier is beetje lager
                /* data[0] = The index of what level we have currently unlocked
                 *  = The total amount of coins collected
                 *  inplaats van dit, gwn de save naam da nu "astrorun" is veranderen
                 */
            }

            else // If false, that means we are reading
            {
                ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, SaveRead);
            }
        }
    }

    //Succes Save
    private void SaveUpdate(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        Debug.Log(status);
        DataToSave = null;
    }

    //Load
    private void SaveRead(SavedGameRequestStatus status, byte[] data)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            string savedData = System.Text.ASCIIEncoding.ASCII.GetString(data);
            DataToLoad = savedData;
        }
    }

    
}
