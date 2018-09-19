using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//角色基础属性脚本：不涉及数值的数据从此脚本获得
//修改时机：升级时，加上或减去属性，仅为加法叠加！
//基本属性在角色建立之后就永久决定了，如职业

/* 具体根据是Player还是Npc，实现不同的IInitialize接口
 * 方法
 * +初始化
 * 
 * 属性
 * +各种属性
 * 
 * */

public class ActorPropertiesBase : MonoBehaviour
{
    
    //Awake先于Start，PlayerProperties先于PlayerPropertiesFinal实例化
    void Awake() 
    {
        
    }
    
    //其他脚本调用
    public virtual void Initialzed()
    {
        Level = 1;
        Str = 10;
        Dex = 10;
        Int = 10;
        Spi = 10;
        Cun = 10;
        Vit = 10;
        Spd = 5;
        SpMax = 100;
        PhyMeleeMax = 10;
    }
    
    public int Level { get; set; }//等级

    //主属性
    public int Str { get; set; }//力量
    public int Dex { get; set; }//敏捷
    public int Int { get; set; }//智力
    public int Spi { get; set; }//精神
    public int Cun { get; set; }//诡诈
    public int Vit { get; set; }//耐力

    //攻击属性
    public int PhyMeleeMax { get; set; }//物理近战攻击上限
    public int PhyMeleeMin { get; set; }//物理近战攻击下限

    public int PhyRangeMax { get; set; }//物理远程攻击上限
    public int PhyRangeMin { get; set; }//物理远程攻击下限

    public int MgiMax { get; set; }//魔法攻击上限
    public int MgiMin { get; set; }//魔法攻击下限

    //元素伤害
    public int FireDmg { get; set; }
    public int IceDmg { get; set; }
    public int LightningDmg { get; set; }
    public int PoisonDmg { get; set; }
    public int ShadowDmg { get; set; }
    public int HolyDmg { get; set; }
    public int ArcaneDmg { get; set; }

    public float Ias { get; set; }//攻击速度（动画播放速度）

    public float CriCha { get; set; }//通用暴击几率
    public float CriDmg { get; set; }//通用暴击伤害

    public float CriPhyMeleeCha { get; set; }//物理暴击几率
    public float CriPhyMeleeDmg { get; set; }//物理暴击伤害
    public float CriPhyRangeCha { get; set; }//物理暴击几率
    public float CriPhyRangeDmg { get; set; }//物理暴击伤害

    public float CriMgiCha { get; set; }//魔法暴击几率
    public float CriMgiDmg { get; set; }//魔法暴击伤害

    public int AmrPeneFix { get; set; }//护甲穿透固定
    public float AmrPenePer { get; set; }//护甲穿透百分比
    public int ResPeneFix { get; set; }//魔法穿透固定
    public float ResPenePer { get; set; }//魔法穿透百分比

    public float Cdr { get; set; }//冷却缩减
    public float Csr { get; set; }//消耗缩减
    public float Acc { get; set; }//精准命中（慎用，抵消闪避）

    //进攻属性 歧视伤害 生物类型
    public float HumanDmg { get; set; }//人形生物增伤
    public float BeastDmg { get; set; }//野兽增伤
    public float UndeadDmg { get; set; }//亡灵增伤
    public float DragonDmg { get; set; }//龙类增伤
    public float DemonDmg { get; set; }//恶魔增伤
    public float ElementDmg { get; set; }//元素生物增伤

    //进攻属性 歧视伤害 怪物级别
    public float NormalDmg { get; set; }//普通怪物增伤
    public float EliteDmg { get; set; }//精英怪物增伤
    public float BossDmg { get; set; }//首领怪物增伤
    //进攻属性-特殊类型歧视伤害 TODO(带盾牌/有护盾/...)

    //防御属性
    public int Amr { get; set; }//物理护甲
    public int Res { get; set; }//魔法抗性

    //元素抗性 
    //火焰（红）-寒冰（青）-闪电（蓝）-毒药（绿）-暗影（紫）-神圣（黄）-秘法 （粉）
    public int FireRes { get; set; }
    public int IceRes { get; set; }
    public int LightningRes { get; set; }
    public int PoisonRes { get; set; }
    public int ShadowRes { get; set; }
    public int HolyRes { get; set; }
    public int ArcaneRes { get; set; }

    //防御属性 其他
    public float BlkCha { get; set; }//格挡 几率
    public int BlkFix { get; set; }//格挡 固定值
    public float BlkPer { get; set; }//格挡 百分比
    public float Eva { get; set; }//闪避 几率
    public float Tough { get; set; }//坚韧（影响受控制时间 0.1表示减少控制时间10%）
    public int Thorns { get; set; }//荆棘伤害（受到伤害反弹，纯粹伤害，偏向给T）

    //防御属性 歧视减伤 近战远程
    public float MeleeDef { get; set; }//近战百分比减伤
    public float RangeDef { get; set; }//远程百分比减伤
    //TODO 其他歧视减伤

    //生命和能量
    public int HpMax { get; set; }//生命 上限
    public float HpReg { get; set; }//生命 恢复每秒

    public int SpMax { get; set; }//能量 上限
    public float SpReg { get; set; }//能量 恢复每秒

    public int HpReciFix { get; set; }//受治疗固定数值加成（技能，药剂和神符）
    public float HpReciPer { get; set; }//受治疗百分比加成（技能，药剂和神符）

    public int HpHitReg { get; set; }//击中生命回复
    public int HpKillReg { get; set; }//击杀生命回复

    public int SpHitReg { get; set; }//击中能量回复
    public int SpKillReg { get; set; }//击杀能量回复
    
    public float SpCostHpReg { get; set; }//消耗每点能量回复生命

    //冒险属性
    public int Spd { get; set; }//移动速度(TODO 移动速度额外有一个 最终百分比加成 FXSpdP)
    public float GoldGet { get; set; }//金钱获取
    public float ExpGet { get; set; }//经验获取
    public float ItemGet { get; set; }//装备获取
    public int GetRange { get; set; }//拾取范围

    //全局增减伤
    //全局独立增伤
    public float FinalDmgBoost { get; set; }
    //全局独立减伤
    public float FinalDmgReduce { get; set; }
    
}