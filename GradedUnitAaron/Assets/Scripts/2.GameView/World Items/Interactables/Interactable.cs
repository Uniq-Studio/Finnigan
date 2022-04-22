using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private UIUpdater UI;
    private Inventory inventory;
    private TriggerSystem triggerSystem = new TriggerSystem();
    // Start is called before the first frame update
    void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
        inventory = FindObjectOfType<Inventory>();
    }


    public void GetItem(GameObject item, int id)
    {
        if (id == 0)
        {
            inventory.AddAmount(id, Mathf.FloorToInt(Random.Range(3, 8)));
            item.SetActive(false);
        }
        else
        {
            inventory.AddAmount(id, 1);
            Destroy(item);
        }
    }

}
