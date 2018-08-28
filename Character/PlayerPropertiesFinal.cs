using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Guirao.UltimateTextDamage;

//角色最终属性脚本：游戏中的所有涉及数值的信息都从PlayerPropertiesFinal获得
//修改时机：帧刷新

public class PlayerPropertiesFinal : MonoBehaviour
{
    public static PlayerPropertiesFinal GetInstance { get; set; }
    public CharacterBehaviour characterBehaviour;
    public CharacterAction characterAttack;
    public UltimateTextDamageManager textManager;
    public PlayerPropertiesBase b;
    public PlayerPropertiesExtra e;
    public uint DoCheckProperties = 0;

    void Awake()
    {
        GetInstance = this;
    }

    void Start()
    {
        //CheckProperties ();
        FullHP();
        FullSP();
        b = PlayerPropertiesBase.GetInstance;
        e = PlayerPropertiesExtra.GetInstance;
    }

    void Update()
    {
        if (DoCheckProperties > 0)
        {
            CheckProperties();//需要时检查
        }
        else
        {
            CheckProperties();//临时
        }
        //每一帧检查
        FrameCheck();
        //归零
        DoCheckProperties = 0;
    }

    //基础属性
    public bool IsDead { get; set; }//是否死亡

    //主属性 属性最低为1
    public int Str { get { return Mathf.Clamp(_str, 1, _str); } set { _str = value; } }//力量
    public int _str;
    public int Dex { get { return Mathf.Clamp(_dex, 1, _dex); } set { _dex = value; } }//敏捷
    public int _dex;
    public int Int { get { return Mathf.Clamp(_int, 1, _int); } set { _int = value; } }//智力
    public int _int;
    public int Spi { get { return Mathf.Clamp(_spi, 1, _spi); } set { _spi = value; } }//精神
    public int _spi;
    public int Cun { get { return Mathf.Clamp(_cun, 1, _cun); } set { _cun = value; } }//诡诈
    public int _cun;
    public int Vit { get { return Mathf.Clamp(_vit, 1, _vit); } set { _vit = value; } }//耐力
    public int _vit;

    //攻击属性 物理伤害
    public int BasePhyMeleeMax { get { return Mathf.Clamp(_basePhyMeleeMax, 1, _basePhyMeleeMax); } set { _basePhyMeleeMax = value; } }
    public int _basePhyMeleeMax;
    public int BasePhyMeleeMin { get { return Mathf.Clamp(_basePhyMeleeMin, 1, BasePhyMeleeMax); } set { _basePhyMeleeMin = value; } }//最小值不能超过最大值，所以优先计算最大值，再计算最小值
    public int _basePhyMeleeMin;
    public int BasePhyMelee { get { return Mathf.Clamp(_baseMeleePhy, 1, _baseMeleePhy); } set { _baseMeleePhy = value; } }
    public int _baseMeleePhy;

    public int BasePhyRangeMax { get { return Mathf.Clamp(_basePhyRangeMax, 1, _basePhyRangeMax); } set { _basePhyRangeMax = value; } }
    public int _basePhyRangeMax;
    public int BasePhyRangeMin { get { return Mathf.Clamp(_basePhyRangeMin, 1, BasePhyRangeMax); } set { _basePhyRangeMin = value; } }//最小值不能超过最大值，所以优先计算最大值，再计算最小值
    public int _basePhyRangeMin;
    public int BasePhyRange { get { return Mathf.Clamp(_baseRangePhy, 1, _baseRangePhy); } set { _baseRangePhy = value; } }
    public int _baseRangePhy;

    public int PhyMeleeMax { get { return Mathf.Clamp(_phyMeleeMax, 1, _phyMeleeMax); } set { _phyMeleeMax = value; } }
    public int _phyMeleeMax;
    public int PhyMeleeMin { get { return Mathf.Clamp(_phyMeleeMin, 1, _phyMeleeMin); } set { _phyMeleeMin = value; } }//最小值不能超过最大值，所以优先计算最大值，再计算最小值
    public int _phyMeleeMin;
    public int PhyMelee { get { return Mathf.Clamp(_PhyMelee, 1, _PhyMelee); } set { _PhyMelee = value; } }
    public int _PhyMelee;

    public int PhyRangeMax { get { return Mathf.Clamp(_phyRangeMax, 1, _phyRangeMax); } set { _phyRangeMax = value; } }
    public int _phyRangeMax;
    public int PhyRangeMin { get { return Mathf.Clamp(_phyRangeMin, 1, _phyRangeMin); } set { _phyRangeMin = value; } }//最小值不能超过最大值，所以优先计算最大值，再计算最小值
    public int _phyRangeMin;
    public int PhyRange { get { return Mathf.Clamp(_PhyRange, 1, _PhyRange); } set { _PhyRange = value; } }
    public int _PhyRange;

    //攻击属性 魔法伤害
    public int BaseMgiMax { get { return Mathf.Clamp(_baseMgiMax, 1, _baseMgiMax); } set { _baseMgiMax = value; } }
    public int _baseMgiMax;
    public int BaseMgiMin { get { return Mathf.Clamp(_baseMgiMin, 1, BaseMgiMax); } set { _baseMgiMin = value; } }//最小值不能超过最大值，所以优先计算最大值，再计算最小值
    public int _baseMgiMin;
    public int BaseMgi { get { return Mathf.Clamp(_baseMgi, 1, _baseMgi); } set { _baseMgi = value; } }
    public int _baseMgi;

    public int MgiMax { get { return Mathf.Clamp(_mgiMax, 1, _mgiMax); } set { _mgiMax = value; } }
    public int _mgiMax;
    public int MgiMin { get { return Mathf.Clamp(_mgiMin, 1, _mgiMin); } set { _mgiMin = value; } }//最小值不能超过最大值，所以优先计算最大值，再计算最小值
    public int _mgiMin;
    public int Mgi { get { return Mathf.Clamp(_mgi, 1, _mgi); } set { _mgi = value; } }
    public int _mgi;

    //攻击属性 元素伤害 是【魔法伤害】的子类
    public int FireDmgMax { get { return Mathf.Clamp(_fireDmgMax, 1, _fireDmgMax); } set { _fireDmgMax = value; } }
    public int _fireDmgMax;
    public int FireDmgMin { get { return Mathf.Clamp(_fireDmgMin, 1, _fireDmgMin); } set { _fireDmgMin = value; } }
    public int _fireDmgMin;
    public int IceDmgMax { get { return Mathf.Clamp(_iceDmgMax, 1, _iceDmgMax); } set { _iceDmgMax = value; } }
    public int _iceDmgMax;
    public int IceDmgMin { get { return Mathf.Clamp(_iceDmgMin, 1, _iceDmgMin); } set { _iceDmgMin = value; } }
    public int _iceDmgMin;
    public int LightningDmgMax { get { return Mathf.Clamp(_lightningDmgMax, 1, _lightningDmgMax); } set { _lightningDmgMax = value; } }
    public int _lightningDmgMax;
    public int LightningDmgMin { get { return Mathf.Clamp(_lightningDmgMin, 1, _lightningDmgMin); } set { _lightningDmgMin = value; } }
    public int _lightningDmgMin;
    public int PoisonDmgMax { get { return Mathf.Clamp(_poisonDmgMax, 1, _poisonDmgMax); } set { _poisonDmgMax = value; } }
    public int _poisonDmgMax;
    public int PoisonDmgMin { get { return Mathf.Clamp(_poisonDmgMin, 1, _poisonDmgMin); } set { _poisonDmgMin = value; } }
    public int _poisonDmgMin;
    public int ArcaneDmgMax { get { return Mathf.Clamp(_arcaneDmgMax, 1, _arcaneDmgMax); } set { _arcaneDmgMax = value; } }
    public int _arcaneDmgMax;
    public int ArcaneDmgMin { get { return Mathf.Clamp(_arcaneDmgMin, 1, _arcaneDmgMin); } set { _arcaneDmgMin = value; } }
    public int _arcaneDmgMin;
    public int ShadowDmgMax { get { return Mathf.Clamp(_shadowDmgMax, 1, _shadowDmgMax); } set { _shadowDmgMax = value; } }
    public int _shadowDmgMax;
    public int ShadowDmgMin { get { return Mathf.Clamp(_shadowDmgMin, 1, _shadowDmgMin); } set { _shadowDmgMin = value; } }
    public int _shadowDmgMin;
    public int HolyDmgMax { get { return Mathf.Clamp(_holyDmgMax, 1, _holyDmgMax); } set { _holyDmgMax = value; } }
    public int _holyDmgMax;
    public int HolyDmgMin { get { return Mathf.Clamp(_holyDmgMin, 1, _holyDmgMin); } set { _holyDmgMin = value; } }
    public int _holyDmgMin;

    //进攻属性 攻击速度
    public float Ias { get { return Mathf.Clamp(_ias, 0.1f, 4.0f); } set { _ias = value; } }
    public float _ias;

    //进攻属性 暴击爆伤
    public float CriCha { get { return Mathf.Clamp(_criCha, 0.0f, _criCha); } set { _criCha = value; } }
    public float _criCha;
    public float CriDmg { get { return Mathf.Clamp(_criDmg, 0.0f, _criDmg); } set { _criDmg = value; } }
    public float _criDmg;

    public float CriPhyMeleeCha { get { return Mathf.Clamp(_criPhyMeleeCha, 0.0f, _criPhyMeleeCha); } set { _criPhyMeleeCha = value; } }
    public float _criPhyMeleeCha;
    public float CriPhyMeleeDmg { get { return Mathf.Clamp(_criPhyMeleeDmg, 0.0f, _criPhyMeleeDmg); } set { _criPhyMeleeDmg = value; } }
    public float _criPhyMeleeDmg;

    public float CriPhyRangeCha { get { return Mathf.Clamp(_criPhyRangeCha, 0.0f, _criPhyRangeCha); } set { _criPhyRangeCha = value; } }
    public float _criPhyRangeCha;
    public float CriPhyRangeDmg { get { return Mathf.Clamp(_criPhyRangeDmg, 0.0f, _criPhyRangeDmg); } set { _criPhyRangeDmg = value; } }
    public float _criPhyRangeDmg;

    public float CriMgiCha { get { return Mathf.Clamp(_criMgiCha, 0.0f, _criMgiCha); } set { _criMgiCha = value; } }
    public float _criMgiCha;
    public float CriMgiDmg { get { return Mathf.Clamp(_criMgiDmg, 0.0f, _criMgiDmg); } set { _criMgiDmg = value; } }
    public float _criMgiDmg;

    //进攻属性 护甲穿透，抗性穿透
    public int AmrPeneFix { get { return Mathf.Clamp(_amrPeneFix, 0, _amrPeneFix); } set { _amrPeneFix = value; } }
    public int _amrPeneFix;
    public float AmrPenePer { get { return Mathf.Clamp(_amrPenePer, 0.0f, _amrPenePer); } set { _amrPenePer = value; } }
    public float _amrPenePer;
    public int ResPeneFix { get { return Mathf.Clamp(_resPeneFix, 0, _resPeneFix); } set { _resPeneFix = value; } }
    public int _resPeneFix;
    public float ResPenePer { get { return Mathf.Clamp(_resPenePer, 0.0f, _resPenePer); } set { _resPenePer = value; } }
    public float _resPenePer;

    //进攻属性 其他（减冷却，减耗，精准）
    public float Cdr { get { return Mathf.Clamp(_cdr, 0.0f, 1.0f); } set { _cdr = value; } }//CDR上限100%
    public float _cdr;
    public float Csr { get { return Mathf.Clamp(_csr, 0.0f, 1.0f); } set { _csr = value; } }//减耗上限100%
    public float _csr;
    public float Acc { get { return _acc; } set { _acc = value; } }//精准可以为负
    public float _acc;

    //进攻属性 歧视伤害 生物类型
    public float HumanDmg { get { return Mathf.Clamp(_HumanDmg, 0.0f, _HumanDmg); } set { _HumanDmg = value; } }//人形生物增伤
    public float _HumanDmg;
    public float BeastDmg { get { return Mathf.Clamp(_BeastDmg, 0.0f, _BeastDmg); } set { _BeastDmg = value; } }//野兽增伤
    public float _BeastDmg;
    public float UndeadDmg { get { return Mathf.Clamp(_UndeadDmg, 0.0f, _UndeadDmg); } set { _UndeadDmg = value; } }//亡灵增伤
    public float _UndeadDmg;
    public float DragonDmg { get { return Mathf.Clamp(_DragonDmg, 0.0f, _DragonDmg); } set { _DragonDmg = value; } }//龙类增伤
    public float _DragonDmg;
    public float DemonDmg { get { return Mathf.Clamp(_DemonDmg, 0.0f, _DemonDmg); } set { _DemonDmg = value; } }//恶魔增伤
    public float _DemonDmg;
    public float ElementDmg { get { return Mathf.Clamp(_ElementDmg, 0.0f, _ElementDmg); } set { _ElementDmg = value; } }//元素生物增伤
    public float _ElementDmg;

    //进攻属性 歧视伤害 怪物级别
    public float NormalDmg { get { return Mathf.Clamp(_NormalDmg, 0.0f, _NormalDmg); } set { _NormalDmg = value; } }//普通怪物增伤
    public float _NormalDmg;
    public float EliteDmg { get { return Mathf.Clamp(_EliteDmg, 0.0f, _EliteDmg); } set { _EliteDmg = value; } }//精英怪物增伤
    public float _EliteDmg;
    public float BossDmg { get { return Mathf.Clamp(_BossDmg, 0.0f, _BossDmg); } set { _BossDmg = value; } }//首领怪物增伤
    public float _BossDmg;

    //防御属性 护甲魔抗
    public int Amr { get { return _amr; } set { _amr = value; } }
    public int _amr;
    public int Res { get { return _res; } set { _res = value; } }
    public int _res;

    //防御属性 元素抗性 减伤同x/x+100公式
    public int FireRes { get; set; }
    public int IceRes { get; set; }
    public int LightningRes { get; set; }
    public int PoisonRes { get; set; }
    public int ArcaneRes { get; set; }
    public int ShadowRes { get; set; }
    public int HolyRes { get; set; }

    //防御属性 其他（格挡，闪避，坚韧，荆棘）
    public float BlkCha { get { return _blkCha; } set { _blkCha = value; } }
    public float _blkCha;
    public int BlkFix { get { return _blkFix; } set { _blkFix = value; } }
    public int _blkFix;
    public float BlkPer { get { return _blkPer; } set { _blkPer = value; } }
    public float _blkPer;
    public float Eva { get { return _eva; } set { _eva = value; } }
    public float _eva;
    public float Tough { get { return _tough; } set { _tough = value; } }
    public float _tough;
    public int Thorns { get { return _thorns; } set { _thorns = value; } }
    public int _thorns;

    //防御属性 歧视减伤 近战远程
    public float MeleeDmgReduce { get { return _meleeDef; } set { _meleeDef = value; } }
    public float _meleeDef;
    public float RangeDmgReduce { get { return _rangeDef; } set { _rangeDef = value; } }
    public float _rangeDef;

    //护盾
    //护盾值最大值Int类型【状态量】,【优先计算】
    public int SdMaxInt { get { return Mathf.RoundToInt(_SdMax); } set { _SdMax = value; } }
    public float _SdMax;
    //护盾值Int类型【状态量】,在 护盾值最大值Int类型 之后计算
    public int SdInt { get { return Mathf.Clamp(Mathf.RoundToInt(_Sd), 0, SdMaxInt); } set { _Sd = value; } }
    public float _Sd;
    public bool have_Sd;//是否有护盾,【状态量】,在 护盾能量值 之后计算

    //生命与能量
    //生命属性值【优先计算】
    public int HpMax { get { return Mathf.Clamp(_hpMax, 1, _hpMax); } set { _hpMax = value; } }
    public int _hpMax;
    public float HpReg { get { return _hpReg; } set { _hpReg = value; } }
    public float _hpReg;
    //生命状态值
    public float Hp { get { return Mathf.Clamp(_hp, 0.0f, HpMax); } set { _hp = value; } }
    public float _hp;
    public int Hp_Int;

    //能量属性值【优先计算】
    public int SpMax { get { return Mathf.Clamp(_spMax, 0, _spMax); } set { _spMax = value; } }
    public int _spMax;
    public float SpReg { get { return _spReg; } set { _spReg = value; } }
    public float _spReg;
    //能量状态值
    public float Sp { get { return Mathf.Clamp(_sp, 0.0f, SpMax); } set { _sp = value; } }
    public float _sp;
    public int Sp_Int;

    //受治疗固定数值加成（技能，药剂和神符）
    public int HpReciFix { get { return _hpReciFix; } set { _hpReciFix = value; } }
    public int _hpReciFix;
    //受治疗百分比加成（技能，药剂和神符）
    public float HpReciPer { get { return Mathf.Clamp(_hpReciPer, 0.0f, _hpReciPer); } set { _hpReciPer = value; } }
    public float _hpReciPer;

    //击中生命回复
    public int HpHitReg { get { return Mathf.Clamp(_hpHitReg, 0, _hpHitReg); } set { _hpHitReg = value; } }
    public int _hpHitReg;
    //击杀生命回复
    public int HpKillReg { get { return Mathf.Clamp(_hpKillReg, 0, _hpKillReg); } set { _hpKillReg = value; } }
    public int _hpKillReg;

    //击中能量回复
    public int SpHitReg { get { return Mathf.Clamp(_spHitReg, 0, _spHitReg); } set { _spHitReg = value; } }
    public int _spHitReg;
    //击杀能量回复
    public int SpKillReg { get { return Mathf.Clamp(_spKillReg, 0, _spKillReg); } set { _spKillReg = value; } }
    public int _spKillReg;
    //消耗每点能量回复生命
    public float HpRegPerSpCost { get { return Mathf.Clamp(_spCostHpReg, 0.0f, _spCostHpReg); } set { _spCostHpReg = value; } }
    public float _spCostHpReg;
    
    //冒险属性
    public float Spd { get { return Mathf.Clamp(_spd, GameProperties.GetInstance.minMoveSpeed, _spd); } set { _spd = value; } }//移动速度有最小值
    public float _spd;
    public float GoldGet { get { return Mathf.Clamp(_goldGet, 0.0f, _goldGet); } set { _goldGet = value; } }
    public float _goldGet;
    public float ExpGet { get { return Mathf.Clamp(_expGet, 0.0f, _expGet); } set { _expGet = value; } }
    public float _expGet;
    public float ItemGet { get { return Mathf.Clamp(_itemGet, 0.0f, _itemGet); } set { _itemGet = value; } }
    public float _itemGet;
    public float GetRange { get { return Mathf.Clamp(_getRange, 0.1f, _getRange); } set { _getRange = value; } }//拾取距离最小为【0.1】
    public float _getRange;

    //全局
    //全局独立增伤
    public float FinalDmgBoost { get { return Mathf.Clamp(_FinalDmgBoost, 0.0f, _FinalDmgBoost); } set { _FinalDmgBoost = value; } }
    public float _FinalDmgBoost;
    //全局独立减伤
    public float FinalDmgReduce { get { return Mathf.Clamp(_FinalDmgReduce, 0.0f, _FinalDmgReduce); } set { _FinalDmgReduce = value; } }
    public float _FinalDmgReduce;

    //帧更新数据（也可改为按时间高频更新,真正需要帧更新的只有HP，SP）
    public void FrameCheck()
    {
        //这里只有是否有护盾值，护盾值的改变条件有【特殊处理】，多半写在增加护盾的技能中，改变SdMaxInt的同时改变SdInt
        have_Sd = (SdInt > 0) ? true : false;

        Hp_Int = Mathf.CeilToInt(Hp);
        Sp_Int = Mathf.RoundToInt(Sp);
        CheckDead();

        if (!IsDead)
        {
            Hp += HpReg * Time.deltaTime;
            Sp += SpReg * Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                //SceneSetting.GetInstance.LoadScene("DownTown", 1f);
                SceneManager.LoadScene("DownTown", LoadSceneMode.Single);
            }
        }
    }


    //特定时机更新，通过投票
    public void CheckProperties()
    {

        //先计算六大属性--------------------------------------------------------------------------------------------------------------------------
        Str = Mathf.RoundToInt((b.Str + e.EXStrF) * (1 + e.EXStrP) + e.FXStr);
        Dex = Mathf.RoundToInt((b.Dex + e.EXDexF) * (1 + e.EXDexP) + e.FXDex);
        Int = Mathf.RoundToInt((b.Int + e.EXIntF) * (1 + e.EXIntP) + e.FXInt);
        Spi = Mathf.RoundToInt((b.Spi + e.EXSpiF) * (1 + e.EXSpiP) + e.FXSpi);
        Cun = Mathf.RoundToInt((b.Cun + e.EXCunF) * (1 + e.EXCunP) + e.FXCun);
        Vit = Mathf.RoundToInt((b.Vit + e.EXVitF) * (1 + e.EXVitP) + e.FXVit);
        
        //攻击--------------------------------------------------------------------------------------------------------------------------

        //物理攻击近战
        BasePhyMeleeMax = Mathf.RoundToInt(b.PhyMeleeMax + Str * GameProperties.GetInstance.Phy_Melee_PerStr + Dex * GameProperties.GetInstance.Phy_Melee_Per_Dex);
        BasePhyMeleeMin = Mathf.RoundToInt(b.PhyMeleeMin + Str * GameProperties.GetInstance.Phy_Melee_PerStr + Dex * GameProperties.GetInstance.Phy_Melee_Per_Dex);
        BasePhyMelee = Mathf.RoundToInt(0.5f * (BasePhyMeleeMax + BasePhyMeleeMin));

        PhyMeleeMax = Mathf.RoundToInt((BasePhyMeleeMax + e.EXPhyMeleeMaxF) * (1 + e.EXPhyMeleeP) + e.FXPhyMelee);
        PhyMeleeMin = Mathf.RoundToInt((BasePhyMeleeMin + e.EXPhyMeleeMinF) * (1 + e.EXPhyMeleeP) + e.FXPhyMelee);
        PhyMelee = Mathf.RoundToInt(0.5f * (PhyMeleeMax + PhyMeleeMin));

        //物理攻击远程
        BasePhyRangeMax = Mathf.RoundToInt(b.PhyRangeMax + Str * GameProperties.GetInstance.Phy_Range_PerStr + Dex * GameProperties.GetInstance.Phy_Range_Per_Dex);
        BasePhyRangeMin = Mathf.RoundToInt(b.PhyRangeMin + Str * GameProperties.GetInstance.Phy_Range_PerStr + Dex * GameProperties.GetInstance.Phy_Range_Per_Dex);
        BasePhyRange = Mathf.RoundToInt(0.5f * (BasePhyRangeMax + BasePhyRangeMin));

        PhyRangeMax = Mathf.RoundToInt((BasePhyRangeMax + e.EXPhyRangeMaxF) * (1 + e.EXPhyRangeP) + e.FXPhyRange);
        PhyRangeMin = Mathf.RoundToInt((BasePhyRangeMin + e.EXPhyRangeMinF) * (1 + e.EXPhyRangeP) + e.FXPhyRange);
        PhyRange = Mathf.RoundToInt(0.5f * (PhyRangeMax + PhyRangeMin));

        //基础魔法攻击
        BaseMgiMax = Mathf.RoundToInt(b.MgiMax + Int * GameProperties.GetInstance.Mgi_Per_Int);
        BaseMgiMin = Mathf.RoundToInt(b.MgiMin + Int * GameProperties.GetInstance.Mgi_Per_Int);
        BaseMgi = Mathf.RoundToInt(0.5f * (BaseMgiMax + BaseMgiMin));

        MgiMax = Mathf.RoundToInt((BaseMgiMax + e.EXMgiMaxF) * (1 + e.EXMgiP) + e.FXMgi);
        MgiMin = Mathf.RoundToInt((BaseMgiMin + e.EXMgiMinF) * (1 + e.EXMgiP) + e.FXMgi);
        Mgi = Mathf.RoundToInt(0.5f * (MgiMax + MgiMin));

        //元素魔法攻击 
        FireDmgMax = Mathf.RoundToInt((BaseMgiMax + e.EXMgiMaxF + b.FireDmg + e.EXFireDmgF) * (1 + e.EXMgiP + e.EXFireDmgP) + e.FXMgi + e.FXFireDmg);
        FireDmgMin = Mathf.RoundToInt((BaseMgiMin + e.EXMgiMinF + b.FireDmg + e.EXFireDmgF) * (1 + e.EXMgiP + e.EXFireDmgP) + e.FXMgi + e.FXFireDmg);
        IceDmgMax = Mathf.RoundToInt((BaseMgiMax + e.EXMgiMaxF + b.IceDmg + e.EXIceDmgF) * (1 + e.EXMgiP + e.EXIceDmgP) + e.FXMgi + e.FXIceDmg);
        IceDmgMin = Mathf.RoundToInt((BaseMgiMin + e.EXMgiMinF + b.IceDmg + e.EXIceDmgF) * (1 + e.EXMgiP + e.EXIceDmgP) + e.FXMgi + e.FXIceDmg);
        LightningDmgMax = Mathf.RoundToInt((BaseMgiMax + e.EXMgiMaxF + b.LightningDmg + e.EXLightningDmgF) * (1 + e.EXMgiP + e.EXLightningDmgP) + e.FXMgi + e.FXLightningDmg);
        LightningDmgMin = Mathf.RoundToInt((BaseMgiMin + e.EXMgiMinF + b.LightningDmg + e.EXLightningDmgF) * (1 + e.EXMgiP + e.EXLightningDmgP) + e.FXMgi + e.FXLightningDmg);
        PoisonDmgMax = Mathf.RoundToInt((BaseMgiMax + e.EXMgiMaxF + b.PoisonDmg + e.EXPoisonDmgF) * (1 + e.EXMgiP + e.EXPoisonDmgP) + e.FXMgi + e.FXPoisonDmg);
        PoisonDmgMin = Mathf.RoundToInt((BaseMgiMin + e.EXMgiMinF + b.PoisonDmg + e.EXPoisonDmgF) * (1 + e.EXMgiP + e.EXPoisonDmgP) + e.FXMgi + e.FXPoisonDmg);
        ShadowDmgMax = Mathf.RoundToInt((BaseMgiMax + e.EXMgiMaxF + b.ShadowDmg + e.EXShadowDmgF) * (1 + e.EXMgiP + e.EXShadowDmgP) + e.FXMgi + e.FXShadowDmg);
        ShadowDmgMin = Mathf.RoundToInt((BaseMgiMin + e.EXMgiMinF + b.ShadowDmg + e.EXShadowDmgF) * (1 + e.EXMgiP + e.EXShadowDmgP) + e.FXMgi + e.FXShadowDmg);
        HolyDmgMax = Mathf.RoundToInt((BaseMgiMax + e.EXMgiMaxF + b.HolyDmg + e.EXHolyDmgF) * (1 + e.EXMgiP + e.EXHolyDmgP) + e.FXMgi + e.FXHolyDmg);
        HolyDmgMin = Mathf.RoundToInt((BaseMgiMin + e.EXMgiMinF + b.HolyDmg + e.EXHolyDmgF) * (1 + e.EXMgiP + e.EXHolyDmgP) + e.FXMgi + e.FXHolyDmg);
        ArcaneDmgMax = Mathf.RoundToInt((BaseMgiMax + e.EXMgiMaxF + b.ArcaneDmg + e.EXArcaneDmgF) * (1 + e.EXMgiP + e.EXArcaneDmgP) + e.FXMgi + e.FXArcaneDmg);
        ArcaneDmgMin = Mathf.RoundToInt((BaseMgiMin + e.EXMgiMinF + b.ArcaneDmg + e.EXArcaneDmgF) * (1 + e.EXMgiP + e.EXArcaneDmgP) + e.FXMgi + e.FXArcaneDmg);
        
        //ArcaneDmg = Mathf.RoundToInt((b.ArcaneDmg + e.EXArcaneDmgF) * (1 + e.EXArcaneDmgP) + e.FXArcaneDmg);

        //攻击速度
        Ias = (b.Ias + e.EXIasF + (Dex * GameProperties.GetInstance.Ias_Per_Dex)) * (1 + e.EXIasP) + e.FXIas;

        //基础暴击
        CriCha = (b.CriCha + e.EXCriChaF + (Dex * GameProperties.GetInstance.CriCha_Per_Dex)) * (1 + e.EXCriChaP) + e.FXCriCha;
        CriDmg = (b.CriDmg + e.EXCriDmgF) * (1 + e.EXCriDmgP) + e.FXCriDmg + GameProperties.GetInstance.basic_CriDmg;
        //物理暴击
        CriPhyMeleeCha = (b.CriPhyMeleeCha + e.EXCriPhyMeleeChaF) * (1 + e.EXCriPhyMeleeChaP) + e.FXCriPhyMeleeCha + CriCha;
        CriPhyMeleeDmg = (b.CriPhyMeleeDmg + e.EXCriPhyMeleeDmgF) * (1 + e.EXCriPhyMeleeDmgP) + e.FXCriPhyMeleeDmg + CriDmg;

        CriPhyRangeCha = (b.CriPhyRangeCha + e.EXCriPhyRangeChaF) * (1 + e.EXCriPhyRangeChaP) + e.FXCriPhyRangeCha + CriCha;
        CriPhyRangeDmg = (b.CriPhyRangeDmg + e.EXCriPhyRangeDmgF) * (1 + e.EXCriPhyRangeDmgP) + e.FXCriPhyRangeDmg + CriDmg;
        //魔法暴击
        CriMgiCha = (b.CriMgiCha + e.EXCriMgiChaF) * (1 + e.EXCriMgiChaP) + e.FXCriMgiCha + CriCha;
        CriMgiDmg = (b.CriMgiDmg + e.EXCriMgiDmgF) * (1 + e.EXCriMgiDmgP) + e.FXCriMgiDmg + CriDmg;

        //物理穿透
        AmrPeneFix = Mathf.RoundToInt((b.AmrPeneFix + e.EXAmrPeneFixF) * (1 + e.EXAmrPeneFixP) + e.FXAmrPeneFix);
        AmrPenePer = (b.AmrPenePer + e.EXAmrPenePerF) * (1 + e.EXAmrPenePerP) + e.FXAmrPenePer;
        //魔法穿透
        ResPeneFix = Mathf.RoundToInt((b.ResPeneFix + e.EXResPeneFixF) * (1 + e.EXResPeneFixP) + e.FXResPeneFix);
        ResPenePer = (b.ResPenePer + e.EXResPenePerF) * (1 + e.EXResPenePerP) + e.FXResPenePer;
        //冷却缩减
        Cdr = (b.Cdr + e.EXCdrF + (Spi * GameProperties.GetInstance.Cdr_Per_Spi)) * (1 + e.EXCdrP) + e.FXCdr;
        //消耗缩减
        Csr = (b.Csr + e.EXCsrF + (Spi * GameProperties.GetInstance.Csr_Per_Spi)) * (1 + e.EXCsrP) + e.FXCsr;
        //精准命中
        Acc = (b.Acc + e.EXAccF) * (1 + e.EXAccP) + e.FXAcc;

        //歧视伤害
        HumanDmg = (b.HumanDmg + e.EXHumanDmgF) * (1 + e.EXHumanDmgP) + e.FXHumanDmg;
        BeastDmg = (b.BeastDmg + e.EXBeastDmgF) * (1 + e.EXBeastDmgP) + e.FXBeastDmg;
        UndeadDmg = (b.UndeadDmg + e.EXUndeadDmgF) * (1 + e.EXUndeadDmgP) + e.FXUndeadDmg;
        DragonDmg = (b.DragonDmg + e.EXDragonDmgF) * (1 + e.EXDragonDmgP) + e.FXDragonDmg;
        DemonDmg = (b.DemonDmg + e.EXDemonDmgF) * (1 + e.EXDemonDmgP) + e.FXDemonDmg;
        ElementDmg = (b.ElementDmg + e.EXElementDmgF) * (1 + e.EXElementDmgP) + e.FXElementDmg;

        NormalDmg = (b.NormalDmg + e.EXNormalDmgF) * (1 + e.EXNormalDmgP) + e.FXNormalDmg;
        EliteDmg = (b.EliteDmg + e.EXEliteDmgF) * (1 + e.EXEliteDmgP) + e.FXEliteDmg;
        BossDmg = (b.BossDmg + e.EXBossDmgF) * (1 + e.EXBossDmgP) + e.FXBossDmg;

        //防御属性--------------------------------------------------------------------------------------------------------------------------

        //护甲和魔抗
        Amr = Mathf.RoundToInt((b.Amr + e.EXAmrF + (Str * GameProperties.GetInstance.Amr_PerStr)) * (1 + e.EXAmrP) + e.FXAmr);
        Res = Mathf.RoundToInt((b.Res + e.EXResF + (Int * GameProperties.GetInstance.Res_Per_Int)) * (1 + e.EXResP) + e.FXRes);

        //元素抗性
        FireRes = Mathf.RoundToInt((b.FireRes + e.EXFireResF) * (1 + e.EXFireResP) + e.FXFireRes);
        IceRes = Mathf.RoundToInt((b.IceRes + e.EXIceResF) * (1 + e.EXIceResP) + e.FXIceRes);
        LightningRes = Mathf.RoundToInt((b.LightningRes + e.EXLightningResF) * (1 + e.EXLightningResP) + e.FXLightningRes);
        PoisonRes = Mathf.RoundToInt((b.PoisonRes + e.EXPoisonResF) * (1 + e.EXPoisonResP) + e.FXPoisonRes);
        ShadowRes = Mathf.RoundToInt((b.ShadowRes + e.EXShadowResF) * (1 + e.EXShadowResP) + e.FXShadowRes);
        HolyRes = Mathf.RoundToInt((b.HolyRes + e.EXHolyResF) * (1 + e.EXHolyResP) + e.FXHolyRes);
        ArcaneRes = Mathf.RoundToInt((b.ArcaneRes + e.EXArcaneResF) * (1 + e.EXArcaneResP) + e.FXArcaneRes);

        //格挡
        BlkCha = (b.BlkCha + e.EXBlkChaF) * (1 + e.EXBlkChaP) + e.FXBlkCha;
        BlkFix = Mathf.RoundToInt((b.BlkFix + e.EXBlkFixF) * (1 + e.EXBlkFixP) + e.FXBlkFix);
        BlkPer = (b.BlkPer + e.EXBlkPerF) * (1 + e.EXBlkPerP) + e.FXBlkPer;
        //闪避
        Eva = (b.Eva + e.EXEvaF + (Dex * GameProperties.GetInstance.Eva_Per_Dex)) * (1 + e.EXEvaP) + e.FXEva;
        //坚韧
        Tough = (b.Tough + e.EXToughF + (Vit * GameProperties.GetInstance.Tough_Per_Vit)) * (1 + e.EXToughP) + e.FXTough;
        //荆棘伤害
        Thorns = Mathf.RoundToInt((b.Thorns + e.EXThornsF) * (1 + e.EXThornsP) + e.FXThorns);
        //歧视减伤
        MeleeDmgReduce = (b.MeleeDef + e.EXMeleeDefF) * (1 + e.EXMeleeDefP) + e.FXMeleeDef; //近战百分比减伤
        RangeDmgReduce = (b.RangeDef + e.EXRangeDefF) * (1 + e.EXRangeDefP) + e.FXRangeDef; //远程百分比减伤


        //生命与能量--------------------------------------------------------------------------------------------------------------------------

        //生命最大值，先算属性值再算状态值
        HpMax = Mathf.RoundToInt((b.HpMax + e.EXHpMaxF + (Vit * GameProperties.GetInstance.HpMax_Per_Vit)) * (1 + e.EXHpMaxP) + e.FXHpMax);
        HpReg = (b.HpReg + e.EXHpRegF + (Vit * GameProperties.GetInstance.HpReg_Per_Vit) + (Spi * GameProperties.GetInstance.HpReg_Per_Spi)) * (1 + e.EXHpRegP) + e.FXHpReg;

        //能量最大值，先算属性值再算状态值
        SpMax = Mathf.RoundToInt((b.SpMax + e.EXSpMaxF) * (1 + e.EXSpMaxP) + e.FXSpMax);
        SpReg = (b.SpReg + e.EXSpRegF + (Spi * GameProperties.GetInstance.SpReg_Per_Spi)) * (1 + e.EXSpRegP) + e.FXSpReg;

        //受治疗固定数值加成（技能，药剂和神符）
        HpReciFix = Mathf.RoundToInt((b.HpReciFix + e.EXHpReciFixF) * (1 + e.EXHpReciFixP) + e.FXHpReciFix);
        //受治疗百分比加成（技能，药剂和神符）
        HpReciPer = (b.HpReciPer + e.EXHpReciPerF) * (1 + e.EXHpReciPerP) + e.FXHpReciPer;
        //击中生命回复
        HpHitReg = Mathf.RoundToInt((b.HpHitReg + e.EXHpHitRegF) * (1 + e.EXHpHitRegP) + e.FXHpHitReg);
        //击杀生命回复
        HpKillReg = Mathf.RoundToInt((b.HpKillReg + e.EXHpKillRegF) * (1 + e.EXHpKillRegP) + e.FXHpKillReg);
        //击中能量回复
        SpHitReg = Mathf.RoundToInt((b.SpHitReg + e.EXSpHitRegF) * (1 + e.EXSpHitRegP) + e.FXSpHitReg);
        //击杀能量回复
        SpKillReg = Mathf.RoundToInt((b.SpKillReg + e.EXSpKillRegF) * (1 + e.EXSpKillRegP) + e.FXSpKillReg);
        //消耗能量回复生命
        HpRegPerSpCost = (b.SpCostHpReg + e.EXSpCostHpRegF) * (1 + e.EXSpCostHpRegP) + e.FXSpCostHpReg;


        //其他属性--------------------------------------------------------------------------------------------------------------------------

        Spd = ((b.Spd + e.EXSpdF) * (1 + e.EXSpdP) + e.FXSpd) * (1 + e.FX_P_Spd);
        GoldGet = ((b.GoldGet + e.EXGoldGetF) * (1 + e.EXGoldGetP) + e.FXGoldGet);
        ExpGet = ((b.ExpGet + e.EXExpGetF) * (1 + e.EXExpGetP) + e.FXExpGet);
        ItemGet = ((b.ItemGet + e.EXItemGetF) * (1 + e.EXItemGetP) + e.FXItemGet);
        GetRange = ((b.GetRange + e.EXGetRangeF) * (1 + e.EXGetRangeP) + e.FXGetRange);

        //全局增减伤--------------------------------------------------------------------------------------------------------------------------
        //全局独立增伤
        FinalDmgBoost = ((b.FinalDmgBoost + e.EXFinalDmgBoostF) * (1 + e.EXFinalDmgBoostP) + e.FXFinalDmgBoost);
        //全局独立减伤
        FinalDmgReduce = ((b.FinalDmgReduce + e.EXFinalDmgReduceF) * (1 + e.EXFinalDmgReduceP) + e.FXFinalDmgReduce);
    }

    public bool CheckEvade()
    {
        if (Random.Range(0.0f, 1.0f) <= Eva)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CheckDead()
    {
        if (Hp_Int <= 0)
        {
            CharacterBehaviour.GetInstace.bIsDead = true;
            CharacterBehaviour.GetInstace.Die();
        }
    }

    void Hit()
    {
        if (!characterBehaviour.bInAction)
        {
            characterBehaviour.anim.SetLayerWeight(3, 1.1f);
            characterAttack.attackLayerWeight3 = 1.1f;
            characterBehaviour.anim.SetTrigger("Hit");
        }
    }

    public void ChangeHP(float percent)
    {
        Hp += percent * HpMax; ;
    }

    public void ChangeHP(int number)
    {
        Hp += number;
    }

    public void ChangeSP(float percent)
    {
        Sp += percent * SpMax;
    }

    public void ChangeSP(int number)
    {
        Sp += number;
    }
    public void FullHP()
    {
        Hp = HpMax;
    }

    public void FullSP()
    {
        Sp = SpMax;
    }

    public bool TakeDamage(int physicalDamage, int magicDamage, GameObject enemy)
    {
        if (IsDead)
        {
            return false;
        }
        if (characterAttack.isEvade)
        {
            textManager.Add("Evade", this.characterBehaviour.hitPoint.transform, "evade");
            return false;
        }
        if (CheckEvade())
        {
            textManager.Add("Evade", this.characterBehaviour.hitPoint.transform, "evade");
            return false;
        }

        physicalDamage = Mathf.RoundToInt(physicalDamage * (1 - (Amr / (Amr + 100.0f))));
        magicDamage = Mathf.RoundToInt(magicDamage * (1 - (Res / (Res + 100.0f))));

        Hp -= physicalDamage + magicDamage;
        Hp_Int = Mathf.CeilToInt(Hp);
        Destroy(GameObject.Instantiate(characterBehaviour.blood, characterBehaviour.hitPoint.transform), 2f);

        textManager.Add("-" + (physicalDamage + magicDamage).ToString(), this.characterBehaviour.hitPoint.transform, "beenHitBig");

        /*
        if (physicalDamage + magicDamage >= 0.2f * HpInt)
        {
            textManager.Add("-" + (physicalDamage + magicDamage).ToString(), this.characterBehaviour.hitPoint.transform, "beenHitBig");
        }
        else
        {
            textManager.Add("-" + (physicalDamage + magicDamage).ToString(), this.characterBehaviour.hitPoint.transform, "beenHit");
        }
        */

        CheckDead();
        if (CharacterBehaviour.GetInstace.bIsDead)
        {
            
            CharacterBehaviour.GetInstace.Die();
        }
        else
        {
            Hit();
        }
        return true;
    }
}