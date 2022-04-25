using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
		We want to create a new list and get
		the slot and panel so we can start to
		populate the UI.
     */
    #endregion
    public List<UIItem> uiItems = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    #endregion

    #region Unity Triggers
    void Awake()
    {
        #region Comment
        /*
			We want to populate the inventory with
			only four slots as that how many we can
			fit and fill them with slots and add the
			items, if there is any.
         */
        #endregion
        for (int i = 0; i < 4; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiItems.Add(instance.GetComponentInChildren<UIItem>());
        }
    }
    #endregion

    #region Methods

    #region Update Slots
    #region Comment
    /*
		We can update the slots so if there
		is an added item, we can get it to
		populate the slot and if we lose the
		item then it will get removed.
     */
    #endregion
    public void UpdateSlot(int slot, Item item)
    {
        uiItems[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(Item item)
    {
        UpdateSlot(uiItems.FindIndex(i => i.item == item), null);
    }
    #endregion

    #endregion
}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE:	UNKNOWN
 * TIME:	UNKNOWN
 * BY:		Aaron Hamilton
 */
#endregion

#region Edit Logs
//Date: Mon, 25 Apr 2022 | Time: 16:52 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title: 	Inventory System
 * By:		Gordon Stirling
 * URL: 	OneNote Resource
 */
#endregion
#endregion

//Uniq Studio