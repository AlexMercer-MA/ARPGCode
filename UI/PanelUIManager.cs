using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelUIManager : MonoBehaviour {

    //************提示************
    //调用完所有SetXXXVisibility之后一定要 检查是否在UI模式 去判断鼠标是否可见
    //CheckInUIMode_AllPanel();
    //CursorController.GetInstance.CheckCursor();

    public static PanelUIManager GetInstance;

    public bool bInPanelUIMode = false;//所有Panel面板 是否有任何一个打开
    public bool bInCenterPanelUIMode = false;//中间的交互面板 是否有任何一个打开

    public GameObject Tab_Panel;//Tab(此面板不显示鼠标)

    public GameObject menuPanel;//Esc

    //CenterPanel
    public GameObject exitPanel;//需要鼠标按Button
    public GameObject dungenEnterPanel;//进入地下城面板
    public GameObject portalEnterPanel;//传送门面板
    public GameObject shopPanel;//商店页面
    public GameObject questPanel;//任务界面

    //Panel
    public GameObject characterPanel;//C
    public GameObject attributePanel;//V
    public GameObject bagPanel;//B
    public GameObject talentPanel;//N
    public GameObject mapPanel;//M
    public GameObject skillPanel;//K
    public GameObject logPanel;//L
    
    public bool b_Tab_PanelOpen;//Tab

    public bool bMenuPanelOpen;//Esc
    public bool bExitPanelOpen;//需要鼠标按Button

    public bool bDungenEnterPanel;//进入地下城面板
    public bool bPortalEnterPanel;//传送门面板
    public bool bShopPanel;//商店页面
    public bool bQuestPanel;//任务界面

    public bool bCharacterPanelOpen;//C
    public bool bAttributePanelOpen;//V
    public bool bBagPanelOpen;//B
    public bool bTalentPanelOpen;//N
    public bool bMapPanelOpen;//M
    public bool bSkillPanelOpen;//K
    public bool bLogPanelOpen;//L
    
    private void Awake()
    {
        GetInstance = this;
    }

    void Start()
    {
        PanelUIEventManager.GetInstance.EvtMenuPanel_Change += OnMenuPanelChange;
        PanelUIEventManager.GetInstance.Evt_TAB_Panel_Show += On_TAB_PanelShow;
        PanelUIEventManager.GetInstance.Evt_TAB_Panel_Hide += On_TAB_PanelHide;
        PanelUIEventManager.GetInstance.EvtExitPanel_Change += OnExitPanelChange;
        
        PanelUIEventManager.GetInstance.EvtShopPanel_Change += OnShopPanelChange;
        PanelUIEventManager.GetInstance.EvtQuestPanel_Change += OnQuestPanelChange;

        PanelUIEventManager.GetInstance.EvtCharacterPanel_Change += OnCharacterPanelChange;
        PanelUIEventManager.GetInstance.EvtAttributePanel_Change += OnAttributePanelChange;
        PanelUIEventManager.GetInstance.EvtBagPanel_Change += OnBagPanelChange;
        PanelUIEventManager.GetInstance.EvtTalentPanel_Change += OnTalentPanelChange;
        PanelUIEventManager.GetInstance.EvtMapPanel_Change += OnMapPanelChange;
        PanelUIEventManager.GetInstance.EvtLogPanel_Change += OnLogPanelChange;
        PanelUIEventManager.GetInstance.EvtSkillPanel_Change += OnSkillPanelChange;

        PanelUIEventManager.GetInstance.EvtDungenEnterPanel_Open += OnDungeonPanelOpen;
        PanelUIEventManager.GetInstance.EvtDungenEnterPanel_Close += OnDungeonPanelClose;

        PanelUIEventManager.GetInstance.EvtPortalEnterPanel_Open += OnPortalPanelOpen;
        PanelUIEventManager.GetInstance.EvtPortalEnterPanel_Close += OnPortalPanelClose;

    }

    void OnMenuPanelChange()
    {
        if (!GameController.GetInstance.bCanOperate || b_Tab_PanelOpen)
            return;
        
        //UIPanel全都关闭了的时候，打开Menu菜单
        if (!CheckInUIMode_AllPanel())
        {
            bMenuPanelOpen = true;
            SetMenuPanelVisibility(bMenuPanelOpen);
        }
        else
        //UIPanel还有正在显示的，则关闭所有Panel
        {
            CloseAllPanel();//关闭所有UI
        }
        
        CheckInUIMode_AllPanel();
        CheckInUIMode_AllCenterPanel();
        CursorController.GetInstance.CheckCursor();
    }

    public void SetMenuPanelVisibility(bool visiblity)
    {
        bMenuPanelOpen = visiblity;
        CanvasGroup tempCanvasGroup = menuPanel.GetComponent<CanvasGroup>();
        tempCanvasGroup.alpha = visiblity ? 1 : 0;
        tempCanvasGroup.blocksRaycasts = visiblity;
        tempCanvasGroup.interactable = visiblity;
    }
    
    void On_TAB_PanelShow()
    {
        if (!GameController.GetInstance.bCanOperate || bExitPanelOpen)
            return;

        CloseAllPanel();

        b_Tab_PanelOpen = true;
        Set_TAB_PanelVisibility(b_Tab_PanelOpen);
        CheckInUIMode_AllPanel();
        CheckInUIMode_AllCenterPanel();
        CursorController.GetInstance.CheckCursor();
    }

    void On_TAB_PanelHide()
    {
        if (!GameController.GetInstance.bCanOperate)
            return;

        b_Tab_PanelOpen = false;
        Set_TAB_PanelVisibility(b_Tab_PanelOpen);
        CheckInUIMode_AllPanel();
        CheckInUIMode_AllCenterPanel();
        CursorController.GetInstance.CheckCursor();
    }

    public void Set_TAB_PanelVisibility(bool visiblity)
    {
        b_Tab_PanelOpen = visiblity;
        CanvasGroup tempCanvasGroup = Tab_Panel.GetComponent<CanvasGroup>();
        tempCanvasGroup.alpha = visiblity ? 1 : 0;
        tempCanvasGroup.blocksRaycasts = visiblity;
        tempCanvasGroup.interactable = visiblity;
    }

    void OnExitPanelChange()
    {
        if (!GameController.GetInstance.bCanOperate /*|| b_Tab_PanelOpen*/)
            return;

        bExitPanelOpen = !bExitPanelOpen;
        SetExitPanelVisibility(bExitPanelOpen);

        if (bExitPanelOpen)
        {
            SetDungenPanelVisibility(false);
            SetPortalPanelVisibility(false);
            SetShopEnterPanelVisibility(false);
            SetQuestPanelVisibility(false);
            CloseAllPanelExceptExit();
        }

        CheckInUIMode_AllPanel();
        CheckInUIMode_AllCenterPanel();
        CursorController.GetInstance.CheckCursor();
    }

    public void SetExitPanelVisibility(bool visiblity)
    {
        bExitPanelOpen = visiblity;
        CanvasGroup tempCanvasGroup = exitPanel.GetComponent<CanvasGroup>();
        tempCanvasGroup.alpha = visiblity ? 1 : 0;
        tempCanvasGroup.blocksRaycasts = visiblity;
        tempCanvasGroup.interactable = visiblity;
    }

    void OnDungenTriggerEnter()
    {
        if (!GameController.GetInstance.bCanOperate || b_Tab_PanelOpen || bExitPanelOpen)
            return;
        
        CursorController.GetInstance.CheckCursor();
    }
    
    void OnDungenTriggerExit()
    {
        if (!GameController.GetInstance.bCanOperate || !bDungenEnterPanel)
            return;

        bDungenEnterPanel = false;
        SetDungenPanelVisibility(bDungenEnterPanel);
        SetDungenPanelVisibility(false);

        CheckInUIMode_AllPanel();
        CheckInUIMode_AllCenterPanel();
        CursorController.GetInstance.CheckCursor();
    }

    void OnDungeonPanelOpen()
    {
        if (!GameController.GetInstance.bCanOperate || b_Tab_PanelOpen || bExitPanelOpen)
            return;
        
        CloseAllPanel();

        SetDungenPanelVisibility(true);

        //TODO 关闭Hint提示

        CheckInUIMode_AllPanel();
        CheckInUIMode_AllCenterPanel();
        CursorController.GetInstance.CheckCursor();
    }

    void OnDungeonPanelClose()
    {
        SetDungenPanelVisibility(false);
        
        CheckInUIMode_AllPanel();
        CheckInUIMode_AllCenterPanel();
        CursorController.GetInstance.CheckCursor();
    }

    public void SetDungenPanelVisibility(bool visiblity)
    {
        bDungenEnterPanel = visiblity;
        CanvasGroup tempCanvasGroup = dungenEnterPanel.GetComponent<CanvasGroup>();
        tempCanvasGroup.alpha = visiblity ? 1 : 0;
        tempCanvasGroup.blocksRaycasts = visiblity;
        tempCanvasGroup.interactable = visiblity;

        if (!visiblity)
        {
            DungeonDifficultyManager.GetInstance.CloseDropDownList();
        }
    }

    //------------------------------------------------------------------------------------------------------------------
    void OnPortalTriggerEnter()
    {
        if (!GameController.GetInstance.bCanOperate || b_Tab_PanelOpen || bExitPanelOpen)
            return;

        CursorController.GetInstance.CheckCursor();
    }

    void OnPortalTriggerExit()
    {
        if (!GameController.GetInstance.bCanOperate || !bPortalEnterPanel)
            return;

        bPortalEnterPanel = false;
        SetPortalPanelVisibility(bPortalEnterPanel);

        CheckInUIMode_AllPanel();
        CheckInUIMode_AllCenterPanel();
        CursorController.GetInstance.CheckCursor();
    }

    void OnPortalPanelOpen()
    {
        if (!GameController.GetInstance.bCanOperate || b_Tab_PanelOpen || bExitPanelOpen)
            return;

        CloseAllPanel();

        bPortalEnterPanel = true;
        SetPortalPanelVisibility(bPortalEnterPanel);

        //TODO 关闭Hint提示

        CheckInUIMode_AllPanel();
        CheckInUIMode_AllCenterPanel();
        CursorController.GetInstance.CheckCursor();
    }

    void OnPortalPanelClose()
    {
        bPortalEnterPanel = false;
        SetPortalPanelVisibility(bPortalEnterPanel);

        CheckInUIMode_AllPanel();
        CheckInUIMode_AllCenterPanel();
        CursorController.GetInstance.CheckCursor();
    }

    public void SetPortalPanelVisibility(bool visiblity)
    {
        bPortalEnterPanel = visiblity;
        CanvasGroup tempCanvasGroup = portalEnterPanel.GetComponent<CanvasGroup>();
        tempCanvasGroup.alpha = visiblity ? 1 : 0;
        tempCanvasGroup.blocksRaycasts = visiblity;
        tempCanvasGroup.interactable = visiblity;
    }
    
    void OnShopPanelChange()
    {
        if (!GameController.GetInstance.bCanOperate)
            return;

        SetShopEnterPanelVisibility(!bShopPanel);

        if (bShopPanel)
        {
            SetExitPanelVisibility(false);
            SetDungenPanelVisibility(false);
            SetPortalPanelVisibility(false);
            SetQuestPanelVisibility(false);
            SetCharacterPanelVisibility(true);
            SetBagPanelVisibility(true);
        }
        CheckInUIMode_AllPanel();
        CheckInUIMode_AllCenterPanel();
        CursorController.GetInstance.CheckCursor();
    }

    public void SetShopEnterPanelVisibility(bool visiblity)
    {
        bShopPanel = visiblity;
        CanvasGroup tempCanvasGroup = shopPanel.GetComponent<CanvasGroup>();
        tempCanvasGroup.alpha = visiblity ? 1 : 0;
        tempCanvasGroup.blocksRaycasts = visiblity;
        tempCanvasGroup.interactable = visiblity;
    }

    void OnQuestPanelChange()
    {
        if (!GameController.GetInstance.bCanOperate)
            return;
        
        SetQuestPanelVisibility(!bQuestPanel);

        if (bQuestPanel)
        {
            SetExitPanelVisibility(false);
            SetDungenPanelVisibility(false);
            SetPortalPanelVisibility(false);
            SetQuestPanelVisibility(false);
            SetMapPanelVisibility(false);
            SetSkillPanelVisibility(false);
            SetLogPanelVisibility(true);
        }
        CheckInUIMode_AllPanel();
        CheckInUIMode_AllCenterPanel();
        CursorController.GetInstance.CheckCursor();
    }

    public void SetQuestPanelVisibility(bool visiblity)
    {
        bQuestPanel = visiblity;
        CanvasGroup tempCanvasGroup = questPanel.GetComponent<CanvasGroup>();
        tempCanvasGroup.alpha = visiblity ? 1 : 0;
        tempCanvasGroup.blocksRaycasts = visiblity;
        tempCanvasGroup.interactable = visiblity;
    }

    //CenterPanel 结束

    void OnCharacterPanelChange()
    {
        if (!GameController.GetInstance.bCanOperate || b_Tab_PanelOpen || bExitPanelOpen)
            return;

        SetCharacterPanelVisibility(!bCharacterPanelOpen);

        if (bCharacterPanelOpen)
        {
            SetDungenPanelVisibility(false);
            SetPortalPanelVisibility(false);
        }

        CheckInUIMode_AllPanel();
        CursorController.GetInstance.CheckCursor();
    }

    public void SetCharacterPanelVisibility(bool visiblity)
    {
        bCharacterPanelOpen = visiblity;
        CanvasGroup tempCanvasGroup = characterPanel.GetComponent<CanvasGroup>();
        tempCanvasGroup.alpha = visiblity ? 1 : 0;
        tempCanvasGroup.blocksRaycasts = visiblity;
        tempCanvasGroup.interactable = visiblity;
    }

    void OnBagPanelChange()
    {
        if (!GameController.GetInstance.bCanOperate || b_Tab_PanelOpen || bExitPanelOpen)
            return;
        
        SetBagPanelVisibility(!bBagPanelOpen);

        if (bBagPanelOpen)
        {
            SetAttributePanelVisibility(false);
            SetTalentPanelVisibility(false);
            SetMapPanelVisibility(false);
            SetSkillPanelVisibility(false);
            SetDungenPanelVisibility(false);
            SetPortalPanelVisibility(false);
        }
        CheckInUIMode_AllPanel();
        CursorController.GetInstance.CheckCursor();
    }

    public void SetBagPanelVisibility(bool visiblity)
    {
        bBagPanelOpen = visiblity;
        CanvasGroup tempCanvasGroup = bagPanel.GetComponent<CanvasGroup>();
        tempCanvasGroup.alpha = visiblity ? 1 : 0;
        tempCanvasGroup.blocksRaycasts = visiblity;
        tempCanvasGroup.interactable = visiblity;
    }

    void OnAttributePanelChange()
    {
        if (!GameController.GetInstance.bCanOperate || b_Tab_PanelOpen || bExitPanelOpen)
            return;
        
        SetAttributePanelVisibility(!bAttributePanelOpen);

        if (bAttributePanelOpen)
        {
            SetBagPanelVisibility(false);
            SetTalentPanelVisibility(false);
            SetMapPanelVisibility(false);
            SetSkillPanelVisibility(false);
            SetDungenPanelVisibility(false);
            SetPortalPanelVisibility(false);
        }
        CheckInUIMode_AllPanel();
        CursorController.GetInstance.CheckCursor();
    }

    public void SetAttributePanelVisibility(bool visiblity)
    {
        bAttributePanelOpen = visiblity;
        CanvasGroup tempCanvasGroup = attributePanel.GetComponent<CanvasGroup>();
        tempCanvasGroup.alpha = visiblity ? 1 : 0;
        tempCanvasGroup.blocksRaycasts = visiblity;
        tempCanvasGroup.interactable = visiblity;
    }

    void OnTalentPanelChange()
    {
        if (!GameController.GetInstance.bCanOperate || b_Tab_PanelOpen || bExitPanelOpen)
            return;

        SetTalentPanelVisibility(!bTalentPanelOpen);

        if (bTalentPanelOpen)
        {
            SetAttributePanelVisibility(false);
            SetBagPanelVisibility(false);
            SetMapPanelVisibility(false);
            SetSkillPanelVisibility(false);
            SetDungenPanelVisibility(false);
            SetPortalPanelVisibility(false);
        }
        CheckInUIMode_AllPanel();
        CursorController.GetInstance.CheckCursor();
    }

    public void SetTalentPanelVisibility(bool visiblity)
    {
        bTalentPanelOpen = visiblity;
        CanvasGroup tempCanvasGroup = talentPanel.GetComponent<CanvasGroup>();
        tempCanvasGroup.alpha = visiblity ? 1 : 0;
        tempCanvasGroup.blocksRaycasts = visiblity;
        tempCanvasGroup.interactable = visiblity;
    }

    void OnMapPanelChange()
    {
        if (!GameController.GetInstance.bCanOperate || b_Tab_PanelOpen || bExitPanelOpen)
            return;

        SetMapPanelVisibility(!bMapPanelOpen);

        if (bMapPanelOpen)
        {
            SetAttributePanelVisibility(false);
            SetBagPanelVisibility(false);
            SetTalentPanelVisibility(false);
            SetSkillPanelVisibility(false);
            SetDungenPanelVisibility(false);
            SetPortalPanelVisibility(false);
        }
        CheckInUIMode_AllPanel();
        CursorController.GetInstance.CheckCursor();
    }

    public void SetMapPanelVisibility(bool visiblity)
    {
        bMapPanelOpen = visiblity;
        CanvasGroup tempCanvasGroup = mapPanel.GetComponent<CanvasGroup>();
        tempCanvasGroup.alpha = visiblity ? 1 : 0;
        tempCanvasGroup.blocksRaycasts = visiblity;
        tempCanvasGroup.interactable = visiblity;
    }

    void OnLogPanelChange()
    {
        if (!GameController.GetInstance.bCanOperate || b_Tab_PanelOpen || bExitPanelOpen)
            return;

        SetLogPanelVisibility(!bLogPanelOpen);

        if (bLogPanelOpen)
        {
            SetMapPanelVisibility(false);
            SetSkillPanelVisibility(false);
            SetDungenPanelVisibility(false);
            SetPortalPanelVisibility(false);
        }
        CheckInUIMode_AllPanel();
        CursorController.GetInstance.CheckCursor();
    }

    public void SetLogPanelVisibility(bool visiblity)
    {
        bLogPanelOpen = visiblity;
        CanvasGroup tempCanvasGroup = logPanel.GetComponent<CanvasGroup>();
        tempCanvasGroup.alpha = visiblity ? 1 : 0;
        tempCanvasGroup.blocksRaycasts = visiblity;
        tempCanvasGroup.interactable = visiblity;
    }

    void OnSkillPanelChange()
    {
        if (!GameController.GetInstance.bCanOperate || b_Tab_PanelOpen || bExitPanelOpen)
            return;

        SetSkillPanelVisibility(!bSkillPanelOpen);

        if (bSkillPanelOpen)
        {
            SetAttributePanelVisibility(false);
            SetBagPanelVisibility(false);
            SetTalentPanelVisibility(false);
            SetMapPanelVisibility(false);
            SetLogPanelVisibility(false);
            SetDungenPanelVisibility(false);
            SetPortalPanelVisibility(false);
        }
        CheckInUIMode_AllPanel();
        CursorController.GetInstance.CheckCursor();
    }

    public void SetSkillPanelVisibility(bool visiblity)
    {
        bSkillPanelOpen = visiblity;
        CanvasGroup tempCanvasGroup = skillPanel.GetComponent<CanvasGroup>();
        tempCanvasGroup.alpha = visiblity ? 1 : 0;
        tempCanvasGroup.blocksRaycasts = visiblity;
        tempCanvasGroup.interactable = visiblity;
    }

    //影响鼠标光标显示与否（除了Tab面板）
    public bool CheckInUIMode_AllPanel()
    {
        if (!bMenuPanelOpen &&
            !bExitPanelOpen &&
            !bDungenEnterPanel &&
            !bPortalEnterPanel &&
            !bShopPanel &&
            !bQuestPanel &&
            !bCharacterPanelOpen &&
            !bAttributePanelOpen &&
            !bBagPanelOpen &&
            !bTalentPanelOpen &&
            !bMapPanelOpen &&
            !bSkillPanelOpen &&
            !bLogPanelOpen
            )
        {
            bInPanelUIMode = false;
            return false;
        }
        else
        {
            bInPanelUIMode = true;
            return true;
        }
    }

    //检查中间部分的UIPanel是否全部隐藏，用以检查Raycast是否生效，是否显示ShowHint
    public bool CheckInUIMode_AllCenterPanel()
    {
        if (!bExitPanelOpen&&
            !bDungenEnterPanel &&
            !bPortalEnterPanel &&
            !bShopPanel &&
            !bQuestPanel)
        {
            bInCenterPanelUIMode = false;
            return false;
        }
        else
        {
            bInCenterPanelUIMode = true;
            return true;
        }
    }
    
    //关闭所有面板
    public void CloseAllPanel()
    {
        bMenuPanelOpen = false;//Esc
        bExitPanelOpen = false;//Exit
        
        //不操作交互提示
        bDungenEnterPanel = false;//进入地下城面板
        bPortalEnterPanel = false;//传送门面板
        bShopPanel = false;//商店页面
        bQuestPanel = false;//任务界面
        
        bCharacterPanelOpen = false;//C
        bAttributePanelOpen = false;//V
        bBagPanelOpen = false;//B
        bTalentPanelOpen = false;//N
        bMapPanelOpen = false;//M
        bSkillPanelOpen = false;//K
        bLogPanelOpen = false;//L
        
        SetMenuPanelVisibility(bMenuPanelOpen);
        SetExitPanelVisibility(bExitPanelOpen);

        //不操作交互提示
        SetDungenPanelVisibility(bDungenEnterPanel);
        SetPortalPanelVisibility(bPortalEnterPanel);
        SetShopEnterPanelVisibility(bShopPanel);
        SetQuestPanelVisibility(bQuestPanel);
        
        SetCharacterPanelVisibility(bCharacterPanelOpen);
        SetAttributePanelVisibility(bAttributePanelOpen);
        SetBagPanelVisibility(bBagPanelOpen);
        SetTalentPanelVisibility(bTalentPanelOpen);
        SetMapPanelVisibility(bMapPanelOpen);
        SetSkillPanelVisibility(bSkillPanelOpen);
        SetLogPanelVisibility(bLogPanelOpen);
    }


    void CloseAllPanelExceptExit()
    {
        bMenuPanelOpen = false;//Esc

        //不操作交互提示
        bDungenEnterPanel = false;//进入地下城面板
        bPortalEnterPanel = false;//传送门面板
        bShopPanel = false;//商店页面
        bQuestPanel = false;//任务界面

        bCharacterPanelOpen = false;//C
        bAttributePanelOpen = false;//V
        bBagPanelOpen = false;//B
        bTalentPanelOpen = false;//N
        bMapPanelOpen = false;//M
        bSkillPanelOpen = false;//K
        bLogPanelOpen = false;//L

        SetMenuPanelVisibility(bMenuPanelOpen);

        //不操作交互提示
        SetDungenPanelVisibility(bDungenEnterPanel);
        SetPortalPanelVisibility(bPortalEnterPanel);
        SetShopEnterPanelVisibility(bShopPanel);
        SetQuestPanelVisibility(bQuestPanel);

        SetCharacterPanelVisibility(bCharacterPanelOpen);
        SetAttributePanelVisibility(bAttributePanelOpen);
        SetBagPanelVisibility(bBagPanelOpen);
        SetTalentPanelVisibility(bTalentPanelOpen);
        SetMapPanelVisibility(bMapPanelOpen);
        SetSkillPanelVisibility(bSkillPanelOpen);
        SetLogPanelVisibility(bLogPanelOpen);
    }
}
