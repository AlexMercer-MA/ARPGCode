using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Skill01_WindMill : ActionBase
{
    private void Start()
    {
        Initilize(ActionKey.Action_Q);
    }

    protected override void ActionCastStartImplement()
    {
        anim.SetLayerWeight(1, 2f);
        anim.SetInteger("ActionType", 1);
        anim.SetTrigger("ActionStart");
    }
    //public CharacterAction characterAttack;
    //public CharacterBehaviour characterBehaviour;
    //public Animator anim;

    ////技能数值
    //public float damage = 5f;
    //public float range = 4f;

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
    //    ActorProperty.GetInstance.Sp -= energy * (1f - ActorProperty.GetInstance.Csr);
    //    //先选择哪一种技能动画在setTrigger
    //    anim.SetInteger("SkillNum", 1);
    //    anim.SetTrigger("Skill");
    //    //设置技能层权重
    //    anim.SetLayerWeight(2, 2f);
    //    characterAttack.attackLayerWeight2 = 2f;

    //    characterBehaviour.bInAction = true;
    //    characterBehaviour.lockMoveSpeedModifier = 0.75f;
    //}

    //public override void SphereDetect()
    //{
    //    //设置攻击力
    //    damage = ActorProperty.GetInstance.PhyMelee * 0.5f;

    //    Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, this.range);

    //    for (int i = 0; i < hitColliders.Length; i++)
    //    {
    //        if (hitColliders[i].CompareTag("Enemy"))
    //        {
    //            EnemyProperties tempEnemyStatus = hitColliders[i].GetComponent<EnemyProperties>();
    //            tempEnemyStatus.TakePhysicalRangeDamage(Mathf.RoundToInt(damage), ActorProperty.GetInstance.AmrPeneFix, ActorProperty.GetInstance.AmrPenePer);
    //            Debug.Log(hitColliders[i].transform.name);

    //            //音效
    //            PlayerAudio.GetInstance.Hit();

    //        }
    //    }
    //}

    //public override void ActionStart() { }
    //public override void ActionFinish() { }
    //public override void ClearTargetGroup() { }

    //public override void ActionFinish()
    //{
    //    bInAction = false;
    //}
}
