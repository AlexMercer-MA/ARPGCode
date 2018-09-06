using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPanelUIManager : MonoBehaviour {

    public static ActionPanelUIManager GetInstance { get; set; }

    public UI_ActionIcon UI_Action_Tab;
    public UI_ActionIcon UI_Action_LMB;
    public UI_ActionIcon UI_Action_RMB;
    public UI_ActionIcon UI_Action_Shift;
    public UI_ActionIcon UI_Action_Ctrl;
    public UI_ActionIcon UI_Action_Q;
    public UI_ActionIcon UI_Action_E;
    public UI_ActionIcon UI_Action_R;
    public UI_ActionIcon UI_Action_1;
    public UI_ActionIcon UI_Action_2;
    public UI_ActionIcon UI_Action_3;
    public UI_ActionIcon UI_Action_4;

    private void Awake()
    {
        GetInstance = this;
    }

    private void Start()
    {
        ActionManager.GetInstance.EvtActionPreCheck += OnActionPreCheck;
    }

    private void OnActionPreCheck(object obj,EventArgs e)
    {

    }

    public void SetHighLightUI(ActionKey action)
    {
        switch (action)
        {
            case ActionKey.Action_Q:
                break;
            case ActionKey.Action_E:
                break;
            case ActionKey.Action_R:
                break;
            case ActionKey.Action_1:
                break;
            case ActionKey.Action_2:
                break;
            case ActionKey.Action_3:
                break;
            case ActionKey.Action_4:
                break;
            case ActionKey.Action_Shift:
                break;
            case ActionKey.Action_Ctrl:
                break;
            case ActionKey.Action_Tab:
                break;
            case ActionKey.Action_LMB:
                break;
            case ActionKey.Action_RMB:
                break;
            case ActionKey.None:
                break;
            default:
                break;
        }
    }

    public void ResetUI()
    {
        //取消所有高亮UI

    }
}
