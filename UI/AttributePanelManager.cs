using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributePanelManager : MonoBehaviour {

    public static AttributePanelManager GetInstance;
    public int attributePoints;
    public Text attributePointsText;
    public Text[] attributeTextArray;
    public Button[] attributeButtonArray;
    public bool bHavePointsLeft;

    
    void Awake ()
    {
        GetInstance = this;
    }

    private void Start()
    {
        ActorPropertiesBase.GetInstance.EvtPlayerPropertiesBaseChange += OnEvtPlayerPropertiesBaseChange;
        OnAttributePointsChange();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            GetAttributePoints(5);
        }
    }

    void GetAttributePoints (int num)
    {
        attributePoints += num;
        OnAttributePointsChange();
    }

    //刷新底部剩余点数数字，检查是否还有剩余点数，决定图标显示状态是不是Disabled
    public void OnAttributePointsChange()
    {
        if (bHavePointsLeft)
        {
            if (attributePoints <= 0)
            {
                foreach (var item in attributeButtonArray)
                {
                    item.interactable = false;
                }
                bHavePointsLeft = false;
            }
        }
        else
        {
            if (attributePoints > 0)
            {
                foreach (var item in attributeButtonArray)
                {
                    item.interactable = true;
                }
                bHavePointsLeft = true;
            }
        }
        attributePointsText.text = "Attribute Points: " + attributePoints.ToString();
    }

    void OnEvtPlayerPropertiesBaseChange()
    {
        attributeTextArray[0].text = ActorPropertiesBase.GetInstance.Str.ToString();
        attributeTextArray[1].text = ActorPropertiesBase.GetInstance.Dex.ToString();
        attributeTextArray[2].text = ActorPropertiesBase.GetInstance.Int.ToString();
        attributeTextArray[3].text = ActorPropertiesBase.GetInstance.Spi.ToString();
        attributeTextArray[4].text = ActorPropertiesBase.GetInstance.Cun.ToString();
        attributeTextArray[5].text = ActorPropertiesBase.GetInstance.Vit.ToString();
    }
}
