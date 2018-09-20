using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelUI_AttributePanel_Btn : MonoBehaviour
{

    public Button btn;
    public AttributePanel_ButtonType btnType;

    // Use this for initialization
    void Start()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClick);
    }
    
    void OnButtonClick()
    {
        if (AttributePanelManager.GetInstance.attributePoints > 0)
        {
            switch (btnType)
            {
                case AttributePanel_ButtonType.Str:
                    ActorPropertiesBasic.GetInstance.Str++;
                    AttributePanelManager.GetInstance.attributePoints--;
                    AttributePanelManager.GetInstance.OnAttributePointsChange();
                    break;

                case AttributePanel_ButtonType.Dex:
                    ActorPropertiesBasic.GetInstance.Dex++;
                    AttributePanelManager.GetInstance.attributePoints--;
                    AttributePanelManager.GetInstance.OnAttributePointsChange();
                    break;

                case AttributePanel_ButtonType.Int:
                    ActorPropertiesBasic.GetInstance.Int++;
                    AttributePanelManager.GetInstance.attributePoints--;
                    AttributePanelManager.GetInstance.OnAttributePointsChange();
                    break;

                case AttributePanel_ButtonType.Spi:
                    ActorPropertiesBasic.GetInstance.Spi++;
                    AttributePanelManager.GetInstance.attributePoints--;
                    AttributePanelManager.GetInstance.OnAttributePointsChange();
                    break;

                case AttributePanel_ButtonType.Cun:
                    ActorPropertiesBasic.GetInstance.Cun++;
                    AttributePanelManager.GetInstance.attributePoints--;
                    AttributePanelManager.GetInstance.OnAttributePointsChange();
                    break;

                case AttributePanel_ButtonType.Vit:
                    ActorPropertiesBasic.GetInstance.Vit++;
                    AttributePanelManager.GetInstance.attributePoints--;
                    AttributePanelManager.GetInstance.OnAttributePointsChange();
                    break;
            }
        }
    }
}

public enum AttributePanel_ButtonType
{
    Str,
    Dex,
    Int,
    Spi,
    Cun,
    Vit,
}
