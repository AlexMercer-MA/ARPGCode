using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 抽象类 所有Action的基类
public abstract class ActionBase : MonoBehaviour
{
    // 基础属性
    public Animator anim;                           //动画状态机

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
    //public string effectRatio;                    //(影响范围，应该放在更高级的类中)
    // 打断相关（核心需求：Shift翻滚可以打断部分技能，右键技能可以打断左键技能）
    public string isCanNotBreak;                    //是否无法被打断
    public string isCanBreakOther;                  //是否可以打断其他技能
    public string nCanNotBreakLv;                   //防止被打断级别
    public string nBreakOtherLv;                    //可以打断级别
    public string isCanCastInDisabled;              //是否可以在被控制情况下使用

    // 运行属性
    public bool isActive;                           //Action 是否被激活
    public ActionProgressType eProgress;            //Action 的状态阶段
    public bool isLockCD;                           //CD是否被锁定
    public float actionTimeStamp;                   //技能时间戳，用以和CD对比
    public ActionCastType castType;
    public ActionEffectType effectType;

    // -------------------------------------方法-------------------------------------
    public void Start()
    {

    }

    // 每帧刷新操作  每次Update时，由CharacterAction调用
    public virtual void Refresh(float deltaTime)
    {
        if (!isLockCD)
        {
            actionTimeStamp += deltaTime;
        }
    }

    // 重置CD
    public virtual void ResetCD()
    {
        actionTimeStamp = 0f;
    }

    // -------------------------------------Action方法-------------------------------------
    // 1  ActionPreCheck
    public virtual void ActionPreCheck(ActionKey actionKey)
    {
        //通过全部检查 则可以释放技能
        ActionPreCheckInfo info = new ActionPreCheckInfo();
        info.actionKey = actionKey;
        info.actor = this.gameObject;

        // TODO Slience 检查
        // TODO 具体逻辑

        if (!ActionPreCheckEnergy())
        {
            info.result = EActionPreCheckResult.EnergyCheckFail;
            ActionManager.GetInstance.ActionPreCheck(this, info);
            return;
        }

        if (kpAfCost > 0 && !ActionPreCheckKpAf())
        {
            info.result = EActionPreCheckResult.KPAfCheckFail;
            ActionManager.GetInstance.ActionPreCheck(this, info);
            return;
        }

        if (kpBfCost > 0 && !ActionPreCheckKpBf())
        {
            info.result = EActionPreCheckResult.KPBfCheckFail;
            ActionManager.GetInstance.ActionPreCheck(this, info);
            return;
        }

        if (kpAiCost > 0 && !ActionPreCheckKpAi())
        {
            info.result = EActionPreCheckResult.KPAiCheckFail;
            ActionManager.GetInstance.ActionPreCheck(this, info);
            return;
        }

        if (kpBiCost > 0 && !ActionPreCheckKpBi())
        {
            info.result = EActionPreCheckResult.KPBiCheckFail;
            ActionManager.GetInstance.ActionPreCheck(this, info);
            return;
        }

        if (!ActionPreCheckCD())
        {
            info.result = EActionPreCheckResult.CDCheckFail;
            ActionManager.GetInstance.ActionPreCheck(this, info);
            return;
        }

        info.result = EActionPreCheckResult.Success;
        ActionManager.GetInstance.ActionPreCheck(this, info);
        ActionChargeStart(info);
        return;
    }


    // 2 ActionChargeStart
    public virtual void ActionChargeStart(ActionPreCheckInfo info)
    {
        //开始播放动画

    }
    

    //3 ActionChargeEnd


    //4 ActionSingStart


    //5 ActionSingEnd







    //public virtual void ActionFinish();            // Action 执行完成
    //public virtual void ActionOver();              // Action 全部完成（最终完成）


    //public virtual void SphereDetect();            // 进行一次球体检测
    //public virtual void ClearTargetGroup();        // 清空检测检测组（这样仅仅保存一个碰撞信息）



    /*
     * --------------------------判断CD--------------------------
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

    /*
     * --------------------------打断优先级--------------------------
     * nCanNotBreakLv 是防止被打断级别
     * nBreakOtherLv 是可以打断级别
     * 当一个可以被打断的技能进行中，释放了另一个有打断权限的技能
     * 如果防止打断级别 >= 打断级别，则无法打断
     * */

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
    Normal,
    Sing,
    Charge,
    Channel,
    Independent,
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
    Custom,
    Self,
    SelfAOE,
    Dummy,
    RayDirection,
    RayTarget,
    RayTargetAoe,
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
    Default,
    Charge,
    Sing,
    Cast,
}