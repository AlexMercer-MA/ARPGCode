using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float H { get; set; }
    public float V { get; set; }
    public bool Jump { get; set; }
    public ActionKey ActionKey { get; set; }

    void Awake()
    {
        //Axis 轴值输入
        H = Input.GetAxisRaw("Horizontal");
        V = Input.GetAxisRaw("Vertical");
        //jump 是否进行了 跳跃按键输入
        jump = Input.GetButtonDown("Action_Space") ? true : false;
        //Action 是否进行了 动作按键输入，有优先级(Tab>Shift>Ctrl>4>3>2>1>R>E>Q>RMB>LMB)
        if (Input.GetButton("Action_Tab"))
            actionKey = ActionKey.Action_Tab;
        else if (Input.GetButton("Action_Shift"))
            actionKey = ActionKey.Action_Shift;
        else if (Input.GetButton("Action_Ctrl"))
            actionKey = ActionKey.Action_Ctrl;
        else if (Input.GetButton("Action_4"))
            actionKey = ActionKey.Action_4;
        else if (Input.GetButton("Action_3"))
            actionKey = ActionKey.Action_3;
        else if (Input.GetButton("Action_2"))
            actionKey = ActionKey.Action_2;
        else if (Input.GetButton("Action_1"))
            actionKey = ActionKey.Action_1;
        else if (Input.GetButton("Action_R"))
            actionKey = ActionKey.Action_R;
        else if (Input.GetButton("Action_E"))
            actionKey = ActionKey.Action_E;
        else if (Input.GetButton("Action_Q"))
            actionKey = ActionKey.Action_Q;
        else if (Input.GetMouseButton(1))
            actionKey = ActionKey.Action_RMB;
        else if (Input.GetMouseButton(0))
            actionKey = ActionKey.Action_LMB;
        else
            actionKey = ActionKey.None;
    }
}
