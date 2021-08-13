![](Assets/RiolRat/Textures/MainMenu/AstrorRunLogo.png)

# AstroRun
AstroRun is an indie game developed by a small team of three people. It's about a lost adventurer in space, that has to complete different levels which are all part from a diverse collection of worlds. Each world is based around a certain theme and has its own unique intractable objects such as trampolines, falling spikes, enemies, turrets and much more for you to discover. On his way, the adventurer can collect a variety of items which can be used to buy new packages and accessories.

# Playing the game
You can try out the game for yourself by downloading it from the [Play Store](https://play.google.com/store/apps/details?id=com.jam54.AstroRun)

# Getting the project
To get the project folder you will need to clone the project.

> __IMPORTANT__: 
> This project uses Git Large Files Support (LFS). Downloading a zip file using the green button on GitHub
> **will not work**. You must clone the project with a version of git that has LFS.
> You can download Git LFS here: https://git-lfs.github.com/.

After you installed both Git LFS and GitHub Desktop you can start cloning the project.

### How do I clone AstroRun
Open *GitHub Desktop > file > Clone repository > URL >* enter the following url: https://github.com/jam53/AstroRun.git and press Clone

After cloning the project, you will see the following message:
> This repository uses Git LFS. To contribute to it, Git LFS must first be initialized. Would you like to do so now?

Press **Initialize Git LFS**

## Getting the right version of Unity

Once you cloned the repository, you should install the most recent, stable version of Unity. Make sure you also include *android build support* during the installation.

## Opening the project for the first time

The following guide should take you to the point where
you can hit play in the editor and run around the levels and build a
standalone version of the game.

### Unity Safe Mode
After you opened the project for the first time there will be some compilation errors, Unity will recommend you to enter safe mode, press **Ignore**.

### Errors in the console
You will be met by the following **error** in the console: 
> Assets\RiolRat\Scripts\GPGSAutenthicator.cs(22,19): error CS0246: The type or namespace name 'PlayGamesPlatform' could not be found (are you missing a using directive or an assembly reference?)

To fix this you should set the **build platform** to **Android**.

*File > Build Settings > Platform > Android > Switch Platform*

### Android Auto-resolution
After the project has been reimported for Android, you will be greeted by a message
asking you if you want to enable **Android Auto-resolution**, press **enable.**

### Google Play Games Plugins for Unity
~~After the project has been reimported for Android, navigate to:~~

~~*Windows > Google Play Games > Setup > Android Setup*~~
> Google ended support for certain packages after May 20th. Check your package manager and look for the 'in project' packages. Remove the *external dependency manager*, this should have already been done if you cloned the latest version of this repo.

This package should from now on be included in the project. However, if you decide to upgrade to a newer version of **External Dependency Manager for Unity** follow the steps described below:

Go to: https://developers.google.com/unity/archive#external_dependency_manager_for_unity

Download the latest version of **External Dependency Manager for Unity** as a unitypackage

Import the package into AstroRun.
> Deleting the old version first may help to prevent issues.

Under **Resources Definition**, you should paste the **resources** from the **Google Play** leaderboards.

### JAVA_HOME is not set and no 'java' command could be found in your PATH
Inside Unity copy paste the path inside: Edit > Preferences > External Tools > JDK Installed with Unity > Copy Path

Inside Windows open: System > Advanced system settings > Advanced > PATH > New > Name: JAVA_HOME > Copy paste the path from the previous step > OK

### Android SDK not found
If you get this error, go to:

*Edit > Preferences > External Tools*

**Uncheck** `Android SDK Tools Installed with Unity (recommended)` and input the **path** to the **Android SDK.**

### Main scene
The **main scene** for this project can be found under:

*Assets > RiolRat > Scenes > Loader*

Open the **Loader scene**, and hit **play.**

## Development of AstroRun

AstroRun was previously known under the name RiolRat, but this was later changed to a more appealing name.
It is currently being developed by a small team of 3 people, that consists of a programmer, level designer and a music composer.
