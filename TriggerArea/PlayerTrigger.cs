using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour {

    //singleton
    public static PlayerTrigger GetInstance;
    bool canInteractive;

    public void Awake()
    {
        GetInstance = this;
    }
    public GameObject TriggerObj; //唯一触发区域
    public eTriggerType TriggerType;//唯一触发区域类型
    public List<GameObject> ItemsObj; //掉落物触发数组

    // Use this for initialization
    void Start ()
    {
        GameEventManager.GetInstance.EvtTriggerEnter += OnEvtTriggerEnter;
        GameEventManager.GetInstance.EvtTriggerStay += OnEvtTriggerStay;
        GameEventManager.GetInstance.EvtTriggerExit += OnEvtTriggerExit;
        InputEventManager.GetInstance.EvtInteractKeyPressed += OnInteractiveKeyPressed;
    }

    void OnEvtTriggerEnter(GameObject other, eTriggerType type)
    {
        if (type == eTriggerType.Item)
        {
            ItemsObj.Add(other);
            //ListAdd下表最大
        }
        else if (type == eTriggerType.DungeonEnter || type == eTriggerType.Portal || type == eTriggerType.Shop)
        {
            TriggerObj = other;
            TriggerType = type;
        }

        CheckStatus();
    }

    void OnEvtTriggerStay(GameObject other, eTriggerType type)
    {
        if (ScreenSpaceUIManager.GetInstance.bIsInteractiveHintShow)
        {
            if (PanelUIManager.GetInstance.bInCenterPanelUIMode || PanelUIManager.GetInstance.b_Tab_PanelOpen)
            {
                ScreenSpaceUIManager.GetInstance.EvtInteractiveHint_Close();
                canInteractive = false;
            }
            return;
        }

        if (!canInteractive)
        {
            canInteractive = true;
        }

        CheckStatus();
    }

    void OnEvtTriggerExit(GameObject other, eTriggerType type)
    {
        if (type == eTriggerType.Item)
        {
            for (int i = 0; i < ItemsObj.Count; i++)
            {
                if(other == ItemsObj[i])
                {
                    ItemsObj.Remove(other);
                    CheckStatus();
                }
            }
        }
        else if (type == eTriggerType.DungeonEnter || type == eTriggerType.Portal || type == eTriggerType.Shop)
        {
            if (other == TriggerObj)
            {
                //调用方法
                switch (TriggerType)
                {
                    case eTriggerType.DungeonEnter:
                        PanelUIEventManager.GetInstance.EvtDungenEnterPanel_Close();
                        break;
                    case eTriggerType.Portal:
                        PanelUIEventManager.GetInstance.EvtPortalEnterPanel_Close();
                        break;
                    case eTriggerType.Shop:
                        break;
                    default:
                        break;
                }
                TriggerObj = null;
                CheckStatus();
            }
        }
    }

    public void OnInteractiveKeyPressed()
    {
        if (!canInteractive) return;

        if (ItemsObj.Count > 0)
        {
            Debug.Log(ItemsObj[ItemsObj.Count - 1].GetComponent<Transform>().name);
            GameObject temp = ItemsObj[ItemsObj.Count - 1];
            ItemsObj.Remove(ItemsObj[ItemsObj.Count - 1]);
            Destroy(temp);
            CheckStatus();
        }
        else if (TriggerObj)
        {
            //调用方法
            switch (TriggerType)
            {
                case eTriggerType.DungeonEnter:
                    PanelUIEventManager.GetInstance.EvtDungenEnterPanel_Open();
                    break;
                case eTriggerType.Portal:
                    PanelUIEventManager.GetInstance.EvtPortalEnterPanel_Open();
                    break;
                case eTriggerType.Shop:
                    break;
                default:
                    break;
            }
        }
    }

    void CheckStatus()
    {
        if (ItemsObj.Count > 0)
        {
            ScreenSpaceUIManager.GetInstance.EvtInteractiveHint_Open_Item();
            //先改文字 再显示出来
            canInteractive = true;
            return;
        }
        else if (TriggerObj)
        {
            ScreenSpaceUIManager.GetInstance.EvtInteractiveHint_Open_Interactive();
            canInteractive = true;
            return;
        }
        else
        {
            ScreenSpaceUIManager.GetInstance.EvtInteractiveHint_Close();
            canInteractive = false;
            return;
        }
    }
}
