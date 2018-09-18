using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerProperties : MonoBehaviour
{
    public Text text;

    void Awake()
    {
        text = this.GetComponent<Text>();
    }

    void Update()
    {
        text.text =
            "\n" +
            "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.Str + "\n" +
            ActorPropertiesFinal.GetInstance.Dex + "\n" +
            ActorPropertiesFinal.GetInstance.Int + "\n" +
            ActorPropertiesFinal.GetInstance.Spi + "\n" +
            ActorPropertiesFinal.GetInstance.Cun + "\n" +
            ActorPropertiesFinal.GetInstance.Vit + "\n" +
            "\n" +
            "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.PhyMeleeMin + "-" + ActorPropertiesFinal.GetInstance.PhyMeleeMax + "\n" +
            ActorPropertiesFinal.GetInstance.PhyRangeMin + "-" + ActorPropertiesFinal.GetInstance.PhyRangeMax + "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.MgiMin + "-" + ActorPropertiesFinal.GetInstance.MgiMax + "\n" +
            ActorPropertiesFinal.GetInstance.FireDmgMax + "-" + ActorPropertiesFinal.GetInstance.FireDmgMin + "\n" +
            ActorPropertiesFinal.GetInstance.IceDmgMax + "-" + ActorPropertiesFinal.GetInstance.IceDmgMin + "\n" +
            ActorPropertiesFinal.GetInstance.LightningDmgMax + "-" + ActorPropertiesFinal.GetInstance.LightningDmgMin + "\n" +
            ActorPropertiesFinal.GetInstance.PoisonDmgMax + "-" + ActorPropertiesFinal.GetInstance.PoisonDmgMin + "\n" +
            ActorPropertiesFinal.GetInstance.ArcaneDmgMax + "-" + ActorPropertiesFinal.GetInstance.ArcaneDmgMin + "\n" +
            ActorPropertiesFinal.GetInstance.HolyDmgMax + "-" + ActorPropertiesFinal.GetInstance.HolyDmgMin + "\n" +
            ActorPropertiesFinal.GetInstance.ShadowDmgMax + "-" + ActorPropertiesFinal.GetInstance.ShadowDmgMin + "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.Ias + "\n" +
            ActorPropertiesFinal.GetInstance.Acc + "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.CriPhyMeleeCha + "\n" +
            ActorPropertiesFinal.GetInstance.CriPhyMeleeDmg + "\n" +
            ActorPropertiesFinal.GetInstance.CriPhyRangeCha + "\n" +
            ActorPropertiesFinal.GetInstance.CriPhyRangeDmg + "\n" +
            ActorPropertiesFinal.GetInstance.CriMgiCha + "\n" +
            ActorPropertiesFinal.GetInstance.CriMgiDmg + "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.AmrPeneFix + "\n" +
            ActorPropertiesFinal.GetInstance.AmrPenePer + "\n" +
            ActorPropertiesFinal.GetInstance.ResPeneFix + "\n" +
            ActorPropertiesFinal.GetInstance.ResPenePer + "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.Cdr + "\n" +
            ActorPropertiesFinal.GetInstance.Csr + "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.HumanDmg + "\n" +
            ActorPropertiesFinal.GetInstance.BeastDmg + "\n" +
            ActorPropertiesFinal.GetInstance.UndeadDmg + "\n" +
            ActorPropertiesFinal.GetInstance.DragonDmg + "\n" +
            ActorPropertiesFinal.GetInstance.DemonDmg + "\n" +
            ActorPropertiesFinal.GetInstance.ElementDmg + "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.NormalDmg + "\n" +
            ActorPropertiesFinal.GetInstance.EliteDmg + "\n" +
            ActorPropertiesFinal.GetInstance.BossDmg + "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.FinalDmgBoost + "\n" +
            "\n" +
            "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.Amr + "\n" +
            ActorPropertiesFinal.GetInstance.Res + "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.FireRes + "\n" +
            ActorPropertiesFinal.GetInstance.IceRes + "\n" +
            ActorPropertiesFinal.GetInstance.LightningRes + "\n" +
            ActorPropertiesFinal.GetInstance.PoisonRes + "\n" +
            ActorPropertiesFinal.GetInstance.ShadowRes + "\n" +
            ActorPropertiesFinal.GetInstance.HolyRes + "\n" +
            ActorPropertiesFinal.GetInstance.ArcaneRes + "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.BlkCha + "\n" +
            ActorPropertiesFinal.GetInstance.BlkFix + "\n" +
            ActorPropertiesFinal.GetInstance.BlkPer + "\n" +
            ActorPropertiesFinal.GetInstance.Eva + "\n" +
            ActorPropertiesFinal.GetInstance.Tough + "\n" +
            ActorPropertiesFinal.GetInstance.Thorns + "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.MeleeDmgReduce + "\n" +
            ActorPropertiesFinal.GetInstance.RangeDmgReduce + "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.FinalDmgReduce + "\n" +
            "\n" +
            "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.HpMax + "\n" +
            ActorPropertiesFinal.GetInstance.HpReg + "\n" +
            ActorPropertiesFinal.GetInstance.HpHitReg + "\n" +
            ActorPropertiesFinal.GetInstance.HpKillReg + "\n" +
            ActorPropertiesFinal.GetInstance.HpRegPerSpCost + "\n" +
            ActorPropertiesFinal.GetInstance.HpReciFix + "\n" +
            ActorPropertiesFinal.GetInstance.HpReciPer + "\n" +
            "\n" +
            "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.SpMax + "\n" +
            ActorPropertiesFinal.GetInstance.SpReg + "\n" +
            ActorPropertiesFinal.GetInstance.SpHitReg + "\n" +
            ActorPropertiesFinal.GetInstance.SpKillReg + "\n" +
            "\n" +
            "\n" +
            "\n" +
            ActorPropertiesFinal.GetInstance.Spd + "\n" +
            ActorPropertiesFinal.GetInstance.GoldGet + "\n" +
            ActorPropertiesFinal.GetInstance.ExpGet + "\n" +
            ActorPropertiesFinal.GetInstance.ItemGet + "\n" +
            ActorPropertiesFinal.GetInstance.GetRange + "\n";
    }
}
