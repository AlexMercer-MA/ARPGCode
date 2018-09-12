﻿using System;
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
 * 13EvtActionChannelCastLanuch
 * 14EvtActionChannelCastEnd
 * 15EvtActionBreak
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
    public event EventHandler EvtActionChargeUpdate;
    public void ActionChargeUpdate(ActionBase action, ActionChargeInfo info)
    {
        EvtActionChargeUpdate(this, info);
        return;
    }

    //4 EvtActionChargeEnd
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionChargeEnd;
    public void ActionChargeEnd(ActionBase action, ActionChargeInfo info)
    {
        EvtActionChargeEnd(this, info);
        return;
    }


    //5 EvtActionSingStart
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionSingStart;
    public void ActionChargeStart(ActionBase action, ActionSingInfo info)
    {
        EvtActionSingStart(this, info);
        return;
    }

    //6 EvtActionSingUpdate
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionSingUpdate;
    public void ActionChargeUpdate(ActionBase action, ActionSingInfo info)
    {
        EvtActionSingUpdate(this, info);
        return;
    }

    //7 EvtActionSingEnd
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionSingEnd;
    public void ActionSingEnd(ActionBase action, ActionSingInfo info)
    {
        EvtActionSingEnd(this, info);
        return;
    }

    //8 EvtActionCastStart
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionCastStart;
    public void ActionCastStart(ActionBase action, ActionCastInfo info)
    {
        EvtActionCastStart(this, info);
        return;
    }

    //9 EvtActionCastLaunch
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionCastLaunch;
    public void ActionCastLaunch(ActionBase action, ActionCastInfo info)
    {
        EvtActionCastLaunch(this, info);
        return;
    }

    //10 EvtActionCastEnd
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionCastEnd;
    public void ActionCastEnd(ActionBase action, ActionCastInfo info)
    {
        EvtActionCastEnd(this, info);
        return;
    }
    
    //11 EvtActionChannelStart
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionChannelStart;
    public void ActionChannelStart(ActionBase action, ActionChannelInfo info)
    {
        EvtActionChannelStart(this, info);
        return;
    }

    //12 EvtActionChannelLaunch
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionChannelLaunch;
    public void ActionChannelLaunch(ActionBase action, ActionChannelInfo info)
    {
        EvtActionChannelLaunch(this, info);
        return;
    }

    //13 EvtActionChannelUpdate
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionChannelUpdate;
    public void ActionChannelUpdate(ActionBase action, ActionChannelInfo info)
    {
        EvtActionChannelUpdate(this, info);
        return;
    }

    //14 EvtActionChannelEnd
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionChannelEnd;
    public void ActionChannelEnd(ActionBase action, ActionChannelInfo info)
    {
        EvtActionChannelEnd(this, info);
        return;
    }

    //14 EvtActionBreak
    //----------------------------------------------------------------------------------------
    public event EventHandler EvtActionBreak;
    public void ActionBreak(ActionBase action, ActionBreakInfo info)
    {
        EvtActionBreak(this, info);
        return;
    }

    public void ActionCooldownUpdate()
    {
        throw new NotImplementedException();
    }

    public void ActionChargeUpdate(float actionChargeStamp)
    {
        throw new NotImplementedException();
    }

    public void ActionSingUpdate(float actionSingStamp)
    {
        throw new NotImplementedException();
    }

    public void ActionChannelUpdate(float actionChannelStamp)
    {
        throw new NotImplementedException();
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
    public float chargeProgress = 0f;
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
    public float singProgress = 0f;
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
    public ActionCastInfo(ActionBase action, GameObject actor, ActionKey actionKey)
    {
        this.action = action;
        this.actor = actor;
        this.actionKey = actionKey;
    }
}

public class ActionChannelInfo : EventArgs
{
    public ActionBase action;
    public GameObject actor;
    public ActionKey actionKey;
    public float channelProgress = 0f;
    public ActionChannelInfo(ActionBase action, GameObject actor, ActionKey actionKey)
    {
        this.action = action;
        this.actor = actor;
        this.actionKey = actionKey;
    }
}

public class ActionBreakInfo : EventArgs
{
    public ActionBase action;
    public GameObject actor;
    public ActionKey actionKey;
    public EActionBreakType breakType;
    public ActionBreakInfo(ActionBase action, GameObject actor, ActionKey actionKey)
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
