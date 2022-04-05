using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berries : MonoBehaviour
{
    public GameObject berries;
    private int berryAmount;

    private int points;

    private bool isClose;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log("Berries: " + berryAmount);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            berryAmount = Mathf.FloorToInt(Random.Range(3, 8));
            berries.gameObject.SetActive(false);
            StartCoroutine(RespawnBerries());
        }
    }

    IEnumerator RespawnBerries()
    {
        yield return new WaitForSeconds(Random.Range(600, 900));
        berries.gameObject.SetActive(true);
    }
}
