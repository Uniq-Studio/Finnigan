using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Item item;

    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
        UpdateItem(null);
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            image.color = Color.white;
            image.sprite = item.icon;
        }
        else
        {
            image.color = Color.clear;
        }
    }
}
