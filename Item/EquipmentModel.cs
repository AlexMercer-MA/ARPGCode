//Made by Alex
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentModel : ItemData 
{
    public eSlotType SlotType;
	public eEquipmentType EquipmentType;

    public int EXStrF0;
    public int EXStrF1;
    public float EXStrP0;
    public float EXStrP1;
    public int FXStr0;
    public int FXStr1;

    public int EXDexF0;
	public int EXDexF1;
    public float EXDexP0;
    public float EXDexP1;
    public int FXDex0;
    public int FXDex1;

    public int EXIntF0;
    public int EXIntF1;
    public float EXIntP0;
    public float EXIntP1;
    public int FXInt0;
    public int FXInt1;
    
    public int EXSpiF0;
    public int EXSpiF1;
    public float EXSpiP0;
    public float EXSpiP1;
    public int FXSpi0;
    public int FXSpi1;

    public int EXCunF0;
    public int EXCunF1;
    public float EXCunP0;
    public float EXCunP1;
    public int FXCun0;
    public int FXCun1;

    public int EXVitF0;
    public int EXVitF1;
    public float EXVitP0;
    public float EXVitP1;
    public int FXVit0;
    public int FXVit1;

    public int EXPhyMeleeMinF0;
    public int EXPhyMeleeMinF1;
    public int EXPhyMeleeMaxF0;
    public int EXPhyMeleeMaxF1;
    public float EXPhyMeleeP0;
    public float EXPhyMeleeP1;
    public int FXPhyMelee0;
    public int FXPhyMelee1;

    public int EXPhyRangeMinF0;
    public int EXPhyRangeMinF1;
    public int EXPhyRangeMaxF0;
    public int EXPhyRangeMaxF1;
    public float EXPhyRangeP0;
    public float EXPhyRangeP1;
    public int FXPhyRange0;
    public int FXPhyRange1;

    public int EXMgiMinF0;
    public int EXMgiMinF1;
    public int EXMgiMaxF0;
    public int EXMgiMaxF1;
    public float EXMgiP0;
    public float EXMgiP1;
    public int FXMgi0;
    public int FXMgi1;

    public int EXFireDmgF0;
    public int EXFireDmgF1;
    public float EXFireDmgP0;
    public float EXFireDmgP1;
    public int FXFireDmg0;
    public int FXFireDmg1;

    public int EXIceDmgF0;
    public int EXIceDmgF1;
    public float EXIceDmgP0;
    public float EXIceDmgP1;
    public int FXIceDmg0;
    public int FXIceDmg1;

    public int EXLightningDmgF0;
    public int EXLightningDmgF1;
    public float EXLightningDmgP0;
    public float EXLightningDmgP1;
    public int FXLightningDmg0;
    public int FXLightningDmg1;

    public int EXPoisonDmgF0;
    public int EXPoisonDmgF1;
    public float EXPoisonDmgP0;
    public float EXPoisonDmgP1;
    public int FXPoisonDmg0;
    public int FXPoisonDmg1;

    public int EXArcaneDmgF0;
    public int EXArcaneDmgF1;
    public float EXArcaneDmgP0;
    public float EXArcaneDmgP1;
    public int FXArcaneDmg0;
    public int FXArcaneDmg1;

    public int EXShadowDmgF0;
    public int EXShadowDmgF1;
    public float EXShadowDmgP0;
    public float EXShadowDmgP1;
    public int FXShadowDmg0;
    public int FXShadowDmg1;

    public int EXHolyDmgF0;
    public int EXHolyDmgF1;
    public float EXHolyDmgP0;
    public float EXHolyDmgP1;
    public int FXHolyDmg0;
    public int FXHolyDmg1;

    public float EXIasF0;
    public float EXIasF1;
    public float EXIasP0;
    public float EXIasP1;
    public float FXIas0;
    public float FXIas1;

    public float EXCriChaF0;
    public float EXCriChaF1;
    public float EXCriChaP0;
    public float EXCriChaP1;
    public float FXCriCha0;
    public float FXCriCha1;

    public float EXCriDmgF0;
    public float EXCriDmgF1;
    public float EXCriDmgP0;
    public float EXCriDmgP1;
    public float FXCriDmg0;
    public float FXCriDmg1;

    public float EXCriPhyMeleeChaF0;
    public float EXCriPhyMeleeChaF1;
    public float EXCriPhyMeleeChaP0;
    public float EXCriPhyMeleeChaP1;
    public float FXCriPhyMeleeCha0;
    public float FXCriPhyMeleeCha1;

    public float EXCriPhyMeleeDmgF0;
    public float EXCriPhyMeleeDmgF1;
    public float EXCriPhyMeleeDmgP0;
    public float EXCriPhyMeleeDmgP1;
    public float FXCriPhyMeleeDmg0;
    public float FXCriPhyMeleeDmg1;

    public float EXCriPhyRangeChaF0;
    public float EXCriPhyRangeChaF1;
    public float EXCriPhyRangeChaP0;
    public float EXCriPhyRangeChaP1;
    public float FXCriPhyRangeCha0;
    public float FXCriPhyRangeCha1;

    public float EXCriPhyRangeDmgF0;
    public float EXCriPhyRangeDmgF1;
    public float EXCriPhyRangeDmgP0;
    public float EXCriPhyRangeDmgP1;
    public float FXCriPhyRangeDmg0;
    public float FXCriPhyRangeDmg1;

    public float EXCriMgiChaF0;
    public float EXCriMgiChaF1;
    public float EXCriMgiChaP0;
    public float EXCriMgiChaP1;
    public float FXCriMgiCha0;
    public float FXCriMgiCha1;

    public float EXCriMgiDmgF0;
    public float EXCriMgiDmgF1;
    public float EXCriMgiDmgP0;
    public float EXCriMgiDmgP1;
    public float FXCriMgiDmg0;
    public float FXCriMgiDmg1;

    public int EXAmrPeneFixF0;
    public int EXAmrPeneFixF1;
    public float EXAmrPeneFixP0;
    public float EXAmrPeneFixP1;
    public int FXAmrPeneFix0;
    public int FXAmrPeneFix1;

    public float EXAmrPenePerF0;
    public float EXAmrPenePerF1;
    public float EXAmrPenePerP0;
    public float EXAmrPenePerP1;
    public float FXAmrPenePer0;
    public float FXAmrPenePer1;

    public int EXResPeneFixF0;
    public int EXResPeneFixF1;
    public float EXResPeneFixP0;
    public float EXResPeneFixP1;
    public int FXResPeneFix0;
    public int FXResPeneFix1;

    public float EXResPenePerF0;
    public float EXResPenePerF1;
    public float EXResPenePerP0;
    public float EXResPenePerP1;
    public float FXResPenePer0;
    public float FXResPenePer1;

    public float EXCdrF0;
    public float EXCdrF1;
    public float EXCdrP0;
    public float EXCdrP1;
    public float FXCdr0;
    public float FXCdr1;

    public float EXCsrF0;
    public float EXCsrF1;
    public float EXCsrP0;
    public float EXCsrP1;
    public float FXCsr0;
    public float FXCsr1;

    public float EXAccF0;
    public float EXAccF1;
    public float EXAccP0;
    public float EXAccP1;
    public float FXAcc0;
    public float FXAcc1;

    public float EXHumanDmgF0;
    public float EXHumanDmgF1;
    public float EXHumanDmgP0;
    public float EXHumanDmgP1;
    public float FXHumanDmg0;
    public float FXHumanDmg1;

    public float EXBeastDmgF0;
    public float EXBeastDmgF1;
    public float EXBeastDmgP0;
    public float EXBeastDmgP1;
    public float FXBeastDmg0;
    public float FXBeastDmg1;

    public float EXUndeadDmgF0;
    public float EXUndeadDmgF1;
    public float EXUndeadDmgP0;
    public float EXUndeadDmgP1;
    public float FXUndeadDmg0;
    public float FXUndeadDmg1;

    public float EXDragonDmgF0;
    public float EXDragonDmgF1;
    public float EXDragonDmgP0;
    public float EXDragonDmgP1;
    public float FXDragonDmg0;
    public float FXDragonDmg1;

    public float EXDemonDmgF0;
    public float EXDemonDmgF1;
    public float EXDemonDmgP0;
    public float EXDemonDmgP1;
    public float FXDemonDmg0;
    public float FXDemonDmg1;

    public float EXElementDmgF0;
    public float EXElementDmgF1;
    public float EXElementDmgP0;
    public float EXElementDmgP1;
    public float FXElementDmg0;
    public float FXElementDmg1;

    public float EXNormalDmgF0;
    public float EXNormalDmgF1;
    public float EXNormalDmgP0;
    public float EXNormalDmgP1;
    public float FXNormalDmg0;
    public float FXNormalDmg1;

    public float EXEliteDmgF0;
    public float EXEliteDmgF1;
    public float EXEliteDmgP0;
    public float EXEliteDmgP1;
    public float FXEliteDmg0;
    public float FXEliteDmg1;

    public float EXBossDmgF0;
    public float EXBossDmgF1;
    public float EXBossDmgP0;
    public float EXBossDmgP1;
    public float FXBossDmg0;
    public float FXBossDmg1;

    public int EXAmrF0;
    public int EXAmrF1;
    public float EXAmrP0;
    public float EXAmrP1;
    public int FXAmr0;
    public int FXAmr1;

    public int EXResF0;
    public int EXResF1;
    public float EXResP0;
    public float EXResP1;
    public int FXRes0;
    public int FXRes1;

    public int EXFireResF0;
    public int EXFireResF1;
    public float EXFireResP0;
    public float EXFireResP1;
    public int FXFireRes0;
    public int FXFireRes1;

    public int EXIceResF0;
    public int EXIceResF1;
    public float EXIceResP0;
    public float EXIceResP1;
    public int FXIceRes0;
    public int FXIceRes1;

    public int EXLightningResF0;
    public int EXLightningResF1;
    public float EXLightningResP0;
    public float EXLightningResP1;
    public int FXLightningRes0;
    public int FXLightningRes1;

    public int EXPoisonResF0;
    public int EXPoisonResF1;
    public float EXPoisonResP0;
    public float EXPoisonResP1;
    public int FXPoisonRes0;
    public int FXPoisonRes1;

    public int EXShadowResF0;
    public int EXShadowResF1;
    public float EXShadowResP0;
    public float EXShadowResP1;
    public int FXShadowRes0;
    public int FXShadowRes1;

    public int EXHolyResF0;
    public int EXHolyResF1;
    public float EXHolyResP0;
    public float EXHolyResP1;
    public int FXHolyRes0;
    public int FXHolyRes1;

    public int EXArcaneResF0;
    public int EXArcaneResF1;
    public float EXArcaneResP0;
    public float EXArcaneResP1;
    public int FXArcaneRes0;
    public int FXArcaneRes1;

    public float EXBlkChaF0;
    public float EXBlkChaF1;
    public float EXBlkChaP0;
    public float EXBlkChaP1;
    public float FXBlkCha0;
    public float FXBlkCha1;

    public int EXBlkFixF0;
    public int EXBlkFixF1;
    public float EXBlkFixP0;
    public float EXBlkFixP1;
    public int FXBlkFix0;
    public int FXBlkFix1;

    public float EXBlkPerF0;
    public float EXBlkPerF1;
    public float EXBlkPerP0;
    public float EXBlkPerP1;
    public float FXBlkPer0;
    public float FXBlkPer1;

    public float EXEvaF0;
    public float EXEvaF1;
    public float EXEvaP0;
    public float EXEvaP1;
    public float FXEva0;
    public float FXEva1;

    public float EXToughF0;
    public float EXToughF1;
    public float EXToughP0;
    public float EXToughP1;
    public float FXTough0;
    public float FXTough1;

    public int EXThornsF0;
    public int EXThornsF1;
    public float EXThornsP0;
    public float EXThornsP1;
    public int FXThorns0;
    public int FXThorns1;

    public float EXMeleeDefF0;
    public float EXMeleeDefF1;
    public float EXMeleeDefP0;
    public float EXMeleeDefP1;
    public float FXMeleeDef0;
    public float FXMeleeDef1;

    public float EXRangeDefF0;
    public float EXRangeDefF1;
    public float EXRangeDefP0;
    public float EXRangeDefP1;
    public float FXRangeDef0;
    public float FXRangeDef1;

    public int EXHpMaxF0;
    public int EXHpMaxF1;
    public float EXHpMaxP0;
    public float EXHpMaxP1;
    public int FXHpMax0;
    public int FXHpMax1;

    public float EXHpRegF0;
    public float EXHpRegF1;
    public float EXHpRegP0;
    public float EXHpRegP1;
    public float FXHpReg0;
    public float FXHpReg1;

    public int EXSpMaxF0;
    public int EXSpMaxF1;
    public float EXSpMaxP0;
    public float EXSpMaxP1;
    public int FXSpMax0;
    public int FXSpMax1;

    public float EXSpRegF0;
    public float EXSpRegF1;
    public float EXSpRegP0;
    public float EXSpRegP1;
    public float FXSpReg0;
    public float FXSpReg1;

    public int EXHpReciFixF0;
    public int EXHpReciFixF1;
    public float EXHpReciFixP0;
    public float EXHpReciFixP1;
    public int FXHpReciFix0;
    public int FXHpReciFix1;

    public float EXHpReciPerF0;
    public float EXHpReciPerF1;
    public float EXHpReciPerP0;
    public float EXHpReciPerP1;
    public float FXHpReciPer0;
    public float FXHpReciPer1;

    public int EXHpHitRegF0;
    public int EXHpHitRegF1;
    public float EXHpHitRegP0;
    public float EXHpHitRegP1;
    public int FXHpHitReg0;
    public int FXHpHitReg1;

    public int EXHpKillRegF0;
    public int EXHpKillRegF1;
    public float EXHpKillRegP0;
    public float EXHpKillRegP1;
    public int FXHpKillReg0;
    public int FXHpKillReg1;

    public int EXSpHitRegF0;
    public int EXSpHitRegF1;
    public float EXSpHitRegP0;
    public float EXSpHitRegP1;
    public int FXSpHitReg0;
    public int FXSpHitReg1;

    public int EXSpKillRegF0;
    public int EXSpKillRegF1;
    public float EXSpKillRegP0;
    public float EXSpKillRegP1;
    public int FXSpKillReg0;
    public int FXSpKillReg1;

    public int EXSpCostHpRegF0;
    public int EXSpCostHpRegF1;
    public float EXSpCostHpRegP0;
    public float EXSpCostHpRegP1;
    public int FXSpCostHpReg0;
    public int FXSpCostHpReg1;

    public float EXSpdF0;
    public float EXSpdF1;
    public float EXSpdP0;
    public float EXSpdP1;
    public float FXSpd0;
    public float FXSpd1;

    public float EXGoldGetF0;
    public float EXGoldGetF1;
    public float EXGoldGetP0;
    public float EXGoldGetP1;
    public float FXGoldGet0;
    public float FXGoldGet1;

    public float EXExpGetF0;
    public float EXExpGetF1;
    public float EXExpGetP0;
    public float EXExpGetP1;
    public float FXExpGet0;
    public float FXExpGet1;

    public float EXItemGetF0;
    public float EXItemGetF1;
    public float EXItemGetP0;
    public float EXItemGetP1;
    public float FXItemGet0;
    public float FXItemGet1;

    public float EXGetRangeF0;
    public float EXGetRangeF1;
    public float EXGetRangeP0;
    public float EXGetRangeP1;
    public float FXGetRange0;
    public float FXGetRange1;

    public float EXFinalDmgBoostF0;
    public float EXFinalDmgBoostF1;
    public float EXFinalDmgBoostP0;
    public float EXFinalDmgBoostP1;
    public float FXFinalDmgBoost0;
    public float FXFinalDmgBoost1;

    public int EXFinalDmgReduceF0;
    public int EXFinalDmgReduceF1;
    public float EXFinalDmgReduceP0;
    public float EXFinalDmgReduceP1;
    public int FXFinalDmgReduce0;
    public int FXFinalDmgReduce1;

    public string Script1;
    public string Script2;
    public string Script3;
    public string Script4;
    public string Script5;
    public string Script6;
}