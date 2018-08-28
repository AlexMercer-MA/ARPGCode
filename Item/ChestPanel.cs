//Made by Alex
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPanel : InventoryPanel 
{
	private static ChestPanel instance;
	public static ChestPanel GetInstance
	{
		get
		{
			return instance;
		}
	}

	void Awake()
	{
		instance = this;
		slotArray = this.GetComponentsInChildren<Slot> ();
	}

}