using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_BasicAttack : ActionBase
{
    //public float generateSp = 20f;
    //public CharacterAction characterAttack;
    //public CharacterBehaviour characterBehaviour;
    //public Animator anim;

    ////技能数值
    //public float damage = 10f;
    //public float range = 10f;
    //public float attackAngle = 180f;

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
    //    ActorPropertiesFinal.GetInstance.Sp -= energy * (1f - ActorPropertiesFinal.GetInstance.Cdr);
    //    //动画相关
    //    if (anim.GetBool("AttackHand") == false)
    //    {
    //        anim.SetBool("AttackHand", true);       //true is Righthand Attack
    //    }
    //    else
    //    {
    //        anim.SetBool("AttackHand", false);      //false is Lefthand Attack
    //    }
    //    //先选择哪一种攻击动画在setTrigger
    //    anim.SetTrigger("Attack");

    //    //设置Animator
    //    anim.SetLayerWeight(1, 1.5f);
    //    characterAttack.attackLayerWeight1 = 1.5f;

    //    //设置玩家锁定相关设置
    //    characterBehaviour.bInAction = true;//强制玩家面向前方	
    //    characterBehaviour.TurnToForward();
    //    characterBehaviour.eLockRotationDir = LockDirection.Forward; //锁定角色始终面向摄像机前方
    //    characterBehaviour.lockMoveSpeedModifier = 0f;

    //}

    //public override void SphereDetect()
    //{
    //    //击中了多少敌人
    //    int hitEnemy = 0;

    //    //音效
    //    PlayerAudio.GetInstance.Whoosh();

    //    //设置攻击力
    //    damage = Random.Range(ActorPropertiesFinal.GetInstance.PhyMeleeMin, ActorPropertiesFinal.GetInstance.PhyMeleeMax);
        
    //    //获得攻击目标
    //    Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, this.range);

    //    for (int i = 0; i < hitColliders.Length; i++)
    //    {

    //        if (hitColliders[i].CompareTag("Enemy"))
    //        {
    //            Vector3 enemyPos = hitColliders[i].transform.position;
    //            if (Vector3.Dot(Vector3.Normalize(this.gameObject.transform.forward), Vector3.Normalize(enemyPos - this.transform.position)) >= Mathf.Cos((this.attackAngle / 2) * Mathf.Deg2Rad))
    //            {
    //                EnemyProperties tempEnemyStatus = hitColliders[i].GetComponent<EnemyProperties>();
    //                Debug.Log("playerDamage" + Mathf.RoundToInt(damage));
    //                hitEnemy++;
    //                //造成伤害
    //                if (tempEnemyStatus != null)
    //                {
    //                    tempEnemyStatus.TakePhysicalRangeDamage(Mathf.RoundToInt(damage), ActorPropertiesFinal.GetInstance.AmrPeneFix, ActorPropertiesFinal.GetInstance.AmrPenePer);
    //                }
    //            }
    //        }
    //    }

    //    if (hitEnemy > 0)
    //    {
    //        //击中敌人就回复能量
    //        ActorPropertiesFinal.GetInstance.Sp += generateSp;

    //        //音效
    //        PlayerAudio.GetInstance.Hit();
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
