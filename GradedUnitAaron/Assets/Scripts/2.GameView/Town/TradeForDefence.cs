using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeForDefence : MonoBehaviour
{
    private bool doneDefOne = false;
    private bool doneDefTwo = false;
    private bool doneDefThree = false;

    private bool doOnce;

    private int round;

    void OnTriggerEnter(Collider collider)
    {
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
        round++;
    }

    void InventoryCheck(int amount)
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
        }
    }

    void DefenceSpawn()
    {
        if (round == 0)
        {
            Tasks.startDefenceOne = true;
        }
        else if (round == 1)
        {
            Tasks.startDefenceTwo = true;
        }
        else if (round == 2)
        {
            Tasks.startDefenceThree = true;
        }
    }
}
