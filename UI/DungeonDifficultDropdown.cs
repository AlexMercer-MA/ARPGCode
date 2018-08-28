using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonDifficultDropdown : MonoBehaviour
{
    public Dropdown dropdown;

    public void Awake()
    {
        dropdown = this.GetComponent<Dropdown>();
    }

    private void Start()
    {
        dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(dropdown); });
    }

    void DropdownValueChanged(Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                DungeonDifficultyManager.GetInstance.dungeonDifficulty = DungeonDifficulty.easy;
                break;
            case 1:
                DungeonDifficultyManager.GetInstance.dungeonDifficulty = DungeonDifficulty.normal;
                break;
            case 2:
                DungeonDifficultyManager.GetInstance.dungeonDifficulty = DungeonDifficulty.hard;
                break;
            case 3:
                DungeonDifficultyManager.GetInstance.dungeonDifficulty = DungeonDifficulty.nightmare;
                break;
            default:
                break;
        }
    }
}
