using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownLogic : MonoBehaviour
{
    private UIUpdater UI;
    public Collider m_Collider;

    void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
        m_Collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            UI.UpdateTask("Welcome to the Village! Lets talk to someone");
            Tasks.discoveredVillage = true;
            m_Collider.enabled = false;
        }
    }
}
