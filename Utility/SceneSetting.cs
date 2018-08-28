using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSetting : MonoBehaviour
{
    public static SceneSetting GetInstance;

    public int level = 0;
    [SerializeField]
    private int enemyCount = 0;

    void Awake()
    {
        GetInstance = this;
    }

    void Update()
    {
        //Debug.Log ("EnemyCount"+enemyCount);
    }

    public bool HaveEnemyAlive()
    {
        if (enemyCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddEnemy()
    {
        enemyCount++;
    }

    public void MinusEnemy()
    {
        enemyCount--;
    }

    public void LoadScene(string name, float delay)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
