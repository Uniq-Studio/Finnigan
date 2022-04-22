using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Interactable //1
{
    public GameObject self;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            GetItem(self, 1);
        }
    }
}
