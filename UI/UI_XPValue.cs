using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_XPValue : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = this.GetComponent<Text>();
    }

    //TODO 改为事件触发
    void Update()
    {
        text.text = PlayerPropertiesBase.GetInstance.Experience + "/" + GameProperties.GetInstance.UpgradeExperience[PlayerPropertiesBase.GetInstance.Level];
    }
}

