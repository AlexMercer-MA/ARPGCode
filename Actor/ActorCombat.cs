using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorCombat : MonoBehaviour
{
    //往往由技能类调用到这个地方
    //技能类决定了伤害公式，如何传递
    //传递 KeyValue Pair 每一个伤害因子的系数
    //包括所有攻击属性的因子Struct
    
    //必定命中
    //必定暴击
    public void DealDamage()
    {




        CombatManager.Instance.Damage();
    }

    public void TakeDamage()
    {

    }

    //自身中心，进行相交球
    public ActorMain[] GetTargetBySphere()
    {

    }

    //自身中心，进行扇形相交球
    public ActorMain[] GetTargetByArcSphere()
    {

    }

    //发射射线，找到第一个目标
    public ActorMain[] GetTargetByRay()
    {

    }
    
    //发射射线，找到第一个目标点周围相交球
    public ActorMain[] GetTargetByRaySphere()
    {

    }

}
