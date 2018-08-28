//Made by Alex
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
using System.Text;
using LitJson;

public class ItemManager : MonoBehaviour
{
    string JSON_ItemDataPath;                                                       //路径
    public Dictionary<int, ItemData> itemDic = new Dictionary<int, ItemData>();     //字典 模板
    NormalItem[] normalItemArray;                                                   //EXCEL 表格转换后 承载的容器
    Consumable[] consumableArray;                                                   //EXCEL 表格转换后 承载的容器
    EquipmentModel[] equipmentModelArray;                                           //EXCEL 表格转换后 承载的容器
    public GameObject itemPrefab;

    //ToolTip
    public ToolTip toolTip;
    private bool isShowToolTip;
    public bool IsShowToolTip
    {
        get { return isShowToolTip; }
        private set { isShowToolTip = value; }
    }

    //singleton
    static ItemManager instance;
    public static ItemManager GetInstace{ get { return instance; } }

	void Awake()
	{
		instance = this;
		toolTip = GameObject.FindObjectOfType<ToolTip> ();
	}

    void Start()
    {
        JSONParse ();
    }
    
    void Update()
	{
		//显示ToolTip的时候，将ToolTip重新定位
		if (isShowToolTip)
		{
			toolTip.Reposition ();
		}

		//丢弃物品 - 在手上有物品的时候，点击不是UI界面的区域
		if (Input.GetMouseButtonDown(0))
		{
			if (PickedItem.GetInstace.havePickedItem && !EventSystem.current.IsPointerOverGameObject())
			{
				PickedItem.GetInstace.RemovePickedItem ();
				PickedItem.GetInstace.havePickedItem = false;
				//在Scene里生成带有这个物品的游戏物体！ CreateItemObject_Scene
			}
		}
	}
    
	void JSONParse()
	{
        normalItemArray = JsonMapper.ToObject<NormalItem[]>(File.ReadAllText(@"Assets/Table/NormalItem.json"));
        consumableArray = JsonMapper.ToObject<Consumable[]>(File.ReadAllText(@"Assets/Table/Consumable.json"));
        equipmentModelArray = JsonMapper.ToObject<EquipmentModel[]>(File.ReadAllText(@"Assets/Table/Equipment.json"));

        for (int i = 0; i < normalItemArray.Length; i++)
        {
            itemDic.Add(normalItemArray[i].ID, normalItemArray[i]);
        }

        for (int i = 0; i < consumableArray.Length; i++)
        {
            itemDic.Add(consumableArray[i].ID, consumableArray[i]);
        }

        for (int i = 0; i < equipmentModelArray.Length; i++)
        {
            itemDic.Add(equipmentModelArray[i].ID, equipmentModelArray[i]);
        }

        /*   -- TEST --
        foreach (var item in itemDic)
        {
            Debug.Log(item.Value.Name);
            switch (item.Value.ItemType)
            {
                case eItemType.Normal:
                    NormalItem temp1 = (NormalItem)item.Value;
                    Debug.Log(temp1.DesMain);
                    break;
                case eItemType.Consumable:
                    Consumable temp2 = (Consumable)item.Value;
                    Debug.Log(temp2.SdRecover);
                    break;
                case eItemType.Equipment:
                    EquipmentModel temp3 = (EquipmentModel)item.Value;
                    Debug.Log(temp3.EXCriPhyMeleeDmgF0);
                    Debug.Log(temp3.EXCriPhyMeleeDmgF1);
                    break;
                default:
                    break;
            }
        }
        */
    }

    public ItemData GetItemdataByID(int ID)
	{
        ItemData itemdata;
        if (itemDic.TryGetValue(ID, out itemdata))
        {
            if (itemdata != null)
            {
                switch (itemdata.ItemType)
                {
                    case eItemType.Normal:
                        return (NormalItem)itemdata;
                    case eItemType.Consumable:
                        return (Consumable)itemdata;
                    case eItemType.Equipment:
                        Equipment equipment = new Equipment((EquipmentModel)itemdata);
                        return equipment;
                    default:
                        break;
                }
            }
        }
        return null;
    }

	public void ShowToolTip(ItemData itemData)
	{
		//如果此时鼠标正在移动一个物品，则不显示ToolTip
		if (PickedItem.GetInstace.havePickedItem)
		{
			return;
		}
		isShowToolTip = true;
		toolTip.Show (itemData);
	}

	public void HideToolTip()
	{
		toolTip.Hide ();
		isShowToolTip = false;
	}

}