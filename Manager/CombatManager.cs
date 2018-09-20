using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    /*
     * 计算流程
     * Source 通过DealDamage发起 进行计算伤害 先计算出最终伤害是多少 本次伤害是否暴击 是否必中，传递给Damage方法
     * DealDamage()
     * Source ActorMain 
     * Targets ActorMain[] 目标数组，可以既有Player又有Npc
     * int damageValue 伤害数值
     * EDamageType type 伤害类型
     * Args.. 其他参数
     */

    public void Damage(ActorMain Source, ActorMain[] Targets)
    {
        //Player -> Npc

        //Npc -> Player

        //Npc -> Npc
    }
}

public enum EDamageType
{
    PHYSICAL_MELEE,
    PHYSICAL_RANGE,
    MAGIC_FIRE,
    MAGIC_ICE,
    MAGIC_LIGHTNING,
    MAGIC_POISON,
    MAGIC_ACRANE,
    MAGIC_SHADOW,
    MAGIC_HOLY,
    PURE,              //真实伤害
}

//ActorProperties 类可以通过方法GetOffenseInfo获取
public struct OffenseInfo
{

}

//ActorProperties 类可以通过方法GetDefenceInfo获取
public struct DefenceInfo
{

}
