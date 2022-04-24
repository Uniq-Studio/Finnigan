using System.Collections;
using UnityEngine;

public class Berries : Interactable //0
{
    private bool doOnce;
    public GameObject berries;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && !doOnce)
        {
            GetItem(berries, 0);
            doOnce = true;
            StartCoroutine(RespawnBerries());
        }
    }
    private IEnumerator RespawnBerries()
    {
        if (Tasks.filledFoodBoxOver100)
        {
            yield return new WaitForSeconds(Random.Range(300, 450));
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(30, 60));
        }
        
        berries.gameObject.SetActive(true);
        doOnce = false;
    }
}