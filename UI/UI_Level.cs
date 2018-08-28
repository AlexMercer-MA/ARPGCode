using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Level : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = this.GetComponent<Text>();
    }

    void Update()
    {
        text.text = "Level " + PlayerPropertiesBase.GetInstance.Level;
    }
}

