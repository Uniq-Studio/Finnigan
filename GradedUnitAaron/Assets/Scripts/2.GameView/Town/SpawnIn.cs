using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIn : MonoBehaviour
{
    public GameObject DF1;
    public GameObject DF2;
    public GameObject DF3;

    // Update is called once per frame
    void Update()
    {
        if (Tasks.startDefenceOne && !Tasks.startDefenceTwo && !Tasks.startDefenceThree)
        {
            DF1.gameObject.SetActive(true);
        }
        else if (Tasks.startDefenceOne && Tasks.startDefenceTwo && !Tasks.startDefenceThree)
        {
            DF1.gameObject.SetActive(false);
            DF2.gameObject.SetActive(true);
        }
        else if (Tasks.startDefenceOne && Tasks.startDefenceTwo && Tasks.startDefenceThree)
        {
            DF2.gameObject.SetActive(false);
            DF3.gameObject.SetActive(true);
        }
    }
}
