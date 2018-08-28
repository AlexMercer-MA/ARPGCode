//Made by Alex
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour 
{
	public ItemData itemData;
	public int amount;
	public Image iconImage;
	public Text amountText;
	public Vector3 animationScale;
	public float smoothSpeed = 10f;
	public float threshold = 1.02f;
	public bool haveItemData = false;

	void Awake()
	{
		iconImage = this.GetComponent<Image> ();
		amountText = this.GetComponentInChildren<Text> ();
		animationScale = new Vector3 (1.2f, 1.2f, 1.2f);
		smoothSpeed = 20f;
		threshold = 1.02f;
	}

	void Update()
	{
		if (this.GetComponent<RectTransform>().localScale!=Vector3.one)
		{
			this.GetComponent<RectTransform>().localScale = Vector3.Lerp (this.GetComponent<RectTransform>().localScale,Vector3.one,smoothSpeed*Time.deltaTime);
			if (this.GetComponent<RectTransform>().localScale.magnitude<threshold)
			{
				this.GetComponent<RectTransform>().localScale = Vector3.one;
			}
		}
	}

	//在Item层级，才对UI进行操作
	//SetItem(ItemData,Amount)
	//ChangeAmount	(增加X个，X可小于0)
	//SetAmount		(直接指定为X个)
	//SetAmountFull	(直接将堆叠数量设置为满)
	//GetRemainAmount
	//CheckAmountZero
	//CheckAmountFull

	public bool SetItem(ItemData itemData,int amount)
	{
		//检查是否有物品(是否需要？)
		//如果该Item中已经有ItemData，是否能直接覆盖设置？
		if (haveItemData)
		{
			Debug.LogWarning("Warning... Override the old ItemData");
		}

		//检查是否超过上限
		if (amount > itemData.Capacity)
		{
			return false;
		}
		this.itemData = itemData;
		this.amount = amount;
		iconImage.sprite = Resources.Load<Sprite> (this.itemData.IconPath);
		RefreshUI (true);
		haveItemData = true;
		return true;
	}

	public bool ChangeAmount(int amount = 1)
	{
		//检查是否有物品
		if (!haveItemData)
		{
			return false;
		}
		//检查是否超过上限
		if ( (this.amount + amount) > itemData.Capacity )
		{
			return false;
		}
		this.amount += amount;
		RefreshUI (true);
		return true;
	}

	public bool SetAmount(int amount)
	{
		//检查是否有物品
		if (!haveItemData)
		{
			return false;
		}
		//检查是否超过上限
		if ( amount > itemData.Capacity )
		{
			return false;
		}
		this.amount = amount;
		RefreshUI (true);
		return true;
	}

	public bool SetAmountFull()
	{
		//检查是否有物品
		if (!haveItemData)
		{
			return false;
		}
		//检查是否超过上限
		if ( amount > itemData.Capacity )
		{
			return false;
		}
		this.amount = itemData.Capacity;
		RefreshUI (true);
		return true;
	}

	public int GetRemainAmount()
	{
		//如果有错误情况返回 -1
		//检查是否有物品
		if (!haveItemData)
		{
			return -1;
		}
		//检查是否超过上限
		if ( amount > itemData.Capacity )
		{
			return -1;
		}
		return itemData.Capacity - amount;
	}

	public bool CheckAmountZero()
	{
		if (amount <= 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool CheckAmountFull()
	{
		if (amount >= itemData.Capacity)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private void RefreshUI(bool reScale)
	{
		if (this.amount > 1)
		{
			amountText.text = this.amount.ToString ();
		}
		else
		{
			amountText.text = "";
		}
		if (reScale)
		{
			this.GetComponent<RectTransform>().localScale = animationScale;
		}
	}
}