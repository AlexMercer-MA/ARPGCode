using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : ActorProperty
{
    public PlayerProperty Instance
    {
        get
        {
            return instance;
        }

        private set
        {
            instance = value;
        }
    }
    private PlayerProperty instance;

    private void Awake()
    {
        Instance = this;
    }
    
    //基础技能  Player类Only
    public short canDuelWeapon;//能双持武器
    public short canBlock;//能格挡
    public short canEvade;//能闪避

    //可装备物品（需要用脚本初始化）  Player类Only
    public short canSingleHandSword;//能装备单手剑
    
    //TODO 其他武器
    //TODO 其他武器
    //TODO 其他武器

    public void ChangeCanEquip()
    {

    }

}
