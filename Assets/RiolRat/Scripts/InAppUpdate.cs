using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Android;
using Google.Play;
using Google.Play.AssetDelivery;
using Google.Play.AssetDelivery.Internal;
using Google.Play.Common;
using Google.Play.Common.Internal;
using Google.Play.Common.LoadingScreen;
using Google.Play.Core;
using Google.Play.Core.Internal;
using update

public class InAppUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //// Creates instance of the manager.
        AppUpdateManager appUpdateManager = AppUpdateManagerFactory.create(context);

        //// Returns an intent object that you use to check for an update.
        //Task<AppUpdateInfo> appUpdateInfoTask = appUpdateManager.getAppUpdateInfo();

        //// Checks that the platform will allow the specified type of update.
        //appUpdateInfoTask.addOnSuccessListener(appUpdateInfo-> {
        //    if (appUpdateInfo.updateAvailability() == UpdateAvailability.UPDATE_AVAILABLE
        //          // For a flexible update, use AppUpdateType.FLEXIBLE
        //          && appUpdateInfo.isUpdateTypeAllowed(AppUpdateType.IMMEDIATE))
        //    {
        //        // Request the update.
        //    }
        //});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
