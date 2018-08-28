using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    public static GameSetting GetInstance;
    public float audioValue;
    public float mouseSensitivity = 16f;

    void Awake()
    {
        GetInstance = this;
    }
}
