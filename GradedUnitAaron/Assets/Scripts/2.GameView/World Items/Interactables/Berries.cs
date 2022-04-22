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
        yield return new WaitForSeconds(Random.Range(600, 900));
        berries.gameObject.SetActive(true);
        doOnce = false;
    }
}