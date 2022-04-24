using UnityEngine;

public class Trader : MonoBehaviour
{
    public GameObject ces;
    private TriggerSystem triggerSystem;
    private UIUpdater UI;

    private bool doOnce = true;

    private void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
        triggerSystem = new TriggerSystem();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (doOnce)
        {
            triggerSystem.Interact(TradeForItem, collider);
        }
    }

    private void TradeForItem()
    {
        if (Inventory.berryAmount >= 2 && Inventory.leafAmount >= 2 && Inventory.stickAmount >= 2 && Inventory.stoneAmount >=2 && Reputation.reputation >= 3)
        {
            Inventory.berryAmount -= 2;
            UI.UpdateBerries(Inventory.berryAmount);
            Vector3 position = transform.position + new Vector3(0, 0, +(-3));
            Instantiate(ces, position, transform.rotation);
            doOnce = false;
        }
    }
}