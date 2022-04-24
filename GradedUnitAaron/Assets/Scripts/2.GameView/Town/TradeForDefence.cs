using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeForDefence : MonoBehaviour
{
    private bool doneDefOne = false;
    private bool doneDefTwo = false;
    private bool doneDefThree = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Hey Player");
            if (!doneDefOne)
            {
                if (Inventory.berryAmount >= 10 &&
                    Inventory.leafAmount >= 10 &&
                    Inventory.stoneAmount >= 10 &&
                    Inventory.stickAmount >= 10 &&
                    Reputation.reputation >= 3)
                {
                    Inventory.berryAmount -= 10;
                    Inventory.leafAmount -= 10;
                    Inventory.stoneAmount -= 10;
                    Inventory.stickAmount -= 10;

                    Tasks.startDefenceOne = true;
                }
                doneDefOne = true;
            }
            else if (doneDefOne && !doneDefTwo)
            {
                if (Inventory.berryAmount >= 15 &&
                    Inventory.leafAmount >= 15 &&
                    Inventory.stoneAmount >= 15 &&
                    Inventory.stickAmount >= 15 &&
                    Reputation.reputation >= 3)
                {
                    Inventory.berryAmount -= 15;
                    Inventory.leafAmount -= 15;
                    Inventory.stoneAmount -= 15;
                    Inventory.stickAmount -= 15;

                    Tasks.startDefenceTwo = true;
                }
                doneDefTwo = true;
            }
            else if (doneDefOne && doneDefTwo && !doneDefThree)
            {
                if (Inventory.berryAmount >= 20 &&
                    Inventory.leafAmount >= 20 &&
                    Inventory.stoneAmount >= 20 &&
                    Inventory.stickAmount >= 20 &&
                    Reputation.reputation >= 3)
                {
                    Inventory.berryAmount -= 20;
                    Inventory.leafAmount -= 20;
                    Inventory.stoneAmount -= 20;
                    Inventory.stickAmount -= 20;

                    Tasks.startDefenceThree = true;
                }
                doneDefThree = true;
            }
        }

    }
}
