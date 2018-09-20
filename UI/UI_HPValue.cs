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
        text.text = ActorProperty.GetInstance.Hp_Int + "/" + ActorProperty.GetInstance.HpMax;
    }
}
