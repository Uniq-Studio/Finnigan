using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIn : MonoBehaviour
{
    private UIUpdater UI;
    public GameObject DF1;
    public GameObject DF2;
    public GameObject DF3;

    void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
    }

    void Update()
    {
        if (Tasks.startDefenseOne && !Tasks.startDefenseTwo && !Tasks.startDefenseThree)
        {
            DF1.gameObject.SetActive(true);
            UI.UpdateTask("Perfect time, THE ENEMY ARE RAIDING US");

        }
        else if (Tasks.startDefenseOne && Tasks.startDefenseTwo && !Tasks.startDefenseThree)
        {
            DF1.gameObject.SetActive(false);
            DF2.gameObject.SetActive(true);
            UI.UpdateTask("New wall, ANOTHER RAID!");
        }
        else if (Tasks.startDefenseOne && Tasks.startDefenseTwo && Tasks.startDefenseThree)
        {
            DF2.gameObject.SetActive(false);
            DF3.gameObject.SetActive(true);
            UI.UpdateTask("LAST TIME! TAKE THEM DOWN!");
        }
    }
}
