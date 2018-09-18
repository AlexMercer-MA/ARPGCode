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
                    ActorPropertiesBase.GetInstance.Str++;
                    AttributePanelManager.GetInstance.attributePoints--;
                    AttributePanelManager.GetInstance.OnAttributePointsChange();
                    break;

                case AttributePanel_ButtonType.Dex:
                    ActorPropertiesBase.GetInstance.Dex++;
                    AttributePanelManager.GetInstance.attributePoints--;
                    AttributePanelManager.GetInstance.OnAttributePointsChange();
                    break;

                case AttributePanel_ButtonType.Int:
                    ActorPropertiesBase.GetInstance.Int++;
                    AttributePanelManager.GetInstance.attributePoints--;
                    AttributePanelManager.GetInstance.OnAttributePointsChange();
                    break;

                case AttributePanel_ButtonType.Spi:
                    ActorPropertiesBase.GetInstance.Spi++;
                    AttributePanelManager.GetInstance.attributePoints--;
                    AttributePanelManager.GetInstance.OnAttributePointsChange();
                    break;

                case AttributePanel_ButtonType.Cun:
                    ActorPropertiesBase.GetInstance.Cun++;
                    AttributePanelManager.GetInstance.attributePoints--;
                    AttributePanelManager.GetInstance.OnAttributePointsChange();
                    break;

                case AttributePanel_ButtonType.Vit:
                    ActorPropertiesBase.GetInstance.Vit++;
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
