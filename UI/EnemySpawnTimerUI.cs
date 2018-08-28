using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnTimerUI : MonoBehaviour
{
    public static EnemySpawnTimerUI GetInstance;

    Text text;
    float timer;
    bool isCountDown;

    void Awake()
    {
        text = this.GetComponent<Text>();
        GetInstance = this;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (isCountDown)
        {
            if (timer > 0)
            {
                text.text = "Enemy Spawn In\n" + Mathf.CeilToInt(timer) + " sec";
            }
            else
            {
                isCountDown = false;
                text.enabled = false;
            }
        }
    }

    public void CountDown(float time)
    {
        isCountDown = true;
        timer = time;
        text.enabled = true;
    }
}
