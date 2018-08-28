using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_XPBar : MonoBehaviour
{
    RectTransform rect;

    void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    void Update()
    {
        rect.sizeDelta = new Vector2(300.0f * PlayerPropertiesBase.GetInstance.Experience / GameProperties.GetInstance.UpgradeExperience[PlayerPropertiesBase.GetInstance.Level], 12f);
    }
}
