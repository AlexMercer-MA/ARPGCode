using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnWaringUI : MonoBehaviour
{
    public static EnemySpawnWaringUI GetInstance;

    Text text;
    float scale;
    float alpha;
    bool isWarning;

    // Use this for initialization
    void Awake()
    {
        GetInstance = this;
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWarning)
        {
            scale = Mathf.Lerp(scale, 1, Time.deltaTime);
            alpha -= 2 * Time.deltaTime;
            alpha = Mathf.Clamp(alpha, 0, alpha);

            text.color = new Color(1f, 0.35f, 0.35f, alpha);
            text.fontSize = Mathf.RoundToInt(100f * scale);
        }
    }

    public void ShowWarning(int currentWave, int totalWave)
    {
        isWarning = true;
        text.enabled = true;
        if (currentWave == totalWave)
        {
            text.text = "FinalWave\nWave " + (currentWave) + "/" + (totalWave) + "\nEnemy Spawn";
        }
        else
        {
            text.text = "Wave " + (currentWave) + "/" + (totalWave) + "\nEnemy Spawn";
        }
        scale = 2f;
        alpha = 4f;
    }
}