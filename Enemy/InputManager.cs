using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    
    public static ActorBehaviour GetInstace { get { return instance; } }
    private static ActorBehaviour instance;
    
}

public enum ActionKey
{
    Action_Q,
    Action_E,
    Action_R,
    Action_1,
    Action_2,
    Action_3,
    Action_4,
    Action_Shift,
    Action_Ctrl,
    Action_Tab,
    Action_LMB,
    Action_RMB,
    None,
}
