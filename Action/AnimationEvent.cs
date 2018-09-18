using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public Animator anim;
    public CharacterBehaviour characterBehaviour;
    public CharacterAction characterAttack;

    //--------------------------------------------方法--------------------------------------------

    //表现
    //调用其他脚本的TrailStart
    //调用其他脚本的TrailEnd
    public void TrailStart()
    {
        TrailStartLeft();
        TrailStartRight();
    }

    public void TrailEnd()
    {
        TrailEndLeft();
        TrailEndRight();
    }

    public void TrailStartLeft()
    {
        //开启武器拖尾渲染器
        characterAttack.trailRendererLeft.enabled = true;
    }

    public void TrailStartRight()
    {
        //关闭武器拖尾渲染器
        characterAttack.trailRendererRight.enabled = true;
    }

    public void TrailEndLeft()
    {
        //开启武器拖尾渲染器
        characterAttack.trailRendererLeft.enabled = false;
    }

    public void TrailEndRight()
    {
        //关闭武器拖尾渲染器
        characterAttack.trailRendererRight.enabled = false;
    }
    
    //Anim 回调方法
    public void ActionCastLaunch(int id)
    {
        ActionBase action = CharacterAction.GetInstance.TryGetActionByID(id);
        if (action == null)
            return;
        action.ActionCastLaunch();
    }

    public void ActionCastEnd(int id)
    {
        ActionBase action = CharacterAction.GetInstance.TryGetActionByID(id);
        if (action == null)
            return;
        action.ActionCastEnd();
        //可以在这之后，就结束player的硬直状态
    }

    public void ActionChannelLaunch(int id)
    {
        ActionBase action = CharacterAction.GetInstance.TryGetActionByID(id);
        if (action == null)
            return;
        action.ActionChannelLaunch();
    }

    public void ActionChannelEnd(int id)
    {
        ActionBase action = CharacterAction.GetInstance.TryGetActionByID(id);
        if (action == null)
            return;
        action.ActionChannelEnd();
        //可以在这之后，就结束player的硬直状态
    }

    public void ActionEnd(int id)
    {
        ActionBase action = CharacterAction.GetInstance.TryGetActionByID(id);
        if (action == null)
            return;
        action.ActionEnd(EActionEndType.NORMAL);
    }

    public void ChangeFlatMoveSpeedLerp(float speed)
    {

    }

    public void ChangeFlatMoveSpeedForce(float speed)
    {

    }
    
    /*
    //造成伤害--------------------------------------------------------------------
    //A 球形判定造成伤害
    public void SphereDetect(int skillNum)
    {
        characterAttack.SphereDetect(skillNum);
    }

    //B 投射类型判定，要配合清理目标组
    public void AttackStart(int skillNum)
    {
        characterAttack.AttackStart(skillNum);
    }

    public void AttackOver(int skillNum)
    {
        characterAttack.AttackOver(skillNum);
    }

    public void ClearTargetGroup(int skillNum)
    {
        characterAttack.ClearTargetGroup(skillNum);
    }


    //物体拖尾效果--------------------------------------------------------------
    public void TrailStartLeft()
    {
        //开启武器拖尾渲染器
        characterAttack.trailRendererLeft.enabled = true;
    }

    public void TrailStartRight()
    {
        //开启武器拖尾渲染器
        characterAttack.trailRendererRight.enabled = true;
    }

    public void TrailStart()
    {
        TrailStartLeft();
        TrailStartRight();
    }

    public void TrailOverLeft()
    {
        //关闭武器拖尾渲染器
        characterAttack.trailRendererLeft.enabled = false;
    }

    public void TrailOverRight()
    {
        //关闭武器拖尾渲染器
        characterAttack.trailRendererRight.enabled = false;
    }

    public void TrailOver()
    {
        TrailOverLeft();
        TrailOverRight();
    }

    public void Whoosh()
    {
        PlayerAudio.GetInstance.Whoosh();
    }

    //Action释放结束--------------------------------------------------------------
    public void BasicAttackOver()
    {
        //重置攻击CD
        basicAttack.ActionOver();
    }

    public void SpecialAttackOver()
    {
        //重置特殊攻击的CD
        specialAttack.ActionOver();
        characterBehaviour.anim.SetInteger("SkillNum", 0);

    }

    public void SkillOver_01()
    {
        //重置技能1的CD
        skill01.ActionOver();
        characterBehaviour.anim.SetInteger("SkillNum", 0);

    }

    public void SkillOver_02()
    {
        //重置技能2的CD
        skill02.ActionOver();
        characterBehaviour.anim.SetInteger("SkillNum", 0);
    }

    public void SkillOver_03()
    {
        //重置技能3的CD
        skill03.ActionOver();
        characterBehaviour.anim.SetInteger("SkillNum", 0);
    }

    public void RollOver()
    {
        //重置翻滚技能的CD
        skillEvade.ActionOver();
        characterBehaviour.anim.SetInteger("SkillNum", 0);
        //超过时间停止躲避/翻滚
        characterAttack.isEvade = false;
    }

    //角色限制效果结束---------------------------------------------------
    public void StopForceMoveForward()
    {
        //characterBehaviour.forceMoveForward = false;
    }

    public void FallToGround()
    {
        characterBehaviour.gSpeed = -100f;
    }

    public void ChangeFlatMovement(float speed)
    {
        characterBehaviour.lockMoveSpeedModifier = speed;
    }

    public void ChangeRealFlatMovement(float speed)
    {
        //characterBehaviour.reallockSpeedModifier = speed;
    }

    //实例化特效----------------------------------------------------------
    public void InstantiateObject(GameObject obj)
    {
        Instantiate<GameObject>(obj, characterBehaviour.transform.position, characterBehaviour.transform.rotation);
    }

    //组合命令------------------------------------------------------------
    public void AllOver()
    {
        characterBehaviour.bLockRotate = false; //不再锁定旋转
        characterBehaviour.bLockMove = false; //不再锁定移动
        characterBehaviour.bCanJump = false; //不再锁定跳跃

        characterBehaviour.eLockRotationDir = LockDirection.None; //不再强制面对镜头前方
        characterBehaviour.lockMoveSpeedModifier = 1f; //恢复普通移动速度
        characterAttack.skill = Skills.none; //不再处于释放某种技能的状态
        TrailOver();                        //不在拖尾

        //if (characterAttack.basicAttack.bInAction)
        //{
        //    characterAttack.basicAttack.ActionOver();
        //}
        //if (characterAttack.specialAttack.bInAction)
        //{
        //    characterAttack.specialAttack.ActionOver();
        //}
        //if (characterAttack.skill01.bInAction)
        //{
        //    characterAttack.skill01.ActionOver();
        //}
        //if (characterAttack.skill02.bInAction)
        //{
        //    characterAttack.skill02.ActionOver();
        //}
        //if (characterAttack.skill03.bInAction)
        //{
        //    characterAttack.skill03.ActionOver();
        //}
        //if (characterAttack.skillEvade.bInAction)
        //{
        //    characterAttack.skillEvade.ActionOver();
        //}
        //if (characterAttack.potion.bInAction)
        //{
        //    characterAttack.potion.ActionOver();
        //}

        characterBehaviour.bInAction = false; //动作完成，可以进行别的操作了
    }
    */

}