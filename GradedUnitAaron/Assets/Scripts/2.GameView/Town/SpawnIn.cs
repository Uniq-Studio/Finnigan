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
        if (Tasks.startDefenseOne && !Tasks.startDefenseTwo && !Tasks.startDefenseThree)
        {
            DF1.gameObject.SetActive(true);
        }
        else if (Tasks.startDefenseOne && Tasks.startDefenseTwo && !Tasks.startDefenseThree)
        {
            DF1.gameObject.SetActive(false);
            DF2.gameObject.SetActive(true);
        }
        else if (Tasks.startDefenseOne && Tasks.startDefenseTwo && Tasks.startDefenseThree)
        {
            DF2.gameObject.SetActive(false);
            DF3.gameObject.SetActive(true);
        }
    }
}
