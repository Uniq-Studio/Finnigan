using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornEncrustedStick : MonoBehaviour
{
    public GameObject self;

    UIUpdater UI;
    private TriggerSystem m_TriggerSystem;

    private void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
        m_TriggerSystem = new TriggerSystem();
    }

    /* Update the enemy to see that the player has the item
     * Gives the quest to return it and destroyed itself */
    void CollectItem()
    {
        Enemy.HasStick = true;
        UI.UpdateTask("Quick! Lets return the stick!");
        Destroy(self);
    }

    void OnTriggerStay(Collider collider)
    {
        m_TriggerSystem.Interact(CollectItem, collider);
    }
}