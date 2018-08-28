using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour {

    public static CursorController GetInstance;

	// Use this for initialization
	void Awake () {
        GetInstance = this;
        Cursor.visible = true;
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
        CharacterBehaviour.GetInstace.inUIMode = true;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        CharacterBehaviour.GetInstace.inUIMode = false;
    }

    public void CheckCursor()
    {
        if (PanelUIManager.GetInstance.CheckInUIMode_AllPanel())
        {
            ShowCursor();
        }
        else
        {
            HideCursor();
        }
    }
}
