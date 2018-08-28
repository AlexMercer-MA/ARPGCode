using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageBuffUI : MonoBehaviour
{
    public Image buffImg;
    public ActionBuffBase actionBuffBase;
    public Vector3 activeColor = new Vector3(1f, 0.25f, 0.25f);

    void Update()
    {
        if (actionBuffBase.haveBuff)
        {
            buffImg.color = new Color(activeColor.x, activeColor.y, activeColor.z, 1f);
        }
        else
        {
            buffImg.color = Color.clear;
        }
    }
}
