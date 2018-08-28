using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelUI_MenuPanel_Btn : MonoBehaviour {

    public Button btn;
    public CharacterPanel_ButtonType btnType;
    
	void Start ()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClick);
    }
	
	void OnButtonClick()
    {
        switch (btnType)
        {
            case CharacterPanel_ButtonType.CharacterButton:
                PanelUIEventManager.GetInstance.EvtCharacterPanel_Change();
                break;

            case CharacterPanel_ButtonType.AttributeButton:
                PanelUIEventManager.GetInstance.EvtAttributePanel_Change();
                break;

            case CharacterPanel_ButtonType.InventoryButton:
                PanelUIEventManager.GetInstance.EvtBagPanel_Change();
                break;

            case CharacterPanel_ButtonType.ExitButton:
                PanelUIEventManager.GetInstance.EvtExitPanel_Change();
                break;

            case CharacterPanel_ButtonType.MapButton:
                PanelUIEventManager.GetInstance.EvtMapPanel_Change();
                break;

            case CharacterPanel_ButtonType.SkillButton:
                PanelUIEventManager.GetInstance.EvtSkillPanel_Change();
                break;

            case CharacterPanel_ButtonType.LogButton:
                PanelUIEventManager.GetInstance.EvtLogPanel_Change();
                break;
        }
    }
}

public enum CharacterPanel_ButtonType
{
    CharacterButton,
    AttributeButton,
    InventoryButton,
    ExitButton,
    MapButton,
    SkillButton,
    LogButton,
}
