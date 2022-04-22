using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sick : Interactable //2
{
    public GameObject self;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            GetItem(self, 2);
        }

    }
}
