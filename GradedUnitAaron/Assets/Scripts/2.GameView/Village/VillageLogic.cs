using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageLogic : MonoBehaviour
{
    private UIUpdater UI;
    public Collider m_Collider;

    private bool welcome;

    public static bool round1;
    public static bool round2;
    public static bool round3;

    void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
        m_Collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Welcome();
            SpawnInDefence();
        }
    }

    void Welcome()
    {
        if (!welcome)
        {
            UI.UpdateTask("Welcome to the Village! Lets talk to someone");
            Tasks.discoveredVillage = true;
            welcome = true;
        }
    }

    void SpawnInDefence()
    {
        if (round1 && !round2 && !round3)
            Tasks.startDefenseOne = true;

        if (round1 && round2 && !round3)
            Tasks.startDefenseTwo = true;

        if (round1 && round2 && round3)
        {
            Tasks.startDefenseThree = true;
            Tasks.talkToTheEnemy = true;
        }
        
    }
}
