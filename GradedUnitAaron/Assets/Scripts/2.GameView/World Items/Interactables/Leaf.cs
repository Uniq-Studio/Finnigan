using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Interactable //3
{
    public GameObject self;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            GetItem(self, 3);
        }
        
    }
}
