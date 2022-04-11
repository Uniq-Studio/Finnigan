using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berries : MonoBehaviour
{
    UIUpdater UI;
    Inventory inventory;
    TriggerSystem triggerSystem;

    public GameObject berries;
    public static int berryAmount;

    private int points;
    // Start is called before the first frame update
    void Start()
    {
        //Call this to get access to the methods
        UI = FindObjectOfType<UIUpdater>();
        inventory = FindObjectOfType<Inventory>();
        triggerSystem = new TriggerSystem();
    }



    void OnTriggerStay(Collider collider)
    {
        triggerSystem.Interact(GetBerries, collider);
    }

    /*Gives the player a random amount of berries
     * updates the ui with the new amount
     * remove the berries from the bush
     * and starts the respawn method */
    void GetBerries()
    {
        berryAmount = Mathf.FloorToInt(Random.Range(3, 8));
        inventory.GiveItem(0);
        UI.UpdateBerries(berryAmount);
        berries.gameObject.SetActive(false);
        StartCoroutine(RespawnBerries());
    }

    /* Respawn after around a couple of minutes */
    IEnumerator RespawnBerries()
    {
        yield return new WaitForSeconds(Random.Range(600, 900));
        berries.gameObject.SetActive(true);
    }
}
