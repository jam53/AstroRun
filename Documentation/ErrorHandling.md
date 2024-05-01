# Error handling

## Unity Safe Mode
After you opened the project for the first time there will be some compilation errors, Unity will recommend you to enter safe mode, press **Ignore**.

<br/>

## Errors inside the console
When the following **error message** is displayed.
> Assets\RiolRat\Scripts\GPGSAutenthicator.cs(15,19): error CS0246: The type or namespace name 'PlayGamesPlatform' could not be found (are you missing a using directive or an assembly reference?)

Setting the **build platform** to **Android** will resolve the issue.

*File > Build Settings > Platform > Android > Switch Platform*

<br/>

## Android Auto-resolution
After the project has been reimported for Android, you may be greeted by a message
asking you if you want to enable **Android Auto-resolution**, press **enable.**

<br/>

## JAVA_HOME is not set and no 'java' command could be found in your PATH
1) Inside Unity copy the path from: Edit > Preferences > External Tools > JDK Installed with Unity > Copy Path

2) Open Windows settings: System > About > Advanced system settings > Advanced > Environment Variables > New > Name: JAVA_HOME > Value: Paste the path from the previous step > OK

<br/>

## Android SDK not found
Inside Unity navigate to:

*Edit > Preferences > External Tools*

**Uncheck** `Android SDK Tools Installed with Unity (recommended)` and input the **path** to the **Android SDK** on your system.

## (Resolving Android Dependencies) Could not create an instance of type org.gradle.initialization.DefaultSettings_Decorated
- *Edit > Preferences > External Tools*
    - Uncheck the checkboxes of JDK, SDK, NDK and Gradle and enter the same paths that were there when the checkboxes were checked. 
- Set the value of the *JAVA_HOME* environment variable in Windows to the path next to the JDK's checkbox.
    - Restart Unity.
    - Toggle the *Export Project* checkbox in the build settings, this will cause the *Resolving Android Dependencies* to restart.

## Error during Gradle Sync in Android Studio - Cannot use @TaskAction annotation on method IncrementalTask.taskAction$gradle() because interface ...
The way to get around this issue is by downgrading to an older version of Android Studio. This approach likely resolves the issue because it also downgrades the version of Gradle bundled with the IDE. I didn't take the time to figure out which version exactly was the latest one that still worked, but using [Android Studio Bumblebee | 2021.1.1 January 25, 2022](https://developer.android.com/studio/archive) I was able to build the exported project from Unity successfully.
