using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElite : MonoBehaviour
{
    public EnemyBehaviour enemyBehaviour;
    public EnemyProperties enemyProperties;
    public EliteType eliteType;

    // Use this for initialization
    void Awake()
    {
        enemyBehaviour = this.GetComponent<EnemyBehaviour>();
        enemyProperties = this.GetComponent<EnemyProperties>();
        eliteType = (EliteType)UnityEngine.Random.Range(0, Enum.GetNames(eliteType.GetType()).Length);
        switch (eliteType)
        {
            case EliteType.Counter:
                //TODO 增加脚本，改变材质球
                break;
            case EliteType.Molten:

                break;
            case EliteType.Posion:

                break;
            case EliteType.Lightning:

                break;
            case EliteType.Arcane:

                break;
            case EliteType.Rock:

                break;
            default:
                break;
        }
    }

}

public enum EliteType
{
    Counter,            //红色
    Molten,             //橙色
    Posion,             //绿色
    Lightning,          //蓝色
    Arcane,             //紫色
    Rock                //棕色
}
