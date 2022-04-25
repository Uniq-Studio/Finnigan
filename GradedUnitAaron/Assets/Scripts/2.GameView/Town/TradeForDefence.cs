using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeForDefence : MonoBehaviour
{
    private bool doneDefOne = false;
    private bool doneDefTwo = false;
    private bool doneDefThree = false;

    private bool doOnce;
    private bool add1Once;

    private int round;

    void Update()
    {
        Debug.Log(round);
        Debug.Log(Tasks.startDefenseOne +" "+ Tasks.startDefenseTwo +" "+ Tasks.startDefenseThree);
    }

    void OnTriggerEnter(Collider collider)
    {
        add1Once = false;
        if (collider.CompareTag("Player"))
        {
            if (round == 0)
            {
                InventoryCheck(10);
            }
            if (round == 1)
            {
                InventoryCheck(15);
            }

            if (round == 2)
            {
                InventoryCheck(20);
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (!add1Once)
        {
            round ++;
            doOnce = false;
            add1Once = true;
        }
    }

    void InventoryCheck(int amount)
    {
        if (!doOnce)
        {
            if (Inventory.berryAmount >= amount &&
                Inventory.leafAmount >= amount &&
                Inventory.stoneAmount >= amount &&
                Inventory.stickAmount >= amount &&
                Reputation.reputation >= 3)
            {
                Inventory.berryAmount -= amount;
                Inventory.leafAmount -= amount;
                Inventory.stoneAmount -= amount;
                Inventory.stickAmount -= amount;

                DefenceSpawn();
                doOnce = true;
            }
        }
        
    }

    void DefenceSpawn()
    {
        if (round == 0)
        {
            Tasks.startDefenseOne = true;
        }
        else if (round == 1)
        {
            Tasks.startDefenseTwo = true;
        }
        else if (round == 2)
        {
            Tasks.startDefenseThree = true;
        }
    }
}
