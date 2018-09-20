﻿using System.Collections;
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
        rect.sizeDelta = new Vector2(300.0f * ActorPropertiesBasic.GetInstance.Experience / GameSettingManager.GetInstance.UpgradeExperience[ActorPropertiesBasic.GetInstance.Level], 12f);
    }
}
