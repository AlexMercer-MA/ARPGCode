using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseBtn : MonoBehaviour
{
    public Button btn;
    public CloseBtn_Type btnType;

    void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(CloseBtnClick);
    }
    
    public void CloseBtnClick()
    {
        switch (btnType)
        {
            case CloseBtn_Type.Character:
                PanelUIEventManager.GetInstance.EvtCharacterPanel_Change();
                break;
            case CloseBtn_Type.Properties:
                CharacterPanelManager.GetInstance.HidePropertiesPanel();
                break;
            case CloseBtn_Type.Attributes:
                PanelUIEventManager.GetInstance.EvtAttributePanel_Change();
                break;
            case CloseBtn_Type.Inventory:
                PanelUIEventManager.GetInstance.EvtBagPanel_Change();
                break;
            case CloseBtn_Type.Talent:
                PanelUIEventManager.GetInstance.EvtTalentPanel_Change();
                break;
            case CloseBtn_Type.Map:
                PanelUIEventManager.GetInstance.EvtMapPanel_Change();
                break;
            case CloseBtn_Type.Skill:
                PanelUIEventManager.GetInstance.EvtSkillPanel_Change();
                break;
            case CloseBtn_Type.Log:
                PanelUIEventManager.GetInstance.EvtLogPanel_Change();
                break;
            case CloseBtn_Type.Exit:
                PanelUIEventManager.GetInstance.EvtExitPanel_Change();
                break;
            case CloseBtn_Type.PortalEnter:
                PanelUIEventManager.GetInstance.EvtPortalEnterPanel_Close();
                break;
            case CloseBtn_Type.DungenEnter:
                PanelUIEventManager.GetInstance.EvtDungenEnterPanel_Close();
                break;
            case CloseBtn_Type.Shop:
                PanelUIEventManager.GetInstance.EvtShopPanel_Change();
                break;
            case CloseBtn_Type.Quest:
                PanelUIEventManager.GetInstance.EvtQuestPanel_Change();
                break;
        }
        //操作完之后检查是否锁定镜头和显示鼠标
        PanelUIManager.GetInstance.CheckInUIMode_AllPanel();
        CursorController.GetInstance.CheckCursor();
    }
}

public enum CloseBtn_Type
{
    Character,
    Properties,
    Attributes,
    Inventory,
    Talent,
    Map,
    Skill,
    Log,
    Exit,
    DungenEnter,
    PortalEnter,
    Shop,
    Quest,
}
