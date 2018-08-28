using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 抽象类 所有Action的基类
public abstract class ActionBase : MonoBehaviour
{
    public abstract void TryAction();               // 执行这个Action（检测各种条件，一旦通过触发事件OnActionStart）
    public abstract void ActionStart();             // Action 开始执行（一旦结束触发事件OnActionFinish）
    public abstract void ActionFinish();            // Action 执行完成
    public abstract void ActionOver();              // Action 全部完成（最终完成）

    public abstract void SphereDetect();            // 进行一次球体检测
    public abstract void ClearTargetGroup();        // 清空检测检测组（这样仅仅保存一个碰撞信息）

    // 运行时 数据
    public bool bInProgress;
    public float actionTimeStamp;
    /*
     * 在TryAction中 如果 bInProgress == false && Time.time >= actionTimeStamp + coolDown
     * 才可以正式开始 Action
     * 
     * OnActionStart中，设置：
     * 设置 bInProgress 
     * ActionManager.bInAction
     * 
     * OnActionOver中，设置
     * 设置 actionTimeStamp通常会在 ActionOver中进行
     */

    // From EXCEL 读取表格的数据
    public int ID;
    public string Name;
    public string des;
    public string image;
    public float coolDown;
    public float energyCost;
    public string effectRatio;
    public string bCanNotBreak;
    public string bCanBreakOther;
    public string bCanCastWhenControllered;

}