//Made by Alex
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System.Text;
using LitJson;

public class EffectManager : MonoBehaviour
{
    //JSON路径
    string JSON_ItemDataPath;
    //只读单例类
    static EffectManager instance;
    public static EffectManager GetInstace { get { return instance; } }
    //EXCEL 表格转换后 承载的容器
    EffectMod[] effectModArray;
    //一个字典 包含所有Effect信息 用于读取              //目前它是空的，需要在JSONParse中从上一个EffectMod[]中读取数据
    public Dictionary<int,EffectMod> effectDic = new Dictionary<int, EffectMod>();

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        JSONParse();
    }
    
    void JSONParse()
    {
        effectModArray = JsonMapper.ToObject<EffectMod[]>(File.ReadAllText(@"Assets/Table/Effect.json"));

        for (int i = 0; i < effectModArray.Length; i++)
        {
            effectDic.Add(effectModArray[i].ID, effectModArray[i]);
        }

        foreach (var item in effectDic)
        {
            Debug.Log(item);
        }
    }

    public EffectMod GetEffectModByID(int ID)
    {
        if (effectDic.ContainsKey(ID))
        {
            return effectModArray[ID];
        }
        throw new Exception("Bad Effect ID");
    }

    public int GetEffectMaxStackNumByID(int ID)
    {
        if (effectDic.ContainsKey(ID))
        {
            return effectDic[ID].MaxStackNum;
        }
        return 0;
    }

    /*
    //Function1 添加 ID 效果 ，添加 1 层，返回是否成功
    public bool AddEffect(int ID, ActorEffect owner, ActorEffect master)
    {
        //判断传入ID是否有效
        if (!effectDic.ContainsKey(ID))
            return false;
        //如果OK， 添加1层
        EffectMod tempEffectMod = effectDic[ID];
        EffectGroup tempEffectGroup = owner.effectGroup[ID];
        tempEffectGroup.AddEffect(ID);
        return true;
    }

    //Function2 添加 ID 效果，添加 N 层，返回是否成功
    public bool AddEffect(int ID, int stackNum, ActorEffect owner, ActorEffect master)
    {
        //判断传入ID是否有效
        if (!effectDic.ContainsKey(ID))
            return false;
        //如果OK， 添加N层
        tEffectGroup[ID].AddEffect(ID, stackNum);
        return true;
    }

    //Function3 去除所有Debuff，传入去除等级 暂时无返回值
    //TODO 如果有任何一个BUFF被驱散了返回成功
    public void RemoveAllDebuff(eEffectDisperseType eDisperseType)
    {
        //TODO
    }

    //Function4 去除所有Buff，传入去除等级 暂时无返回值
    //TODO 如果有任何一个BUFF被驱散了返回成功
    public void RemoveAllBuff()
    {
        //TODO
    }

    //Function5 去除所有Effect，传入去除等级 暂时无返回值
    //TODO 如果有任何一个BUFF被驱散了返回成功
    public void RemoveAllEffect()
    {
        //TODO
    }
    */
}






//----------------------------------------------------------------------------------------------------------------
// -- 具体实例身上挂载的脚本 --
//新增的Effect实例会被加入到ID相同的EffectGroup中
public class EffectGroup
{
    //当前 EffectGroup的ID
    public int ID;
    //这个EffectGroup中所包含的全部Effect实例
    Effect[] aEffectLists;
    //首 Node
    int HeadNode;
    //尾 Node
    int RearNode;

    //构造函数 Constructor
    public EffectGroup(int ID)
    {
        this.ID = ID;
        
        int maxStackNum = EffectManager.GetInstace.GetEffectMaxStackNumByID(ID);

        // 没有上限的buff叠加层数为9999
        aEffectLists = new Effect[maxStackNum];
    }

    //更高效的队列，数组运作方法
    //https://www.cnblogs.com/lz3018/p/5728581.html

    //加X层 Effect
    public void AddEffect(int ID, GameObject owner, GameObject master, float fStartTime, float fEndTime, int Stack = 1)
    {
        if (Stack == 1)
        {

        }
        else
        {
            for (int i = 0; i < Stack; i++)
            {
                //根据 tEffectMod[ID] 规则来加effect
                Effect tempEffect = new Effect(owner, master, fStartTime, fEndTime);
            }
        }
    }

    //去掉X层 Effect 优先去掉 添加时间更靠前的
    public void RemoveEffect()
    {

    }

}

//----------------------------------------------------------------------------------------------------------------
// -- 具体实例身上挂载的脚本 --
public class Effect
{
    GameObject owner;           //Effect 接受者
    GameObject master;          //Effect 施加者
    //每层Effect开始时间和结束时间
    float fStartTime;
    float fEndTime;
    //上次操作的list的Index
    int lastOperateIndex;

    public Effect(GameObject owner, GameObject master, float fStartTime, float fEndTime)
    {
        this.owner = owner;
        this.master = master;
        this.fStartTime = fStartTime;
        this.fEndTime = fEndTime;
    }
}











//----------------------------------------------------------------------------------------------------------------
// 模板类
//EffectMod结构体，用于生成Effect实例时作为参考

// -- 暂时去掉的特性 --
//叠加组ID         同一组ID互相叠加
//叠加优先级       同一叠加ID之间可以叠加

public class EffectMod
{
    int id;                                 //ID
    string name;                            //名字
    string icon;                            //图标路径
    string description;                     //描述
    eEffectType basicType;                 //Effect 基础类型 (BUFF/DEBUFF)
    bool isControl;                         //是否是控制型效果（影响是否控制递减）
    eEffectStackNumType eStackNumType;      //叠加层数类型
    int maxStackNum;                        //最大叠加层数（仅有最大层数上限时生效）
    eEffectStackType eStackType;            //叠加类型（仅叠加层数>1时才生效）
    eEffectDisperseType eDisperseType;      //驱散类型（驱散级别）
    eEffectClearType eClearType;            //清除类型（受击/死亡/不清除）
    bool isPermanent;                       //是否是永久效果 类似wow中的N/A

    public int ID { get{ return id; } }    //最大叠加层数 Read-Only
    public string Name { get { return name; } }
    public string Icon { get { return icon; } }
    public string Description { get { return description; } }
    public eEffectType eBasicType { get { return basicType; } }
    public bool bIsControl { get { return isControl; } }
    public eEffectStackNumType StackNumType { get { return eStackNumType; } }
    public int MaxStackNum { get { return maxStackNum; } }
    public eEffectStackType EffectStackType { get { return eStackType; } }
    public eEffectDisperseType DisperseType { get { return eDisperseType; } }
    public eEffectClearType ClearType { get { return eClearType; } }
    public bool IsPermanent { get { return isPermanent; } }
}



















// 基础类型 枚举 BUFF/DEBUFF
public enum eEffectType
{
    BUFF,               //正面效果
    DEBUFF,             //负面效果
}

// 叠加层数 枚举
public enum eEffectStackNumType
{
    ONE,                //只有1层
    MAXSTACK,           //最大N层
    INFINITY,           //无限层数
}

// 叠加方式 枚举
public enum eEffectStackType
{
    ADD_SEPARATE,       //分层独立添加，List数据模式，到达层数上限后，新增项目顶替最初项
    ADD_REFRESH_ALL,    //叠加且刷新全部层数的持续时间
    //还可以区分是否来源同一个master，但是单人游戏暂时没有必要做区分
}

// 清除类型 枚举
public enum eEffectClearType
{
    UNTIL_TIMEOVER,     //直到时间结束，其他情况都不消失(死亡！不会！被清除)
    ON_DEATH,           //死亡时清除buff
    ON_TAKEDMG,         //承伤时清除buff(死亡会被清除)
    ON_DEATH_SUB_ONE,   //死亡时减少1层buff
    ON_TAKEDMG_SUB_ONE, //承伤时减少1层buff(死亡会被清除)
}

// 驱散类型 枚举
public enum eEffectDisperseType
{
    WEAK,               //需弱驱散
    STRONG,             //需强驱散
    CANNOT,             //无法驱散
}

