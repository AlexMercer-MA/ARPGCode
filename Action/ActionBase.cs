using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 抽象类 所有Action的基类
public abstract class ActionBase : MonoBehaviour
{
    // 基础属性
    public Animator anim;                           //动画状态机
    public ActionKey actionKey;                     //Action按键

    // 静态属性（从EXCEL读取）
    public int ID;                                  //技能ID
    public string actionName;                       //技能名字
    public string actionDes;                        //技能说明
    public string image;                            //技能图标
    public float coolDown;                          //冷却时间
    public float energyCost;                        //消耗能量
    public float kpAfCost;                          //消耗kpA float能量
    public float kpBfCost;                          //消耗kpB float能量
    public int kpAiCost;                            //消耗kpA int能量
    public int kpBiCost;                            //消耗kpB int能量
    public float chargeTime;                        //蓄力时间长度（没有就是0）
    public float singTIme;                          //吟唱时间长度（没有就是0）
    public float channelTime;                       //通道时间长度（这个是倒计时！）
    public string isCanNotBreak;                    //是否无法被打断（这个属性拥有最高优先级）   （需求：Shift翻滚可以打断部分技能，右键技能可以打断左键技能）
    public string isCanBreakOther;                  //是否可以打断其他技能（如果不能打断其他技能，则无需判断打断优先关系）
    public string nCanNotBreakLv;                   //防止被打断级别（如果相等，则可以打断）
    public string nBreakOtherLv;                    //可以打断级别（如果相等，则可以打断）   （类似的控制级别和防止控制级别，也可以这样制作）
    public string isCanCastInDisabled;              //是否可以在被控制情况下使用（拥有最高优先级，可以在一切被控制状态下使用）
    public float triggerRatio;                      //触发系数

    // 运行属性
    public bool isActive;                           //Action 是否被激活
    public GameObject actor;                        //Action 的拥有者
    public ActionProgressType eProgress;            //Action 的状态阶段
    public ActionPreCheckInfo actionPreCheckInfo;   //ActionPreCheckInfo
    public ActionChargeInfo actionChargeInfo;       //ActionChargeInfo
    public ActionSingInfo actionSingInfo;           //ActionSingInfo
    public ActionCastInfo actionCastInfo;           //ActionCastInfo
    public ActionEndInfo actionEndInfo;             //actionEndInfo
    public bool isLockCD;                           //CD是否被锁定
    public float actionTimeStamp;                   //技能时间戳，用以和CD对比
    public float actionChargeStamp;                 //技能蓄力程度
    public float actionSingStamp;                   //技能吟唱戳
    public float actionChannelStamp;                //通道技能引道戳
    public ActionCastType castType;                 //技能释放类型 1普通/2蓄力/3吟唱/4通道/5独立
    public ActionEffectType effectType;             //技能效果类型 

    /* ----------------------------- 判断CD -----------------------------
     * 在TryAction中 如果 bInProgress == false && Time.time >= actionTimeStamp + coolDown
     * 才可以正式开始
     * 
     * OnActionStart中，设置：
     * 设置 bInProgress 
     * ActionManager.bInAction
     * 
     * OnActionOver中，设置
     * 设置 actionTimeStamp通常会在 ActionOver中进行
     * */

    /* ----------------------------- 打断优先级 -----------------------------
     * nCanNotBreakLv 是防止被打断级别
     * nBreakOtherLv 是可以打断级别
     * 当一个可以被打断的技能进行中，释放了另一个有打断权限的技能
     * 如果防止打断级别 >= 打断级别，则无法打断
     * */

    //更高级抽象的属性
    //public string effectRatio;                    //(影响范围，应该放在更高级的类中)

    // ------------------------------------- 初始化 -------------------------------------
    public virtual void Initilize(ActionKey actionKey)
    {
        this.actionKey = actionKey;
        actionPreCheckInfo = new ActionPreCheckInfo(this, this.gameObject, this.actionKey);
        actionChargeInfo = new ActionChargeInfo(this, this.gameObject, this.actionKey);
        actionSingInfo = new ActionSingInfo(this, this.gameObject, this.actionKey);
        actionCastInfo = new ActionCastInfo(this, this.gameObject, this.actionKey);
        actionEndInfo = new ActionEndInfo(this, this.gameObject, this.actionKey);
        isActive = true;
    }

    // ------------------------------------- 帧刷新 -------------------------------------
    // 每帧刷新操作  每次Update时，由CharacterAction调用
    public virtual void Refresh(float deltaTime)
    {
        if (!isActive) { return; }
        if (!isLockCD)
        {
            //如果在 冷却阶段，需要持续向UI或其他发消息
            actionTimeStamp += deltaTime;
            ActionManager.GetInstance.
                ActionCooldownUpdate();   //TODO
        }
        else
        {
            //如果在 蓄力Charge/吟唱Sing/释放Cast 阶段，需要持续向UI或其他发消息
            switch (eProgress)
            {
                case ActionProgressType.CHARGE:
                    ActionManager.GetInstance.ActionChargeUpdate(actionChargeStamp);
                    break;
                case ActionProgressType.SING:
                    ActionManager.GetInstance.ActionSingUpdate(actionSingStamp);
                    break;
                case ActionProgressType.CHANNEL:
                    ActionManager.GetInstance.ActionChannelUpdate(actionChannelStamp);
                    break;
                default:
                    break;
            }
        }
    }

    // ------------------------------------- 重置CD -------------------------------------
    public virtual void ResetCD()
    {
        actionTimeStamp = 0f;
    }

    // --------------------------------- Action 生命周期方法 ---------------------------------
    // 1  ActionPreCheck
    protected virtual void ActionPreCheckImplement() { }         //在这里写具体实现的代码逻辑
    public virtual void ActionPreCheck(ActionBase action, ActionPreCheckInfo info)
    {
        //通过全部检查 则可以释放技能

        // TODO Slience 检查
        // 具体逻辑

        if (!ActionPreCheckEnergy())
        {
            info.result = EActionPreCheckResult.EnergyCheckFail;
            ActionManager.GetInstance.ActionPreCheck(this, actionPreCheckInfo);
            return;
        }

        if (kpAfCost > 0 && !ActionPreCheckKpAf())
        {
            info.result = EActionPreCheckResult.KPAfCheckFail;
            ActionManager.GetInstance.ActionPreCheck(this, actionPreCheckInfo);
            return;
        }

        if (kpBfCost > 0 && !ActionPreCheckKpBf())
        {
            info.result = EActionPreCheckResult.KPBfCheckFail;
            ActionManager.GetInstance.ActionPreCheck(this, actionPreCheckInfo);
            return;
        }

        if (kpAiCost > 0 && !ActionPreCheckKpAi())
        {
            info.result = EActionPreCheckResult.KPAiCheckFail;
            ActionManager.GetInstance.ActionPreCheck(this, actionPreCheckInfo);
            return;
        }

        if (kpBiCost > 0 && !ActionPreCheckKpBi())
        {
            info.result = EActionPreCheckResult.KPBiCheckFail;
            ActionManager.GetInstance.ActionPreCheck(this, actionPreCheckInfo);
            return;
        }

        if (!ActionPreCheckCD())
        {
            info.result = EActionPreCheckResult.CDCheckFail;
            ActionManager.GetInstance.ActionPreCheck(this, actionPreCheckInfo);
            return;
        }

        info.result = EActionPreCheckResult.Success;
        ActionManager.GetInstance.ActionPreCheck(this, actionPreCheckInfo);

        //PreCheck结束，进行下一步骤
        if (castType == ActionCastType.CHARGE)
        {
            ActionChargeStart();
        }
        else if(castType == ActionCastType.CHANNEL)
        {
            ActionChannelStart();
        }
        else if (castType == ActionCastType.CAST)
        {
            ActionCastStart();
        }

        //异常
        eProgress = ActionProgressType.DEFAULT;
        return;
    }

    // 2 ActionChargeStart
    protected virtual void ActionChargeStartImplement() { }         //在这里写具体实现的代码逻辑
    public void ActionChargeStart()
    {
        //设置action状态
        eProgress = ActionProgressType.CHARGE;
        //开始播放动画
        ActionChargeStartImplement();
        //anim.SetTrigger() 等等实现
        actionChargeInfo.chargeProgress = 0f;
        ActionManager.GetInstance.ActionChargeStart(this, actionChargeInfo);
    }

    // 3 ActionChargeUpdate
    protected virtual void ActionChargeUpdateImplement() { }        //在这里写具体实现的代码逻辑
    public virtual void ActionChargeUpdate(float process)
    {
        actionChargeInfo.chargeProgress = process;
        ActionChargeUpdateImplement();
        ActionManager.GetInstance.ActionChargeUpdate(this, actionChargeInfo);
    }

    // 4 ActionChargeEnd
    protected virtual void ActionChargeEndImplement() { }           //在这里写具体实现的代码逻辑
    public virtual void ActionChargeEnd()
    {
        ActionChargeEndImplement();
        ActionManager.GetInstance.ActionChargeUpdate(this, actionChargeInfo);
        //Charge结束，进行下一步骤
        ActionCastStart();
    }

    // 5 ActionSingStart
    protected virtual void ActionSingStartImplement() { }           //在这里写具体实现的代码逻辑
    public virtual void ActionSingStart()
    {
        //设置action状态
        eProgress = ActionProgressType.SING;
        actionSingInfo.singProgress = 0f;
        ActionSingStartImplement();
        ActionManager.GetInstance.ActionChargeStart(this, actionSingInfo);
    }

    // 6 ActionSingUpdate
    protected virtual void ActionSingUpdateImplement() { }          //在这里写具体实现的代码逻辑
    public virtual void ActionSingUpdate(float process)
    {
        actionSingInfo.singProgress = process;
        ActionSingUpdateImplement();
        ActionManager.GetInstance.ActionChargeUpdate(this, actionSingInfo);
    }

    // 7 ActionSingEnd
    protected virtual void ActionSingEndImplement() { }             //在这里写具体实现的代码逻辑
    public virtual void ActionSingEnd()
    {
        ActionManager.GetInstance.ActionChargeUpdate(this, actionSingInfo);
        ActionSingEndImplement();
        //Charge结束，进行下一步骤
        ActionCastStart();
    }

    // 8 ActionCastStart
    protected virtual void ActionCastStartImplement() { }           //在这里写具体实现的代码逻辑
    public virtual void ActionCastStart()
    {
        eProgress = ActionProgressType.CAST;
        ActionCastStartImplement();
        ActionManager.GetInstance.ActionCastStart(this, actionCastInfo);
    }

    // 9 ActionCastLaunch (可能由脚本触发，也可以由Animator触发)
    protected virtual void ActionCastLaunchImplement() { }          //在这里写具体实现的代码逻辑
    public virtual void ActionCastLaunch()
    {
        ActionCastLaunchImplement();
        ActionManager.GetInstance.ActionCastStart(this, actionCastInfo);
    }

    // 10 ActionCastEnd
    protected virtual void ActionCastEndImplement() { }             //在这里写具体实现的代码逻辑
    public virtual void ActionCastEnd()
    {
        ActionCastEndImplement();
        ActionManager.GetInstance.ActionCastStart(this, actionCastInfo);
    }

    // 11 ActionChannelStart
    protected virtual void ActionChannelStartImplement() { }        //在这里写具体实现的代码逻辑
    public virtual void ActionChannelStart()
    {
        eProgress = ActionProgressType.CHANNEL;
        ActionChannelStartImplement();
        ActionManager.GetInstance.ActionCastStart(this, actionCastInfo);
    }

    // 12 ActionChannelLaunch (可能由脚本触发，也可以由Animator触发)
    protected virtual void ActionChannelLaunchImplement() { }       //在这里写具体实现的代码逻辑
    public virtual void ActionChannelLaunch()
    {
        ActionChannelLaunchImplement();
        ActionManager.GetInstance.ActionCastStart(this, actionCastInfo);
    }

    // 13 ActionChannelUpdate
    protected virtual void ActionChannelUpdateImplement() { }       //在这里写具体实现的代码逻辑
    public virtual void ActionChannelUpdate()
    {
        ActionChannelUpdateImplement();
        ActionManager.GetInstance.ActionCastStart(this, actionCastInfo);
    }

    // 14 ActionChannelEnd
    protected virtual void ActionChannelEndImplement() { }          //在这里写具体实现的代码逻辑
    public virtual void ActionChannelEnd()
    {
        eProgress = ActionProgressType.DEFAULT;
        ActionChannelEndImplement();
        ActionManager.GetInstance.ActionCastStart(this, actionCastInfo);
    }

    // 15 ActionEnd
    protected virtual void ActionEndImplement() { }               //在这里写具体实现的代码逻辑
    public virtual void ActionEnd(EActionEndType endType)
    {
        ActionEndImplement();
        actionEndInfo.endType = endType;
        ActionManager.GetInstance.ActionEnd(this, actionEndInfo);
    }



    bool ActionPreCheckEnergy()                //检查能量消耗
    {
        if (PlayerPropertiesFinal.GetInstance.Sp >= energyCost * PlayerPropertiesFinal.GetInstance.Csr_Action)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool ActionPreCheckKpAf()                  //检查职业资源 KPA float
    {
        if (!(kpAfCost > 0))
            return true;
        if (kpAfCost <= PlayerPropertiesFinal.GetInstance.KPA_f)
            return true;
        return false;
    }

    bool ActionPreCheckKpBf()                  //检查职业资源 KPB float
    {
        if (!(kpBfCost > 0))
            return true;
        if (kpBfCost <= PlayerPropertiesFinal.GetInstance.KPB_f)
            return true;
        return false;
    }

    bool ActionPreCheckKpAi()                  //检查职业资源 KPA int
    {
        if (kpAiCost <= 0)
            return true;
        if (kpAiCost <= PlayerPropertiesFinal.GetInstance.KPA_i)
            return true;
        return false;
    }

    bool ActionPreCheckKpBi()                  //检查职业资源 KPB int
    {
        if (kpBiCost <= 0)
            return true;
        if (kpBiCost <= PlayerPropertiesFinal.GetInstance.KPB_i)
            return true;
        return false;
    }

    bool ActionPreCheckCD()                    //检查冷却时间
    {
        if (actionTimeStamp >= coolDown * PlayerPropertiesFinal.GetInstance.Cdr_Action)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

/*
 * --------------------------技能释放类型--------------------------
 * 0 普通技能，检查所有条件
 * 1 吟唱技能
 * 2 蓄力技能
 * 3 引导技能
 * 4 不受任何影响，随时都可以使用，且独立判断
 * */
public enum ActionCastType
{
    CAST,
    SING,
    CHARGE,
    CHANNEL,
    INDEPENDENT,
}

/*
 * --------------------------技能效果类型--------------------------
 * 0 脚本处理                               （自由处理）
 * 1 仅自身                                 （无输入）（无返回，可以用来做始终在面前的召唤技能）
 * 2 扇形/圆形自身AOE                        （输入角度，TargetType）（返回所有命中单位）
 * 3 召唤虚拟体，产生投射物                   （返回召唤的投射物，以及相应脚本做后续处理）
 * 4 射线目标点方向可穿透加设置距离           （返回目标点坐标，和射线经过的所有单位）瞬发射击，目标点召唤
 * 5 射线目标点首个命中单位                  （返回目标点，命中单位）刺客-瞬步
 * 6 射线目标点圆形AOE                      （返回目标点，命中单位）刺客-瞬步
 * */
public enum ActionEffectType
{
    CUSTOM,
    SELF,
    SELF_AOE,
    DUMMY,
    RAY_DIRECTION,
    RAY_TARGET,
    RAY_TARGET_AOE,
}

/*
 * --------------------------技能状态类型--------------------------
 * 0 未在任何状态     （表示此技能没在释放）
 * 1 蓄力中
 * 2 吟唱中
 * 3 释放中
 * */
public enum ActionProgressType
{
    DEFAULT,
    CHARGE,
    SING,
    CAST,
    CHANNEL,
}

/*
 * --------------------------技能结束原因类型--------------------------
 * 0 正常结束     （表示此技能没在释放）
 * 1 在CAST过程中被打断
 * 2 在CHARGE过程中被打断
 * 3 在SING过程中被打断
 * 4 在CHANNEL过程中被打断
 * */
public enum EActionEndType
{
    NORMAL,
    BREAK_IN_CAST,
    BREAK_IN_CHARGE,
    BREAK_IN_SING,
    BREAK_IN_CHANNEL,
}
