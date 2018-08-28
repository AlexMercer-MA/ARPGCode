using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSpaceUIManager : MonoBehaviour {

    public static ScreenSpaceUIManager GetInstance;

    public System.Action EvtInteractiveHint_Open_Interactive;//事件 - 交互提示出现(进入NPC等Trigger范围)
    public System.Action EvtInteractiveHint_Open_Item;//事件 - 交互提示出现(进入物品Trigger范围)
    public System.Action EvtInteractiveHint_Close;//事件 - 交互提示关闭(按下关闭键 / 超出距离)
    public System.Action EvtWarningHint_Open;//事件 - 警告提示打开（CD/能量不够）
    public System.Action EvtWarningHint_Close;//事件 - 警告提示关闭（CD/能量不够）
    public System.Action EvtRebitrhHint_Open;//事件 - 复活提示打开
    public System.Action EvtRebitrhHint_Close;//事件 - 复活提示关闭

    public GameObject InteractiveHintObj;
    public Text InteractiveHintText;
    public bool bIsInteractiveHintShow;
    public GameObject WarningHintObj;
    public bool bIsWarningHintShow;
    public GameObject RebirthHintObj;
    public bool bIsRebirthHintShow;

    private void Awake()
    {
        GetInstance = this;
    }

    public void OpenInteractiveHint()
    {
        bIsInteractiveHintShow = true;
        InteractiveHintObj.SetActive(true);
        InteractiveHintText.text = "<color=#ffe36aff>Press 'F'</color>\n<size=55>to</size>\nInteract";
    }

    public void OpenItemHint()
    {
        bIsInteractiveHintShow = true;
        InteractiveHintObj.SetActive(true);
        InteractiveHintText.text = "<color=#ffe36aff>Press 'F'</color>\n<size=55>to</size>\nPick";
    }

    public void CloseInteractiveHint()
    {
        bIsInteractiveHintShow = false;
        InteractiveHintObj.SetActive(false);
    }

    public void OpenWarningHint()
    {
        bIsWarningHintShow = true;
        WarningHintObj.SetActive(true);
    }

    public void CloseWarningHint()
    {
        bIsWarningHintShow = false;
        WarningHintObj.SetActive(false);
    }

    public void OpenRebirthHint()
    {
        bIsRebirthHintShow = true;
        RebirthHintObj.SetActive(true);
    }

    public void CloseRebirthHint()
    {
        bIsRebirthHintShow = false;
        RebirthHintObj.SetActive(false);
    }
}
