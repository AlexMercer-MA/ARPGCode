using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPotion : ActionBase
{

    //public CharacterAction characterAttack;
    //public CharacterBehaviour characterBehaviour;
    //public Animator anim;

    //public GameObject recoverEffect;

    ////技能数值
    //public float duration = 5f;

    //void Update()
    //{
    //    if (!bInAction)
    //    {
    //        skillTime += Time.deltaTime;
    //    }
    //}

    //public override void Action()
    //{
    //    bInAction = true;
    //    skillTime = 0f;
    //    //扣除消耗
    //    ActorPropertiesFinal.GetInstance.Sp -= energy;
    //    //回复生命和能量
    //    ActorPropertiesFinal.GetInstance.Hp += 0.5f * ActorPropertiesFinal.GetInstance.HpMax;
    //    ActorPropertiesFinal.GetInstance.Sp += 0.5f * ActorPropertiesFinal.GetInstance.SpMax;

    //    Instantiate(recoverEffect, CharacterBehaviour.GetInstace.hitPoint.transform);

    //    Invoke("ActionOver", 0.5f);
    //    //ActionOver ();
    //}

    //public override void SphereDetect() { }
    //public override void ActionStart() { }
    //public override void ActionFinish() { }
    //public override void ClearTargetGroup() { }

    //public override void ActionFinish()
    //{
    //    bInAction = false;
    //}
}
