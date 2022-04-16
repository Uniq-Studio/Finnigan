using System.Collections;
using UnityEngine;

public class Berries : MonoBehaviour
{
    private UIUpdater UI;
    private Inventory inventory;
    private TriggerSystem triggerSystem;

    public GameObject berries;
    public static int berryAmount = 300;

    private bool doOnce = true;

    private int points;

    // Start is called before the first frame update
    private void Start()
    {
        //Call this to get access to the methods
        UI = FindObjectOfType<UIUpdater>();
        inventory = FindObjectOfType<Inventory>();
        triggerSystem = new TriggerSystem();
    }

    private void Update()
    {
        if (berryAmount <= 0)
        {
            inventory.RemoveItem(0);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (doOnce)
        {
            triggerSystem.Interact(GetBerries, collider);
            doOnce = false;
        }
    }

    /*Gives the player a random amount of berries
     * updates the ui with the new amount
     * remove the berries from the bush
     * and starts the respawn method */

    private void GetBerries()
    {
        berryAmount += Mathf.FloorToInt(Random.Range(3, 8));
        UI.UpdateBerries(berryAmount);
        berries.gameObject.SetActive(false);
        doOnce = false;
        StartCoroutine(RespawnBerries());
        if (berryAmount >= 1)
        {
            inventory.GiveItem(0);
        }
    }

    /* Respawn after around a couple of minutes */

    private IEnumerator RespawnBerries()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        berries.gameObject.SetActive(true);
        doOnce = true;
    }
}