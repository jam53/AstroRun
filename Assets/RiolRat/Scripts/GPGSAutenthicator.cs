using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System;
using System.IO;
using System.Text;


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

            #region SaveToGooglePlay
            //if (Social.localUser.authenticated)
            //{
            //    OpenSave(true);//Call the function to upload the data to the cloud.
            //}
            #endregion
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
            #region SaveToGooglePlay
            //if (success)
            //{
            //    Debug.Log("Loged in successfully");
            //    OnStartUp();
            //}

            //else
            //{
            //    Debug.Log("FAILED TO LOG IN");
            //}
            #endregion
        });
    }

        #region SaveToGooglePlay
        //// Logic to do when the user is logged in
        //if (Social.localUser.authenticated)
        //{
        //    string[] DataToSaveHolder = PlayerPrefsX.GetStringArray("AstroRun"); //Get the savefile and put it in a temporary variable
        //    DataToSaveHolder[KeyIndex] = DataTooSave; //Update whatever data needs to be updated
        //    PlayerPrefsX.SetStringArray("AstroRun", DataToSaveHolder);//Save the temp array to the savefile
        //    OpenSave(true);//Call the function to upload the data to the cloud.
        //}
        //
        //// Logic to do when the user isnt logged in
        //else
        //{
        //    PlayerPrefs.SetInt("UnUploadedData", 1); //Set this to true, so that we know that we 
        //    // have to upload some data to the cloud, the very next time we have internet/are loged in
        //    string[] DataToSaveHolder = PlayerPrefsX.GetStringArray("AstroRun"); //Get the savefile and put it in a temporary variable
        //    DataToSaveHolder[KeyIndex] = DataTooSave;//Update whatever data needs to be updated
        //    PlayerPrefsX.SetStringArray("AstroRun", DataToSaveHolder);//Save the temp array to the savefile
        //}
        #endregion

    #region SaveToGooglePlay
    // This should be called when we launch the application, to download any changes from the cloud
    //// and overwrite them on the save file
    //public void OnStartUp()
    //{
    //    //If the user is online, load the data from the cloud and overwrite the current savefile
    //    if (Social.localUser.authenticated)
    //    {
    //        OpenSave(false);
    //    }

    //    //If the user isnt online, do nothing. The old savefile will be used.
    //    else
    //    {
    //        Debug.Log("Couldnt load data from cloud. User is not connected");
    //    }
    //}
    #endregion

    #region SaveToGooglePlay
    ////Cloud Saving
    //private bool isSaving = false;
    //public void OpenSave(bool saving)
    //{
    //    Debug.Log("Open Save");

    //    //Check if the user is online.
    //    if (Social.localUser.authenticated)
    //    {
    //        //Declare a variabe to know wheter we are saving or loading. isSaving(true) = saving / isSaving(false) = loading
    //        isSaving = saving;
    //        ((PlayGamesPlatform)Social.Active).SavedGame.OpenWithAutomaticConflictResolution("AstroRun"/*Save name*/, GooglePlayGames.BasicApi.DataSource.ReadCacheOrNetwork, ConflictResolutionStrategy.UseLastKnownGood/* how to resolve conflict */, SaveGameOpened);
    //        // Open the save in the cloud with the name "AstroRun"
    //    }

    //    //Incase the user isnt online/logged in
    //    else
    //    {
    //        Debug.LogWarning("Dit stukje code zou in principe nooit bereikt mogen worden. Aangezien we in Savestring en Loadstring al kijken als we connectie hebben.");
    //            //we zijn niet // online dus met player prefs. en als we weer online zijn, checken als er nog iets is in playerprefs, zo ja,
    //            //da eerst opslaan
    //            // mss zo bool van saved playerprefs = false;
    //            // en als we het dan hebben gesaved naar cloud, kunnen we het op true zetten
    //    }
    //}
    #endregion

    #region SaveToGooglePlay
    ////Logic to save/load
    //private void SaveGameOpened(SavedGameRequestStatus status, ISavedGameMetadata meta)
    //{
    //    Debug.Log("SaveGameOpened");

    //    if (status ==  SavedGameRequestStatus.Success)
    //    {
    //if (isSaving) // If true, that means we are writing
    //{
    //    byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(String.Join("|", PlayerPrefsX.GetStringArray("AstroRun")));//Get the save file
    //    //Then create a string from the save file, which is an array. Because we can only save strings to the cloud, not arrays.
    //    //Convert the string to a byte array
    //    //And save that byte array below
    //    SavedGameMetadataUpdate update = new SavedGameMetadataUpdate.Builder().WithUpdatedDescription("Saved at " + DateTime.Now.ToString()).Build();
    //    ((PlayGamesPlatform)Social.Active).SavedGame.CommitUpdate(meta, update, data, SaveUpdate);
    //}

    //        else // If false, that means we are reading
    //        {
    //            ((PlayGamesPlatform)Social.Active).SavedGame.ReadBinaryData(meta, SaveRead);
    //        }
    //    }
    //}

    ////Succes Save
    //private void SaveUpdate(SavedGameRequestStatus status, ISavedGameMetadata meta)
    //{
    //    Debug.Log(status);
    //}

    ////Load
    //private void SaveRead(SavedGameRequestStatus status, byte[] data)
    //{
    //    if (status == SavedGameRequestStatus.Success)
    //    {
    //        //If we saved without an internet connection last time
    //        if (PlayerPrefs.GetInt("UnUploadedData") == 1)
    //        {
    //            PlayerPrefs.SetInt("UnUploadedData", 0); // Set this to false, so then we know there isnt any data
    //            // that still needs to be uploaded to the cloud
    //            OpenSave(true);// Upload the unuploaded data to the cloud
    //    }

    //    // If we were able to save with internet last time
    //    else
    //    {
    //        string savedData = System.Text.ASCIIEncoding.ASCII.GetString(data);// Get the byte array from the cloud
    //        //Then convert the byte array to a string, and put it in a temporary variable
    //        PlayerPrefsX.SetStringArray("AstroRun", savedData.Split('|'));//Now convert the string to an array.
    //        //And save the array to the save file            
    //    }
    //}
    #endregion


    //Post score to leaderboard
    public void UpdateLeaderboardScoreLevel1(long TimeInMilliseconds)
    {
        Social.ReportScore(TimeInMilliseconds, GPGSIds.leaderboard_level_1, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Updated To LeaderBoard");
            }

            else if (!success)
            {
                Debug.Log("Couldnt submit score to LeaderBoard");
                SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_1 = TimeInMilliseconds; SaveLoadManager.slm.SaveJSONToDisk();
            }
        });
    }
    
    public void UpdateLeaderboardScoreLevel2(long TimeInMilliseconds)
    {
        Social.ReportScore(TimeInMilliseconds, GPGSIds.leaderboard_level_2, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Updated To LeaderBoard");
            }

            else if (!success)
            {
                Debug.Log("Couldnt submit score to LeaderBoard");
                SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_2 = TimeInMilliseconds; SaveLoadManager.slm.SaveJSONToDisk();
            }
        });
    }

    public void UpdateLeaderboardScoreLevel3(long TimeInMilliseconds)
    {
        Social.ReportScore(TimeInMilliseconds, GPGSIds.leaderboard_level_3, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Updated To LeaderBoard");
            }

            else if (!success)
            {
                Debug.Log("Couldnt submit score to LeaderBoard");
                SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_3 = TimeInMilliseconds; SaveLoadManager.slm.SaveJSONToDisk();
            }
        });
    }

    public void UpdateLeaderboardScoreLevel4(long TimeInMilliseconds)
    {
        Social.ReportScore(TimeInMilliseconds, GPGSIds.leaderboard_level_4, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Updated To LeaderBoard");
            }

            else if (!success)
            {
                Debug.Log("Couldnt submit score to LeaderBoard");
                SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_4 = TimeInMilliseconds; SaveLoadManager.slm.SaveJSONToDisk();
            }
        });
    }

    public void UpdateLeaderboardScoreLevel5(long TimeInMilliseconds)
    {
        Social.ReportScore(TimeInMilliseconds, GPGSIds.leaderboard_level_5, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Updated To LeaderBoard");
            }

            else if (!success)
            {
                Debug.Log("Couldnt submit score to LeaderBoard");
                SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_5 = TimeInMilliseconds; SaveLoadManager.slm.SaveJSONToDisk();
            }
        });
    }

    public void UpdateLeaderboardScoreLevel6(long TimeInMilliseconds)
    {
        Social.ReportScore(TimeInMilliseconds, GPGSIds.leaderboard_level_6, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Updated To LeaderBoard");
            }

            else if (!success)
            {
                Debug.Log("Couldnt submit score to LeaderBoard");
                SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_6 = TimeInMilliseconds; SaveLoadManager.slm.SaveJSONToDisk();
            }
        });
    }

    public void UpdateLeaderboardScoreLevel7(long TimeInMilliseconds)
    {
        Social.ReportScore(TimeInMilliseconds, GPGSIds.leaderboard_level_7, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Updated To LeaderBoard");
            }

            else if (!success)
            {
                Debug.Log("Couldnt submit score to LeaderBoard");
                SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_7 = TimeInMilliseconds; SaveLoadManager.slm.SaveJSONToDisk();
            }
        });
    }

    public void UpdateLeaderboardScoreLevel8(long TimeInMilliseconds)
    {
        Social.ReportScore(TimeInMilliseconds, GPGSIds.leaderboard_level_8, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Updated To LeaderBoard");
            }

            else if (!success)
            {
                Debug.Log("Couldnt submit score to LeaderBoard");
                SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_8 = TimeInMilliseconds; SaveLoadManager.slm.SaveJSONToDisk();
            }
        });
    }

    public void UpdateLeaderboardScoreLevel9(long TimeInMilliseconds)
    {
        Social.ReportScore(TimeInMilliseconds, GPGSIds.leaderboard_level_9, (bool success) =>
        {
            if (success)
            {
                Debug.Log("Updated To LeaderBoard");
            }

            else if (!success)
            {
                Debug.Log("Couldnt submit score to LeaderBoard");
                SaveLoadManager.slm.astroRunData.timeToSubmitLevel1_9 = TimeInMilliseconds; SaveLoadManager.slm.SaveJSONToDisk();
            }
        });
    }
}