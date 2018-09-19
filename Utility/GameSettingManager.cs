using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingManager : MonoBehaviour
{
    public static GameSettingManager GetInstance { get; set; }

    public float GlobalGravity = 20f;

    //基础属性
    public float basic_MoveSpeed = 5f;//移动速度 = 5.0
    public float basic_AttackSpeed = 1f;//攻击速度 = 1.0
    public float basic_CriDmg = 1f;//初始暴击伤害100%
    public float minMoveSpeed = 0.5f;//最小移动速度

    //升级属性
    public int maxLevel = 20;
    public int[] UpgradeExperience = {0,10,20,40,70,110,160,220,290,370,460,560,670,790,920,1060,1210,1370,1540,1720};//升级需要的经验值
    public int extraPropertyPointsPerLevel = 5;//升级时获得的属性点

    //力量 +2近战物理攻击 +0.5远程物理攻击 +1护甲
    public float Phy_Melee_PerStr = 2f;
    public float Phy_Range_PerStr = 0.5f;
    public float Amr_PerStr = 1f;

    //敏捷 +0.5近战物理攻击 +1远程物理攻击 +0.1%暴击 +1%攻速 +0.1%闪避
    public float Phy_Melee_Per_Dex = 0.5f;
    public float Phy_Range_Per_Dex = 1f;
    public float CriCha_Per_Dex = 0.001f;
    public float Ias_Per_Dex = 0.01f;
    public float Eva_Per_Dex = 0.001f;

    //智力 +2魔法攻击 +1魔抗
    public float Mgi_Per_Int = 2f;
    public float Res_Per_Int = 1f;

    //精神 +0.2生命恢复 +0.2能量恢复 +0.25%冷却缩减 +0.25%消耗缩减
    public float HpReg_Per_Spi = 0.2f;
    public float SpReg_Per_Spi = 0.2f;
    public float Cdr_Per_Spi = 0.0025f;
    public float Csr_Per_Spi = 0.0025f;

    //耐力 +10最大生命 +0.2生命恢复 +0.1%坚韧
    public float HpMax_Per_Vit = 10f;
    public float HpReg_Per_Vit = 0.2f;
    public float Tough_Per_Vit = 0.001f;



    void Awake()
    {
        GetInstance = this;
    }
}