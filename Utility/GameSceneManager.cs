using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour {

    public static GameSceneManager GetInstance;
    public string[] dungeonName;
    public int currentDungeonCount = 0;

    private void Awake()
    {
        GetInstance = this;
    }
    
    public void LoadNextDungeonScene()
    {
        int nextIndex = Random.Range(0, dungeonName.Length);
        string nextDungen = dungeonName[nextIndex];
        currentDungeonCount++;
        SceneSetting.GetInstance.level = currentDungeonCount + (int)DungeonDifficultyManager.GetInstance.dungeonDifficulty;
        SceneManager.LoadScene(nextDungen, LoadSceneMode.Single);
    }
}
