using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionKey
{
    Action_Q,
    Action_E,
    Action_R,
    Action_1,
    Action_2,
    Action_3,
    Action_4,
    Action_Shift,
    Action_Ctrl,
    Action_Tab,
    Action_LMB,
    Action_RMB,
    None,
}

public enum Direction
{
    None,
    Forward,
    Backward,
}

public class CharacterBehaviour : MonoBehaviour
{
    public static CharacterBehaviour GetInstace { get; set; }

    //摄像机
    public GameObject cam;
    //获得CharacterController
    public CharacterController cc;
    //动画控制器
    public Animator anim;
    //Action类 动作控制类
    public CharacterAction characterAction;
    //移动速度 现在移到 GameBaseProperties 中
    //public float moveSpeed;
    //角色转向平滑程度
    public float rotateLerp = 10f;


    // -------------------------- 玩家输入PlayerInput --------------------------
    //玩家按下的方向键
    bool right = false;
    bool left = false;
    bool forward = false;
    bool backward = false;
    float H;               //水平轴值输入
    float V;               //垂直轴值输入
    //玩家按下的动作键，同一时间仅一个有效值
    ActionKey actionKey;   //是否进行动作按键，有优先级(Tab>Shift>Ctrl>4>3>2>1>R>E>Q>RMB>LMB)
    [SerializeField]
    bool jump;             //是否进行跳跃按键


    // -------------------------- 玩家角色信息 PlayerCharacter --------------------------
    //玩家目标y轴角度(插值目标的值)
    float targetAngle;
    //玩家当前y轴角度(插值之后的值)
    float playerAngle;
    //玩家输入按键补偿角度
    float turnAngle;
    //垂直方向速度
    public float gSpeed;
    //重力
    public float gravity = 20f;
    //跳跃力
    public float jumpForce = 8f;
    //GroundCheck脚本
    public GroundCheck groundCheck;
    //玩家在水平面的移动向量（不包括重力方向）
    public Vector3 flatMove;
    //玩家最终移动向量（包括重力方向）
    public Vector3 finalMove;


    // -------------------------- 状态 State --------------------------

    // --------- 1 主要 Major ---------
    //------------------------------------------------------------------------------------------
    //玩家能否控制角色
    public bool bCanControl = true;
    //是否死亡(不一定 hp <= 0 就是死亡，还会有其他条件)(是否可以死亡)
    public bool bIsDead = false;
    //玩家是否进入UI菜单模式(UI模式 可以移动Move, 不能旋转Rotate)
    public bool inUIMode = false;
    //是否可以死亡（默认可以死亡）
    public bool bCanDead = true;
    //是否脚踩地面
    public bool bIsGrounded;

    // --------- 2 重力 Gravity ---------
    //------------------------------------------------------------------------------------------
    //可选设置：不受重力，锁定重力（Num），默认重力
    // - 无视重力 bIgnoreGravity（最高优先级）
    public bool bIgnoreGravity = false;
    // - 锁定重力 bLockGravity（第二优先级）
    public bool bLockGravity = false;
    // - 锁定重力值 lockGravityValue
    public float lockGravityValue = 20f;    //(默认重力为 20f)

    // --------- 3 旋转 Rotate ---------
    //------------------------------------------------------------------------------------------
    // - 锁定旋转 bLockRotate(第一优先级，锁定角色无法旋转)
    public bool bLockRotate = false;
    // - 锁定面对摄像机前方向(第二优先级，锁定旋转后角色只能朝角色自身前/后方移动)
    public Direction eLockRotationDir = Direction.None;

    // --------- 4 移动 Move ---------
    //------------------------------------------------------------------------------------------
    // - 玩家是否可以移动（最高优先级）
    public bool bCanMove = true;
    // - 玩家是否强制移动
    public bool bLockMove = false;
    // - 如何处理 强制移动的速度
    // (true-使用lockMoveSpeedValue来强制移动; false-使用PropertiesFinal.Spd * lockMoveSpeedModifier来强制移动)
    public bool bUseLockMoveSpeed = false;
    // - 玩家强制移动速度 定额数值
    public float lockMoveSpeedValue = 0.0f;
    // - 玩家强制移动速度 乘以系数
    public float lockMoveSpeedModifier = 1.0f;

    // --------- 5 跳跃 Jump ---------
    //------------------------------------------------------------------------------------------
    //是否可以跳跃
    public bool bCanJump = true;
    //是否可以多段跳
    public bool bCanMultiJump = false;
    //最大跳跃次数
    public int maxJumpNum = 1;
    //已经跳跃的次数(每次执行跳跃 Jump 增加1 着陆 OnLand 重置为0)
    public int jumpNum = 0;
    //跳跃之间的间隔(sec)
    public float jumpTimeInterval = 0.25f;
    //最近一次可以跳跃的时间戳（sec),用来配合时间戳比对是否可以再次跳跃
    public float nextJumpTimeStamp = 0f;

    // --------- 6 动作 Action ---------
    //------------------------------------------------------------------------------------------
    // - 当前动作可被另一个动作打断（结束前能否做其他操作，如Shift能否打断LMB普通攻击）
    public bool bCanBreak = false;
    // - 玩家是否正在进行一个动作，已经在进行一个动作就无法开始第二个动作
    public bool bInAction = false;

    // -------------------------- 子物体挂载点ChildObj --------------------------
    public GameObject upgrade;
    public GameObject blood;
    public GameObject attackPoint;
    public GameObject hitPoint;

    void Awake()
    {
        GetInstace = this;
        cam = Camera.main.gameObject;
        cc = gameObject.GetComponent<CharacterController>();
    }
    
    //  Update  主循环
    //------------------------------------------------------------------------------------------
    void Update()
    {
        // 玩家输入 PlayerInput
        PlayerInput();

        // 重力 Gravity
        //------------------------------------------------------------------------------------------
        if (!bIgnoreGravity)
        {
            Gravity();
        }

        // 存活 IsDead
        //------------------------------------------------------------------------------------------
        if (bIsDead)
        {
            //已经死亡，就无法控制了
            CannotControlDie();
            return;
        }
        
        // 可以 控制  Can Control
        //------------------------------------------------------------------------------------------
        if (bCanControl)
        {
            // 1 旋转玩家角度 Rotate
            //------------------------------------------------------------------------------------------
            if (!bLockRotate && !inUIMode && eLockRotationDir == Direction.None)
            {
                Rotate();
            }
            else if (eLockRotationDir == Direction.Forward)
            {
                // 锁定必须向前 FaceDirectionCorrection玩家面向角度校正 仅改变玩家面朝方向 不改变移动方向向量playerAngle
                TurnToCameraForward();
            }
            else if (eLockRotationDir == Direction.Forward)
            {
                TurnToCameraBackward();
            }
            // 其余情况 锁定旋转 不用处理(bLockRotate 或者 inUIMode)

            //------------------------------------------------------------------------------------------
            // 2 移动玩家 Move
            if (bCanMove)
            {
                if (bLockMove)
                {
                    //只能向前移动（可以通过乘以系数 lockSpeedModifier 变成只能向后移动）
                    MoveLock();
                }
                else
                {
                    Move();
                }
            }

            //------------------------------------------------------------------------------------------
            // 3 跳跃 Jump
            if (!inUIMode && bCanJump)
            {
                Jump();
            }

            //------------------------------------------------------------------------------------------
            //06 Attack&Skills玩家释放技能
            //每一次Update中只能对一个输入值进行Action
            if (!inUIMode && actionKey != ActionKey.None)
            {
                characterAction.UseAction(actionKey);
            }
        }
        else
        {
            CannotControl(); //如果不能控制的操作
        }
    }










    //  FixedUpdate 主循环
    //------------------------------------------------------------------------------------------
    void FixedUpdate()
    {

    }










    //  其他函数 Function
    //------------------------------------------------------------------------------------------

    // 玩家输入 Player Input
    void PlayerInput()
    {
        //Axis 轴值输入
        H = Input.GetAxisRaw("Horizontal");
        V = Input.GetAxisRaw("Vertical");
        //jump 是否进行了 跳跃按键输入
        jump = Input.GetButtonDown("Action_Space") ? true : false;
        //Action 是否进行了 动作按键输入，有优先级(Tab>Shift>Ctrl>4>3>2>1>R>E>Q>RMB>LMB)
        if (Input.GetButton("Action_Tab"))
            actionKey = ActionKey.Action_Tab;
        else if (Input.GetButton("Action_Shift"))
            actionKey = ActionKey.Action_Shift;
        else if (Input.GetButton("Action_Ctrl"))
            actionKey = ActionKey.Action_Ctrl;
        else if (Input.GetButton("Action_4"))
            actionKey = ActionKey.Action_4;
        else if (Input.GetButton("Action_3"))
            actionKey = ActionKey.Action_3;
        else if (Input.GetButton("Action_2"))
            actionKey = ActionKey.Action_2;
        else if (Input.GetButton("Action_1"))
            actionKey = ActionKey.Action_1;
        else if (Input.GetButton("Action_R"))
            actionKey = ActionKey.Action_R;
        else if (Input.GetButton("Action_E"))
            actionKey = ActionKey.Action_E;
        else if (Input.GetButton("Action_Q"))
            actionKey = ActionKey.Action_Q;
        else if (Input.GetMouseButton(1))
            actionKey = ActionKey.Action_RMB;
        else if (Input.GetMouseButton(0))
            actionKey = ActionKey.Action_RMB;
        else
            actionKey = ActionKey.None;
    }

    void Rotate()
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
            cc.transform.rotation = Quaternion.Euler(new Vector3(0f, playerAngle, 0f));
        }
    }

    void Gravity()
    {
        //物理下落速度 gSpeed
        //垂直方向速度,无论什么状态 都应该受到重力影响
        if (cc.isGrounded)
        {
            Debug.Log("Gravity_Ground");
            if (bLockGravity)
            {
                gSpeed = Mathf.Max(-lockGravityValue, gSpeed - lockGravityValue * Time.deltaTime);
            }
            else
            {
                gSpeed = Mathf.Max(-gravity, gSpeed - gravity * Time.deltaTime);
            }
            // 如果上一帧还在空中，说明这一帧着陆
            if (!bIsGrounded)
            {
                Land();
            }
            bIsGrounded = true;
            //动画相关
            anim.SetFloat("gSpeed", 0);
            anim.SetBool("isGrounded", true);
        }
        else
        {
            Debug.Log("Gravity_Fall");
            if (bLockGravity)
            {
                gSpeed -= lockGravityValue * Time.deltaTime;
            }
            else
            {
                gSpeed -= gravity * Time.deltaTime;
            }
            bIsGrounded = false;
            //动画相关
            anim.SetFloat("gSpeed", gSpeed);
            anim.SetBool("isGrounded", false);
        }
    }

    void Jump()
    {
        if (!jump)
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

    void Land()
    {
        Debug.Log("Land");
        // 着陆时，重置跳跃次数
        if (jumpNum > 0)
        {
            jumpNum = 0;
        }
        anim.SetFloat("gSpeed", 0);
        anim.SetBool("isGrounded", true);
    }

    void Move()
    {
        //水平面方向速度
        flatMove = ((Mathf.Abs(V) + Mathf.Abs(H)) * transform.TransformDirection(Vector3.forward)).normalized * PlayerPropertiesBase.GetInstance.Spd;//保证两个方向键一起按的时候，速度不会超过1
                                                                                                                                                        //改变animator fSpeed
        anim.SetFloat("fSpeed", flatMove.magnitude);
        //总速度向量
        finalMove = (flatMove + new Vector3(0f, gSpeed, 0f));
        cc.Move(finalMove * Time.deltaTime);
    }

    //锁定 向角色前方移动
    void MoveLock()
    {
        if (bUseLockMoveSpeed)
        {
            flatMove = transform.forward * lockMoveSpeedValue;
        }
        else
        {
            flatMove = transform.forward * PlayerPropertiesFinal.GetInstance.Spd * lockMoveSpeedModifier;
        }
        //改变animator fSpeed
        anim.SetFloat("fSpeed", flatMove.magnitude);
        //总速度向量
        finalMove = (flatMove + new Vector3(0f, gSpeed, 0f));
        cc.Move(finalMove * Time.deltaTime);
    }
    
    //立刻转向某一方向 TurnImmediate（最高优先级，不受LockRotate影响，如果需要可以先做判断是否已经LockRotate）
    public void TurnImmediate(Direction dir)
    {
        switch (dir)
        {
            case Direction.Forward:
                cc.transform.rotation = Quaternion.Euler(new Vector3(0f, cam.transform.rotation.eulerAngles.y, 0f));
                break;
            case Direction.Backward:
                cc.transform.rotation = Quaternion.Euler(new Vector3(0f, -cam.transform.rotation.eulerAngles.y, 0f));
                break;
            default:
                break;
        }
    }

    //旋转转向镜头前方
    public void TurnToCameraForward()
    {
        cc.transform.rotation = Quaternion.Euler(new Vector3(0f, cam.transform.rotation.eulerAngles.y, 0f));
    }

    //旋转转向镜头前方
    public void TurnToCameraBackward()
    {
        cc.transform.rotation = Quaternion.Euler(new Vector3(0f, -cam.transform.rotation.eulerAngles.y, 0f));
    }

    //玩家无法控制时的人物行为
    void CannotControl()
    {
        Gravity();
        anim.SetFloat("fSpeed", 0f);
        finalMove = new Vector3(0f, gSpeed, 0f);
        cc.Move(finalMove * Time.deltaTime);
    }

    //玩家死亡后的人物行为
    void CannotControlDie()
    {
        //垂直方向速度,无论什么状态 都应该受到重力影响
        if (cc.isGrounded)
        {
            gSpeed = -gravity;
        }
        else
        {
            gSpeed -= gravity * Time.deltaTime;
        }
        finalMove = new Vector3(0f, gSpeed, 0f);
        cc.Move(finalMove * Time.deltaTime);
    }

    public void Die()
    {
        anim.SetLayerWeight(1, 0.001f);
        anim.SetLayerWeight(2, 0.001f);
        anim.SetLayerWeight(3, 0.001f);
        anim.SetTrigger("Die");
        ScreenSpaceUIManager.GetInstance.OpenWarningHint();
        PlayerAudio.GetInstance.Die();
    }


}
