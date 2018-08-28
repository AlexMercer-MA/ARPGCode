//Made by Alex
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickedItem : MonoBehaviour 
{
	public GameObject itemObject;
	public Item item;
	public bool havePickedItem;

	//singleton
	static PickedItem instance;
	public static PickedItem GetInstace
	{
		get
		{
			return instance;
		}
	}

	void Awake()
	{
		instance = this;
	}

	void Update()
	{
		if (havePickedItem)
		{
			this.GetComponent<RectTransform> ().position = Input.mousePosition;
		}
	}

	public void SetPickedItem(ItemData itemData, int amount)
	{
		if (havePickedItem)
		{
			RemovePickedItem ();
		}
		//创建一个新在Canvas-PickedItem下的ItemObject物体!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		//获得itemObject和item
		this.itemObject = Instantiate (ItemManager.GetInstace.itemPrefab,this.transform);
		this.item = itemObject.GetComponent<Item> ();
		//设置这个游戏物体
		this.itemObject.transform.localPosition = Vector3.zero;
		this.item.SetItem (itemData, amount);
		havePickedItem = true;
	}

	public void SetAmount(int amount)
	{
		this.item.SetAmount (amount);
	}

	public void ChangeAmount(int amount)
	{
		this.item.ChangeAmount (amount);
	}

	public bool CheckAmountZero()
	{
		if (this.item.CheckAmountZero())
		{
			RemovePickedItem ();
			return true;
		}
		else
		{
			return false;
		}
	}

	public void RemovePickedItem()
	{
		Destroy (this.itemObject);
		itemObject = null;
		item = null;
		havePickedItem = false;
	}
}