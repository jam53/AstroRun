﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System;

// Tested Logic, that should work
//with = internet/logged in
/*v Save with, load with
 *v Save with, load without
 *V save without, load with
 *v savewithout, loadwithout
 *
 *x save with after with after saved withouth
 */

public class GPGSAutenthicator : MonoBehaviour
{
    public static PlayGamesPlatform platform;

    public static GPGSAutenthicator GPGSZelf; //Om dan te kunnen oproepen van andere scripts GPGSAutenthicator.GPGSZelf.FunctieNaam;

    private void Awake()
    {
        //If there is nothing (which is always the case when you restart the application)
        //Put this script in the static variable, so that we can acces it from elsewhere
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

        /* Whats in the saved array (also dont forget to create the array with the default values; line: 47)
         * AstroRun[0] = Level1 Best Time
         * AstroRun[1] = Level2 Best Time
         * AstroRun[2] = Level3 Best Time
         * AstroRun[3] = Level4 Best Time
         * AstroRun[4] = Total amount of coins across all levels
         * AstroRun[5] = Total amount of coins collected in Level 1
         * AstroRun[6] = Total amount of coins collected in Level 2
         * AstroRun[7] = Total amount of coins collected in Level 3
         * AstroRun[8] = Total amount of coins collected in Level 4
         * AstroRun[9] = Total amount of coins collected in World 1
         * AstroRun[10] = The Level We are at, the heighest unlocked level
         */

        // Check if the user has a save file, if not do the following:
        if (PlayerPrefsX.GetStringArray("AstroRun").Length <= 0)
        {
            string[] DefaultValues = { "00:00:00", "00:00:00", "00:00:00", "00:00:00", "0", "0", "0", "0", "0", "0", "1" };// Create an array with default values
            PlayerPrefsX.SetStringArray("AstroRun", DefaultValues);// Create a savefile with default values
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //If there is nothing (which is always the case when you restart the application)
        //Crate the GPGS thing
        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();//Because we save to the cloud we have to include .EnableSavedGames()
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            platform = PlayGamesPlatform.Activate();
        }

        // Check if the user logged in
        // If the user logged in, when he starts the application he will see:
        // Connecting to google play
        // Welcome back: "username"! -> If this doesnt get displayed, it means we didnt log in succesfully
        Social.Active.localUser.Authenticate(success=>
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

    // We call this function from other script to save data
    public void SaveString(int KeyIndex, string DataTooSave)
    {
        // Logic to do when the user is logged in
        if (Social.localUser.authenticated)
        {
            string[] DataToSaveHolder = PlayerPrefsX.GetStringArray("AstroRun"); //Get the savefile and put it in a temporary variable
            DataToSaveHolder[KeyIndex] = DataTooSave; //Update whatever data needs to be updated
            PlayerPrefsX.SetStringArray("AstroRun", DataToSaveHolder);//Save the temp array to the savefile
            OpenSave(true);//Call the function to upload the data to the cloud.
        }

        // Logic to do when the user isnt logged in
        else
        {
            PlayerPrefs.SetInt("UnUploadedData", 1); //Set this to true, so that we know that we 
            // have to upload some data to the cloud, the very next time we have internet/are loged in
            string[] DataToSaveHolder = PlayerPrefsX.GetStringArray("AstroRun"); //Get the savefile and put it in a temporary variable
            DataToSaveHolder[KeyIndex] = DataTooSave;//Update whatever data needs to be updated
            PlayerPrefsX.SetStringArray("AstroRun", DataToSaveHolder);//Save the temp array to the savefile
        }
    }

    // We call this function from other scripts to load data
    public string LoadString(int KeyIndex)
    {
        string[] DataToLoadHolder = PlayerPrefsX.GetStringArray("AstroRun");
        return DataToLoadHolder[KeyIndex];//Load whatever data is needed from whatever position in the array
    }

    // This should be called when we launch the application, to download any changes from the cloud
    // and overwrite them on the save file
    public void OnStartUp()
    {
        //If the user is online, load the data from the cloud and overwrite the current savefile
        if (Social.localUser.authenticated)
        {
            OpenSave(false);
        }

        //If the user isnt online, do nothing. The old savefile will be used.
        else
        {
            Debug.Log("Couldnt load data from cloud. User is not connected");
        }
    }

    //Cloud Saving
    private bool isSaving = false;
    public void OpenSave(bool saving)
    {
        Debug.Log("Open Save");

        //Check if the user is online.
        if (Social.localUser.authenticated)
        {
            //Declare a variabe to know wheter we are saving or loading. isSaving(true) = saving / isSaving(false) = loading
            isSaving = saving;
            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution("AstroRun"/*Save name*/, GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLastKnownGood/* how to resolve conflict */, SaveGameOpened);
            // Open the save in the cloud with the name "AstroRun"
        }

        //Incase the user isnt online/logged in
        else
        {
            Debug.LogWarning("Dit stukje code zou in principe nooit bereikt mogen worden. Aangezien we in Savestring en Loadstring al kijken als we connectie hebben.");
                //we zijn niet // online dus met player prefs. en als we weer online zijn, checken als er nog iets is in playerprefs, zo ja,
                //da eerst opslaan
                // mss zo bool van saved playerprefs = false;
                // en als we het dan hebben gesaved naar cloud, kunnen we het op true zetten
        }
    }

    //Logic to save/load
    private void SaveGameOpened(SavedGameRequestStatus status, ISavedGameMetadata meta)
    {
        Debug.Log("SaveGameOpened");

        if (status ==  SavedGameRequestStatus.Success)
        {
            if (isSaving) // If true, that means we are writing
            {
                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(String.Join("|", PlayerPrefsX.GetStringArray("AstroRun")));//Get the save file
                //Then create a string from the save file, which is an array. Because we can only save strings to the cloud, not arrays.
                //Convert the string to a byte array
                //And save that byte array below
                SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().WithUpdatedDescription("Saved at " + DateTime.Now.ToString()).Build();
                ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta, update, data, SaveUpdate);
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
    }

    //Load
    private void SaveRead(SavedGameRequestStatus status, byte[] data)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            //If we saved without an internet connection last time
            if (PlayerPrefs.GetInt("UnUploadedData") == 1)
            {
                PlayerPrefs.SetInt("UnUploadedData", 0); // Set this to false, so then we know there isnt any data
                // that still needs to be uploaded to the cloud
                OpenSave(true);// Upload the unuploaded data to the cloud
            }

            // If we were able to save with internet last time
            else
            {
                string savedData = System.Text.ASCIIEncoding.ASCII.GetString(data);// Get the byte array from the cloud
                //Then convert the byte array to a string, and put it in a temporary variable
                PlayerPrefsX.SetStringArray("AstroRun", savedData.Split('|'));//Now convert the string to an array.
                //And save the array to the save file
            }
        }
    }

    
}

#region oud
//Hier dee ik elke variabele appart, ipv alles in één save file te steken
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SocialPlatforms;
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
//using GooglePlayGames.BasicApi.SavedGame;
//using System;

//// Tested Logic, that should work

///*v Save with, load with
// *v Save with, load without
// *V save without, load with
// *v savewithout, loadwithout
// *
// *x save with after with after saved withouth
// */
//public class GPGSAutenthicator : MonoBehaviour
//{
//    public static PlayGamesPlatform platform;

//    public static GPGSAutenthicator GPGSZelf;

//    private void Awake()
//    {
//        if (GPGSZelf == null)
//        {
//            DontDestroyOnLoad(gameObject);
//            GPGSZelf = this;
//        }
//        else
//        {
//            if (GPGSZelf != this)
//            {
//                Destroy(gameObject);
//            }
//        }

//        if (PlayerPrefsX.GetStringArray("KeysToLoad")[0] != "exists")
//        {
//            string[] cars = new string[] { "exists" };
//            PlayerPrefsX.SetStringArray("KeysToLoad", cars);
//        }
//    }
//    // Start is called before the first frame update
//    void Start()
//    {
//        if (platform == null)
//        {
//            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build();
//            PlayGamesPlatform.InitializeInstance(config);
//            PlayGamesPlatform.DebugLogEnabled = true;
//            platform = PlayGamesPlatform.Activate();
//        }

//        Social.Active.localUser.Authenticate(success =>
//        {
//            if (success)
//            {
//                Debug.Log("Loged in successfully");
//            }

//            else
//            {
//                Debug.Log("FAILED TO LOG IN");
//            }
//        });
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    string DataToSave = null;
//    string DataToLoad = null;
//    public void SaveString(string KeyName, string DataTooSave)
//    {
//        if (Social.localUser.authenticated)
//        {
//            string[] cars = PlayerPrefsX.GetStringArray("KeysToLoad");
//            if (cars.Length > 1)
//            {
//                for (int i = 1; i < cars.Length; i++)
//                {
//                    DataToSave = PlayerPrefs.GetString(cars[i]);
//                    OpenSave(true, cars[i]);
//                }
//            }
//            DataToSave = DataTooSave;
//            OpenSave(true, KeyName);
//            PlayerPrefs.SetString(KeyName, DataTooSave);
//        }

//        else
//        {
//            string[] cars = PlayerPrefsX.GetStringArray("KeysToLoad");
//            Array.Resize(ref cars, cars.Length + 1);
//            PlayerPrefs.SetString(KeyName, DataTooSave);
//            cars[cars.Length - 1] = KeyName;
//            PlayerPrefsX.SetStringArray("KeysToLoad", cars);
//        }

//    }

//    public string LoadString(string KeyName)
//    {
//        DataToLoad = null;
//        StartCoroutine(CoRoutineLoadString(KeyName));
//        while (DataToLoad == null)
//        {

//        }
//        return DataToLoad;
//    }

//    public IEnumerator CoRoutineLoadString(string KeyName)
//    {
//        string[] cars = PlayerPrefsX.GetStringArray("KeysToLoad");
//        if (Social.localUser.authenticated && cars.Length == 1)
//        {
//            OpenSave(false, KeyName);
//            yield return new WaitUntil(() => DataToLoad != null);
//            //while (DataToLoad == null)
//            //{

//            //}
//            //return DataToLoad;
//        }

//        else if (Social.localUser.authenticated && cars.Length > 1)
//        {
//            for (int i = 1; i < cars.Length; i++)
//            {
//                DataToSave = PlayerPrefs.GetString(cars[i]);
//                OpenSave(true, cars[i]);
//            }
//            Array.Resize(ref cars, 1);
//            cars[0] = "exists";
//            PlayerPrefsX.SetStringArray("KeysToLoad", cars);
//            OpenSave(false, KeyName);
//            yield return new WaitUntil(() => DataToLoad != null);
//            //while (DataToLoad == null)
//            //{

//            //}
//            //return DataToLoad;
//        }

//        else
//        {
//            DataToLoad = PlayerPrefs.GetString(KeyName);
//            yield return new WaitUntil(() => DataToLoad != null);
//        }
//    }

//    //Cloud Saving
//    private bool isSaving = false;
//    public void OpenSave(bool saving, string SaveName)
//    {
//        Debug.Log("Open Save");

//        if (Social.localUser.authenticated)
//        {
//            isSaving = saving;
//            ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution(SaveName/*Save name*/, GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseMostRecentlySaved/* how to resolve conflict */, SaveGameOpened);
//        }

//        else
//        {
//            Debug.LogWarning("Dit stukje code zou in principe nooit bereikt mogen worden. Aangezien we in Savestring en Loadstring al kijken als we connectie hebben.");
//            //we zijn niet // online dus met player prefs. en als we weer online zijn, checken als er nog iets is in playerprefs, zo ja,
//            //da eerst opslaan
//            // mss zo bool van saved playerprefs = false;
//            // en als we het dan hebben gesaved naar cloud, kunnen we het op true zetten
//        }
//    }

//    private void SaveGameOpened(SavedGameRequestStatus status, ISavedGameMetadata meta)
//    {
//        Debug.Log("SaveGameOpened");

//        if (status == SavedGameRequestStatus.Success)
//        {
//            if (isSaving) // If true, that means we are writing
//            {
//                byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(DataToSave);
//                // Zie een beetje lager voor welke data op welke plek van de array staat
//                SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().WithUpdatedDescription("Saved at " + DateTime.Now.ToString()).Build();

//                ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta, update, data, SaveUpdate);
//                // Hier is beetje lager
//                /* data[0] = The index of what level we have currently unlocked
//                 *  = The total amount of coins collected
//                 *  inplaats van dit, gwn de save naam da nu "astrorun" is veranderen
//                 */
//            }

//            else // If false, that means we are reading
//            {
//                ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, SaveRead);
//            }
//        }
//    }

//    //Succes Save
//    private void SaveUpdate(SavedGameRequestStatus status, ISavedGameMetadata meta)
//    {
//        Debug.Log(status);
//        DataToSave = null;
//    }

//    //Load
//    private void SaveRead(SavedGameRequestStatus status, byte[] data)
//    {
//        if (status == SavedGameRequestStatus.Success)
//        {
//            string savedData = System.Text.ASCIIEncoding.ASCII.GetString(data);
//            DataToLoad = savedData;
//        }
//    }


//}
#endregion