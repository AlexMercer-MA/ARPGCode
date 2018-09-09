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
 * 不同阶段的事件（Evt）
 * 
 * 1 EvtActionPreCheck          （IN ActionBase）（OUT 检查结果）
 * 2 EvtActionChargeStart
 * 3 EvtActionChargeUpdate
 * 4 EvtActionChargeEnd
 * 5 EvtActionSingStart
 * 6 EvtActionSingUpdate
 * 7 EvtActionSingEnd
 * 8 EvtActionCastStart             （Channel Action直接触发ActionStart）
 * 9 EvtActionCastLanuch            （Channel Action直接触发ActionStart）
 * 10EvtActionCastEnd               （Channel Action直接触发ActionEnd）
 * 11EvtActionChannelCastStart
 * 12EvtActionChannelCastUpdate
 * 12EvtActionChannelCastLanuch
 * 13EvtActionChannelCastEnd
 * 14EvtActionBreak
 */

public class ActionManager{

    public static ActionManager GetInstance { get { return instance; } }
    private static ActionManager instance;

    void Awake ()
    {
        instance = this;
    }

    //1 EvtActionPreCheck
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

    //2 EvtActionChargeStart
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionChargeStart;
    public void ActionChargeStart(ActionBase action, ActionChargeInfo info)
    {
        EvtActionChargeStart(this, info);
        return;
    }

    //3 EvtActionChargeUpdate
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionChargeStart;
    public void ActionChargeUpdate(ActionBase action, ActionChargeInfo info)
    {
        EvtActionChargeStart(this, info);
        return;
    }

    //4 EvtActionChargeEnd
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionChargeStart;
    public void ActionChargeStart(ActionBase action, ActionChargeInfo info)
    {
        EvtActionChargeStart(this, info);
        return;
    }


    //5 EvtActionSingStart
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionChargeStart;
    public void ActionChargeStart(ActionBase action, ActionSingInfo info)
    {
        EvtActionChargeStart(this, info);
        return;
    }

    //6 EvtActionSingUpdate
    /Sing---------------------Sing--------------------------------------------------------
    public event EventHandler EvtActionChargeStart;
    public void ActionChargeUpdate(ActionBase action, ActionSingInfo info)
    {
        EvtActionChargeStart(this, info);
        return;
    }

    //7 EvtActionSingEnd
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionChargeStart;
    public void ActionChargeStart(ActionBase action, ActionSingInfo info)
    {
        EvtActionChargeStart(this, info);
        return;
    }

}

public class ActionPreCheckInfo : EventArgs
{
    public ActionBase action;
    public GameObject actor;
    public ActionKey actionKey;
    public EActionPreCheckResult result = EActionPreCheckResult.OtherFail;
    public ActionPreCheckInfo(ActionBase action, GameObject actor, ActionKey actionKey)
    {
        this.action = action;
        this.actor = actor;
        this.actionKey = actionKey;
    }
}

public class ActionChargeInfo : EventArgs
{
    public ActionBase action;
    public GameObject actor;
    public ActionKey actionKey;
    public float chargeProcess = 0f;
    public ActionChargeInfo(ActionBase action, GameObject actor, ActionKey actionKey)
    {
        this.action = action;
        this.actor = actor;
        this.actionKey = actionKey;
    }
}

public class ActionSingInfo : EventArgs
{
    public ActionBase action;
    public GameObject actor;
    public ActionKey actionKey;
    public float singProcess = 0f;
    public ActionSingInfo(ActionBase action, GameObject actor, ActionKey actionKey)
    {
        this.action = action;
        this.actor = actor;
        this.actionKey = actionKey;
    }
}

public class ActionCastInfo : EventArgs
{
    public ActionBase action;
    public GameObject actor;
    public ActionKey actionKey;
    public bool isLanuched = false;
    public ActionCastInfo(ActionBase action, GameObject actor, ActionKey actionKey)
    {
        this.action = action;
        this.actor = actor;
        this.actionKey = actionKey;
    }
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

