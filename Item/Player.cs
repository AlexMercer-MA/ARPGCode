//Made by Alex
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.G))
		{
			Debug.Log ("Add");
			int itemID = Random.Range (1001, 1003);
            //ItemData itemdata = ItemManager.GetInstace.GetItemdataByID (itemID);
            Equipment itemdata = (Equipment)ItemManager.GetInstace.GetItemdataByID(itemID);
            Debug.Log("Max DAMAGE is" + itemdata.EXPhyMeleeMaxF);
            Debug.Log("Min DAMAGE is" + itemdata.EXPhyMeleeMinF);
            BagPanel.GetInstance.AddItemObject(itemdata, 1);
		}
	}
}