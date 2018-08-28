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
            PlayerPropertiesFinal.GetInstance.Str + "\n" +
            PlayerPropertiesFinal.GetInstance.Dex + "\n" +
            PlayerPropertiesFinal.GetInstance.Int + "\n" +
            PlayerPropertiesFinal.GetInstance.Spi + "\n" +
            PlayerPropertiesFinal.GetInstance.Cun + "\n" +
            PlayerPropertiesFinal.GetInstance.Vit + "\n" +
            "\n" +
            "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.PhyMeleeMin + "-" + PlayerPropertiesFinal.GetInstance.PhyMeleeMax + "\n" +
            PlayerPropertiesFinal.GetInstance.PhyRangeMin + "-" + PlayerPropertiesFinal.GetInstance.PhyRangeMax + "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.MgiMin + "-" + PlayerPropertiesFinal.GetInstance.MgiMax + "\n" +
            PlayerPropertiesFinal.GetInstance.FireDmgMax + "-" + PlayerPropertiesFinal.GetInstance.FireDmgMin + "\n" +
            PlayerPropertiesFinal.GetInstance.IceDmgMax + "-" + PlayerPropertiesFinal.GetInstance.IceDmgMin + "\n" +
            PlayerPropertiesFinal.GetInstance.LightningDmgMax + "-" + PlayerPropertiesFinal.GetInstance.LightningDmgMin + "\n" +
            PlayerPropertiesFinal.GetInstance.PoisonDmgMax + "-" + PlayerPropertiesFinal.GetInstance.PoisonDmgMin + "\n" +
            PlayerPropertiesFinal.GetInstance.ArcaneDmgMax + "-" + PlayerPropertiesFinal.GetInstance.ArcaneDmgMin + "\n" +
            PlayerPropertiesFinal.GetInstance.HolyDmgMax + "-" + PlayerPropertiesFinal.GetInstance.HolyDmgMin + "\n" +
            PlayerPropertiesFinal.GetInstance.ShadowDmgMax + "-" + PlayerPropertiesFinal.GetInstance.ShadowDmgMin + "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.Ias + "\n" +
            PlayerPropertiesFinal.GetInstance.Acc + "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.CriPhyMeleeCha + "\n" +
            PlayerPropertiesFinal.GetInstance.CriPhyMeleeDmg + "\n" +
            PlayerPropertiesFinal.GetInstance.CriPhyRangeCha + "\n" +
            PlayerPropertiesFinal.GetInstance.CriPhyRangeDmg + "\n" +
            PlayerPropertiesFinal.GetInstance.CriMgiCha + "\n" +
            PlayerPropertiesFinal.GetInstance.CriMgiDmg + "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.AmrPeneFix + "\n" +
            PlayerPropertiesFinal.GetInstance.AmrPenePer + "\n" +
            PlayerPropertiesFinal.GetInstance.ResPeneFix + "\n" +
            PlayerPropertiesFinal.GetInstance.ResPenePer + "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.Cdr + "\n" +
            PlayerPropertiesFinal.GetInstance.Csr + "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.HumanDmg + "\n" +
            PlayerPropertiesFinal.GetInstance.BeastDmg + "\n" +
            PlayerPropertiesFinal.GetInstance.UndeadDmg + "\n" +
            PlayerPropertiesFinal.GetInstance.DragonDmg + "\n" +
            PlayerPropertiesFinal.GetInstance.DemonDmg + "\n" +
            PlayerPropertiesFinal.GetInstance.ElementDmg + "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.NormalDmg + "\n" +
            PlayerPropertiesFinal.GetInstance.EliteDmg + "\n" +
            PlayerPropertiesFinal.GetInstance.BossDmg + "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.FinalDmgBoost + "\n" +
            "\n" +
            "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.Amr + "\n" +
            PlayerPropertiesFinal.GetInstance.Res + "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.FireRes + "\n" +
            PlayerPropertiesFinal.GetInstance.IceRes + "\n" +
            PlayerPropertiesFinal.GetInstance.LightningRes + "\n" +
            PlayerPropertiesFinal.GetInstance.PoisonRes + "\n" +
            PlayerPropertiesFinal.GetInstance.ShadowRes + "\n" +
            PlayerPropertiesFinal.GetInstance.HolyRes + "\n" +
            PlayerPropertiesFinal.GetInstance.ArcaneRes + "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.BlkCha + "\n" +
            PlayerPropertiesFinal.GetInstance.BlkFix + "\n" +
            PlayerPropertiesFinal.GetInstance.BlkPer + "\n" +
            PlayerPropertiesFinal.GetInstance.Eva + "\n" +
            PlayerPropertiesFinal.GetInstance.Tough + "\n" +
            PlayerPropertiesFinal.GetInstance.Thorns + "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.MeleeDmgReduce + "\n" +
            PlayerPropertiesFinal.GetInstance.RangeDmgReduce + "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.FinalDmgReduce + "\n" +
            "\n" +
            "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.HpMax + "\n" +
            PlayerPropertiesFinal.GetInstance.HpReg + "\n" +
            PlayerPropertiesFinal.GetInstance.HpHitReg + "\n" +
            PlayerPropertiesFinal.GetInstance.HpKillReg + "\n" +
            PlayerPropertiesFinal.GetInstance.HpRegPerSpCost + "\n" +
            PlayerPropertiesFinal.GetInstance.HpReciFix + "\n" +
            PlayerPropertiesFinal.GetInstance.HpReciPer + "\n" +
            "\n" +
            "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.SpMax + "\n" +
            PlayerPropertiesFinal.GetInstance.SpReg + "\n" +
            PlayerPropertiesFinal.GetInstance.SpHitReg + "\n" +
            PlayerPropertiesFinal.GetInstance.SpKillReg + "\n" +
            "\n" +
            "\n" +
            "\n" +
            PlayerPropertiesFinal.GetInstance.Spd + "\n" +
            PlayerPropertiesFinal.GetInstance.GoldGet + "\n" +
            PlayerPropertiesFinal.GetInstance.ExpGet + "\n" +
            PlayerPropertiesFinal.GetInstance.ItemGet + "\n" +
            PlayerPropertiesFinal.GetInstance.GetRange + "\n";
    }
}
