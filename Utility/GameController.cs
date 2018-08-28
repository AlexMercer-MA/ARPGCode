using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController GetInstance;

    public bool bCanOperate = true;//玩家是否可以操作,例如死亡时无法操作

    void Awake ()
    {
        GetInstance = this;
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {

	}

    //TODO 脚本负责检查 是否可以操作
    void CheckCanOperate()
    {
        //是否死亡 之类
        //有任何一条满足 则bCanOperate = false
    }
}
