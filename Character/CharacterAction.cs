using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum ActionKey
//{
//    Action_Q,
//    Action_E,
//    Action_R,
//    Action_1,
//    Action_2,
//    Action_3,
//    Action_4,
//    Action_Shift,
//    Action_Ctrl,
//    Action_Tab,
//    Action_LMB,
//    Action_RMB,
//    None,
//}

public class CharacterAction : MonoBehaviour
{

    //单例模式
    public static CharacterAction GetInstance;

    //获取 CharacterBehaviour组件
    public CharacterBehaviour characterBehaviour;
    //获取 Animator组件
    public Animator anim;
    //获取 Action释放者
    public GameObject actor;

    //字典储存所有 ActionKey - ActionBase 键值对
    public Dictionary<ActionKey, ActionBase> actionDic = new Dictionary<ActionKey, ActionBase>();
    //攻击和技能基类 ActionBase
    ActionBase action_LMB;
    ActionBase action_RMB;
    ActionBase action_Shift;
    ActionBase action_Ctrl;
    ActionBase action_Q;
    ActionBase action_E;
    ActionBase action_R;
    ActionBase action_1;
    ActionBase action_2;
    ActionBase action_3;
    ActionBase action_4;
    ActionBase action_Tab;

    //动画控制器

    //技能/动作冷却时间 写在actionBase类里

    //public Skills skill;

    //玩家是不是在翻滚状态(翻滚状态无敌)
    //public bool isEvade = false;

    //武器拖尾渲染器
    public TrailRenderer trailRendererLeft;
    public TrailRenderer trailRendererRight;

    //动画权重值
    public float attackLayerWeight1;
    public float attackLayerWeight2;
    public float attackLayerWeight3;

    void Awake()
    {
        GetInstance = this;
        if (characterBehaviour)
        {
            actor = characterBehaviour.gameObject;
        }
        else
        {
            throw new Exception("NOT GET ACTION ACTOR");
        }

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
    
    //1 更新技能CD和 eProgress
    public void UpdateAction()
    {
        //TODO Effect Manager 如果人物进入锁定状态，则无法更新CD 并且 return

        //更新技能CD
        foreach (ActionBase action in actionDic.Values)
        {
            //更新所有已经激活的技能的CD （只有学习过的 ActionKey 位置的 Action 才被激活）
            if (!action.isActive) continue;
            //(内部处理) Action 没有被锁定CD，就更新CD
            action.Refresh(Time.deltaTime);
        }
    }

    //2 操作当前Action
    public void UseAction(ActionKey actionKey)
    {
        //在UI模式 或 没有按键的时候， 则没有 Action 被释放
        if (CharacterBehaviour.GetInstace.inUIMode || actionKey == ActionKey.None)
        {
            //复位所有UI(取消所有的高亮 ActionKey UI)
            ActionPanelUIManager.GetInstance.ResetUI();
            return;
        }

        //无论是否释放成功，都要设置高亮UI
        ActionPanelUIManager.GetInstance.SetHighLightUI(actionKey);
        //判断对应按键是否有技能 ActionBase 类
        ActionBase action;
        if (!actionDic.TryGetValue(actionKey, out action)) return;
        //判断是否能使用技能
        ActionPreCheckInfo info = new ActionPreCheckInfo(action, actor, actionKey);
        action.ActionPreCheck(action, info);
    }

    //TODO 03 更改动画权重层级（）
    /*void Update()
    {
        //取消攻击层动画权重
        attackLayerWeight1 -= Time.deltaTime * 1f;  //layer1 Attack
        attackLayerWeight2 -= Time.deltaTime * 1f;  //layer2 Skill
        attackLayerWeight3 -= Time.deltaTime * 1f;  //layer3 Hit

        if (attackLayerWeight1 <= 0f)
            attackLayerWeight1 = 0.001f;
        if (attackLayerWeight2 <= 0f)
            attackLayerWeight2 = 0.001f;
        if (attackLayerWeight3 <= 0f)
            attackLayerWeight3 = 0.001f;

        //设置权重在0到1范围内
        anim.SetLayerWeight(1, Mathf.Clamp01(attackLayerWeight1));
        anim.SetLayerWeight(2, Mathf.Clamp01(attackLayerWeight2));
        anim.SetLayerWeight(3, Mathf.Clamp01(attackLayerWeight3));
    }*/
}
