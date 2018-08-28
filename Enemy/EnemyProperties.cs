using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnazzlebotTools.ENPCHealthBars;
using Guirao.UltimateTextDamage;

public class EnemyProperties : MonoBehaviour
{
    public EnemyBehaviour enemyBehaviour;
    public ENPCHealthBar healthBar;
    public GameObject hit;
    public GameObject critcalHit;
    public GameObject bulletPrefab;
    public UltimateTextDamageManager textManager;

    //怪物属性
    public string name;
    public int level;

    public float hp;
    public int hpInt;
    public int maxHp;
    public float resHp;

    public int atk;
    public int mgk;
    public int def;
    public int res;

    public float battleRange;               //警戒范围
    public float attackRange;               //攻击范围
    public float attackDamageRange;         //攻击判定范围
    public float attackAngle;               //攻击角度
    public float attackSpeed = 1f;          //攻击动画播放倍速
    public float attackCd = 2f;             //攻击间隔x秒
    public float walkSpeed = 1f;            //闲置状态下 移动速度
    public float runSpeed = 3f;             //战斗状态下 移动速度
    public float angularSpeed = 240f;       //战斗状态下 转身速率 x度/秒
    public float projectionMoveSpeed;       //投射物移动速度
    public float projectionGravity;         //投射物抛物线重力
    public float projectionLastTime;        //投射物持续时间
    public bool projectionIgnoreBlock;      //投射物是否穿透

    public bool cannotStun;
    public bool cannotSlow;
    public bool cannotSlowCold;
    public bool cannotFreezeCold;
    public bool cannotPosion;
    public bool cannotIgnite;

    public float reduceControlMultipler = 0f;
    public float reduceControlTimer = 0f;

    public Renderer render;

    public int exp;                         //提供的经验值

    public eEnemyClass enemyClass;
    public eEnemyAttackDistanceType enemyAttackDistanceType;
    public eEnemyType enemyType;

    //怪物构造函数
    public EnemyProperties()
    {

    }

    void Awake()
    {
        healthBar = gameObject.GetComponentInChildren<ENPCHealthBar>();
        textManager = GameObject.FindWithTag("DamageUI").GetComponent<UltimateTextDamageManager>();

        RefreshUI();

        //LevelEnhance ();
        //EliteEnhance ();
    }

    void Update()
    {
        //更新生命值Hp
        hp += resHp * Time.deltaTime;
        hp = Mathf.Clamp(hp, 0, maxHp);
        hpInt = Mathf.CeilToInt(hp);
        healthBar.Value = hpInt;
        //判断是否死亡
        CheckDie();
    }

    public void TakePhysicalMeleeDamage(int damage, int ArmorPeneNumber, float ArmorPenePercent)
    {
        //是否暴击
        bool isCrit = CheckPhyMeleeCrit();
        if (isCrit)
        {
            damage *= Mathf.RoundToInt(PlayerPropertiesFinal.GetInstance.CriPhyMeleeDmg);
            GameObject.Instantiate(critcalHit, enemyBehaviour.hitPoint.transform);
        }
        GameObject.Instantiate(hit, enemyBehaviour.hitPoint.transform);

        //护甲穿透
        float FinalArmor = def * (1 - ArmorPenePercent) - ArmorPeneNumber;
        //计算伤害
        damage = Mathf.RoundToInt(damage * (1 - (FinalArmor / (FinalArmor + 100.0f))));
        //造成伤害
        hp -= damage;
        //被攻击动画和掉血效果
        BeenHit();

        //伤害数字
        if (isCrit)
        {
            textManager.Add(damage.ToString(), enemyBehaviour.hitPoint.transform, "critical");
        }
        else
        {
            textManager.Add(damage.ToString(), enemyBehaviour.hitPoint.transform, "default");
        }
    }

    public void TakePhysicalRangeDamage(int damage, int ArmorPeneNumber, float ArmorPenePercent)
    {
        //是否暴击
        bool isCrit = CheckPhyMeleeCrit();
        if (isCrit)
        {
            damage *= Mathf.RoundToInt(PlayerPropertiesFinal.GetInstance.CriPhyMeleeDmg);
            GameObject.Instantiate(critcalHit, enemyBehaviour.hitPoint.transform);
        }
        GameObject.Instantiate(hit, enemyBehaviour.hitPoint.transform);

        //护甲穿透
        float FinalArmor = def * (1 - ArmorPenePercent) - ArmorPeneNumber;
        //计算伤害
        damage = Mathf.RoundToInt(damage * (1 - (FinalArmor / (FinalArmor + 100.0f))));
        //造成伤害
        hp -= damage;
        //被攻击动画和掉血效果
        BeenHit();

        //伤害数字
        if (isCrit)
        {
            textManager.Add(damage.ToString(), enemyBehaviour.hitPoint.transform, "critical");
        }
        else
        {
            textManager.Add(damage.ToString(), enemyBehaviour.hitPoint.transform, "default");
        }
    }

    public void TakeMagicDamage(int damage, int ResistancePeneNumber, float ResistancePenePercent)
    {
        //是否暴击
        bool isCrit = CheckMgiCrit();
        if (isCrit)
        {
            damage *= Mathf.RoundToInt(PlayerPropertiesFinal.GetInstance.CriMgiDmg);
            GameObject.Instantiate(critcalHit, enemyBehaviour.hitPoint.transform);
        }
        GameObject.Instantiate(hit, enemyBehaviour.hitPoint.transform);
        //魔法穿透
        float FinalResistance = def * (1 - ResistancePenePercent) - ResistancePeneNumber;
        //计算伤害
        damage = Mathf.RoundToInt(damage * (1 - (FinalResistance / (FinalResistance + 100.0f))));
        //造成伤害
        hp -= damage;
        //被攻击动画和掉血效果
        BeenHit();

        //伤害数字
        if (isCrit)
        {
            textManager.Add(damage.ToString(), enemyBehaviour.hitPoint.transform, "critical");
        }
        else
        {
            textManager.Add(damage.ToString(), enemyBehaviour.hitPoint.transform, "default");
        }
    }

    void BeenHit()
    {
        if (Random.Range(0, 3) == 0)
        {
            enemyBehaviour.BeenHit();
        }
    }

    void CheckDie()
    {
        if (hp <= 0)
        {
            enemyBehaviour.Die();
            Destroy(this);
        }
    }

    bool CheckPhyMeleeCrit()
    {
        if (Random.Range(0f, 1f) <= PlayerPropertiesFinal.GetInstance.CriPhyMeleeCha)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckPhyRangeCrit()
    {
        if (Random.Range(0f, 1f) <= PlayerPropertiesFinal.GetInstance.CriPhyRangeCha)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool CheckMgiCrit()
    {
        if (Random.Range(0f, 1f) <= PlayerPropertiesFinal.GetInstance.CriMgiCha)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void EliteEnhance()
    {
        if (enemyType == eEnemyType.Elite)
        {
            atk *= 2;
            mgk *= 2;
            hp *= 4;
            maxHp *= 4;
            exp *= 2;
        }
    }

    public void LevelEnhance()
    {
        //属性随等级增强
        atk += Mathf.RoundToInt(atk * 0.1f * (level - 1));
        mgk += Mathf.RoundToInt(mgk * 0.1f * (level - 1));
        def += Mathf.RoundToInt(def * 0.1f * (level - 1));
        res += Mathf.RoundToInt(res * 0.1f * (level - 1));
        hp += Mathf.RoundToInt(hp * 0.2f * (level - 1));
        maxHp += Mathf.RoundToInt(maxHp * 0.2f * (level - 1));
        resHp += Mathf.RoundToInt(resHp * 0.02f * (level - 1));
        exp += Mathf.RoundToInt(exp * 0.2f * (level - 1));
    }

    public void RefreshUI()
    {
        healthBar.MaxValue = maxHp;
        healthBar.Name = this.name;
        healthBar.Level = this.level;
    }

    public void Reset()
    {
        hp = maxHp;
    }
}


//To reduce or add to the health bar value, first add the following namespace directive to the top of your C# script:
//using SnazzlebotTools.ENPCHealthBars;
//
//Then simply obtain a reference to the gameobject's ENPCHealthBar component 
//e.g. gameObject.GetComponent<ENPCHealthBar>()
//and then add or subtract from its Value property
//e.g. healthBar.Value -= 10;