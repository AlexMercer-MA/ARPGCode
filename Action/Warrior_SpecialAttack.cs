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
	public class Warrior_SpecialAttack : ActionChargeBase 
	{

		////	public CharacterPropoties characterPropoties  绑定玩家属性脚本
		//public CharacterAction characterAttack;
		//public CharacterBehaviour characterBehaviour;
		//public Animator anim;

		////技能数值
		//public float damage = 0f;
		//public float damageDelta = 20f;
		//public float damageMax = 40f;

		//public float bInActionSpeed = 0.5f;
		//public float bInActionSpeedDelta = 3f;
		//public float bInActionSpeedMax = 6.5f;

		//public float range = 10f;

		////技能释放状态
		//public bool isPrepare = false;		//正在蓄力状态
		//public bool isDamage = false;		//正在攻击状态

		////目标组
		//List<GameObject> targetGroup = new List<GameObject>();

		//void Update()
		//{
		//	if (!bInAction)
		//	{
		//		skillTime += Time.deltaTime;
		//	}

		//	if (PlayerPropertiesFinal.GetInstance.IsDead)
		//	{
		//		isPrepare = false;
		//		isDamage = false;
		//		return;
		//	}

		//	if (isPrepare)
		//	{
		//		anim.SetLayerWeight (2, 1.6f);
		//		characterAttack.attackLayerWeight2 = 1.6f;
				
		//		damage += damageDelta*Time.deltaTime;
		//		damage = Mathf.Clamp (damage,damage,damageMax);
				
		//		bInActionSpeed += bInActionSpeedDelta * Time.deltaTime;
		//		bInActionSpeed = Mathf.Clamp (bInActionSpeed,bInActionSpeed,bInActionSpeedMax);
				
		//		fillAmount += 1f * Time.deltaTime;
				
		//		if (Input.GetMouseButtonUp(1)&&CharacterBehaviour.GetInstace.bCanControl&&!PlayerPropertiesFinal.GetInstance.IsDead)
		//		{
		//			isPrepare = false;
		//			isDamage = true;
		//			anim.SetTrigger ("SkillRelease");

		//			//音效
		//			PlayerAudio.GetInstance.Whoosh ();

		//			fillAmount = 0f;
		//			characterBehaviour.bLockRotate = true; 	  //锁定角色方向
		//			characterBehaviour.bLockMove = true;       //锁定角色移动
		//			characterBehaviour.lockMoveSpeedModifier = bInActionSpeed; //X倍速度移动
		//		}
		//	}
			
		//	if (isDamage)
		//	{
		//		SphereDetect ();
		//	}
		//}

		//public override void Action()
		//{
		//	bInAction = true;
		//	skillTime = 0f;	
		//	//扣除消耗
		//	PlayerPropertiesFinal.GetInstance.Sp -= energy * (1f-PlayerPropertiesFinal.GetInstance.Csr);
		//	//初始化攻击力和速度
		//	damage = PlayerPropertiesFinal.GetInstance.PhyMelee*1f;
		//	damageDelta = PlayerPropertiesFinal.GetInstance.PhyMelee * 2f;
		//	damageMax =  PlayerPropertiesFinal.GetInstance.PhyMelee * 3f;
		//	bInActionSpeed = 0.5f;

		//	//先选择哪一种技能动画在setTrigger
		//	anim.SetInteger("SkillNum",-1);
		//	anim.SetTrigger ("Skill");
		//	//设置技能层权重
		//	anim.SetLayerWeight (2, 1.6f);
		//	characterAttack.attackLayerWeight2 = 1.6f;

		//	//正在蓄力状态
		//	isPrepare = true;

		//	characterBehaviour.bInAction = true;
		//	characterBehaviour.TurnToCameraForward(); //强制面向摄像机前方
		//	characterBehaviour.eLockRotationDir = Direction.Forward; //锁定角色始终面向摄像机前方
		//	characterBehaviour.bCanJump = true;       //锁定角色跳跃
		//	characterBehaviour.lockMoveSpeedModifier = 0f; //0倍速度移动
		//}


		//public override void SphereDetect()
		//{
		//	Debug.Log ("SpecialAttack");
		//	Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, this.range);

		//	for (int i = 0;i < hitColliders.Length;i++)
		//	{
		//		if (hitColliders[i].CompareTag("Enemy")&&!targetGroup.Contains(hitColliders[i].gameObject))
		//		{
		//			EnemyProperties tempEnemyStatus = hitColliders [i].GetComponent<EnemyProperties> ();
		//			tempEnemyStatus.TakePhysicalRangeDamage (Mathf.RoundToInt(damage),PlayerPropertiesFinal.GetInstance.AmrPeneFix,PlayerPropertiesFinal.GetInstance.AmrPenePer);
		//			targetGroup.Add (hitColliders[i].gameObject);
		//			Debug.Log (hitColliders[i].transform.name);

		//			//音效
		//			PlayerAudio.GetInstance.Hit ();
		//		}
		//	}
		//}

		//public override void ActionStart()
		//{
		//	isDamage = true;
		//}

		//public override void ActionFinish()
		//{
		//	isDamage = false;
		//	ClearTargetGroup ();
		//}

		//public override void ClearTargetGroup()
		//{
		//	targetGroup.Clear ();
		//}

		//public override void ActionFinish()
		//{
		//	bInAction = false;
		//}
	}
}
