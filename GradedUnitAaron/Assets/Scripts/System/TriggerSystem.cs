using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem : MonoBehaviour
{
    private bool isClose = false;

    public delegate void passingMethod();


    void Interact(passingMethod method)
    {
        if (isClose && Input.GetKeyDown(KeyCode.E))
        {
            method();
        }
    }
}
