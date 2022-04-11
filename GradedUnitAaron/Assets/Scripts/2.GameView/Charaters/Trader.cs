using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
    public GameObject ces;
    private TriggerSystem triggerSystem;
    UIUpdater UI;

    void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
        triggerSystem = new TriggerSystem();
    }

    void OnTriggerStay(Collider collider)
    {
        triggerSystem.Interact(TradeForItem, collider);
    }

    void TradeForItem()
    {
        if (Berries.berryAmount >= 2)
        {
            Berries.berryAmount -= 2;
            UI.UpdateBerries(Berries.berryAmount);
            Vector3 position = transform.position + new Vector3(0, 0, +(-1));
            Instantiate(ces, position, transform.rotation);
        }
    }
}
