using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeUI : MonoBehaviour
{
    public Image chargeImg;
    public ActionChargeBase actionChargeBase;

    void Update()
    {
        chargeImg.fillAmount = actionChargeBase.fillAmount;
    }
}
