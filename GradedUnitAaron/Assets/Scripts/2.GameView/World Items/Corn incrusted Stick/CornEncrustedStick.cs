using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornEncrustedStick : MonoBehaviour
{
    private bool isClose = false;
    public GameObject self;

    void Update()
    {
        if (isClose && Input.GetKeyDown(KeyCode.E))
        {
            Enemy.HasStick = true;
            Destroy(self);
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")) { isClose = true; }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player")) { isClose = false; }
    }
}
