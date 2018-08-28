using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HPValue : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = this.GetComponent<Text>();
    }

    void Update()
    {
        text.text = PlayerPropertiesFinal.GetInstance.Hp_Int + "/" + PlayerPropertiesFinal.GetInstance.HpMax;
    }
}
