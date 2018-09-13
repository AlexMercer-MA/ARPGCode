using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ActionSelfAOE
 * 属性：
 * AOE范围
 * AOE角度
 * 
 * 方法：
 * 球形检测
 * 清除检测组
 * 
 * */
public class ActionSelfAOE : ActionBase
{
    public float range;
    public float angle;

    protected void SphereDetect()
    {
        Physics.OverlapSphere(this.transform.position, this.range);
    }

    protected void ClearDetectGroup()
    {

    }
}