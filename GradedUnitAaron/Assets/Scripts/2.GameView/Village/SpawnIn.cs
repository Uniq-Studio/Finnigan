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

    private bool doOnceR1;
    private bool doOnceR2;
    private bool doOnceR3;

    void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
    }

    void Update()
    {
        if (Tasks.startDefenseOne && !Tasks.startDefenseTwo && !Tasks.startDefenseThree && !doOnceR1)
        {
            DF1.gameObject.SetActive(true);
            UI.UpdateTask("Perfect time, THE ENEMY ARE RAIDING US");
            doOnceR1 = true;
        }
        else if (Tasks.startDefenseOne && Tasks.startDefenseTwo && !Tasks.startDefenseThree && !doOnceR2)
        {
            DF1.gameObject.SetActive(false);
            DF2.gameObject.SetActive(true);
            UI.UpdateTask("New wall, ANOTHER RAID!");
            doOnceR2 = true;
        }
        else if (Tasks.startDefenseOne && Tasks.startDefenseTwo && Tasks.startDefenseThree && !doOnceR3)
        {
            DF2.gameObject.SetActive(false);
            DF3.gameObject.SetActive(true);
            UI.UpdateTask("LAST TIME! TAKE THEM DOWN!");
            doOnceR3 = true;
        }
    }
}
