using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum ActionKey
//{
//    Action_Q,
//    Action_E,
//    Action_R,
//    Action_1,
//    Action_2,
//    Action_3,
//    Action_4,
//    Action_Shift,
//    Action_Ctrl,
//    Action_Tab,
//    Action_LMB,
//    Action_RMB,
//    None,
//}


public class CharacterAction : MonoBehaviour
{

    //单例模式
    public static CharacterAction GetInstace;

    //获取 CharacterBehaviour组件
    public CharacterBehaviour characterBehaviour;
    //获取 Animator组件
    public Animator anim;

    //攻击和技能基类 ActionBase
    public ActionBase action_LMB;
    public ActionBase action_RMB;
    public ActionBase action_Shift;
    public ActionBase action_Q;
    public ActionBase action_E;
    public ActionBase action_R;
    public ActionBase action_1;
    public ActionBase action_2;
    public ActionBase action_3;
    public ActionBase action_4;
    public ActionBase action_Tab;
    
    //动画控制器

    //技能/动作冷却时间
    //		public float basicAttackCD;
    //		public float basicAttackTime;
    //		public float specialAttackCD;
    //		public float specialAttackTime;
    //		public float skillCD_01;
    //		public float skillTime_01;
    //		public float skillCD_02;
    //		public float skillTime_02;
    //		public float skillCD_03;
    //		public float skillTime_03;
    //		public float evadeCD;
    //		public float evadeTime;
    //		public float PotionCD;
    //		public float PotionTime;

    public Skills skill;

    //玩家是不是在翻滚状态(翻滚状态无敌)
    public bool isEvade = false;

    //武器拖尾渲染器
    public TrailRenderer trailRendererLeft;
    public TrailRenderer trailRendererRight;

    //动画权重值
    public float attackLayerWeight1;
    public float attackLayerWeight2;
    public float attackLayerWeight3;

    void Start()
    {
        GetInstace = this;
    }

    void Update()
    {
        //取消攻击层动画权重
        attackLayerWeight1 -= Time.deltaTime * 1f;  //layer1 Attack
        attackLayerWeight2 -= Time.deltaTime * 1f;  //layer2 Skill
        attackLayerWeight3 -= Time.deltaTime * 1f;  //layer3 Hit

        if (attackLayerWeight1 <= 0f)
            attackLayerWeight1 = 0.001f;
        if (attackLayerWeight2 <= 0f)
            attackLayerWeight2 = 0.001f;
        if (attackLayerWeight3 <= 0f)
            attackLayerWeight3 = 0.001f;

        //设置权重在0到1范围内
        anim.SetLayerWeight(1, Mathf.Clamp01(attackLayerWeight1));
        anim.SetLayerWeight(2, Mathf.Clamp01(attackLayerWeight2));
        anim.SetLayerWeight(3, Mathf.Clamp01(attackLayerWeight3));
    }

    public void UseAction(ActionKey action)
    {
        //设置高亮UI
        ActionPanelUIManager.GetInstace.SetHighLightUI(action);

        //TODO 其余UI的设置
        //这一段代码需要重写 在UI管理类中
        /*potion.isHighLight = false;
        basicAttack.isHighLight = false;
        specialAttack.isHighLight = false;
        skillEvade.isHighLight = false;
        skill01.isHighLight = false;
        skill02.isHighLight = false;
        skill03.isHighLight = false;*/
        //这一段代码需要重写 在UI管理类中
        
        //if (Input.GetKey(KeyCode.Tab))//独立判断使用药剂
        //{
        //    potion.isHighLight = true;
        //    //				if (!characterBehaviour.bInAction)
        //    //				{
        //    //					Potion_use ();
        //    //				}
        //    if (!potion.bInAction)
        //    {
        //        Potion_use();
        //    }
        //}
        ////技能判断
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    skillEvade.isHighLight = true;
        //    if (!characterBehaviour.bInAction/*&&characterBehaviour.flatMove.magnitude>=0.1f*/)
        //    {
        //        Evade_use();
        //    }
        //}
        //else if (Input.GetKey(KeyCode.Alpha1))
        //{
        //    skill01.isHighLight = true;
        //    if (!characterBehaviour.bInAction)
        //    {
        //        Skill_01_use();
        //    }
        //}
        //else if (Input.GetKey(KeyCode.Alpha2))
        //{
        //    skill02.isHighLight = true;
        //    if (!characterBehaviour.bInAction)
        //    {
        //        Skill_02_use();
        //    }
        //}
        //else if (Input.GetKey(KeyCode.Alpha3))
        //{
        //    skill03.isHighLight = true;
        //    if (!characterBehaviour.bInAction)
        //    {
        //        Skill_03_use();
        //    }
        //}
        //else if (Input.GetMouseButton(1))
        //{
        //    specialAttack.isHighLight = true;
        //    if (!characterBehaviour.bInAction)
        //    {
        //        SpecialAttack_use();
        //    }
        //}
        //else if (Input.GetMouseButton(0))
        //{
        //    basicAttack.isHighLight = true;
        //    if (!characterBehaviour.bInAction)
        //    {
        //        BasicAttack_use();
        //    }
        //}
        //同时操作时有优先级
        //翻滚>技能1>技能2>技能3>右键>左键
    }

    //判断技能是否能使用，能使用则立即使用
    //public void BasicAttack_use()
    //{
    //    if (basicAttack.skillTime >= basicAttack.cooldown)
    //    {
    //        if (PlayerPropertiesFinal.GetInstance.Sp >= basicAttack.energy * (1f - PlayerPropertiesFinal.GetInstance.Csr))
    //        {
    //            basicAttack.Action();//近战攻击
    //            skill = Skills.basicAttack;
    //        }
    //        else
    //        {
    //            UI_Warning.GetInstance.WarnSP();
    //        }
    //    }
    //    else
    //    {
    //        UI_Warning.GetInstance.WarnCD();
    //    }
    //}

    //public void SpecialAttack_use()
    //{
    //    if (specialAttack.skillTime >= specialAttack.cooldown)
    //    {
    //        if (PlayerPropertiesFinal.GetInstance.Sp >= specialAttack.energy * (1f - PlayerPropertiesFinal.GetInstance.Csr))
    //        {
    //            specialAttack.Action();
    //            skill = Skills.specialAttack;
    //        }
    //        else
    //        {
    //            UI_Warning.GetInstance.WarnSP();
    //        }
    //    }
    //    else
    //    {
    //        UI_Warning.GetInstance.WarnCD();
    //    }
    //}

    //public void Evade_use()
    //{
    //    if (skillEvade.skillTime >= skillEvade.cooldown)
    //    {
    //        if (PlayerPropertiesFinal.GetInstance.Sp >= skillEvade.energy * (1f - PlayerPropertiesFinal.GetInstance.Csr))
    //        {
    //            skillEvade.Action();
    //            skill = Skills.evade;
    //        }
    //        else
    //        {
    //            UI_Warning.GetInstance.WarnSP();
    //        }
    //    }
    //    else
    //    {
    //        UI_Warning.GetInstance.WarnCD();
    //    }
    //}

    //public void Skill_01_use()
    //{
    //    if (skill01.skillTime > skill01.cooldown)
    //    {
    //        if (PlayerPropertiesFinal.GetInstance.Sp >= skill01.energy * (1f - PlayerPropertiesFinal.GetInstance.Csr))
    //        {
    //            skill01.Action();
    //            skill = Skills.skill01;
    //        }
    //        else
    //        {
    //            UI_Warning.GetInstance.WarnSP();
    //        }
    //    }
    //    else
    //    {
    //        UI_Warning.GetInstance.WarnCD();
    //    }
    //}

    //public void Skill_02_use()
    //{
    //    if (skill02.skillTime > skill02.cooldown)
    //    {
    //        if (PlayerPropertiesFinal.GetInstance.Sp >= skill02.energy * (1f - PlayerPropertiesFinal.GetInstance.Csr))
    //        {
    //            skill02.Action();
    //            skill = Skills.skill02;
    //        }
    //        else
    //        {
    //            UI_Warning.GetInstance.WarnSP();
    //        }
    //    }
    //    else
    //    {
    //        UI_Warning.GetInstance.WarnCD();
    //    }
    //}

    //public void Skill_03_use()
    //{
    //    if (skill03.skillTime > skill03.cooldown)
    //    {
    //        if (PlayerPropertiesFinal.GetInstance.Sp >= skill03.energy * (1f - PlayerPropertiesFinal.GetInstance.Csr))
    //        {
    //            skill03.Action();
    //            skill = Skills.skill03;
    //        }
    //        else
    //        {
    //            UI_Warning.GetInstance.WarnSP();
    //        }
    //    }
    //    else
    //    {
    //        UI_Warning.GetInstance.WarnCD();
    //    }
    //}


    //public void Potion_use()
    //{
    //    if (potion.skillTime > potion.cooldown)
    //    {
    //        if (PlayerPropertiesFinal.GetInstance.Sp >= potion.energy * (1f - PlayerPropertiesFinal.GetInstance.Csr))
    //        {
    //            potion.Action();
    //            skill = Skills.potion;
    //        }
    //        else
    //        {
    //            UI_Warning.GetInstance.WarnSP();
    //        }
    //    }
    //    else
    //    {
    //        UI_Warning.GetInstance.WarnCD();
    //    }
    //}

    //做一次圆形或者扇形范围检测，然后将检测结果的GameObject传给具体技能实现脚本做计算
    public void SphereDetect(int skillNum)
    {
        //根据技能不同选择不同的判断方法
        //switch (skillNum)
        //{
        //    case 0:
        //        break;
        //    case 1:
        //        basicAttack.SphereDetect();
        //        break;
        //    case 2:
        //        specialAttack.SphereDetect();
        //        //暂时不用
        //        break;
        //    case 3:
        //        skill01.SphereDetect();
        //        break;
        //    case 4:
        //        skill02.SphereDetect();
        //        break;
        //    case 5:
        //        break;
        //    case 6:
        //        break;
        //    case 7:
        //        break;
        //    default:
        //        break;
        //}
    }

    //清空目标组
    public void ClearTargetGroup(int skillNum)
    {
        //根据技能不同选择不同的判断方法
        //switch (skillNum)
        //{
        //    case 0:
        //        break;
        //    case 1:
        //        basicAttack.ClearTargetGroup();
        //        break;
        //    case 2:
        //        specialAttack.ClearTargetGroup();
        //        break;
        //    case 3:
        //        break;
        //    case 4:
        //        break;
        //    case 5:
        //        break;
        //    case 6:
        //        break;
        //    case 7:
        //        break;
        //    default:
        //        break;
        //}
    }

    public void AttackStart(int skillNum)
    {
        //根据技能不同选择不同的判断方法
        //switch (skillNum)
        //{
        //    case 0:
        //        break;
        //    case 1:
        //        break;
        //    case 2:
        //        specialAttack.AttackStart();
        //        break;
        //    case 3:
        //        break;
        //    case 4:
        //        break;
        //    case 5:
        //        break;
        //    case 6:
        //        break;
        //    case 7:
        //        break;
        //    default:
        //        break;
        //}
    }

    public void AttackOver(int skillNum)
    {
        //根据技能不同选择不同的判断方法
        //    switch (skillNum)
        //    {
        //        case 0:
        //            break;
        //        case 1:
        //            break;
        //        case 2:
        //            specialAttack.AttackOver();
        //            break;
        //        case 3:
        //            break;
        //        case 4:
        //            break;
        //        case 5:
        //            break;
        //        case 6:
        //            break;
        //        case 7:
        //            break;
        //        default:
        //            break;
        //    }
    }
}

//技能类型枚举
public enum Skills
{
    none,               //SkillNum 0
    basicAttack,        //SkillNum 1
    specialAttack,      //SkillNum 2
    skill01,            //SkillNum 3
    skill02,            //SkillNum 4
    skill03,            //SkillNum 5
    evade,              //SkillNum 6
    potion,              //SkillNum 7
}
