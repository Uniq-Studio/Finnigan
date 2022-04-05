using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berries : TriggerSystem
{
    public GameObject berries;
    private int berryAmount;

    private int points;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Interact(GetBerries);
    }

    void OnTriggerEnter(Collider collider)
    {
        isClose = true;
    }

    void GetBerries()
    {
        berryAmount = Mathf.FloorToInt(Random.Range(3, 8));
        berries.gameObject.SetActive(false);
        StartCoroutine(RespawnBerries());
    }
    IEnumerator RespawnBerries()
    {
        yield return new WaitForSeconds(Random.Range(600, 900));
        berries.gameObject.SetActive(true);
    }
}
