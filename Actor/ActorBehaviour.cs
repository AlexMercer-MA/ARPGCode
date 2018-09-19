using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ActorBehaviour : MonoBehaviour
{
    public ActorMain ActorMain { get; set; }        //Actor主控制

    public bool IsAlive { get; set; }               //是否存活
    public bool IsInvernable { get; set; }          //无敌，不可被杀死，最小HP_int为1

    public bool CanMove { get; set; }               //能否移动
    public bool IsLockMove { get; set; }            //是否锁定移动
    public float LockMoveSpeed { get; set; }        //强制移动速度

    public bool CanRotate { get; set; }             //能否旋转
    public bool IsLockRotate { get; set; }          //是否锁定旋转
    public float LockTurnAngle { get; set; }        //强制锁定角度
    
    public bool IsUseGravity { get; set; }          //是否受重力影响
    public bool IsUseCustomGravity { get; set; }    //是否使用自定义重力
    public float CustomGravity { get; set; }        //自定义重力值（标准重力为 -20f）
    public float gSpeed { get; set; }               //重力速度
    public bool IsGrounded { get; set; }            //是否着地

    public bool CanJump { get; set; }               //能否跳跃
    public bool CanMultiJump { get; set; }          //能否多段跳
    public int JumpNum { get; set; }                //当前跳跃次数
    public int MultiJumpLimit { get; set; }         //多段跳次数上限
    public float JumpInterval { get; set; }         //跳跃间隔
    public float JumpForce { get; set; }            //跳跃力
    
    public abstract void UpdateBehaviour();         //更新方法

    public void SetCanJump(bool b)
    {
        CanJump = b;
    }

    public void SetCanMove(bool b)
    {
        CanJump = b;
    }

    public void SetCanMultiMove(bool b)
    {
        CanMultiJump = b;
    }
    
    public void SetMultiJumpLimit(int num)
    {
        MultiJumpLimit = num;
    }

    public void SetLockMoveSpeedValue(float value)
    {
        LockMoveSpeed = value;
    }

    public void SetLockMoveSpeedValueAndLock(float value)
    {
        SetLockMoveSpeedValue(value);
        if (!IsLockMove)
            IsLockMove = true;
    }

    public void SetLockTurnAngleValue(float angle)
    {
        LockTurnAngle = angle;
    }

    public void SetLockTurnAngleValueAndLock(float angle)
    {
        SetLockTurnAngleValue(angle);
        if (!IsLockRotate)
            IsLockRotate = true;
    }

    /*
    需要每帧在Update中调用，应该写在属性类中
    public bool CheckIsAlive(bool b)
    {
        if (IsAlive && !b)
            //Evt Killed
            return false;
        else if (!IsAlive && b)
            //Evt Revive
            return true;
        else if (IsAlive && b)
            return true;
        else
            return false;
    }
    */
}