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
        if (Berries.berryAmount >= 2)
        {
            Berries.berryAmount -= 2;
            UI.UpdateBerries(Berries.berryAmount);
            Vector3 position = transform.position + new Vector3(0, 0, +(-1));
            Instantiate(ces, position, transform.rotation);
            doOnce = false;
        }
    }
}