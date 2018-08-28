using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HPBar : MonoBehaviour
{
    RectTransform rect;

    void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    void Update()
    {
        rect.sizeDelta = new Vector2(300.0f * PlayerPropertiesFinal.GetInstance.Hp / PlayerPropertiesFinal.GetInstance.HpMax, 30.0f);
    }
}
