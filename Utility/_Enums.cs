//All Enums
//列举了游戏中的所有枚举

public enum ePlayerClassType
{
    Barbarian,
    Gardian,
    Ranger,
    Assassin,
    Mage,
    Necromancer,
    Duird,
}


//物品类型
public enum eItemType
{
    Normal,
    Consumable,
    Equipment,
}


//装备类型
public enum eEquipmentType
{
    //Weapon & Shield
    One_Handed_Sword,       //0 One_Handed_Sword
    One_Handed_Mace,        //1 One_Handed_Mace
    One_Handed_Axe,         //2 One_Handed_Axe
    Two_Handed_Sword,       
    Two_Handed_Mace,
    Two_Handed_Axe,
    Dagger,
    Spear,
    Shield,
    //Armor
    Heavy_Armor,
    Medium_Armor,
    Light_Armor,
    //Others
    Jewel,
}

//装备插槽位置
public enum eSlotType
{
    Weapon_MainHand,            //0 Weapon
    Weapon_OffHand,             //1 Weapon
    Weapon_OneHand,             //2 Weapon
    Weapon_TwoHand,             //3 Weapon
    Head,                       //4 Head
    Shoulder,                   //5 Shoulder
    Chest,                      //6 Chest
    Bracer,                     //7 Bracer
    Gloves,                     //8 Hand
    Belt,                       //9 Belt
    Leg,                        //10 Leg
    Boots,                      //11 Feet
    Necklack,                   //12 Necklack
    Ring,						//13 Ring
}


//装备品质
public enum eItemQuality
{
    Common,
    Rare,
    Special,
    Epic,
    Legendary
}





//怪物类型
public enum eEnemyType
{
    Normal,
    Elite,
    Boss,
}

public enum eEnemyClass
{
    Beast,
    Humanoid,
    UnDead
}

public enum eEnemyAttackDistanceType
{
    Melee,
    Range
}


//触发区域类型
public enum eTriggerType
{
    DungeonEnter,
    Portal,
    Shop,
    Item,
}


