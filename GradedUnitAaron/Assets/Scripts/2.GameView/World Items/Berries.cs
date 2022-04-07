using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berries : TriggerSystem
{
    UIUpdater UI;

    public GameObject berries;
    public static int berryAmount;

    private int points;
    // Start is called before the first frame update
    void Start()
    {
        //Call this to get access to the methods
        UI = FindObjectOfType<UIUpdater>();
    }

    // Update is called once per frame
    void Update()
    {
        Interact(GetBerries);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            //isClose is from TriggerSystem
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
     /*Gives the player a random amount of berries
      * updates the ui with the new amount
      * remove the berries from the bush
      * and starts the respawn method */
    void GetBerries()
    {
        berryAmount = Mathf.FloorToInt(Random.Range(3, 8));
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
