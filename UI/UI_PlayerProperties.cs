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
            ActorProperty.GetInstance.Str + "\n" +
            ActorProperty.GetInstance.Dex + "\n" +
            ActorProperty.GetInstance.Int + "\n" +
            ActorProperty.GetInstance.Spi + "\n" +
            ActorProperty.GetInstance.Cun + "\n" +
            ActorProperty.GetInstance.Vit + "\n" +
            "\n" +
            "\n" +
            "\n" +
            ActorProperty.GetInstance.PhyMeleeMin + "-" + ActorProperty.GetInstance.PhyMeleeMax + "\n" +
            ActorProperty.GetInstance.PhyRangeMin + "-" + ActorProperty.GetInstance.PhyRangeMax + "\n" +
            "\n" +
            ActorProperty.GetInstance.MgiMin + "-" + ActorProperty.GetInstance.MgiMax + "\n" +
            ActorProperty.GetInstance.FireDmgMax + "-" + ActorProperty.GetInstance.FireDmgMin + "\n" +
            ActorProperty.GetInstance.IceDmgMax + "-" + ActorProperty.GetInstance.IceDmgMin + "\n" +
            ActorProperty.GetInstance.LightningDmgMax + "-" + ActorProperty.GetInstance.LightningDmgMin + "\n" +
            ActorProperty.GetInstance.PoisonDmgMax + "-" + ActorProperty.GetInstance.PoisonDmgMin + "\n" +
            ActorProperty.GetInstance.ArcaneDmgMax + "-" + ActorProperty.GetInstance.ArcaneDmgMin + "\n" +
            ActorProperty.GetInstance.HolyDmgMax + "-" + ActorProperty.GetInstance.HolyDmgMin + "\n" +
            ActorProperty.GetInstance.ShadowDmgMax + "-" + ActorProperty.GetInstance.ShadowDmgMin + "\n" +
            "\n" +
            ActorProperty.GetInstance.Ias + "\n" +
            ActorProperty.GetInstance.Acc + "\n" +
            "\n" +
            ActorProperty.GetInstance.CriPhyMeleeCha + "\n" +
            ActorProperty.GetInstance.CriPhyMeleeDmg + "\n" +
            ActorProperty.GetInstance.CriPhyRangeCha + "\n" +
            ActorProperty.GetInstance.CriPhyRangeDmg + "\n" +
            ActorProperty.GetInstance.CriMgiCha + "\n" +
            ActorProperty.GetInstance.CriMgiDmg + "\n" +
            "\n" +
            ActorProperty.GetInstance.AmrPeneFix + "\n" +
            ActorProperty.GetInstance.AmrPenePer + "\n" +
            ActorProperty.GetInstance.ResPeneFix + "\n" +
            ActorProperty.GetInstance.ResPenePer + "\n" +
            "\n" +
            ActorProperty.GetInstance.Cdr + "\n" +
            ActorProperty.GetInstance.Csr + "\n" +
            "\n" +
            ActorProperty.GetInstance.HumanDmg + "\n" +
            ActorProperty.GetInstance.BeastDmg + "\n" +
            ActorProperty.GetInstance.UndeadDmg + "\n" +
            ActorProperty.GetInstance.DragonDmg + "\n" +
            ActorProperty.GetInstance.DemonDmg + "\n" +
            ActorProperty.GetInstance.ElementDmg + "\n" +
            "\n" +
            ActorProperty.GetInstance.NormalDmg + "\n" +
            ActorProperty.GetInstance.EliteDmg + "\n" +
            ActorProperty.GetInstance.BossDmg + "\n" +
            "\n" +
            ActorProperty.GetInstance.FinalDmgBoost + "\n" +
            "\n" +
            "\n" +
            "\n" +
            ActorProperty.GetInstance.Amr + "\n" +
            ActorProperty.GetInstance.Res + "\n" +
            "\n" +
            ActorProperty.GetInstance.FireRes + "\n" +
            ActorProperty.GetInstance.IceRes + "\n" +
            ActorProperty.GetInstance.LightningRes + "\n" +
            ActorProperty.GetInstance.PoisonRes + "\n" +
            ActorProperty.GetInstance.ShadowRes + "\n" +
            ActorProperty.GetInstance.HolyRes + "\n" +
            ActorProperty.GetInstance.ArcaneRes + "\n" +
            "\n" +
            ActorProperty.GetInstance.BlkCha + "\n" +
            ActorProperty.GetInstance.BlkFix + "\n" +
            ActorProperty.GetInstance.BlkPer + "\n" +
            ActorProperty.GetInstance.Eva + "\n" +
            ActorProperty.GetInstance.Tough + "\n" +
            ActorProperty.GetInstance.Thorns + "\n" +
            "\n" +
            ActorProperty.GetInstance.MeleeDmgReduce + "\n" +
            ActorProperty.GetInstance.RangeDmgReduce + "\n" +
            "\n" +
            ActorProperty.GetInstance.FinalDmgReduce + "\n" +
            "\n" +
            "\n" +
            "\n" +
            ActorProperty.GetInstance.HpMax + "\n" +
            ActorProperty.GetInstance.HpReg + "\n" +
            ActorProperty.GetInstance.HpHitReg + "\n" +
            ActorProperty.GetInstance.HpKillReg + "\n" +
            ActorProperty.GetInstance.HpRegPerSpCost + "\n" +
            ActorProperty.GetInstance.HpReciFix + "\n" +
            ActorProperty.GetInstance.HpReciPer + "\n" +
            "\n" +
            "\n" +
            "\n" +
            ActorProperty.GetInstance.SpMax + "\n" +
            ActorProperty.GetInstance.SpReg + "\n" +
            ActorProperty.GetInstance.SpHitReg + "\n" +
            ActorProperty.GetInstance.SpKillReg + "\n" +
            "\n" +
            "\n" +
            "\n" +
            ActorProperty.GetInstance.Spd + "\n" +
            ActorProperty.GetInstance.GoldGet + "\n" +
            ActorProperty.GetInstance.ExpGet + "\n" +
            ActorProperty.GetInstance.ItemGet + "\n" +
            ActorProperty.GetInstance.GetRange + "\n";
    }
}
