//Made by Alex
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagPanel : InventoryPanel 
{
	private static BagPanel instance;
	public static BagPanel GetInstance
	{
		get
		{
			return instance;
		}
	}

	void Awake()
	{
		instance = this;
		slotArray = this.transform.GetComponentsInChildren<Slot> ();
	}
}