﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SPValue : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = this.GetComponent<Text>();
    }

    void Update()
    {
        text.text = ActorPropertiesFinal.GetInstance.Sp_Int + "/" + ActorPropertiesFinal.GetInstance.SpMax;
    }
}
