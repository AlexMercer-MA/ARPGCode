using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour {
    
    public static GameEventManager GetInstance;
    
    public System.Action<GameObject, eTriggerType> EvtTriggerEnter;//进入触发区域触发
    public System.Action<GameObject, eTriggerType> EvtTriggerStay;//保持在触发区域触发
    public System.Action<GameObject, eTriggerType> EvtTriggerExit;//离开触发区域触发

    public void Awake()
    {
        GetInstance = this;
    }
}
