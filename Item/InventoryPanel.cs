//Made by Alex
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class InventoryPanel : MonoBehaviour 
{
	public Slot[] slotArray;
	public bool isShow;

	//AddItemObject(ItemData,Amount)
	//FindEmptySlot()
	//FindExistSlots()

	public void ShowPanel()
	{
		
	}

	public void HidePanel()
	{

	}

	//Raycast获得游戏中已经生成的物品（游戏捡物品标准流程）
//	public bool AddItemObject(GameObject itemObject)
//	{
//		Item item = itemObject.GetComponent<Item> ();
//		//Item下有Itemdata储存信息和amount储存数量
//		if (item)
//		{
//			if (AddItemObject (item))
//			{
//				//如果返回true 表示物品全被装走了
//				Destroy(itemObject);
//				return true;
//			}
//			else
//			{
//				//如果返回false 表示格子不够无法全部装下
//				return false;
//			}
//		}
//		else
//		{
//			return false;
//		}
//	}

	public bool AddItemObject(ItemData itemData, int amount)
	{

		//超过物品堆叠上限
		if (amount > itemData.Capacity)
		{
			return false;
		}

		//Item下有Itemdata储存信息和amount储存数量
		if (itemData == null)	//物品id不存在
		{
			return false;
		}
		if (itemData.Capacity == 1)  //如果物品只能叠加1次
		{
			Slot slot = FindEmptySlot ();
			if (slot == null)
			{
				return false;
			}
			else
			{
				//会返回操作结果是否成功
				return slot.SetItemObject(itemData, amount);
			}
		}
		else  //如果物品可以叠加多次
		{
			Slot[] existSlots = FindExistSlots (itemData);	//是否有已经存在的格子
			if (existSlots == null)
			{
				//如果没有同样ID的格子，就找空格
				Slot tempSlot = FindEmptySlot ();
				if (tempSlot)
				{
					return tempSlot.SetItemObject (itemData,amount);
				}
				else
				{
					return false;
				}
			}
			else
			{
				//寻找所有有相同物品且没有满的格子（Slot增加是否full的判断，Slot增加返回剩余空间的功能）
				//在这些可以容纳的格子里按顺序增加使用次数
				//如果还有多余，则需要装在空格子里

				//物品来源剩余的数量
				int remainAmount = amount;
				foreach (Slot slot in existSlots)
				{
					int tempRemainAmount = slot.item.GetRemainAmount();
					if (remainAmount <= tempRemainAmount)	//够装满
					{
						//如果amount小于这个RemainAmount，这次就可以装完了
						slot.item.ChangeAmount(remainAmount);
						remainAmount = 0;
						break;
					}
					else //不够装满
					{
						slot.item.SetAmountFull ();
						remainAmount -= tempRemainAmount;
					}
				}
				//如果还有东西就要找空格继续装
				if (remainAmount == 0)
				{
					return true;
				}
				else
				{
					//如果还是装不满，就找个空格
					Slot tempSlot = FindEmptySlot ();
					if (tempSlot)
					{

						return tempSlot.SetItemObject (itemData, remainAmount);
					}
					else
					{
						//如果装不满 就打印一句话
						Debug.LogWarning("Still have " + remainAmount + " remains...");
						return false;
					}
				}
			}
		}
	}

	public bool AddItemObject(Item SourceItem)
	{
		ItemData itemData = SourceItem.itemData;
		int amount = SourceItem.amount;

		//超过物品堆叠上限
		if (amount > itemData.Capacity)
		{
			return false;
		}

		//Item下有Itemdata储存信息和amount储存数量
		if (itemData == null)	//物品id不存在
		{
			return false;
		}
		if (itemData.Capacity == 1)  //如果物品只能叠加1次
		{
			Slot slot = FindEmptySlot ();
			if (slot == null)
			{
				return false;
			}
			else
			{
				//会返回操作结果是否成功
				return slot.SetItemObject(itemData, amount);
			}
		}
		else  //如果物品可以叠加多次
		{
			Slot[] existSlots = FindExistSlots (itemData);	//是否有已经存在的格子
			if (existSlots == null)
			{
				//如果没有同样ID的格子，就找空格
				Slot tempSlot = FindEmptySlot ();
				if (tempSlot)
				{
					return tempSlot.SetItemObject (itemData,amount);
				}
				else
				{
					return false;
				}
			}
			else
			{
				//寻找所有有相同物品且没有满的格子（Slot增加是否full的判断，Slot增加返回剩余空间的功能）
				//在这些可以容纳的格子里按顺序增加使用次数
				//如果还有多余，则需要装在空格子里

				//物品来源剩余的数量
				int remainAmount = amount;
				foreach (Slot slot in existSlots)
				{
					int tempRemainAmount = slot.item.GetRemainAmount();
					if (remainAmount <= tempRemainAmount)	//够装满
					{
						//如果amount小于这个RemainAmount，这次就可以装完了
						slot.item.ChangeAmount(remainAmount);
						remainAmount = 0;
						break;
					}
					else //不够装满
					{
						slot.item.SetAmountFull ();
						remainAmount -= tempRemainAmount;
					}
				}
				//如果还有东西就要找空格继续装
				if (remainAmount == 0)
				{
					return true;
				}
				else
				{
					//如果还是装不满，就找个空格
					Slot tempSlot = FindEmptySlot ();
					if (tempSlot)
					{
						
						return tempSlot.SetItemObject (itemData, remainAmount);
					}
					else
					{
						//如果装不满 要对物品源头做一定的处理 改变物品来源的Amount
						SourceItem.amount = remainAmount;
						return false;
					}
				}
			}
		}
	}

	public Slot FindEmptySlot()
	{
		foreach (Slot slot in slotArray)
		{
			if (!slot.itemObject)
			{
				return slot;
			}
		}
		return null;
	}

	public Slot[] FindExistSlots(ItemData itemData)
	{
		List<Slot> tempSlots = new List<Slot>();
		foreach (Slot slot in slotArray)
		{
			if (slot.itemObject)
			{
				if (slot.item.itemData.ID == itemData.ID && !slot.item.CheckAmountFull() )
				{
					tempSlots.Add (slot);
				}
			}
		}
		if (tempSlots.Count > 0)
		{
			return tempSlots.ToArray();
		}
		else
		{
			return null;
		}
	}
}