using UnityEngine;

public class CornEncrustedStick : MonoBehaviour
{
    public GameObject self;

    private TriggerSystem m_TriggerSystem = new TriggerSystem();
    private UIUpdater UI;
    private void CollectItem()
    {
        /* Update the enemy to see that the player has the item
        * Gives the quest to return it and destroyed itself */
        Boss.HasStick = true;
        UI.UpdateTask("Quick! Lets return the stick!");
        Destroy(self);
    }

    private void OnTriggerEnter(Collider collider)
    {
        m_TriggerSystem.Interact(CollectItem, collider);
    }

    private void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
    }
}