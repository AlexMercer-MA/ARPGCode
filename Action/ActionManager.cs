using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * -----------------------Action Manager类-----------------------
 * 
 * 处理Action
 * 事件由其他地方 发起，这里仅负责 处理发起后的逻辑 以及返回
 * 
 * 来源：
 * -当前释放的技能 ActionBase
 * 
 * 目标：
 * -UI脚本 做出对应处理
 * -ActionBase脚本 做出对应处理
 * 
 * 不同阶段的事件广播（回调）
 * 
 * 1 EvtActionPreCheck          （IN ActionBase）（OUT 检查结果）
 * 2 EvtActionChargeStart
 * 3 EvtActionChargeEnd
 * 4 EvtActionSingStart
 * 5 EvtActionSingEnd
 * 6 EvtActionCastStart             （Channel Action直接触发ActionStart）
 * 7 EvtActionCastEnd               （Channel Action直接触发ActionEnd）
 */

public class ActionManager{

    public static ActionManager GetInstance { get { return instance; } }
    private static ActionManager instance;

    void Awake ()
    {
        instance = this;
    }

    //1 EvtActionPreCheck          （IN ActionBase）（OUT 检查结果）
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionPreCheck;
    
    public void ActionPreCheck(ActionBase action, ActionPreCheckInfo info)
    {   
        EvtActionPreCheck(this, info);
        return;
    }

    //回调函数 OnActionPreCheck 模板
    //public virtual void OnActionPreCheck(object sender, EventArgs e)
    //{
    //    ActionBase action = sender as ActionBase;
    //    ActionPreCheckInfo info = e as ActionPreCheckInfo;
    //}
}

public class ActionPreCheckInfo : EventArgs
{
    public EActionPreCheckResult result = EActionPreCheckResult.OtherFail;
    public GameObject actor;
    public ActionKey actionKey;
}

public enum EActionPreCheckResult
{
    Success,
    CDCheckFail,
    EnergyCheckFail,
    KPAfCheckFail,
    KPBfCheckFail,
    KPAiCheckFail,
    KPBiCheckFail,
    SlienceCheckFail,
    OtherFail,
}