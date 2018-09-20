using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : ActorAction
{

    public ActorMain actorMain;

    //字典储存所有 ActionKey - ActionBase 键值对
    public Dictionary<ActionKey, ActionBase> actionDic = new Dictionary<ActionKey, ActionBase>();

    //攻击和技能基类 ActionBase
    public ActionBase action_LMB;
    public ActionBase action_RMB;
    public ActionBase action_Shift;
    public ActionBase action_Ctrl;
    public ActionBase action_Q;
    public ActionBase action_E;
    public ActionBase action_R;
    public ActionBase action_1;
    public ActionBase action_2;
    public ActionBase action_3;
    public ActionBase action_4;
    public ActionBase action_Tab;

    void Awake()
    {
        instance = this;
        //初始化字典
        actionDic.Add(ActionKey.Action_LMB, action_LMB);
        actionDic.Add(ActionKey.Action_RMB, action_RMB);
        actionDic.Add(ActionKey.Action_Shift, action_Shift);
        actionDic.Add(ActionKey.Action_Ctrl, action_Ctrl);
        actionDic.Add(ActionKey.Action_Q, action_Q);
        actionDic.Add(ActionKey.Action_E, action_E);
        actionDic.Add(ActionKey.Action_R, action_R);
        actionDic.Add(ActionKey.Action_1, action_1);
        actionDic.Add(ActionKey.Action_2, action_2);
        actionDic.Add(ActionKey.Action_3, action_3);
        actionDic.Add(ActionKey.Action_4, action_4);
        actionDic.Add(ActionKey.Action_Tab, action_Tab);
    }

    //学到新技能之后
    public void SetAction(ActionKey key, ActionBase action)
    {

    }
}