using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonDifficultyManager : MonoBehaviour {

    public static DungeonDifficultyManager GetInstance;
    public DungeonDifficulty dungeonDifficulty;
    public Dropdown dropdown;

    private void Awake()
    {
        GetInstance = this;
    }

    public void CloseDropDownList()
    {
        //dropdown.Hide();
    }
}

public enum DungeonDifficulty
{
    easy,
    normal,
    hard,
    nightmare,
}