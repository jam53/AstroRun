using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelsInfo", menuName = "LevelInfo")]
public class LevelsInfo : ScriptableObject
{
    public string displayName;

    public string nameSceneToLoad;

    public int levelIndex;

    public string coinsKeyName;

    public string timeKeyName;

    public Sprite ImageUnlocked;
}
