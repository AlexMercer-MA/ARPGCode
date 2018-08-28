using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Rebirth : MonoBehaviour
{
    public static UI_Rebirth GetInstance { get; set; }
    Image image;
    Text text;

    void Awake()
    {
        GetInstance = this;
        text = this.GetComponentInChildren<Text>();
        image = this.GetComponentInChildren<Image>();
    }
}
