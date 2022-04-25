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
    private int max;

    private bool doOnce = false;
    private bool round1;
    private bool round2;
    private bool round3;

    // Start is called before the first frame update
    void Update()
    {
        if (Tasks.startDefenseOne && !round1)
        {
            max = 10;
            if (!doOnce && max > 0)
            {
                StartCoroutine(SpawnIn());
            }
            if (max <= 0)
            {
                round1 = true;
            }
        }

        if (Tasks.startDefenseTwo && !round2)
        {
            max = 20;
            if (!doOnce && max > 0)
            {
                StartCoroutine(SpawnIn());
            }
            if (max <= 0)
            {
                round1 = true;
            }
        }

        if (Tasks.startDefenseThree && !round3)
        {
            max = 30;
            if (!doOnce && max > 0)
            {
                StartCoroutine(SpawnIn());
            }
            if (max <= 0)
            {
                round3 = true;
            }
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
