//Made by Alex
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler , IPointerDownHandler
{
	public GameObject itemObject = null;
	public Item item = null;

	//Slot 只有权限获得Slot下的 GameObject 和 Item 脚本

	//itemObject
	//item

	//SetItemObject(Item)
	//SetItemObject(ItemData,Amount)
	//RemoveItemObject()
	//OnPointerEnter()
	//OnPointerExit()
	//OnPointerDown()

	//设置一个物品，Slot下仅应该有一个唯一的Item
	public bool SetItemObject(ItemData itemData,int amount = 1)
	{
		//只有格子下没有物品才能添加
		if (this.itemObject == null)
		{
			//创建一个新在Canvas-Slot下的ItemObject物体!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			//获得itemObject和item
			this.itemObject = Instantiate (ItemManager.GetInstace.itemPrefab,this.transform);
			this.item = this.itemObject.GetComponent<Item> ();
			//设置这个游戏物体
			this.itemObject.transform.localPosition = Vector3.zero;
			this.item.SetItem (itemData, amount);
			return true;
		}
		else
		{
			Debug.LogWarning ("格子里已经有物品了");
			return false;		//如果已经有物品了就无法设置了
		}
	}

	public void RemoveItemObject()
	{
		Destroy(itemObject);
		this.itemObject = null;
		this.item = null;
	}

	public void OnPointerEnter (PointerEventData eventData)
	{
		Debug.Log ("Move in");
		if (this.transform.childCount>=1)
		{
			ItemManager.GetInstace.ShowToolTip (item.itemData);
		}
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		if (ItemManager.GetInstace.IsShowToolTip)
		{
			ItemManager.GetInstace.HideToolTip ();
		}
	}

	/*
	 * 1 这个格子没有东西 手上没有东西 - 什么都不做
	 * 2 这个格子没有东西 手上有东西 - 将东西放到格子
	 *   没有按下Ctrl - 全部放进格子里
	 *   按下了Crtl - 放一个到格子里 
	 * 3 这个格子有东西 手上没有东西 - 将物品取走
	 *   
	 * 4 这个格子有东西 手上有东西 东西相同 - 堆叠物品
	 * 5 这个格子有东西 手上有东西 东西不同 - 将物品交换
	 * 
	 * 
	 */
	public void OnPointerDown (PointerEventData eventData)
	{
		if (this.itemObject)   //格子有东西
		{
			if (!PickedItem.GetInstace.havePickedItem)  //格子有东西,鼠标为空
			{
				if (Input.GetKey(KeyCode.LeftControl))      //格子有东西,鼠标为空,按Ctrl
				{
					//按下Ctrl键，只拿一半的物品
					int amountPicked = Mathf.CeilToInt (this.item.amount/2f);
					int amountRemain = this.item.amount - amountPicked;
					PickedItem.GetInstace.SetPickedItem (item.itemData,amountPicked);		//将物品移动到鼠标上
					if (amountRemain<=0)
					{
						RemoveItemObject();	//删除格子的物品
					}
					else
					{
						item.SetAmount (amountRemain);	//改变UI的数量
					}
				}
				else    //格子有东西,鼠标为空
				{
					//当前slot信息转移给PickedItem
					PickedItem.GetInstace.SetPickedItem (item.itemData,item.amount);
					RemoveItemObject();
				}
			}
			else      										//格子有东西,鼠标有东西，不按Ctrl
			{
				if (this.item.itemData.ID == PickedItem.GetInstace.item.itemData.ID)    //格子有东西,鼠标有东西,ID相同
				{
					if (Input.GetKey(KeyCode.LeftControl))           //格子有东西,鼠标有东西,ID相同，按Ctrl
					{
						if (this.item.amount < this.item.itemData.Capacity)    //有空间放
						{
							this.item.ChangeAmount (1);						//堆叠次数 +1
							PickedItem.GetInstace.ChangeAmount (-1);
							PickedItem.GetInstace.CheckAmountZero ();
						}
						else
						{
							return;
						}
					}
					else     											//格子有东西,鼠标有东西,ID相同,不按Ctrl
					{
						if (this.item.amount<this.item.itemData.Capacity)	//有足够空间放置
						{
							int spaceRemain = this.item.itemData.Capacity - this.item.amount;
							int pickedItemAmount = PickedItem.GetInstace.item.amount;
							if (spaceRemain>=pickedItemAmount)				//剩余空间大于放入的物品数量，可以全部放入
							{
								this.item.ChangeAmount (pickedItemAmount);
								PickedItem.GetInstace.SetAmount (0);
								PickedItem.GetInstace.CheckAmountZero ();
							}
							else  											//无法全部放入
							{
								this.item.ChangeAmount (spaceRemain);
								PickedItem.GetInstace.ChangeAmount (-spaceRemain);
								PickedItem.GetInstace.CheckAmountZero ();
							}
						}
						else
						{
							return;
						}
					}
				}
				else 														//格子有东西,鼠标有东西,ID不同
				{
					//交换物品
					ItemData slotItemData = this.item.itemData;													//储存slotItemData
					int slotItemAmount = this.item.amount;														//储存slotItemAmount
					RemoveItemObject ();																		//清除slotItem
					ItemData pickedItemData = PickedItem.GetInstace.item.itemData;				//储存pickedItemData
					int pickedItemAmount = PickedItem.GetInstace.item.amount;					//储存pickedItemAmount
					PickedItem.GetInstace.RemovePickedItem ();											//清除pickedItem
					SetItemObject (pickedItemData,pickedItemAmount);											//设置SlotItem
					PickedItem.GetInstace.SetPickedItem (slotItemData,slotItemAmount);					//设置pickedItem
					return;
				}
			}
		}
		else   //格子为空
		{
			if (!PickedItem.GetInstace.havePickedItem)  //格子为空，鼠标也为空，啥也不做
			{
				return;
			}
			else    //格子为空，鼠标有东西
			{
				if (Input.GetKey(KeyCode.LeftControl))      //格子为空，鼠标有东西
				{
					this.SetItemObject (PickedItem.GetInstace.item.itemData,1);
					PickedItem.GetInstace.ChangeAmount (-1);
					PickedItem.GetInstace.CheckAmountZero ();
				}
				else                  						 //格子为空，鼠标有东西
				{
					this.SetItemObject (PickedItem.GetInstace.item.itemData,PickedItem.GetInstace.item.amount);
					PickedItem.GetInstace.SetAmount (0);
					PickedItem.GetInstace.CheckAmountZero ();
				}
			}
		}
	}
}