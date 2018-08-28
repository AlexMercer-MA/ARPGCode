using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonEnterBtn : MonoBehaviour {

    public Button btn;
    
	void Start ()
    {
        btn.onClick.AddListener(EnterDungeon);
	}
	
	void EnterDungeon()
    {
        GameSceneManager.GetInstance.LoadNextDungeonScene();
    }
}
