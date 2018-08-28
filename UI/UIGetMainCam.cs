using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnazzlebotTools.ENPCHealthBars;

public class UIGetMainCam : MonoBehaviour {

	void Start () {
		gameObject.GetComponent<ENPCHealthBar> ().FaceCamera = Camera.main;
	}
}
