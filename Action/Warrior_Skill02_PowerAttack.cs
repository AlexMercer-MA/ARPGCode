using MXX;
using PGW;
using CY;
using HYB;
using YNB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MXX
{
    public class Warrior_Skill02_PowerAttack : ActionBase
    {

        //	public CharacterAction characterAttack;
        //	public CharacterBehaviour characterBehaviour;
        //	public Animator anim;
        //	public GameObject shockWaveParticle;

        //	//技能数值
        //	public float damage = 80f;
        //	public float range = 4f;

        //	void Update()
        //	{
        //		if (!bInAction)
        //		{
        //			skillTime += Time.deltaTime;
        //		}
        //	}

        //	public override void Action()
        //	{
        //		bInAction = true;
        //		skillTime = 0f;
        //		//扣除消耗
        //		ActorPropertiesFinal.GetInstance.Sp -= energy * (1f-ActorPropertiesFinal.GetInstance.Csr);
        //		//先选择哪一种技能动画在setTrigger
        //		anim.SetInteger("SkillNum",2);
        //		anim.SetTrigger ("Skill");
        //		//设置技能层权重
        //		anim.SetLayerWeight (2,2f);
        //		characterAttack.attackLayerWeight2 = 2f;

        //		//音效
        //		PlayerAudio.GetInstance.Whoosh ();



        //		characterBehaviour.bInAction = true;
        //		characterBehaviour.TurnToForward(); //强制面向摄像机前方
        //		characterBehaviour.bLockRotate = true; 	  //锁定角色方向
        //		characterBehaviour.bLockMove = true;       //锁定角色移动
        //		characterBehaviour.bCanJump = true;       //锁定角色跳跃
        //		characterBehaviour.lockMoveSpeedModifier = 2f; //2倍速度移动

        //		//强制玩家做出起跳
        //		characterBehaviour.cc.Move (Vector3.up*1f);
        //		characterBehaviour.gSpeed = 10f;
        //	}

        //	public override void SphereDetect()
        //	{
        //		//设置攻击力
        //		damage = ActorPropertiesFinal.GetInstance.PhyMelee*4f;

        //		//音效
        //		PlayerAudio.GetInstance.Crash ();

        //		Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, this.range);

        //		for (int i = 0;i < hitColliders.Length;i++)
        //		{
        //			if (hitColliders[i].CompareTag("Enemy"))
        //			{
        //				EnemyProperties tempEnemyStatus = hitColliders [i].GetComponent<EnemyProperties> ();
        //				tempEnemyStatus.TakePhysicalRangeDamage (Mathf.RoundToInt(damage),ActorPropertiesFinal.GetInstance.AmrPeneFix,ActorPropertiesFinal.GetInstance.AmrPenePer);
        //				Debug.Log (hitColliders[i].transform.name);
        //			}
        //		}
        //	}

        //	public override void ActionStart(){}
        //	public override void ActionFinish(){}
        //	public override void ClearTargetGroup(){}

        //	public override void ActionFinish()
        //	{
        //		bInAction = false;
        //	}
    }
}
