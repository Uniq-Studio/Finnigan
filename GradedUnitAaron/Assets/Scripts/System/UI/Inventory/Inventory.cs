using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;
    public UIInventory inventoryUI;

    public static int berryAmount;
    public static bool berriesShowing;
    public static int stoneAmount;
    public static bool stoneShowing;
    public static int stickAmount;
    public static bool stickShowing;
    public static int leafAmount;
    public static bool leafShowing;

    void Update()
    {
        if (berryAmount <= 0)
        {
            RemoveItem(0);
            berriesShowing = false;
        }
        if (stoneAmount <= 0)
        {
            RemoveItem(1);
            stoneShowing = false;
        }
        if (stickAmount <= 0)
        {
            RemoveItem(2);
            stickShowing = false;
        }
        if (leafAmount <= 0)
        {
            RemoveItem(3);
            leafShowing = false;
        }
    }


    public void GiveItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added Item: " + itemToAdd.name);
    }

    public void GiveItem(string itemName)
    {
        Item itemToAdd = itemDatabase.GetItem(itemName);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added Item: " + itemToAdd.name);
    }

    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if (itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveItem(itemToRemove);
            Debug.Log("Removed item: " + itemToRemove.name);
        }
    }

    public void AddAmount(int id, int value)
    {
        switch (id)
        {
            case 0:
                berryAmount += value;
                if (berryAmount > 0 && !berriesShowing)
                {
                    GiveItem(0);
                    berriesShowing = true;
                }
                break;
            case 1:
                stoneAmount += value;
                if (stoneAmount > 0 && !stoneShowing)
                {
                    GiveItem(1);
                    stoneShowing = true;
                }
                break;
            case 2:
                stickAmount += value;
                if (stickAmount > 0 && !stickShowing)
                {
                    GiveItem(2);
                    stickShowing = true;
                }
                break;
            case 3:
                leafAmount += value;
                if (leafAmount > 0 && !leafShowing)
                {
                    GiveItem(3);
                    leafShowing = true;
                }
                break;
        }
    }
}
