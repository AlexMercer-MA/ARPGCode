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
        ActorPropertiesBasic.GetInstance.EvtPlayerPropertiesBaseChange += OnEvtPlayerPropertiesBaseChange;
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
        attributeTextArray[0].text = ActorPropertiesBasic.GetInstance.Str.ToString();
        attributeTextArray[1].text = ActorPropertiesBasic.GetInstance.Dex.ToString();
        attributeTextArray[2].text = ActorPropertiesBasic.GetInstance.Int.ToString();
        attributeTextArray[3].text = ActorPropertiesBasic.GetInstance.Spi.ToString();
        attributeTextArray[4].text = ActorPropertiesBasic.GetInstance.Cun.ToString();
        attributeTextArray[5].text = ActorPropertiesBasic.GetInstance.Vit.ToString();
    }
}
