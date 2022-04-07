using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornEncrustedStick : TriggerSystem
{
    public GameObject self;

    UIUpdater UI;

    private void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
    }

    

    void Update()
    {
        Interact(CollectItem);
    }

    /* Update the enemy to see that the player has the item
     * Gives the quest to return it and distroys itself */
    void CollectItem()
    {
        Enemy.HasStick = true;
        UI.UpdateTask("Quick! Lets return the stick!");
        Destroy(self);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isClose = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            isClose = false;
        }
    }
}