using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Guirao.UltimateTextDamage;

public class SceneStartSetting : MonoBehaviour
{
    public string sceneName;

    // Use this for initialization
    void Start()
    {
        //在新场景开始的时候，获得相机
        CharacterBehaviour.GetInstace.cam = Camera.main.gameObject;

        //改变玩家位置
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = this.transform.position;
        player.transform.rotation = this.transform.rotation;

        //复活玩家,设置为满状态
        //UI_Rebirth.GetInstance.Hide();
        PlayerPropertiesFinal.GetInstance.IsDead = false;
        PlayerPropertiesFinal.GetInstance.FullHP();
        PlayerPropertiesFinal.GetInstance.FullSP();
        CharacterBehaviour.GetInstace.anim.SetTrigger("Birth");
        
        Cursor.visible = false;//隐藏光标
        SceneNameUI.GetInstance.ShowSceneName(sceneName);
        CharacterBehaviour.GetInstace.groundCheck.triggerNums = 0;//重置地面检测器
        PlayerPropertiesFinal.GetInstance.textManager = GameObject.FindWithTag("DamageUI").GetComponent<UltimateTextDamageManager>();

        //关闭所有UI
        PanelUIManager.GetInstance.CloseAllPanel();
        PanelUIManager.GetInstance.CheckInUIMode_AllPanel();
        PanelUIManager.GetInstance.CheckInUIMode_AllCenterPanel();
        CursorController.GetInstance.CheckCursor();
        ScreenSpaceUIManager.GetInstance.CloseRebirthHint();


    }
}
