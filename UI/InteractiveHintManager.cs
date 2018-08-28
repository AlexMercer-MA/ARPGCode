using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveHintManager : MonoBehaviour
{
    public static InteractiveHintManager GetInstance;
    public GameObject InteractiveHintObj;

    void Awake()
    {
        GetInstance = this;
    }

    void Start()
    {
        ScreenSpaceUIManager.GetInstance.EvtInteractiveHint_Open_Interactive += OnInteractiveHintOpen;
        ScreenSpaceUIManager.GetInstance.EvtInteractiveHint_Open_Item += OnItemHintOpen;
        ScreenSpaceUIManager.GetInstance.EvtInteractiveHint_Close += OnInteractiveHintClose;
    }

    void OnInteractiveHintOpen()
    {
        if (!GameController.GetInstance.bCanOperate || PanelUIManager.GetInstance.bInCenterPanelUIMode || PanelUIManager.GetInstance.b_Tab_PanelOpen)
            return;

        ScreenSpaceUIManager.GetInstance.OpenInteractiveHint();
    }

    void OnItemHintOpen()
    {
        if (!GameController.GetInstance.bCanOperate || PanelUIManager.GetInstance.bInCenterPanelUIMode || PanelUIManager.GetInstance.b_Tab_PanelOpen)
            return;

        ScreenSpaceUIManager.GetInstance.OpenItemHint();
    }

    void OnInteractiveHintOpen_Item()
    {

    }

    void OnInteractiveHintClose()
    {
        ScreenSpaceUIManager.GetInstance.CloseInteractiveHint();
    }
}
