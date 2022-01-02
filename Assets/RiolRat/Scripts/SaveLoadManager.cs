using UnityEngine;
using System.IO;
using System;
using System.Text;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager slm; //Zodat we het gemakkelijk vanuit andere scripts kunnen oproepen om te saven/loaden

    public AstroRunData astroRunData = new AstroRunData();

    private void Awake()
    {
        if (slm == null)
        {
            DontDestroyOnLoad(gameObject);
            slm = this;
        }

        else if (slm != this)
        {
            Destroy(gameObject);
        }

        LoadSaveFile();
    }

    private void LoadSaveFile()
    {
        #region Load default values
        //Our astroRunData class object holds all the variables + instanciated with their default values.
        //Later we will overwrite this data class with the user's save file. 
        //--- If the user opens the AstroRun for the first time, we will only have the default values and nothing will be overwritten
        //If the user updates to a new version, a part of the default values will be overwritten, and new variables that weren't there in the previous release, will have their default value
        #endregion

        if (File.Exists(Application.persistentDataPath + @"/AstroRun.json"))//Check if the savefile exists, before trying to load it in
        {
            string json = Decode(File.ReadAllText(Application.persistentDataPath + @"/AstroRun.json")); //Load the save file into a string
            JsonUtility.FromJsonOverwrite(json, astroRunData); //Load user's save file and use it to overwrite the default values defined above, with the users data. Leave new default values that aren't present in the user's save file untouched
        }

        SaveJSONToDisk(); //Normally we would just save the exact same json that's already saved to the drive. The only exception to this is when there are new default values (i.e. a there was an update, that added additional data/variables to the save file)
                          //, then we will actually write new stuff to the save file
    }

    public void SaveJSONToDisk()
    { // This saves the current astroRunData object to a savefile called AstroRun.json
        string json = JsonUtility.ToJson(astroRunData, true);
        File.WriteAllText(Application.persistentDataPath + @"/AstroRun.json", Encode(json));
    }

    private string Encode(string data)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(data); //convert the string into a byte array
        return Convert.ToBase64String(bytes); //convert the byte array to a string, this string is "unreadable" compared to the string: 'data'
    }

    private string Decode(string base64)
    {
        byte[] data = Convert.FromBase64String(base64);//Convert the "obfuscated" string into an byte array
        return Encoding.UTF8.GetString(data); //Create the original string from the byte array
    }



    private void Save()
    {
        // Use the following:
        // SaveLoadManager.slm.astroRunData.<variable name> = <value>; SaveLoadManager.slm.SaveJSONToDisk();
        // to save values from other scripts

        //---
        //We could also call this method from other scripts to save values, i.e. SaveLoadManager.slm(keyname, data);
        //However, this would require us to use a bunch of switch cases, to retrieve the appropriate variable from the astroRunData object
        //Or we could use something along these lines, to access a variable, when the variable's name is stored in a string:
        //typeof(AstroRunData).GetProperty(keyName).SetValue(astroRunData, data);  //It would be more performant to do this with a big switch statement, but this is a lot shorter
        //Source: https://social.msdn.microsoft.com/Forums/en-US/ecd7e689-ba7e-4c05-8393-f855a3faec8a/assign-variable-a-value-using-its-name-as-a-string?forum=csharplanguage
        //---
        //Instead the approach provided above is used to save data.
    }


    private void Load()
    {
        // Use the following:
        // SaveLoadManager.slm.astroRunData.<variable name>;
        // to load values from other scripts

        //---
        //We could also call this method from other scripts to load values, i.e. SaveLoadManager.slm(keyname);
        //However, this would require us to use a bunch of switch cases, to retrieve the appropriate variable from the astroRunData object
        //Or we could use something along these lines, to access a variable, when the variable's name is stored in a string:
        //return (string)typeof(AstroRunData).GetField(keyName).GetValue(astroRunData); //It would be more performant to do this with a big switch statement, but this is a lot shorter
        //Source: https://stackoverflow.com/questions/5053521/getting-variable-by-name-in-c-sharp
        //---
        //Instead, the approach provided above is used to load data.
        //Normally we would make this method dynamic. But IL2CPP doesn't support 'dynamic'
    }


}
