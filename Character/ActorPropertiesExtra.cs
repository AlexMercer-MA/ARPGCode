using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//角色额外属性脚本：玩家获得物品和使用技能时，对属性的修改在这里计算
//修改时机：穿上物品，卸下物品，使用技能，技能结束，点天赋，使用永久性技能时

public class ActorPropertiesExtra : MonoBehaviour {
    
    //规则：慎用FX Final_extra，它不受百分比加成
    //Final = (Base + EXFix) * (1 + EXPer) + FXFix
    //EXPer最小值为-1，也就是1+EXPer最小为零

    //主属性
    public int EXStrF { get; set; }//固定力量
    public float EXStrP { get { return Mathf.Clamp(_EXStrP, -1f, _EXStrP); } set { _EXStrP = value; } }//百分比力量
    private float _EXStrP;
    public int FXStr { get; set; }//额外固定 力量

    public int EXDexF { get; set; }//固定敏捷
    public float EXDexP { get { return Mathf.Clamp(_EXDexP, -1f, _EXDexP); } set { _EXDexP = value; } }//百分比敏捷
    private float _EXDexP;
    public int FXDex { get; set; }//额外固定 敏捷

    public int EXIntF { get; set; }//固定智力
    public float EXIntP { get { return Mathf.Clamp(_EXIntP, -1f, _EXIntP); } set { _EXIntP = value; } }//百分比智力
    private float _EXIntP;
    public int FXInt { get; set; }//额外固定 智力

    public int EXSpiF { get; set; }//固定精神
    public float EXSpiP { get { return Mathf.Clamp(_EXSpiP, -1f, _EXSpiP); } set { _EXSpiP = value; } }//百分比精神
    private float _EXSpiP;
    public int FXSpi { get; set; }//额外固定 精神

    public int EXCunF { get; set; }//固定诡诈
    public float EXCunP { get { return Mathf.Clamp(_EXCunP, -1f, _EXCunP); } set { _EXCunP = value; } }//百分比诡诈
    private float _EXCunP;
    public int FXCun { get; set; }//额外固定 诡诈

    public int EXVitF { get; set; }//固定耐力
    public float EXVitP { get { return Mathf.Clamp(_EXVitP, -1f, _EXVitP); } set { _EXVitP = value; } }//百分比耐力
    private float _EXVitP;
    public int FXVit { get; set; }//额外固定 耐力

    //攻击属性--------------------------------------------------------------------------------------------------------------------------
    
    public int EXPhyMeleeMinF { get; set; }//固定最小近战物理攻击
    public int EXPhyMeleeMaxF { get; set; }//固定最大近战物理攻击
    public float EXPhyMeleeP { get { return Mathf.Clamp(_EXPhyMeleeP, -1f, _EXPhyMeleeP); } set { _EXPhyMeleeP = value; } }//百分比近战物理攻击
    private float _EXPhyMeleeP;
    public int FXPhyMelee { get; set; }//额外固定 近战物理攻击

    public int EXPhyRangeMinF { get; set; }//固定最小远程物理攻击
    public int EXPhyRangeMaxF { get; set; }//固定最大远程物理攻击
    public float EXPhyRangeP { get { return Mathf.Clamp(_EXPhyRangeP, -1f, _EXPhyRangeP); } set { _EXPhyRangeP = value; } }//百分比远程物理攻击
    private float _EXPhyRangeP;
    public int FXPhyRange { get; set; }//额外固定 远程物理攻击

    public int EXMgiMinF { get; set; }//固定最小魔法攻击
    public int EXMgiMaxF { get; set; }//固定最大魔法攻击
    public float EXMgiP { get { return Mathf.Clamp(_EXMgiP, -1f, _EXMgiP); } set { _EXMgiP = value; } }//百分比魔法攻击
    private float _EXMgiP;
    public int FXMgi { get; set; }//额外固定 魔法攻击

    public int EXFireDmgF { get; set; }//火焰伤害
    public float EXFireDmgP { get { return Mathf.Clamp(_EXFireDmgP, -1f, _EXFireDmgP); } set { _EXFireDmgP = value; } }
    private float _EXFireDmgP;
    public int FXFireDmg { get; set; }

    public int EXIceDmgF { get; set; }//寒冰伤害
    public float EXIceDmgP { get { return Mathf.Clamp(_EXIceDmgP, -1f, _EXIceDmgP); } set { _EXIceDmgP = value; } }
    private float _EXIceDmgP;
    public int FXIceDmg { get; set; }

    public int EXLightningDmgF { get; set; }//闪电伤害
    public float EXLightningDmgP { get { return Mathf.Clamp(_EXLightningDmgP, -1f, _EXLightningDmgP); } set { _EXLightningDmgP = value; } }
    private float _EXLightningDmgP;
    public int FXLightningDmg { get; set; }

    public int EXPoisonDmgF { get; set; }//剧毒伤害
    public float EXPoisonDmgP { get { return Mathf.Clamp(_EXPoisonDmgP, -1f, _EXPoisonDmgP); } set { _EXPoisonDmgP = value; } }
    private float _EXPoisonDmgP;
    public int FXPoisonDmg { get; set; }

    public int EXArcaneDmgF { get; set; }//秘法伤害
    public float EXArcaneDmgP { get { return Mathf.Clamp(_EXArcaneDmgP, -1f, _EXArcaneDmgP); } set { _EXArcaneDmgP = value; } }
    private float _EXArcaneDmgP;
    public int FXArcaneDmg { get; set; }

    public int EXShadowDmgF { get; set; }//暗影伤害
    public float EXShadowDmgP { get { return Mathf.Clamp(_EXShadowDmgP, -1f, _EXShadowDmgP); } set { _EXShadowDmgP = value; } }
    private float _EXShadowDmgP;
    public int FXShadowDmg { get; set; }

    public int EXHolyDmgF { get; set; }//神圣伤害
    public float EXHolyDmgP { get { return Mathf.Clamp(_EXHolyDmgP, -1f, _EXHolyDmgP); } set { _EXHolyDmgP = value; } }
    private float _EXHolyDmgP;
    public int FXHolyDmg { get; set; }

    public float EXIasF { get; set; }//固定攻击速度
    public float EXIasP { get { return Mathf.Clamp(_EXIasP, -1f, _EXIasP); } set { _EXIasP = value; } }
    private float _EXIasP;
    public float FXIas { get; set; }//额外固定 攻击速度

    //进攻属性 暴击暴伤
    public float EXCriChaF { get; set; }//固定暴击几率
    public float EXCriChaP { get { return Mathf.Clamp(_EXCriChaP, -1f, _EXCriChaP); } set { _EXCriChaP = value; } }
    private float _EXCriChaP;
    public float FXCriCha { get; set; }//额外固定 暴击几率

    public float EXCriDmgF { get; set; }//固定暴击伤害
    public float EXCriDmgP { get { return Mathf.Clamp(_EXCriDmgP, -1f, _EXCriDmgP); } set { _EXCriDmgP = value; } }
    private float _EXCriDmgP;
    public float FXCriDmg { get; set; }//额外固定 暴击伤害

    public float EXCriPhyMeleeChaF { get; set; }//固定物理远程 暴击几率
    public float EXCriPhyMeleeChaP { get { return Mathf.Clamp(_EXCriPhyMeleeChaP, -1f, _EXCriPhyMeleeChaP); } set { _EXCriPhyMeleeChaP = value; } }
    private float _EXCriPhyMeleeChaP;
    public float FXCriPhyMeleeCha { get; set; }

    public float EXCriPhyMeleeDmgF { get; set; }//固定物理近战 暴击伤害
    public float EXCriPhyMeleeDmgP { get { return Mathf.Clamp(_EXCriPhyMeleeDmgP, -1f, _EXCriPhyMeleeDmgP); } set { _EXCriPhyMeleeDmgP = value; } }
    private float _EXCriPhyMeleeDmgP;
    public float FXCriPhyMeleeDmg { get; set; }

    public float EXCriPhyRangeChaF { get; set; }//固定物理远程 暴击几率
    public float EXCriPhyRangeChaP { get { return Mathf.Clamp(_EXCriPhyRangeChaP, -1f, _EXCriPhyRangeChaP); } set { _EXCriPhyRangeChaP = value; } }
    private float _EXCriPhyRangeChaP;
    public float FXCriPhyRangeCha { get; set; }

    public float EXCriPhyRangeDmgF { get; set; }//固定物理近战 暴击伤害
    public float EXCriPhyRangeDmgP { get { return Mathf.Clamp(_EXCriPhyRangeDmgP, -1f, _EXCriPhyRangeDmgP); } set { _EXCriPhyRangeDmgP = value; } }
    private float _EXCriPhyRangeDmgP;
    public float FXCriPhyRangeDmg { get; set; }

    public float EXCriMgiChaF { get; set; }//固定魔法 暴击几率
    public float EXCriMgiChaP { get { return Mathf.Clamp(_EXCriMgiChaP, -1f, _EXCriMgiChaP); } set { _EXCriMgiChaP = value; } }
    private float _EXCriMgiChaP;
    public float FXCriMgiCha { get; set; }//额外固定 魔法暴击几率

    public float EXCriMgiDmgF { get; set; }//固定魔法 暴击伤害
    public float EXCriMgiDmgP { get { return Mathf.Clamp(_EXCriMgiDmgP, -1f, _EXCriMgiDmgP); } set { _EXCriMgiDmgP = value; } }
    private float _EXCriMgiDmgP;
    public float FXCriMgiDmg { get; set; }//额外固定 魔法暴击伤害

    //进攻属性 护甲穿透，抗性穿透
    public int EXAmrPeneFixF { get; set; }//固定 固定护甲穿透
    public float EXAmrPeneFixP { get { return Mathf.Clamp(_EXAmrPeneFixP, -1f, _EXAmrPeneFixP); } set { _EXAmrPeneFixP = value; } }
    private float _EXAmrPeneFixP;
    public int FXAmrPeneFix { get; set; }//额外固定 固定护甲穿透

    public float EXAmrPenePerF { get; set; }//固定 百分比护甲穿透
    public float EXAmrPenePerP { get { return Mathf.Clamp(_EXAmrPenePerP, -1f, _EXAmrPenePerP); } set { _EXAmrPenePerP = value; } }
    private float _EXAmrPenePerP;
    public float FXAmrPenePer { get; set; }//额外固定 百分比护甲穿透

    public int EXResPeneFixF { get; set; }//固定 固定抗性穿透
    public float EXResPeneFixP { get { return Mathf.Clamp(_EXResPeneFixP, -1f, _EXResPeneFixP); } set { _EXResPeneFixP = value; } }
    private float _EXResPeneFixP;
    public int FXResPeneFix { get; set; }//额外固定 固定抗性穿透

    public float EXResPenePerF { get; set; }//固定 百分比抗性穿透
    public float EXResPenePerP { get { return Mathf.Clamp(_EXResPenePerP, -1f, _EXResPenePerP); } set { _EXResPenePerP = value; } }
    private float _EXResPenePerP;
    public float FXResPenePer { get; set; }//额外固定 百分比抗性穿透

    //进攻属性 其他（减冷却，减耗，精准）
    public float EXCdrF { get; set; }//固定 冷却缩减
    public float EXCdrP { get { return Mathf.Clamp(_EXCdrP, -1f, _EXCdrP); } set { _EXCdrP = value; } }
    private float _EXCdrP;
    public float FXCdr { get; set; }//额外固定 冷却缩减

    public float EXCsrF { get; set; }//固定 消耗缩减
    public float EXCsrP { get { return Mathf.Clamp(_EXCsrP, -1f, _EXCsrP); } set { _EXCsrP = value; } }
    private float _EXCsrP;
    public float FXCsr { get; set; }//额外固定 消耗缩减

    public float EXAccF { get; set; }//固定 精准命中（慎用，抵消闪避）
    public float EXAccP { get { return Mathf.Clamp(_EXAccP, -1f, _EXAccP); } set { _EXAccP = value; } }
    private float _EXAccP;
    public float FXAcc { get; set; }//额外固定 精准命中

    //进攻属性 歧视伤害 生物类型
    public float EXHumanDmgF { get; set; }//人形生物增伤
    public float EXHumanDmgP { get { return Mathf.Clamp(_EXHumanDmgP, -1f, _EXHumanDmgP); } set { _EXHumanDmgP = value; } }
    private float _EXHumanDmgP;
    public float FXHumanDmg { get; set; }

    public float EXBeastDmgF { get; set; }//野兽增伤
    public float EXBeastDmgP { get { return Mathf.Clamp(_EXBeastDmgP, -1f, _EXBeastDmgP); } set { _EXBeastDmgP = value; } }
    private float _EXBeastDmgP;
    public float FXBeastDmg { get; set; }

    public float EXUndeadDmgF { get; set; }//亡灵增伤
    public float EXUndeadDmgP { get { return Mathf.Clamp(_EXUndeadDmgP, -1f, _EXUndeadDmgP); } set { _EXUndeadDmgP = value; } }
    private float _EXUndeadDmgP;
    public float FXUndeadDmg { get; set; }

    public float EXDragonDmgF { get; set; }//龙类增伤
    public float EXDragonDmgP { get { return Mathf.Clamp(_EXDragonDmgP, -1f, _EXDragonDmgP); } set { _EXDragonDmgP = value; } }
    private float _EXDragonDmgP;
    public float FXDragonDmg { get; set; }

    public float EXDemonDmgF { get; set; }//恶魔增伤
    public float EXDemonDmgP { get { return Mathf.Clamp(_EXDemonDmgP, -1f, _EXDemonDmgP); } set { _EXDemonDmgP = value; } }
    private float _EXDemonDmgP;
    public float FXDemonDmg { get; set; }

    public float EXElementDmgF { get; set; }//元素生物增伤
    public float EXElementDmgP { get { return Mathf.Clamp(_EXElementDmgP, -1f, _EXElementDmgP); } set { _EXElementDmgP = value; } }
    private float _EXElementDmgP;
    public float FXElementDmg { get; set; }

    //进攻属性 歧视伤害 怪物级别
    public float EXNormalDmgF { get; set; }//普通怪物增伤
    public float EXNormalDmgP { get { return Mathf.Clamp(_EXNormalDmgP, -1f, _EXNormalDmgP); } set { _EXNormalDmgP = value; } }
    private float _EXNormalDmgP;
    public float FXNormalDmg { get; set; }

    public float EXEliteDmgF { get; set; }//精英怪物增伤
    public float EXEliteDmgP { get { return Mathf.Clamp(_EXEliteDmgP, -1f, _EXEliteDmgP); } set { _EXEliteDmgP = value; } }
    private float _EXEliteDmgP;
    public float FXEliteDmg { get; set; }

    public float EXBossDmgF { get; set; }//首领怪物增伤
    public float EXBossDmgP { get { return Mathf.Clamp(_EXBossDmgP, -1f, _EXBossDmgP); } set { _EXBossDmgP = value; } }
    private float _EXBossDmgP;
    public float FXBossDmg { get; set; }

    //防御属性--------------------------------------------------------------------------------------------------------------------------
   
    //防御属性 护甲魔抗
    public int EXAmrF { get; set; }//物理护甲
    public float EXAmrP { get { return Mathf.Clamp(_EXAmrP, -1f, _EXAmrP); } set { _EXAmrP = value; } }
    private float _EXAmrP;
    public int FXAmr { get; set; }

    public int EXResF { get; set; }//魔法抗性
    public float EXResP { get { return Mathf.Clamp(_EXResP, -1f, _EXResP); } set { _EXResP = value; } }
    private float _EXResP;
    public int FXRes { get; set; }

    //防御属性 元素抗性 减伤同x/x+100公式
    public int EXFireResF { get; set; }//火焰抗性
    public float EXFireResP { get { return Mathf.Clamp(_EXFireResP, -1f, _EXFireResP); } set { _EXFireResP = value; } }
    private float _EXFireResP;
    public int FXFireRes { get; set; }

    public int EXIceResF { get; set; }//寒冰抗性
    public float EXIceResP { get { return Mathf.Clamp(_EXIceResP, -1f, _EXIceResP); } set { _EXIceResP = value; } }
    private float _EXIceResP;
    public int FXIceRes { get; set; }

    public int EXLightningResF { get; set; }//闪电抗性
    public float EXLightningResP { get { return Mathf.Clamp(_EXLightningResP, -1f, _EXLightningResP); } set { _EXLightningResP = value; } }
    private float _EXLightningResP;
    public int FXLightningRes { get; set; }

    public int EXPoisonResF { get; set; }//剧毒抗性
    public float EXPoisonResP { get { return Mathf.Clamp(_EXPoisonResP, -1f, _EXPoisonResP); } set { _EXPoisonResP = value; } }
    private float _EXPoisonResP;
    public int FXPoisonRes { get; set; }

    public int EXShadowResF { get; set; }//暗影抗性
    public float EXShadowResP { get { return Mathf.Clamp(_EXShadowResP, -1f, _EXShadowResP); } set { _EXShadowResP = value; } }
    private float _EXShadowResP;
    public int FXShadowRes { get; set; }

    public int EXHolyResF { get; set; }//神圣抗性
    public float EXHolyResP { get { return Mathf.Clamp(_EXHolyResP, -1f, _EXHolyResP); } set { _EXHolyResP = value; } }
    private float _EXHolyResP;
    public int FXHolyRes { get; set; }

    public int EXArcaneResF { get; set; }//秘法抗性
    public float EXArcaneResP { get { return Mathf.Clamp(_EXArcaneResP, -1f, _EXArcaneResP); } set { _EXArcaneResP = value; } }
    private float _EXArcaneResP;
    public int FXArcaneRes { get; set; }

    //防御属性 其他（格挡，闪避，坚韧，荆棘）
    public float EXBlkChaF { get; set; }//格挡 几率
    public float EXBlkChaP { get { return Mathf.Clamp(_EXBlkChaP, -1f, _EXBlkChaP); } set { _EXBlkChaP = value; } }
    private float _EXBlkChaP;
    public float FXBlkCha { get; set; }

    public int EXBlkFixF { get; set; }//格挡 固定值
    public float EXBlkFixP { get { return Mathf.Clamp(_EXBlkFixP, -1f, _EXBlkFixP); } set { _EXBlkFixP = value; } }
    private float _EXBlkFixP;
    public int FXBlkFix { get; set; }

    public float EXBlkPerF { get; set; }//格挡 百分比
    public float EXBlkPerP { get { return Mathf.Clamp(_EXBlkPerP, -1f, _EXBlkPerP); } set { _EXBlkPerP = value; } }
    private float _EXBlkPerP;
    public float FXBlkPer { get; set; }

    public float EXEvaF { get; set; }//闪避 几率
    public float EXEvaP { get { return Mathf.Clamp(_EXEvaP, -1f, _EXEvaP); } set { _EXEvaP = value; } }
    private float _EXEvaP;
    public float FXEva { get; set; }

    public float EXToughF { get; set; }//坚韧（影响受控制时间 0.1表示减少控制时间10%）
    public float EXToughP { get { return Mathf.Clamp(_EXToughP, -1f, _EXToughP); } set { _EXToughP = value; } }
    private float _EXToughP;
    public float FXTough { get; set; }
    
    public int EXThornsF { get; set; }//荆棘伤害（受到伤害反弹，纯粹伤害，偏向给T）
    public float EXThornsP { get { return Mathf.Clamp(_EXThornsP, -1f, _EXThornsP); } set { _EXThornsP = value; } }
    private float _EXThornsP;
    public int FXThorns { get; set; }

    //防御属性 歧视减伤 近战远程
    public float EXMeleeDefF { get; set; }//近战百分比减伤
    public float EXMeleeDefP { get { return Mathf.Clamp(_EXMeleeDefP, -1f, _EXMeleeDefP); } set { _EXMeleeDefP = value; } }
    private float _EXMeleeDefP;
    public float FXMeleeDef { get; set; }

    public float EXRangeDefF { get; set; }//远程百分比减伤
    public float EXRangeDefP { get { return Mathf.Clamp(_EXRangeDefP, -1f, _EXRangeDefP); } set { _EXRangeDefP = value; } }
    private float _EXRangeDefP;
    public float FXRangeDef { get; set; }

    //生命与能量-------------------------------------------------------------------------------------------------------------------------- 
    public int EXHpMaxF { get; set; }//生命 上限
    public float EXHpMaxP { get { return Mathf.Clamp(_EXHpMaxP, -1f, _EXHpMaxP); } set { _EXHpMaxP = value; } }
    private float _EXHpMaxP;
    public int FXHpMax { get; set; }

    public float EXHpRegF { get; set; }//生命 恢复
    public float EXHpRegP { get { return Mathf.Clamp(_EXHpRegP, -1f, _EXHpRegP); } set { _EXHpRegP = value; } }
    private float _EXHpRegP;
    public float FXHpReg { get; set; }

    public int EXSpMaxF { get; set; }//能量 上限
    public float EXSpMaxP { get { return Mathf.Clamp(_EXHpRegP, -1f, _EXHpRegP); } set { _EXHpRegP = value; } }
    private float _EXSpMaxP;
    public int FXSpMax { get; set; }

    public float EXSpRegF { get; set; }//能量 恢复
    public float EXSpRegP { get { return Mathf.Clamp(_EXSpRegP, -1f, _EXSpRegP); } set { _EXSpRegP = value; } }
    private float _EXSpRegP;
    public float FXSpReg { get; set; }

    public int EXHpReciFixF { get; set; }//受治疗固定数值加成（技能，药剂和神符）
    public float EXHpReciFixP { get { return Mathf.Clamp(_EXHpReciFixP, -1f, _EXHpReciFixP); } set { _EXHpReciFixP = value; } }
    private float _EXHpReciFixP;
    public int FXHpReciFix { get; set; }

    public float EXHpReciPerF { get; set; }//受治疗百分比加成（技能，药剂和神符）
    public float EXHpReciPerP { get { return Mathf.Clamp(_EXHpReciPerP, -1f, _EXHpReciPerP); } set { _EXHpReciPerP = value; } }
    private float _EXHpReciPerP;
    public float FXHpReciPer { get; set; }

    public int EXHpHitRegF { get; set; }//击中生命回复
    public float EXHpHitRegP { get { return Mathf.Clamp(_EXHpHitRegP, -1f, _EXHpHitRegP); } set { _EXHpHitRegP = value; } }
    private float _EXHpHitRegP;
    public int FXHpHitReg { get; set; }

    public int EXHpKillRegF { get; set; }//击杀生命回复
    public float EXHpKillRegP { get { return Mathf.Clamp(_EXHpKillRegP, -1f, _EXHpKillRegP); } set { _EXHpKillRegP = value; } }
    private float _EXHpKillRegP;
    public int FXHpKillReg { get; set; }

    public int EXSpHitRegF { get; set; }//击中能量回复
    public float EXSpHitRegP { get { return Mathf.Clamp(_EXSpHitRegP, -1f, _EXSpHitRegP); } set { _EXSpHitRegP = value; } }
    private float _EXSpHitRegP;
    public int FXSpHitReg { get; set; }

    public int EXSpKillRegF { get; set; }//击杀能量回复
    public float EXSpKillRegP { get { return Mathf.Clamp(_EXSpKillRegP, -1f, _EXSpKillRegP); } set { _EXSpKillRegP = value; } }
    private float _EXSpKillRegP;
    public int FXSpKillReg { get; set; }

    public float EXSpCostHpRegF { get; set; }//消耗每点能量回复生命
    public float EXSpCostHpRegP { get { return Mathf.Clamp(_EXSpCostHpRegP, -1f, _EXSpCostHpRegP); } set { _EXSpCostHpRegP = value; } }
    private float _EXSpCostHpRegP;
    public float FXSpCostHpReg { get; set; }

    //冒险属性--------------------------------------------------------------------------------------------------------------------------
    public int EXSpdF { get; set; }//移动速度
    public float EXSpdP { get { return Mathf.Clamp(_EXSpdP, -1f, _EXSpdP); } set { _EXSpdP = value; } }
    private float _EXSpdP;
    public int FXSpd { get; set; }//额外 移动速度
    //唯一特例！移动速度最终百分比修正，用于调节 1武器类型差异 2背包和装甲负重重量【FX_P_Spd】
    public float FX_P_Spd { get { return Mathf.Clamp(_FX_P_Spd, -1f, _FX_P_Spd); } set { _FX_P_Spd = value; } }
    private float _FX_P_Spd;
    
    public float EXGoldGetF { get; set; }//金钱获取
    public float EXGoldGetP { get { return Mathf.Clamp(_EXGoldGetP, -1f, _EXGoldGetP); } set { _EXGoldGetP = value; } }
    private float _EXGoldGetP;
    public float FXGoldGet { get; set; }

    public float EXExpGetF { get; set; }//经验获取
    public float EXExpGetP { get { return Mathf.Clamp(_EXExpGetP, -1f, _EXExpGetP); } set { _EXExpGetP = value; } }
    private float _EXExpGetP;
    public float FXExpGet { get; set; }

    public float EXItemGetF { get; set; }//装备获取
    public float EXItemGetP { get { return Mathf.Clamp(_EXItemGetP, -1f, _EXItemGetP); } set { _EXItemGetP = value; } }
    private float _EXItemGetP;
    public float FXItemGet { get; set; }

    public int EXGetRangeF { get; set; }//移动速度
    public float EXGetRangeP { get { return Mathf.Clamp(_EXGetRangeP, -1f, _EXGetRangeP); } set { _EXGetRangeP = value; } }
    private float _EXGetRangeP;
    public int FXGetRange { get; set; }

    //全局增减伤
    //全局独立增伤
    public float EXFinalDmgBoostF { get; set; }
    public float EXFinalDmgBoostP { get { return Mathf.Clamp(_EXFinalDmgBoostP, -1f, _EXFinalDmgBoostP); } set { _EXFinalDmgBoostP = value; } }
    private float _EXFinalDmgBoostP;
    public float FXFinalDmgBoost { get; set; }
    //全局独立减伤
    public float EXFinalDmgReduceF { get; set; }
    public float EXFinalDmgReduceP { get { return Mathf.Clamp(_EXFinalDmgReduceP, -1f, _EXFinalDmgReduceP); } set { _EXFinalDmgReduceP = value; } }
    private float _EXFinalDmgReduceP;
    public float FXFinalDmgReduce { get; set; }
    
}
