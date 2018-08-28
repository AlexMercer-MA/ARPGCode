using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneNameUI : MonoBehaviour
{
    public static SceneNameUI GetInstance;

    Text text;
    float alpha;
    bool isShowing;

    // Use this for initialization
    void Awake()
    {
        GetInstance = this;
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        alpha -= Time.deltaTime;
        if (alpha > 4)
        {
            text.color = new Color(1f, 1f, 1f, (5 - alpha));
        }
        else
        {
            alpha = Mathf.Clamp(alpha, 0, alpha);
            text.color = new Color(1f, 1f, 1f, alpha);
        }
    }

    public void ShowSceneName(string name)
    {
        isShowing = true;
        text.text = name;
        alpha = 6f;
    }
}
