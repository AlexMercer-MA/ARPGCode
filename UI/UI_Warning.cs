using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Warning : MonoBehaviour
{
    public static UI_Warning GetInstance { get; set; }
    public float ShowTimeDuration = 1.5f;
    Text text;
    float timer;

    void Awake()
    {
        GetInstance = this;
        text = this.GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (timer >= 0f)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                text.enabled = false;
            }
        }
    }

    public void WarnCD()
    {
        timer = ShowTimeDuration;
        text.enabled = true;
        text.text = "CoolDown Not Ready";

    }

    public void WarnSP()
    {
        timer = ShowTimeDuration;
        text.enabled = true;
        text.text = "Not Enough Energy";
    }
}
