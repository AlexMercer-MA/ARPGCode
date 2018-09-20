using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBasicSettingManager : MonoBehaviour {

    public static ActorBehaviour GetInstace { get { return instance; } }
    private static ActorBehaviour instance;

    public float Gravity
    {
        get
        {
            return gravity;
        }

        set
        {
            gravity = value;
        }
    }
    private float gravity = -9.8f;
    
}

public enum LockDirection
{
    NONE,
    FORWARD,        //向前方强制大跳
    BACKWARD,       //中了恐惧术，强制锁死往后跑
}

