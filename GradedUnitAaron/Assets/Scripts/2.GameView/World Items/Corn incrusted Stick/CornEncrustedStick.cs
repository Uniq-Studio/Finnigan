using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornEncrustedStick : TriggerSystem
{
    public GameObject self;

    void Update()
    {
        Interact(CollectItem);
    }

    void CollectItem()
    {
        Enemy.HasStick = true;
        Destroy(self);
    }

    void OnTriggerEnter(Collider other) { isClose = true; }
    void OnTriggerExit(Collider other) { isClose = false; }
}