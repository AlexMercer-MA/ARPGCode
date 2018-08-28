using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEventManager : MonoBehaviour
{

    public static InputEventManager GetInstance;

    public System.Action EvtInteractKeyPressed; //事件 - 进行交互操作
    public KeyCode Interact_KeyCode = KeyCode.F; //交互快捷键

    void Awake()
    {
        GetInstance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(Interact_KeyCode))
        {
            EvtInteractKeyPressed();
        }
    }
}
