# Building the game
Please follow the steps described below, in chronological order to build a new version of the game.

## Incrementing the version number
Since we are building a new version of the game, we have to increment the version number. For AstroRun we use the [Semantic Versioning](https://semver.org/) convention to update the version number. 

In summary: <br/>
Given a version number MAJOR.MINOR.PATCH, increment the:

- MAJOR version when adding a new world.
- MINOR version when adding new features or big improvements.
- PATCH version when making bugfixes or small improvements.

<br/>

### Adjusting Remote Config
1. Window > Remote Config
2. Click the **Pull** button to retrieve the latest remote settings from the service.
3. Search for a **Key** called `ApplicationVersion`. Update the **Value** variable with the new version number.
4. Click the **Push** button to save your changes to the remote service.

<br/>

### Changing the version and bundle version code
1. File > Build Settings > Player Settings > Other Settings 
2. Replace the previous version number inside the **Version** input field, with the new version number. 
3. Increment the previous value inside the **Bundle Version Code** input field with 1.

<br/><br/>

## Build settings
- Texture Compression: Use Player Settings
- ETC2 fallback: 32-bit
- Export Project: true
- Symlink Sources: false
- Export for App Bundle: true
- Create symbols.zip: Disabled
- Run Device: Default Device
- Development Build: false
- IL2CPP Code Generation: Faster Runtime
    - When this option is set to *Faster (smaller) Builds*, the project gets exported correctly. However, the game will crash upon opening it. <br/>
     Although this bug has been [fixed](https://issuetracker.unity3d.com/issues/il2cpp-hdrp-crash-when-opening-the-player-made-with-il2cpp-faster-builds), the game hasn't been tested yet with the option set to *Faster (smaller) Builds*.
- Compression Method: Default
- Export > Clean Build
    - Make sure the path you are exporting the project to, doesn't have any spaces in it.

<br/><br/>

## Building the exported project using Android Studio
### Prerequisites
- Download the latest version of [Android Studio](https://developer.android.com/studio).
- Make sure that *Windows Hotspot* is disabled, when building the project.

<br/>

### Building the project
- Open Android Studio
- Import Project (Gradle, Eclipse ADT, etc.). Select the exported folder by Unity.
- When Android Studio asks whether or not you want to use Android Studio's SDK, or the SDK configured in the project. Opt for Android Studio's SDK.
- Wait for the project to finish importing
- In the lower right corner, there should be a window with the following message: **Project Update Recommended** *Android Gradle Plugin can be **upgraded***
- Click on the highlighted **upgraded** word.
- Click on **Begin Upgrade**.
- When the *Upgrade Assistant* window opens, click on **Run selected steps**.
- Wait for the process to finish.
- Inside the *Project* window, open the following file: Gradle Scripts > gradle.properties.
    - Remove the following line from the file: `android.enableR8=false`
    - When prompted with the following message: *Gradle files have changed since last project sync. A project sync may be necessary for the IDE to work properly.* <br/>
    Choose for the **Sync Now** option.
    - Wait for the sync to finish
- Navigate to: Build > Generate signed Bundle/apk
- Select *Android App Bundle* and press on **Next**.
- Key store path > Choose existing: AstroRun\Assets\RiolRat\Other\Riolrat.keystore
- Key alias: Use an existing key.
- Exported encrypted key for enrolling published apps in Google Play App Signing: false.
- Click on **Next**.
- Select *release*.
- Click on **Finish**.

> If you encounter an error while building the project. You may not have accepted the Android SDK's license yet.
> - Open CMD
> - Navigate to the Android SDK's folder
> - Navigate to `SDK\Tools\bin`
> - Run the following command: `sdkmanager --licenses` and accept the license.
> - Rebuild the project, using the steps described above: [*Building the project*](#building-the-project) 

<br/>

The built .aab file will be placed in the following directory: `/launcher/release`
