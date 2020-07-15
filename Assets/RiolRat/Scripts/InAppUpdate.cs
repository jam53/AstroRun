using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAppUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Creates instance of the manager.
        AppUpdateManager appUpdateManager = AppUpdateManagerFactory.create(context);

        // Returns an intent object that you use to check for an update.
        Task<AppUpdateInfo> appUpdateInfoTask = appUpdateManager.getAppUpdateInfo();

        // Checks that the platform will allow the specified type of update.
        appUpdateInfoTask.addOnSuccessListener(appUpdateInfo-> {
            if (appUpdateInfo.updateAvailability() == UpdateAvailability.UPDATE_AVAILABLE
                  // For a flexible update, use AppUpdateType.FLEXIBLE
                  && appUpdateInfo.isUpdateTypeAllowed(AppUpdateType.IMMEDIATE))
            {
                // Request the update.
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
