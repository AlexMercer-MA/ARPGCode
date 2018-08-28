//Made by Alex
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : ItemData
{
    public eSlotType slotType;
    public eEquipmentType equipmentType;

    public int EXStrF;
    public float EXStrP;
    public int FXStr;
    public int EXDexF;
    public float EXDexP;
    public int FXDex;
    public int EXIntF;
    public float EXIntP;
    public int FXInt;
    public int EXSpiF;
    public float EXSpiP;
    public int FXSpi;
    public int EXCunF;
    public float EXCunP;
    public int FXCun;
    public int EXVitF;
    public float EXVitP;
    public int FXVit;

    public int EXPhyMeleeMinF;
    public int EXPhyMeleeMaxF;
    public float EXPhyMeleeP;
    public int FXPhyMelee;

    public int EXPhyRangeMinF;
    public int EXPhyRangeMaxF;
    public float EXPhyRangeP;
    public int FXPhyRange;

    public int EXMgiMinF;
    public int EXMgiMaxF;
    public float EXMgiP;
    public int FXMgi;

    public int EXFireDmgF;
    public float EXFireDmgP;
    public int FXFireDmg;

    public int EXIceDmgF;
    public float EXIceDmgP;
    public int FXIceDmg;

    public int EXLightningDmgF;
    public float EXLightningDmgP;
    public int FXLightningDmg;

    public int EXPoisonDmgF;
    public float EXPoisonDmgP;
    public int FXPoisonDmg;

    public int EXArcaneDmgF;
    public float EXArcaneDmgP;
    public int FXArcaneDmg;

    public int EXShadowDmgF;
    public float EXShadowDmgP;
    public int FXShadowDmg;

    public int EXHolyDmgF;
    public float EXHolyDmgP;
    public int FXHolyDmg;

    public float EXIasF;
    public float EXIasP;
    public float FXIas;

    public float EXCriChaF;
    public float EXCriChaP;
    public float FXCriCha;

    public float EXCriDmgF;
    public float EXCriDmgP;
    public float FXCriDmg;

    public float EXCriPhyMeleeChaF;
    public float EXCriPhyMeleeChaP;
    public float FXCriPhyMeleeCha;

    public float EXCriPhyMeleeDmgF;
    public float EXCriPhyMeleeDmgP;
    public float FXCriPhyMeleeDmg;

    public float EXCriPhyRangeChaF;
    public float EXCriPhyRangeChaP;
    public float FXCriPhyRangeCha;

    public float EXCriPhyRangeDmgF;
    public float EXCriPhyRangeDmgP;
    public float FXCriPhyRangeDmg;

    public float EXCriMgiChaF;
    public float EXCriMgiChaP;
    public float FXCriMgiCha;

    public float EXCriMgiDmgF;
    public float EXCriMgiDmgP;
    public float FXCriMgiDmg;

    public int EXAmrPeneFixF;
    public float EXAmrPeneFixP;
    public int FXAmrPeneFix;

    public float EXAmrPenePerF;
    public float EXAmrPenePerP;
    public float FXAmrPenePer;

    public int EXResPeneFixF;
    public float EXResPeneFixP;
    public int FXResPeneFix;

    public float EXResPenePerF;
    public float EXResPenePerP;
    public float FXResPenePer;

    public float EXCdrF;
    public float EXCdrP;
    public float FXCdr;

    public float EXCsrF;
    public float EXCsrP;
    public float FXCsr;

    public float EXAccF;
    public float EXAccP;
    public float FXAcc;

    public float EXHumanDmgF;
    public float EXHumanDmgP;
    public float FXHumanDmg;

    public float EXBeastDmgF;
    public float EXBeastDmgP;
    public float FXBeastDmg;

    public float EXUndeadDmgF;
    public float EXUndeadDmgP;
    public float FXUndeadDmg;

    public float EXDragonDmgF;
    public float EXDragonDmgP;
    public float FXDragonDmg;

    public float EXDemonDmgF;
    public float EXDemonDmgP;
    public float FXDemonDmg;

    public float EXElementDmgF;
    public float EXElementDmgP;
    public float FXElementDmg;

    public float EXNormalDmgF;
    public float EXNormalDmgP;
    public float FXNormalDmg;

    public float EXEliteDmgF;
    public float EXEliteDmgP;
    public float FXEliteDmg;

    public float EXBossDmgF;
    public float EXBossDmgP;
    public float FXBossDmg;

    public int EXAmrF;
    public float EXAmrP;
    public int FXAmr;

    public int EXResF;
    public float EXResP;
    public int FXRes;

    public int EXFireResF;
    public float EXFireResP;
    public int FXFireRes;

    public int EXIceResF;
    public float EXIceResP;
    public int FXIceRes;

    public int EXLightningResF;
    public float EXLightningResP;
    public int FXLightningRes;

    public int EXPoisonResF;
    public float EXPoisonResP;
    public int FXPoisonRes;

    public int EXShadowResF;
    public float EXShadowResP;
    public int FXShadowRes;

    public int EXHolyResF;
    public float EXHolyResP;
    public int FXHolyRes;

    public int EXArcaneResF;
    public float EXArcaneResP;
    public int FXArcaneRes;

    public float EXBlkChaF;
    public float EXBlkChaP;
    public float FXBlkCha;

    public int EXBlkFixF;
    public float EXBlkFixP;
    public int FXBlkFix;

    public float EXBlkPerF;
    public float EXBlkPerP;
    public float FXBlkPer;

    public float EXEvaF;
    public float EXEvaP;
    public float FXEva;

    public float EXToughF;
    public float EXToughP;
    public float FXTough;

    public int EXThornsF;
    public float EXThornsP;
    public int FXThorns;

    public float EXMeleeDefF;
    public float EXMeleeDefP;
    public float FXMeleeDef;

    public float EXRangeDefF;
    public float EXRangeDefP;
    public float FXRangeDef;

    public int EXHpMaxF;
    public float EXHpMaxP;
    public int FXHpMax;

    public float EXHpRegF;
    public float EXHpRegP;
    public float FXHpReg;

    public int EXSpMaxF;
    public float EXSpMaxP;
    public int FXSpMax;

    public float EXSpRegF;
    public float EXSpRegP;
    public float FXSpReg;

    public int EXHpReciFixF;
    public float EXHpReciFixP;
    public int FXHpReciFix;

    public float EXHpReciPerF;
    public float EXHpReciPerP;
    public float FXHpReciPer;

    public int EXHpHitRegF;
    public float EXHpHitRegP;
    public int FXHpHitReg;

    public int EXHpKillRegF;
    public float EXHpKillRegP;
    public int FXHpKillReg;

    public int EXSpHitRegF;
    public float EXSpHitRegP;
    public int FXSpHitReg;

    public int EXSpKillRegF;
    public float EXSpKillRegP;
    public int FXSpKillReg;

    public int EXSpCostHpRegF;
    public float EXSpCostHpRegP;
    public int FXSpCostHpReg;

    public float EXSpdF;
    public float EXSpdP;
    public float FXSpd;

    public float EXGoldGetF;
    public float EXGoldGetP;
    public float FXGoldGet;

    public float EXExpGetF;
    public float EXExpGetP;
    public float FXExpGet;

    public float EXItemGetF;
    public float EXItemGetP;
    public float FXItemGet;

    public float EXGetRangeF;
    public float EXGetRangeP;
    public float FXGetRange;

    public float EXFinalDmgBoostF;
    public float EXFinalDmgBoostP;
    public float FXFinalDmgBoost;

    public int EXFinalDmgReduceF;
    public float EXFinalDmgReduceP;
    public int FXFinalDmgReduce;

    //public MonoBehaviour Script1;
    //public MonoBehaviour Script2;
    //public MonoBehaviour Script3;
    //public MonoBehaviour Script4;
    //public MonoBehaviour Script5;
    //public MonoBehaviour Script6;

    //传入一个EquipmentModel，生成一个随机的Equipment
    public Equipment(EquipmentModel mod)
    {
        this.ID = mod.ID;
        this.Name = mod.Name;
        this.SubName = mod.SubName;
        this.DesMain = mod.DesMain;
        this.DesTop = mod.DesTop;
        this.DesSpecial = mod.DesSpecial;
        this.DesWarning = mod.DesWarning;
        this.DesStory = mod.DesStory;
        this.IconPath = mod.IconPath;
        this.ItemType = mod.ItemType;
        this.ItemQuality = mod.ItemQuality;
        this.Capacity = mod.Capacity;
        this.SellPrice = mod.SellPrice;
        this.BuyPrice = mod.BuyPrice;

        this.EXStrF = Random.Range(mod.EXStrF0, mod.EXStrF1);
        this.EXStrP = Random.Range(mod.EXStrP0, mod.EXStrP1);
        this.FXStr = Random.Range(mod.FXStr0, mod.FXStr1);

        this.EXDexF = Random.Range(mod.EXDexF0, mod.EXDexF1);
        this.EXDexP = Random.Range(mod.EXDexP0, mod.EXDexP1);
        this.FXDex = Random.Range(mod.FXDex0, mod.FXDex1);

        this.EXIntF = Random.Range(mod.EXIntF0, mod.EXIntF1);
        this.EXIntP = Random.Range(mod.EXIntP0, mod.EXIntP1);
        this.FXInt = Random.Range(mod.FXInt0, mod.FXInt1);

        this.EXSpiF = Random.Range(mod.EXSpiF0, mod.EXSpiF1);
        this.EXSpiP = Random.Range(mod.EXSpiP0, mod.EXSpiP1);
        this.FXSpi = Random.Range(mod.FXSpi0, mod.FXSpi1);

        this.EXCunF = Random.Range(mod.EXCunF0, mod.EXCunF1);
        this.EXCunP = Random.Range(mod.EXCunP0, mod.EXCunP1);
        this.FXCun = Random.Range(mod.FXCun0, mod.FXCun1);

        this.EXVitF = Random.Range(mod.EXVitF0, mod.EXVitF1);
        this.EXVitP = Random.Range(mod.EXVitP0, mod.EXVitP1);
        this.FXVit = Random.Range(mod.FXVit0, mod.FXVit1);

        this.EXPhyMeleeMinF = Random.Range(mod.EXPhyMeleeMinF0, mod.EXPhyMeleeMinF1);
        this.EXPhyMeleeMaxF = Random.Range(mod.EXPhyMeleeMaxF0, mod.EXPhyMeleeMaxF1);
        this.EXPhyMeleeP = Random.Range(mod.EXPhyMeleeP0, mod.EXPhyMeleeP1);
        this.FXPhyMelee = Random.Range(mod.FXPhyMelee0, mod.FXPhyMelee1);

        this.EXPhyRangeMinF = Random.Range(mod.EXPhyRangeMinF0, mod.EXPhyRangeMinF1);
        this.EXPhyRangeMaxF = Random.Range(mod.EXPhyRangeMaxF0, mod.EXPhyRangeMaxF1);
        this.EXPhyRangeP = Random.Range(mod.EXPhyRangeP0, mod.EXPhyRangeP1);
        this.FXPhyRange = Random.Range(mod.FXPhyRange0, mod.FXPhyRange1);

        this.EXMgiMinF = Random.Range(mod.EXMgiMinF0, mod.EXMgiMinF1);
        this.EXMgiMaxF = Random.Range(mod.EXMgiMaxF0, mod.EXMgiMaxF1);
        this.EXMgiP = Random.Range(mod.EXMgiP0, mod.EXMgiP1);
        this.FXMgi = Random.Range(mod.FXMgi0, mod.FXMgi1);

        this.EXFireDmgF = Random.Range(mod.EXFireDmgF0, mod.EXFireDmgF1);
        this.EXFireDmgP = Random.Range(mod.EXFireDmgP0, mod.EXFireDmgP1);
        this.FXFireDmg = Random.Range(mod.FXFireDmg0, mod.FXFireDmg1);

        this.EXIceDmgF = Random.Range(mod.EXIceDmgF0, mod.EXIceDmgF1);
        this.EXIceDmgP = Random.Range(mod.EXIceDmgP0, mod.EXIceDmgP1);
        this.FXIceDmg = Random.Range(mod.FXIceDmg0, mod.FXIceDmg1);

        this.EXLightningDmgF = Random.Range(mod.EXLightningDmgF0, mod.EXLightningDmgF1);
        this.EXLightningDmgP = Random.Range(mod.EXLightningDmgP0, mod.EXLightningDmgP1);
        this.FXLightningDmg = Random.Range(mod.FXLightningDmg0, mod.FXLightningDmg1);

        this.EXPoisonDmgF = Random.Range(mod.EXPoisonDmgF0, mod.EXPoisonDmgF1);
        this.EXPoisonDmgP = Random.Range(mod.EXPoisonDmgP0, mod.EXPoisonDmgP1);
        this.FXPoisonDmg = Random.Range(mod.FXPoisonDmg0, mod.FXPoisonDmg1);

        this.EXArcaneDmgF = Random.Range(mod.EXArcaneDmgF0, mod.EXArcaneDmgF1);
        this.EXArcaneDmgP = Random.Range(mod.EXArcaneDmgP0, mod.EXArcaneDmgP1);
        this.FXArcaneDmg = Random.Range(mod.FXArcaneDmg0, mod.FXArcaneDmg1);

        this.EXShadowDmgF = Random.Range(mod.EXShadowDmgF0, mod.EXShadowDmgF1);
        this.EXShadowDmgP = Random.Range(mod.EXShadowDmgP0, mod.EXShadowDmgP1);
        this.FXShadowDmg = Random.Range(mod.FXShadowDmg0, mod.FXShadowDmg1);

        this.EXHolyDmgF = Random.Range(mod.EXHolyDmgF0, mod.EXHolyDmgF1);
        this.EXHolyDmgP = Random.Range(mod.EXHolyDmgP0, mod.EXHolyDmgP1);
        this.FXHolyDmg = Random.Range(mod.FXHolyDmg0, mod.FXHolyDmg1);
        
        this.EXIasF = Random.Range(mod.EXIasF0, mod.EXIasF1);
        this.EXIasP = Random.Range(mod.EXIasP0, mod.EXIasP1);
        this.FXIas = Random.Range(mod.FXIas0, mod.FXIas1);

        this.EXCriChaF = Random.Range(mod.EXCriChaF0, mod.EXCriChaF1);
        this.EXCriChaP = Random.Range(mod.EXCriChaP0, mod.EXCriChaP1);
        this.FXCriCha = Random.Range(mod.FXCriCha0, mod.FXCriCha1);

        this.EXCriDmgF = Random.Range(mod.EXCriDmgF0, mod.EXCriDmgF1);
        this.EXCriDmgP = Random.Range(mod.EXCriDmgP0, mod.EXCriDmgP1);
        this.FXCriDmg = Random.Range(mod.FXCriDmg0, mod.FXCriDmg1);

        this.EXCriPhyMeleeChaF = Random.Range(mod.EXCriPhyMeleeChaF0, mod.EXCriPhyMeleeChaF1);
        this.EXCriPhyMeleeChaP = Random.Range(mod.EXCriPhyMeleeChaP0, mod.EXCriPhyMeleeChaP1);
        this.FXCriPhyMeleeCha = Random.Range(mod.FXCriPhyMeleeCha0, mod.FXCriPhyMeleeCha1);

        this.EXCriPhyMeleeDmgF = Random.Range(mod.EXCriPhyMeleeDmgF0, mod.EXCriPhyMeleeDmgF1);
        this.EXCriPhyMeleeDmgP = Random.Range(mod.EXCriPhyMeleeDmgP0, mod.EXCriPhyMeleeDmgP1);
        this.FXCriPhyMeleeDmg = Random.Range(mod.FXCriPhyMeleeDmg0, mod.FXCriPhyMeleeDmg1);

        this.EXCriPhyRangeChaF = Random.Range(mod.EXCriPhyRangeChaF0, mod.EXCriPhyRangeChaF1);
        this.EXCriPhyRangeChaP = Random.Range(mod.EXCriPhyRangeChaP0, mod.EXCriPhyRangeChaP1);
        this.FXCriPhyRangeCha = Random.Range(mod.FXCriPhyRangeCha0, mod.FXCriPhyRangeCha1);

        this.EXCriPhyRangeDmgF = Random.Range(mod.EXCriPhyRangeDmgF0, mod.EXCriPhyRangeDmgF1);
        this.EXCriPhyRangeDmgP = Random.Range(mod.EXCriPhyRangeDmgP0, mod.EXCriPhyRangeDmgP1);
        this.FXCriPhyRangeDmg = Random.Range(mod.FXCriPhyRangeDmg0, mod.FXCriPhyRangeDmg1);
        
        this.EXCriMgiChaF = Random.Range(mod.EXCriMgiChaF0, mod.EXCriMgiChaF1);
        this.EXCriMgiChaP = Random.Range(mod.EXCriMgiChaP0, mod.EXCriMgiChaP1);
        this.FXCriMgiCha = Random.Range(mod.FXCriMgiCha0, mod.FXCriMgiCha1);

        this.EXCriMgiDmgF = Random.Range(mod.EXCriMgiDmgF0, mod.EXCriMgiDmgF1);
        this.EXCriMgiDmgP = Random.Range(mod.EXCriMgiDmgP0, mod.EXCriMgiDmgP1);
        this.FXCriMgiDmg = Random.Range(mod.FXCriMgiDmg0, mod.FXCriMgiDmg1);

        this.EXAmrPeneFixF = Random.Range(mod.EXAmrPeneFixF0, mod.EXAmrPeneFixF1);
        this.EXAmrPeneFixP = Random.Range(mod.EXAmrPeneFixP0, mod.EXAmrPeneFixP1);
        this.FXAmrPeneFix = Random.Range(mod.FXAmrPeneFix0, mod.FXAmrPeneFix1);

        this.EXAmrPenePerF = Random.Range(mod.EXAmrPenePerF0, mod.EXAmrPenePerF1);
        this.EXAmrPenePerP = Random.Range(mod.EXAmrPenePerP0, mod.EXAmrPenePerP1);
        this.FXAmrPenePer = Random.Range(mod.FXAmrPenePer0, mod.FXAmrPenePer1);

        this.EXResPeneFixF = Random.Range(mod.EXResPeneFixF0, mod.EXResPeneFixF1);
        this.EXResPeneFixP = Random.Range(mod.EXResPeneFixP0, mod.EXResPeneFixP1);
        this.FXResPeneFix = Random.Range(mod.FXResPeneFix0, mod.FXResPeneFix1);

        this.EXResPenePerF = Random.Range(mod.EXResPenePerF0, mod.EXResPenePerF1);
        this.EXResPenePerP = Random.Range(mod.EXResPenePerP0, mod.EXResPenePerP1);
        this.FXResPenePer = Random.Range(mod.FXResPenePer0, mod.FXResPenePer1);

        this.EXCdrF = Random.Range(mod.EXCdrF0, mod.EXCdrF1);
        this.EXCdrP = Random.Range(mod.EXCdrP0, mod.EXCdrP1);
        this.FXCdr = Random.Range(mod.FXCdr0, mod.FXCdr1);

        this.EXCsrF = Random.Range(mod.EXCsrF0, mod.EXCsrF1);
        this.EXCsrP = Random.Range(mod.EXCsrP0, mod.EXCsrP1);
        this.FXCsr = Random.Range(mod.FXCsr0, mod.FXCsr1);
        
        this.EXAccF = Random.Range(mod.EXAccF0, mod.EXAccF1);
        this.EXAccP = Random.Range(mod.EXAccP0, mod.EXAccP1);
        this.FXAcc = Random.Range(mod.FXAcc0, mod.FXAcc1);

        this.EXHumanDmgF = Random.Range(mod.EXHumanDmgF0, mod.EXHumanDmgF1);
        this.EXHumanDmgP = Random.Range(mod.EXHumanDmgP0, mod.EXHumanDmgP1);
        this.FXHumanDmg = Random.Range(mod.FXHumanDmg0, mod.FXHumanDmg1);

        this.EXBeastDmgF = Random.Range(mod.EXBeastDmgF0, mod.EXBeastDmgF1);
        this.EXBeastDmgP = Random.Range(mod.EXBeastDmgP0, mod.EXBeastDmgP1);
        this.FXBeastDmg = Random.Range(mod.FXBeastDmg0, mod.FXBeastDmg1);
        
        this.EXUndeadDmgF = Random.Range(mod.EXUndeadDmgF0, mod.EXUndeadDmgF1);
        this.EXUndeadDmgP = Random.Range(mod.EXUndeadDmgP0, mod.EXUndeadDmgP1);
        this.FXUndeadDmg = Random.Range(mod.FXUndeadDmg0, mod.FXUndeadDmg1);

        this.EXDragonDmgF = Random.Range(mod.EXDragonDmgF0, mod.EXDragonDmgF1);
        this.EXDragonDmgP = Random.Range(mod.EXDragonDmgP0, mod.EXDragonDmgP1);
        this.FXDragonDmg = Random.Range(mod.FXDragonDmg0, mod.FXDragonDmg1);

        this.EXDemonDmgF = Random.Range(mod.EXDemonDmgF0, mod.EXDemonDmgF1);
        this.EXDemonDmgP = Random.Range(mod.EXDemonDmgP0, mod.EXDemonDmgP1);
        this.FXDemonDmg = Random.Range(mod.FXDemonDmg0, mod.FXDemonDmg1);

        this.EXElementDmgF = Random.Range(mod.EXElementDmgF0, mod.EXElementDmgF1);
        this.EXElementDmgP = Random.Range(mod.EXElementDmgP0, mod.EXElementDmgP1);
        this.FXElementDmg = Random.Range(mod.FXElementDmg0, mod.FXElementDmg1);
        
        this.EXNormalDmgF = Random.Range(mod.EXNormalDmgF0, mod.EXNormalDmgF1);
        this.EXNormalDmgP = Random.Range(mod.EXNormalDmgP0, mod.EXNormalDmgP1);
        this.FXNormalDmg = Random.Range(mod.FXNormalDmg0, mod.FXNormalDmg1);
        
        this.EXEliteDmgF = Random.Range(mod.EXEliteDmgF0, mod.EXEliteDmgF1);
        this.EXEliteDmgP = Random.Range(mod.EXEliteDmgP0, mod.EXEliteDmgP1);
        this.FXEliteDmg = Random.Range(mod.FXEliteDmg0, mod.FXEliteDmg1);

        this.EXBossDmgF = Random.Range(mod.EXBossDmgF0, mod.EXBossDmgF1);
        this.EXBossDmgP = Random.Range(mod.EXBossDmgP0, mod.EXBossDmgP1);
        this.FXBossDmg = Random.Range(mod.FXBossDmg0, mod.FXBossDmg1);

        this.EXAmrF = Random.Range(mod.EXAmrF0, mod.EXAmrF1);
        this.EXAmrP = Random.Range(mod.EXAmrP0, mod.EXAmrP1);
        this.FXAmr = Random.Range(mod.FXAmr0, mod.FXAmr1);
        
        this.EXResF = Random.Range(mod.EXResF0, mod.EXResF1);
        this.EXResP = Random.Range(mod.EXResP0, mod.EXResP1);
        this.FXRes = Random.Range(mod.FXRes0, mod.FXRes1);
        
        this.EXFireResF = Random.Range(mod.EXFireResF0, mod.EXFireResF1);
        this.EXFireResP = Random.Range(mod.EXFireResP0, mod.EXFireResP1);
        this.FXFireRes = Random.Range(mod.FXFireRes0, mod.FXFireRes1);

        this.EXIceResF = Random.Range(mod.EXIceResF0, mod.EXIceResF1);
        this.EXIceResP = Random.Range(mod.EXIceResP0, mod.EXIceResP1);
        this.FXIceRes = Random.Range(mod.FXIceRes0, mod.FXIceRes1);

        this.EXLightningResF = Random.Range(mod.EXLightningResF0, mod.EXLightningResF1);
        this.EXLightningResP = Random.Range(mod.EXLightningResP0, mod.EXLightningResP1);
        this.FXLightningRes = Random.Range(mod.FXLightningRes0, mod.FXLightningRes1);

        this.EXPoisonResF = Random.Range(mod.EXPoisonResF0, mod.EXPoisonResF1);
        this.EXPoisonResP = Random.Range(mod.EXPoisonResP0, mod.EXPoisonResP1);
        this.FXPoisonRes = Random.Range(mod.FXPoisonRes0, mod.FXPoisonRes1);

        this.EXArcaneResF = Random.Range(mod.EXArcaneResF0, mod.EXArcaneResF1);
        this.EXArcaneResP = Random.Range(mod.EXArcaneResP0, mod.EXArcaneResP1);
        this.FXArcaneRes = Random.Range(mod.FXArcaneRes0, mod.FXArcaneRes1);

        this.EXShadowResF = Random.Range(mod.EXShadowResF0, mod.EXShadowResF1);
        this.EXShadowResP = Random.Range(mod.EXShadowResP0, mod.EXShadowResP1);
        this.FXShadowRes = Random.Range(mod.FXShadowRes0, mod.FXShadowRes1);

        this.EXHolyResF = Random.Range(mod.EXHolyResF0, mod.EXHolyResF1);
        this.EXHolyResP = Random.Range(mod.EXHolyResP0, mod.EXHolyResP1);
        this.FXHolyRes = Random.Range(mod.FXHolyRes0, mod.FXHolyRes1);

        this.EXBlkChaF = Random.Range(mod.EXBlkChaF0, mod.EXBlkChaF1);
        this.EXBlkChaP = Random.Range(mod.EXBlkChaP0, mod.EXBlkChaP1);
        this.FXBlkCha = Random.Range(mod.FXBlkCha0, mod.FXBlkCha1);

        this.EXBlkFixF = Random.Range(mod.EXBlkFixF0, mod.EXBlkFixF1);
        this.EXBlkFixP = Random.Range(mod.EXBlkFixP0, mod.EXBlkFixP1);
        this.FXBlkFix = Random.Range(mod.FXBlkFix0, mod.FXBlkFix1);

        this.EXBlkPerF = Random.Range(mod.EXBlkPerF0, mod.EXBlkPerF1);
        this.EXBlkPerP = Random.Range(mod.EXBlkPerP0, mod.EXBlkPerP1);
        this.FXBlkPer = Random.Range(mod.FXBlkPer0, mod.FXBlkPer1);

        this.EXEvaF = Random.Range(mod.EXEvaF0, mod.EXEvaF1);
        this.EXEvaP = Random.Range(mod.EXEvaP0, mod.EXEvaP1);
        this.FXEva = Random.Range(mod.FXEva0, mod.FXEva1);
        
        this.EXToughF = Random.Range(mod.EXToughF0, mod.EXToughF1);
        this.EXToughP = Random.Range(mod.EXToughP0, mod.EXToughP1);
        this.FXTough = Random.Range(mod.FXTough0, mod.FXTough1);
        
        this.EXThornsF = Random.Range(mod.EXThornsF0, mod.EXThornsF1);
        this.EXThornsP = Random.Range(mod.EXThornsP0, mod.EXThornsP1);
        this.FXThorns = Random.Range(mod.FXThorns0, mod.FXThorns1);

        this.EXMeleeDefF = Random.Range(mod.EXMeleeDefF0, mod.EXMeleeDefF1);
        this.EXMeleeDefP = Random.Range(mod.EXMeleeDefP0, mod.EXMeleeDefP1);
        this.FXMeleeDef = Random.Range(mod.FXMeleeDef0, mod.FXMeleeDef1);

        this.EXRangeDefF = Random.Range(mod.EXRangeDefF0, mod.EXRangeDefF1);
        this.EXRangeDefP = Random.Range(mod.EXRangeDefP0, mod.EXRangeDefP1);
        this.FXRangeDef = Random.Range(mod.FXRangeDef0, mod.FXRangeDef1);

        this.EXHpMaxF = Random.Range(mod.EXHpMaxF0, mod.EXHpMaxF1);
        this.EXHpMaxP = Random.Range(mod.EXHpMaxP0, mod.EXHpMaxP1);
        this.FXHpMax = Random.Range(mod.FXHpMax0, mod.FXHpMax1);

        this.EXHpRegF = Random.Range(mod.EXHpRegF0, mod.EXHpRegF1);
        this.EXHpRegP = Random.Range(mod.EXHpRegP0, mod.EXHpRegP1);
        this.FXHpReg = Random.Range(mod.FXHpReg0, mod.FXHpReg1);

        this.EXSpMaxF = Random.Range(mod.EXSpMaxF0, mod.EXSpMaxF1);
        this.EXSpMaxP = Random.Range(mod.EXSpMaxP0, mod.EXSpMaxP1);
        this.FXSpMax = Random.Range(mod.FXSpMax0, mod.FXSpMax1);

        this.EXSpRegF = Random.Range(mod.EXSpRegF0, mod.EXSpRegF1);
        this.EXSpRegP = Random.Range(mod.EXSpRegP0, mod.EXSpRegP1);
        this.FXSpReg = Random.Range(mod.FXSpReg0, mod.FXSpReg1);


        this.EXHpReciFixF = Random.Range(mod.EXHpReciFixF0, mod.EXHpReciFixF1);
        this.EXHpReciFixP = Random.Range(mod.EXHpReciFixP0, mod.EXHpReciFixP1);
        this.FXHpReciFix = Random.Range(mod.FXHpReciFix0, mod.FXHpReciFix1);
        
        this.EXHpReciPerF = Random.Range(mod.EXHpReciPerF0, mod.EXHpReciPerF1);
        this.EXHpReciPerP = Random.Range(mod.EXHpReciPerP0, mod.EXHpReciPerP1);
        this.FXHpReciPer = Random.Range(mod.FXHpReciPer0, mod.FXHpReciPer1);

        this.EXHpHitRegF = Random.Range(mod.EXHpHitRegF0, mod.EXHpHitRegF1);
        this.EXHpHitRegP = Random.Range(mod.EXHpHitRegP0, mod.EXHpHitRegP1);
        this.FXHpHitReg = Random.Range(mod.FXHpHitReg0, mod.FXHpHitReg1);

        this.EXHpKillRegF = Random.Range(mod.EXHpKillRegF0, mod.EXHpKillRegF1);
        this.EXHpKillRegP = Random.Range(mod.EXHpKillRegP0, mod.EXHpKillRegP1);
        this.FXHpKillReg = Random.Range(mod.FXHpKillReg0, mod.FXHpKillReg1);

        this.EXSpHitRegF = Random.Range(mod.EXSpHitRegF0, mod.EXSpHitRegF1);
        this.EXSpHitRegP = Random.Range(mod.EXSpHitRegP0, mod.EXSpHitRegP1);
        this.FXSpHitReg = Random.Range(mod.FXSpHitReg0, mod.FXSpHitReg1);

        this.EXSpKillRegF = Random.Range(mod.EXSpKillRegF0, mod.EXSpKillRegF1);
        this.EXSpKillRegP = Random.Range(mod.EXSpKillRegP0, mod.EXSpKillRegP1);
        this.FXSpKillReg = Random.Range(mod.FXSpKillReg0, mod.FXSpKillReg1);

        this.EXSpCostHpRegF = Random.Range(mod.EXSpCostHpRegF0, mod.EXSpCostHpRegF1);
        this.EXSpCostHpRegP = Random.Range(mod.EXSpCostHpRegP0, mod.EXSpCostHpRegP1);
        this.FXSpCostHpReg = Random.Range(mod.FXSpCostHpReg0, mod.FXSpCostHpReg1);

        this.EXSpdF = Random.Range(mod.EXSpdF0, mod.EXSpdF1);
        this.EXSpdP = Random.Range(mod.EXSpdP0, mod.EXSpdP1);
        this.FXSpd = Random.Range(mod.FXSpd0, mod.FXSpd1);

        this.EXGoldGetF = Random.Range(mod.EXGoldGetF0, mod.EXGoldGetF1);
        this.EXGoldGetP = Random.Range(mod.EXGoldGetP0, mod.EXGoldGetP1);
        this.FXGoldGet = Random.Range(mod.FXGoldGet0, mod.FXGoldGet1);

        this.EXExpGetF = Random.Range(mod.EXExpGetF0, mod.EXExpGetF1);
        this.EXExpGetP = Random.Range(mod.EXExpGetP0, mod.EXExpGetP1);
        this.FXExpGet = Random.Range(mod.FXExpGet0, mod.FXExpGet1);

        this.EXItemGetF = Random.Range(mod.EXItemGetF0, mod.EXItemGetF1);
        this.EXItemGetP = Random.Range(mod.EXItemGetP0, mod.EXItemGetP1);
        this.FXItemGet = Random.Range(mod.FXItemGet0, mod.FXItemGet1);

        this.EXGetRangeF = Random.Range(mod.EXGetRangeF0, mod.EXGetRangeF1);
        this.EXGetRangeP = Random.Range(mod.EXGetRangeP0, mod.EXGetRangeP1);
        this.FXGetRange = Random.Range(mod.FXGetRange0, mod.FXGetRange1);

        this.EXFinalDmgBoostF = Random.Range(mod.EXFinalDmgBoostF0, mod.EXFinalDmgBoostF1);
        this.EXFinalDmgBoostP = Random.Range(mod.EXFinalDmgBoostP0, mod.EXFinalDmgBoostP1);
        this.FXFinalDmgBoost = Random.Range(mod.FXFinalDmgBoost0, mod.FXFinalDmgBoost1);

        this.EXFinalDmgReduceF = Random.Range(mod.EXFinalDmgReduceF0, mod.EXFinalDmgReduceF1);
        this.EXFinalDmgReduceP = Random.Range(mod.EXFinalDmgReduceP0, mod.EXFinalDmgReduceP1);
        this.FXFinalDmgReduce = Random.Range(mod.FXFinalDmgReduce0, mod.FXFinalDmgReduce1);

        //this.Script1 = mod.Script1;
        //this.Script2 = mod.Script2;
        //this.Script3 = mod.Script3;
        //this.Script4 = mod.Script4;
        //this.Script5 = mod.Script5;
        //this.Script6 = mod.Script6;
    }
}
