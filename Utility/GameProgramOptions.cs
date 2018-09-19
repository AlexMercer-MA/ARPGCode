using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgramOptions : MonoBehaviour
{
    public static GameProgramOptions GetInstance;
    public float audioValue;
    public float mouseSensitivity = 16f;

    void Awake()
    {
        GetInstance = this;
    }
}
