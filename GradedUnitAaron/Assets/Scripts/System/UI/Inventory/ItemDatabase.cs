using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
		We want to create an array called 
		ITEMS, to list the items we have.
     */
    #endregion
    public List<Item> items = new List<Item>();
    #endregion

    #region Unity Triggers
    void Awake()
    {
        #region Comment
        /*
			When the scripts awakes then it will
			go and build the database.
         */
        #endregion
        BuildDatabase();
    }
    #endregion

    #region Methods

    #region Build The Database Of Items
    #region Comment
    /*
		First it will create a new item in
        the list and will populate it with an
        ID, the name, the description of it 
        and then add the stats. 
     */
    #endregion
    void BuildDatabase()
    {
        items = new List<Item>() {
        new Item(0,
        "Berries",
        "Freshly plucked berries, great to feed the cubs or to trade.",
        new Dictionary<string, int>
        {{ "Amount", 1 }}),

        new Item(1,
        "Pretty Stone",
        "Solid for a great foundation.",
        new Dictionary<string, int>
        {{ "Amount", 1 }}),

        new Item(2,
        "Stick",
        "A simple stick with great possibilities.",
        new Dictionary<string, int>
        {{ "Amount", 1 }}),

        new Item(3,
        "Leaf",
        "Perfect for filling in the gaps and waterproof!",
        new Dictionary<string, int>
        {{ "Amount", 1 }})};
    }
    #endregion

    #region GetItem
    #region Comment
    /*
	We create a method with Item class and
        pass through the ID or ITEMNAME and use
        the find to find the item by the item’s
        ID or the ITEMSNAME and returns the item.
     */
    #endregion
    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.name == itemName);
    }
    #endregion

    #endregion
}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE: 	UNKNOWN
 * TIME:	UNKNOWN
 * BY:		Aaron Hamilton
 */
#endregion

#region Edit Logs
//Date: Mon, 25 Apr 2022 | Time: 16:40 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title: Inventory System
 * By: Gordon Stirling
 * URL: OneNote Resource
 */
#endregion
#endregion

//Uniq Studio
