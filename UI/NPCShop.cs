using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShop : MonoBehaviour {

    public float distance;

    void Start()
    {
        InputEventManager.GetInstance.EvtInteractKeyPressed += OnInteractiveKeyPressed;
    }

    void OnInteractiveKeyPressed()
    {

    }
}
