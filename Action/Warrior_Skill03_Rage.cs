using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Skill03_Rage : ActionBuffBase
{

    public CharacterAction characterAttack;
    public CharacterBehaviour characterBehaviour;
    public Animator anim;
    public GameObject effects;

    //技能数值
    public float damageMutilpler = 0.3f;
    public float duration = 10f;

    void Update()
    {
        if (!bInAction)
        {
            skillTime += Time.deltaTime;
        }

        if (haveBuff)
        {
            //TODO
        }
    }

    public override void Action()
    {
        bInAction = true;

        skillTime = 0f;
        //扣除消耗
        PlayerPropertiesFinal.GetInstance.Sp -= energy * (1f - PlayerPropertiesFinal.GetInstance.Csr);

        //先选择哪一种技能动画在setTrigger
        anim.SetInteger("SkillNum", 3);
        anim.SetTrigger("Skill");
        //设置技能层权重
        anim.SetLayerWeight(2, 1.5f);
        characterAttack.attackLayerWeight2 = 1.5f;

        //设置攻击力
        PlayerPropertiesExtra.GetInstance.EXPhyMeleeP += damageMutilpler;
        haveBuff = true;
        //显示右上角的buff
        BuffList.instance.StartBuff(1, duration);
        //在buff持续时间结束后执行ActionOver
        Invoke("EffectOver", duration);

        Instantiate(effects, this.transform);

        characterBehaviour.bInAction = true;
    }

    public override void ActionFinish()
    {

    }

    public void EffectOver()
    {
        //改回攻击力
        PlayerPropertiesExtra.GetInstance.EXPhyMeleeP -= damageMutilpler;
        haveBuff = false;

        skillTime = 0f;
        bInAction = false;
    }

    public override void SphereDetect() { }
    public override void ActionStart() { }
    public override void ActionFinish() { }
    public override void ClearTargetGroup() { }
}
