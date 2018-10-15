using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : ActorBehaviour
{
    private PlayerMain PlayerMain;

    public bool CanControl { get; set; }
    public bool IsUIMode { get; set; }

    private PlayerAction PlayerAction { get; set; }
    private CharacterController CharacterController { get; set; }
    private PlayerAnimation PlayerAnimation { get; set; }

    private void Initialized(PlayerMain PlayerMain)
    {
        this.PlayerMain = PlayerMain;
    }

    private void Start()
    {
        PlayerAnimation = PlayerMain.PlayerAnimation;
    }

    public override void UpdateBehaviour()
    {
        if (IsUseGravity)
        {
            Gravity();
        }

        if(CanMove && IsAlive)
        {
            if (IsLockMove)
            {
                LockMove();
            }
            else if (CanControl)
            {
                Move();
            }
        }

        if (CanRotate && IsAlive)
        {
            if (IsLockRotate)
            {
                LockRotate();
            }
            else if (CanControl && IsUIMode)
            {
                Rotate();
            }
        }
        
        if (CanJump && CanControl && IsAlive && !IsUIMode)
        {
            Jump();
        }
        
        Action();
        
    }
    
    //立刻转向以相机为基准的某个角度
    public void SetLockTurnCamForwardAngle(float angle)
    {

    }

    //立刻转向以相机为基准的某个角度并锁定
    public void SetLockTurnCamForwardAngleAndLock(float angle)
    {
        SetLockTurnCamForwardAngle();
        IsLockRotate = true;
    }
    

    private void Gravity()
    {
        float globalGravity = GameSettingManager.GetInstance.GlobalGravity;

        //物理下落速度 GSpeed
        //垂直方向速度,无论什么状态 都应该受到重力影响
        if (CharacterController.isGrounded)
        {
            Debug.Log("Gravity_Ground");
            if (IsUseCustomGravity)
            {
                GSpeed = Mathf.Max(-CustomGravity, GSpeed - CustomGravity * Time.deltaTime);
            }
            else
            {
                GSpeed = Mathf.Max(-globalGravity, GSpeed - globalGravity * Time.deltaTime);
            }
            // 如果上一帧还在空中，说明这一帧着陆
            if (!IsGrounded)
            {
                Land();
            }
            IsGrounded = true;
            //动画相关
            PlayerAnimation.SetFloat("gSpeed", 0);
            PlayerAnimation.SetBool("isGrounded", true);
        }
        else
        {
            Debug.Log("Gravity_Fall");
            if (IsUseCustomGravity)
            {
                GSpeed -= CustomGravity * Time.deltaTime;
            }
            else
            {
                GSpeed -= globalGravity * Time.deltaTime;
            }
            IsGrounded = false;
            //动画相关
            PlayerAnimation.SetFloat("gSpeed", GSpeed);
            PlayerAnimation.SetBool("isGrounded", false);
        }
    }

    private void Jump()
    {
        if (!InputManager.Jump)
            return;

        // 在地面跳跃 不用检查是否可以多段跳
        if (groundCheck.groundCheckBool)
        {
            if (Time.time > (JumpTimeStamp + jumpTimeInterval) && JumpCountNum < MultiJumpCountLimit)
            {
                PlayerAnimation.SetTrigger("Jump");
                GSpeed = JumpForce;
                PlayerAudio.GetInstance.Jump();
                JumpTimeStamp = Time.time;
                JumpCountNum++;
            }
        }
        // 不在地面时 跳跃需要检查是否可以多段跳
        else if (bCanMultiJump)
        {
            if (Time.time > (JumpTimeStamp + jumpTimeInterval) && JumpCountNum < MultiJumpCountLimit)
            {
                PlayerAnimation.SetTrigger("Jump");
                GSpeed = JumpForce;
                PlayerAudio.GetInstance.Jump();
                JumpTimeStamp = Time.time;
                JumpCountNum++;
            }
        }
    }

    private void Land()
    {
        Debug.Log("Land");
        // 着陆时，重置跳跃次数
        if (JumpCountNum > 0)
        {
            JumpCountNum = 0;
        }
        PlayerAnimation.SetFloat("gSpeed", 0);
        PlayerAnimation.SetBool("isGrounded", true);
    }

    private void Move()
    {
        //水平面方向速度
        FlatSpeed = ((Mathf.Abs(V) + Mathf.Abs(H)) * transform.TransformDirection(Vector3.forward)).normalized * ActorPropertiesBasic.GetInstance.Spd;//保证两个方向键一起按的时候，速度不会超过1
        //改变animator fSpeed
        anim.SetFloat("fSpeed", FlatSpeed.magnitude);
        //总速度向量
        FinalSpeed = (FlatSpeed + new Vector3(0f, GSpeed, 0f));
        CharacterController.Move(FinalSpeed * Time.deltaTime);
    }

    //锁定 向角色前方移动
    private void LockMove()
    {
        //水平速度
        FlatSpeed = transform.forward * LockMoveSpeed;
        //改变animator fSpeed
        anim.SetFloat("fSpeed", FlatSpeed.magnitude);
        //总速度向量
        FinalSpeed = (FlatSpeed + new Vector3(0f, GSpeed, 0f));
        CharacterController.Move(FinalSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        //Vertical Axis 判定前后方向是否有输入值
        if (V > 0.5f)
        {
            forward = true;
            backward = false;
        }
        else if (V < -0.5f)
        {
            backward = true;
            forward = false;
        }
        else
        {
            backward = false;
            forward = false;
        }

        //Horizontal Axis 判定左右方向是否有输入值
        if (H > 0.5f)
        {
            right = true;
            left = false;
        }
        else if (H < -0.5f)
        {
            left = true;
            right = false;
        }
        else
        {
            left = false;
            right = false;
        }

        //根据Input GetAxis输入值，决定旋转增量（八个方向）
        if (forward && !left && !right)
            turnAngle = 0f;

        if (forward && left)
            turnAngle = -45f;

        if (forward && right)
            turnAngle = 45f;

        if (backward && !left && !right)
            turnAngle = 180f;

        if (backward && left)
            turnAngle = 225f;

        if (backward && right)
            turnAngle = 135f;

        if (left && !forward && !backward)
            turnAngle = -90f;

        if (right && !forward && !backward)
            turnAngle = 90f;

        targetAngle = cam.transform.rotation.eulerAngles.y + turnAngle;

        if (forward || backward || left || right)
        {
            CurrentAngle = Mathf.LerpAngle(CurrentAngle, TargetAngle, RotateLerp * Time.deltaTime);
            CharacterController.transform.rotation = Quaternion.Euler(new Vector3(0f, CurrentAngle, 0f));
        }
    }

    private void LockRotate()
    {
        CurrentAngle = LockTurnAngle;
        TargetAngle = LockTurnAngle;
        CharacterController.transform.rotation = Quaternion.Euler(new Vector3(0f, LockTurnAngle, 0f));
    }

    private void Action()
    {
        PlayerAction.Action();
    }

    public void ForceMove(Vector3 moveSpeed)
    {
        
        CharacterController.Move(moveSpeed * Time.deltaTime);
    }
    
}
