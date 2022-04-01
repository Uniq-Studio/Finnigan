using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornEncrustedStick : MonoBehaviour
{
    public GameObject self;
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Trigger");
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player Trigger");
            Wolf.HasStick = true;
            Destroy(self);
        }
    }
}
