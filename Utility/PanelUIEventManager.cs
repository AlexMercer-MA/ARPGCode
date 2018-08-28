using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUIEventManager : MonoBehaviour
{
    public static PanelUIEventManager GetInstance { get; set; }

    public System.Action EvtMenuPanel_Change;//事件 - 主面板改变
    public System.Action EvtExitPanel_Change;//事件 - 退出游戏面板改变
    public System.Action Evt_TAB_Panel_Show;//事件 - 喝药面板显示
    public System.Action Evt_TAB_Panel_Hide;//事件 - 喝药面板隐藏

    public System.Action EvtDungenEnterPanel_Open;//事件 - 地下城面板打开
    public System.Action EvtPortalEnterPanel_Open;//事件 - 传送门面板打开
    public System.Action EvtDungenEnterPanel_Close;//事件 - 地下城面板关闭
    public System.Action EvtPortalEnterPanel_Close;//事件 - 传送门面板关闭
    public System.Action EvtShopPanel_Change;//事件 - 商店面板改变
    public System.Action EvtQuestPanel_Change;//事件 - 任务面板改变

    public System.Action EvtCharacterPanel_Change;//事件 - 角色面板改变
    public System.Action EvtAttributePanel_Change;//事件 - 主属性面板改变
    public System.Action EvtBagPanel_Change;//事件 - 物品栏面板改变
    public System.Action EvtTalentPanel_Change;//事件 - 天赋面板改变
    public System.Action EvtMapPanel_Change;//事件 - 地图面板改变
    public System.Action EvtSkillPanel_Change;//事件 - 技能面板改变
    public System.Action EvtLogPanel_Change;//事件 - 日志面板改变

    public KeyCode MenuPanel_KeyCode = KeyCode.Escape;
    public KeyCode PotionPanel_KeyCode = KeyCode.Tab;

    public KeyCode CharacterPanel_KeyCode = KeyCode.C;
    public KeyCode AttributePanel_KeyCode = KeyCode.V;
    public KeyCode InventoryPanel_KeyCode = KeyCode.B;
    public KeyCode TalentPanel_KeyCode = KeyCode.N;
    public KeyCode MapPanel_KeyCode = KeyCode.M;
    public KeyCode SkillPanel_KeyCode = KeyCode.K;
    public KeyCode LogPanel_KeyCode = KeyCode.L;

    
    private void Awake()
    {
        GetInstance = this;
    }

    void Update ()
    {
		if(Input.GetKeyDown(MenuPanel_KeyCode))//Esc点击
        {
            EvtMenuPanel_Change();
        }
        if (Input.GetKeyDown(PotionPanel_KeyCode))//Tab按下
        {
            Evt_TAB_Panel_Show();
        }
        if (Input.GetKeyUp(PotionPanel_KeyCode))//Tab松开
        {
            Evt_TAB_Panel_Hide();
        }
        if (Input.GetKeyDown(CharacterPanel_KeyCode))//C点击
        {
            EvtCharacterPanel_Change();
        }
        if (Input.GetKeyDown(InventoryPanel_KeyCode))//B点击
        {
            EvtBagPanel_Change();
        }
        if (Input.GetKeyDown(AttributePanel_KeyCode))//V点击
        {
            EvtAttributePanel_Change();
        }
        if (Input.GetKeyDown(TalentPanel_KeyCode))//N点击
        {
            EvtTalentPanel_Change();
        }
        if (Input.GetKeyDown(MapPanel_KeyCode))//M点击
        {
            EvtMapPanel_Change();
        }
        if (Input.GetKeyDown(SkillPanel_KeyCode))//K点击
        {
            EvtSkillPanel_Change();
        }
        if (Input.GetKeyDown(LogPanel_KeyCode))//L点击
        {
            EvtLogPanel_Change();
        }
    }
}
