using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem : MonoBehaviour
{
    //This helps us pass the Method
    public delegate void passingMethod();

    void Update()
    {
    }
    /* This should be called when the player is close to the item
     * and pass through the code chunk that you want to run */
    public void Interact(passingMethod method, Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            method();
        }
    }
}
