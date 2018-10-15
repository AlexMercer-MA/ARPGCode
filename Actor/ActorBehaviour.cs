using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorBehaviour : MonoBehaviour
{
    public bool IsAlive { get; set; }               //是否存活
    public bool IsInvernable { get; set; }          //无敌，不可被杀死，最小HP_int为1

    public bool CanMove { get; set; }               //能否移动
    public bool IsLockMove { get; set; }            //是否锁定移动
    public float LockMoveSpeed { get; set; }        //强制移动速度
    public float3 FlatSpeed { get; set; }            //水平速度
    public float GSpeed { get; set; }               //重力速度
    public float3 FinalSpeed { get; set; }           //总速度

    public bool CanRotate { get; set; }             //能否旋转
    public bool IsLockRotate { get; set; }          //是否锁定旋转
    public float LockTurnAngle { get; set; }        //强制锁定角度
    public float CurrentAngle { get; set; }         //当前角度
    public float TargetAngle { get; set; }          //目标角度
    public float RotateLerp { get; set; }           //角色转向平滑程度(当前角度转向目标角度，默认10f)

    public bool IsUseGravity { get; set; }          //是否受重力影响
    public bool IsUseCustomGravity { get; set; }    //是否使用自定义重力
    public float CustomGravity { get; set; }        //自定义重力值（标准重力为 -20f）
    public bool IsGrounded { get; set; }            //是否着地

    public bool CanJump { get; set; }               //能否跳跃
    public bool CanMultiJump { get; set; }          //能否多段跳
    public int JumpCountNum { get; set; }           //当前跳跃次数
    public int MultiJumpCountLimit { get; set; }    //多段跳次数上限
    public float JumpTimeStamp { get; set; }        //跳跃时间戳
    public float JumpTimeInterval { get; set; }     //跳跃间隔时间
    public float JumpForce { get; set; }            //跳跃力
    
    public abstract void UpdateBehaviour();         //更新方法

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

    //强制按某个方向位移
    public abstract void ForceMove(Vector3 moveSpeed);
    
}