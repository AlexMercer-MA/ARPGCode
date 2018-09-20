using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : ActorBehaviour
{
    private PlayerMain PlayerMain;

    public bool CanControl { get; set; }
    public float RotateLerp { get; set; }           //角色转向平滑程度  默认10f
    public bool IsUIMode { get; set; }

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
    
    public void SetLockTurnCamForwardAngle(float angle)
    {

    }

    public void SetLockTurnCamForwardAngleAndLock(float angle)
    {

    }
    

    private void Gravity()
    {
        float globalGravity = GameSettingManager.GetInstance.GlobalGravity;

        //物理下落速度 gSpeed
        //垂直方向速度,无论什么状态 都应该受到重力影响
        if (PlayerMain.CharacterController.isGrounded)
        {
            Debug.Log("Gravity_Ground");
            if (IsUseCustomGravity)
            {
                gSpeed = Mathf.Max(-CustomGravity, gSpeed - CustomGravity * Time.deltaTime);
            }
            else
            {
                gSpeed = Mathf.Max(-globalGravity, gSpeed - globalGravity * Time.deltaTime);
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
                gSpeed -= CustomGravity * Time.deltaTime;
            }
            else
            {
                gSpeed -= globalGravity * Time.deltaTime;
            }
            IsGrounded = false;
            //动画相关
            PlayerAnimation.SetFloat("gSpeed", gSpeed);
            PlayerAnimation.SetBool("isGrounded", false);
        }
    }

    private void Jump()
    {
        if (!InputManager.Jump)
            return;

        // 在地面跳跃 不用检查是否可以多段跳 w
        if (groundCheck.groundCheckBool)
        {
            if (Time.time > nextJumpTimeStamp && jumpNum < maxJumpNum)
            {
                anim.SetTrigger("Jump");
                gSpeed = jumpForce;
                PlayerAudio.GetInstance.Jump();
                nextJumpTimeStamp = Time.time + jumpTimeInterval;
                jumpNum++;
            }
        }
        // 不在地面时 跳跃需要检查是否可以多段跳
        else if (bCanMultiJump)
        {
            if (Time.time > nextJumpTimeStamp && jumpNum < maxJumpNum)
            {
                anim.SetTrigger("Jump");
                gSpeed = jumpForce;
                PlayerAudio.GetInstance.Jump();
                nextJumpTimeStamp = Time.time + jumpTimeInterval;
                jumpNum++;
            }
        }
    }

    private void Land()
    {
        Debug.Log("Land");
        // 着陆时，重置跳跃次数
        if (JumpNum > 0)
        {
            JumpNum = 0;
        }
        anim.SetFloat("gSpeed", 0);
        anim.SetBool("isGrounded", true);
    }

    private void Move()
    {
        //水平面方向速度
        flatMove = ((Mathf.Abs(V) + Mathf.Abs(H)) * transform.TransformDirection(Vector3.forward)).normalized * ActorPropertiesBasic.GetInstance.Spd;//保证两个方向键一起按的时候，速度不会超过1
                                                                                                                                                    //改变animator fSpeed
        anim.SetFloat("fSpeed", flatMove.magnitude);
        //总速度向量
        finalMove = (flatMove + new Vector3(0f, gSpeed, 0f));
        characterController.Move(finalMove * Time.deltaTime);
    }

    //锁定 向角色前方移动
    private void LockMove()
    {
        if (bUseLockMoveSpeed)
        {
            flatMove = transform.forward * lockMoveSpeedValue;
        }
        else
        {
            flatMove = transform.forward * ActorProperty.GetInstance.Spd * lockMoveSpeedModifier;
        }
        //改变animator fSpeed
        anim.SetFloat("fSpeed", flatMove.magnitude);
        //总速度向量
        finalMove = (flatMove + new Vector3(0f, gSpeed, 0f));
        characterController.Move(finalMove * Time.deltaTime);
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
            playerAngle = Mathf.LerpAngle(playerAngle, targetAngle, rotateLerp * Time.deltaTime);
            characterController.transform.rotation = Quaternion.Euler(new Vector3(0f, playerAngle, 0f));
        }
    }

    private void LockRotate()
    {

    }

    private void Action()
    {
        ActionManager.Action();
    }
}
