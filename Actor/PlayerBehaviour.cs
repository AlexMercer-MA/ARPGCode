using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : ActorBehaviour
{
    private PlayerMain PlayerMain;
    public float RotateLerp { get; set; }           //角色转向平滑程度  默认10f

    private void Initialized()
    {
        PlayerMain = (PlayerMain)ActorMain;
    }

    public override void UpdateBehaviour()
    {
        if (IsUseGravity)
        {

        }
    }
    
    public void SetLockTurnCamForwardAngle()
    {

    }

    public void SetLockTurnCamForwardAngleAndLock()
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
            anim.SetFloat("gSpeed", 0);
            anim.SetBool("isGrounded", true);
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
            anim.SetFloat("gSpeed", gSpeed);
            anim.SetBool("isGrounded", false);
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
}
