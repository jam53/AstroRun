# Adding a new level
Please follow the steps stated in this document, in chronological order.

## The new scene itself
- Add a `LevelTimer` prefab to the new level, and assign *bestTimeLevelx* as the value of `KeyName`
- Change the text that displays what the current level is
	1) \<new level>.unity
	2) Canvas
	3) BlackLevelFade
	4) Text (TMP)
	5) Localize String Event
	6) Local variables
	7) Assign the index of the level to the variable `Integer`
- Adjust the `PickupCoins` script
	1) \<new level>.unity
	2) Player
	3) PickupCoins
	- Fill in the `keyName` variable (coinsLevel**x**)
	- Fill in the `keyNameWorld` variable (coinsWorld**x**)

---

## The scene before the new level
- Add a 'LevelComplete' prefab
	- NextLevelLoader.cs
		- Black Level Fade Animator: `Drag and drop the Canvas > BlackLevelFade gameobject`
		- Name Scene To Load: `Levelx`
		- Level To Unlock: `x`
	- MusicChanger.cs
		- Background Source: `Drag and drop the BackgroundMusic gameobject` 
- Under the hierarchy, find the `AchievementsHandler` gameobject. Set the `MrMoneyBags` variable to true, assign the `NextLeveLoader4` variable and `PickupCoins` variable by using the select window


---

## MainMenu.unity
1) Canvas > SubMenu_Shop_Items > Shop > SelectedItem_Button > BuyButton > `BuyNewLevel.cs`
	- `Amount Of Levels`: change this to the amount of levels currently in the game. Since you are addding only one new level, you should increment this value with +1

---

## Google Play Console
- Add a leaderboard for the new level
	1) Open the [Google Play Console](https://play.google.com/console/about/)
	2) Open AstroRun
	3) Play-gamesservices > Instellen en beheren > Scoreborden
	6) Scorebord maken
	- Naam: `Level x`
	- Indeling: `Duur`
	- Sorteervolgorde: `Kleinste eerst`
	- Beveiliging tegen manipulatie: `Aanzetten`
	- Limieten: `/`
	7) Opslaan als concept + controleren
	8) Publiceren

---

## Editor
- Copy the [Google Play Console](https://play.google.com/console/about/) Resources, and import them into Unity
	1) Open the [Google Play Console](https://play.google.com/console/about/)
	2) Open AstroRun
	3) Play-gamesservices > Instellen en beheren > Scoreborden
	6) Bronnen ophalen
	7) Copy the Android (xml) 
	8) Go back to Unity
	9) Window > Google Play Games > Setup > Android Setup
	10) Paste 
	11) Setup
- Add the new scene to the build settings (File > Build Settings)

---

## Scripts
### <u>AstroRunData.cs</u>
- Add the following values:
	- bestTimeLevelx
	- coinsLevelx
	- timeToSubmitLevelx

### <u>GPGSAuthenticator.cs</u>
- Add a new method (`UpdateLeaderBoardScoreLevelx`) at the bottom of the script

### <u>LevelTimer.cs</u>
- Add a case statement 
	- `case "bestTimeLevelx"`
- Add another case statement a bit lower in the script 
	- `case "bestTimeLevelx"`
- Add an if; to update the time on the leaderboard
	- `if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Levelx")`

### <u>OpenLevelSelection.cs</u>
- Add another if inside the `SubmitTimes()` method, to update the score on the leaderboards
	- `if (SaveLoadManager.slm.astroRunData.timeToSubmitLevelx != 0)`

### <u>ResetCoins.cs</u>
- Add the following line inside the `ResettCoins()` method
	- `SaveLoadManager.slm.astroRunData.coinsLevelx = 0;`

### <u>PickupCoins.cs</u>
- Add another case statement a bit lower in the script 
	- `case "coinsLevelx"`

---

## Scriptable Objects
### <u>LevelInfo</u>
1) Assets/RiolRat/ScriptableObjects/LevelsInfo
2) Create a new ScriptableObject of type `LevelInfo`
	- Display name: `Level x`
	- Name Scene To Load: `Levelx`
	- Scene Index: `x`
	- Coins Key Name: `coinsLevelx`
	- Time Key Name: `bestTimeLevelx`
	- Image Unlocked:
		1) Make a screenshot of the level that can be used as a thumbnail 
		2) Place the screenshot/thumbnail here: `Assets/RiolRat/Textures/MainMenu/LevelIcons/x.png`
		3) Assign this sprite to the `Image Unlocked variable`

---

## MainMenu.unity
1) Canvas > SubMenu_LevelSelectWorld > OptionList > Viewport > Row1 > World1_Button > `OpenLevel Selection.cs`
	- Assign the UI button + the LevelsInfo scriptableobject
---
