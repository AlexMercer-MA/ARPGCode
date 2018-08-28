using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ActionIcon : MonoBehaviour
{

    //获取技能信息
    public ActionBase actionBase;
    //UI的图片
    public Image skillUI_NoEnergy;
    public Image skillUI_CoolDown;
    public Image skillUI_HighLight;
    //数据
    float skillTime;
    float skillCD;
    float skillUIangle;
    float skillEnergy;
    
    void Start()
    {
        skillCD = actionBase.cooldown;
        skillEnergy = actionBase.energy;
    }

    void Update()
    {
        skillCD = actionBase.cooldown;
        skillTime = actionBase.skillTime;

        if (actionBase.isHighLight)
        {
            skillUI_HighLight.enabled = true;
        }
        else
        {
            skillUI_HighLight.enabled = false;
        }

        if (PlayerPropertiesFinal.GetInstance.Sp < skillEnergy)
        {
            skillUI_NoEnergy.enabled = true;
        }
        else
        {
            skillUI_NoEnergy.enabled = false;
        }

        skillCD = actionBase.cooldown * (1f - PlayerPropertiesFinal.GetInstance.Cdr);
        skillUIangle = Mathf.Clamp01((skillCD - skillTime) / skillCD);
        skillUI_CoolDown.fillAmount = skillUIangle;
    }

    //学习技能/拖动技能时 更换技能UI
    void SetData(ActionBase action)
    {

    }
}
