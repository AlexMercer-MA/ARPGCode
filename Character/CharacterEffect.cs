using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEffect : MonoBehaviour {
    
    //一个Dictionary 存储玩家身上所有的EffectGroup 相当于管理器
    // 根据ID 存储一个EffectGroup
    // 在每一个EffectGroup里 存储各种Effect
    public Dictionary<int, EffectGroup> tEffectGroupTable = new Dictionary<int, EffectGroup>();

    // 初始化 Awake
    void Awake ()
    {
		
	}

    //初始化 Start
    void Start()
    {

    }

    //Function1 由谁给谁 添加 ID 效果 ，添加 1/N 层，返回是否成功

    //TODO OverLoad master = this.gameObject

    bool AddEffect(GameObject master, GameObject onwer, int ID, int stack = 1)
    {
        //先确认 目标身上有 tEffectGroupTable
        EffectGroup targetEffectGroup = onwer.GetComponentInChildren<EffectGroup>();
        if (targetEffectGroup == null) return false;

        //获取对应ID EffectMod
        EffectMod effectMod = EffectManager.GetInstace.GetEffectModByID(ID);
        if (effectMod == null) return false;

        EffectGroup tEffectGroupTable = new EffectGroup(ID);

        //如果Dic中没有，就新建EffectGroup
        if (tEffectGroupTable.ContainsKey(ID))
        {
            tEffectGroupTable.Add(ID, 1);
        }
        //如果Dic中有，就直接操作
        else
        {
            tEffectGroupTable.Add();
        }
        return true;
    }

    bool RemoveEffect(int ID, int stack = 1)
    {
        //如果Dic中没有就Return
        if (!tEffectGroupTable.ContainsKey(ID)) return false;
        //如果Dic中操作完，仍然有剩余
        if (true)
        {

        }
        //如果Dic中操作完，次数为0，就Remove Dic中的Index，去掉这一项
        if (true)
        {

        }
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

}
