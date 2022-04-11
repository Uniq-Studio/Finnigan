using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Awake()
    { BuildDatabase(); }

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

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.name == itemName);
    }

}
