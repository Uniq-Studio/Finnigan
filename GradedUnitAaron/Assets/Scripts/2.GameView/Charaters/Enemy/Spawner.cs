using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Attacker;
    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;

    private int num;

    private int max = 5;

    private bool doOnce = false;

    private bool unlocked = false;
    // Start is called before the first frame update
    void Update()
    {
        if (true)
        {
            unlocked = true;
        }
        if (!doOnce && max > 0 && unlocked)
        {
            StartCoroutine(SpawnIn());
        }
            
    }

    IEnumerator SpawnIn()
    {
        num = Mathf.RoundToInt(Random.Range(1, 4));
        switch (num)
        {
                case 1:
                    Instantiate(Attacker, Spawner1.transform.position, transform.rotation);
                    break;
                case 2:
                    Instantiate(Attacker, Spawner2.transform.position, transform.rotation);
                    break;
                case 3:
                    Instantiate(Attacker, Spawner3.transform.position, transform.rotation);
                    break;
        }

        doOnce = true;
        max--;
        yield return new WaitForSeconds(5);
        doOnce = false;
    }
}
