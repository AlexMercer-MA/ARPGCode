using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPropertiesBase : ActorPropertiesBase
{

    public PlayerPropertiesBase Instance
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
    private PlayerPropertiesBase instance;

    public ePlayerClassType playerProfession;//玩家职业
    public int Experience { get { return experience; } set { experience = Mathf.Clamp(value, 0, value); } }//经验值（总是大于等于0）
    private int experience;

    //升级属性 PlayerPropertiesBase专有
    public int StrPerLv { get; set; }
    public int DexPerLv { get; set; }
    public int IntPerLv { get; set; }
    public int SpiPerLv { get; set; }
    public int CunPerLv { get; set; }
    public int VitPerLv { get; set; }
    public int PhyMeleeLv { get; set; }
    public int PhyRangeLv { get; set; }
    public int MgiLv { get; set; }

    void Awake()
    {
        Instance = this;
    }

    public void ChangeExperience(int value)
    {
        Experience += value;
        CheckUpgrade();
    }

    void CheckUpgrade()
    {
        //如果经验值达到了该等级要求，就需要升级
        if (Experience >= GameSettingManager.GetInstance.UpgradeExperience[Level])
        {
            Experience -= GameSettingManager.GetInstance.UpgradeExperience[Level];
            Level++;

            //TODO 改变属性 改为加点
            Str += 2;
            Int += 2;
            Dex += 2;
            Vit += 2;
            Spi += 2;

            ActorPropertiesFinal.GetInstance.UpdateProperties();
            ActorPropertiesFinal.GetInstance.FullHP();
            ActorPropertiesFinal.GetInstance.FullSP();
            Instantiate(CharacterBehaviour.GetInstace.upgrade, this.transform);
        }
    }

}
