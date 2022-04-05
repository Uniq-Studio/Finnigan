using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem : MonoBehaviour
{
    public static bool isClose = false;

    public delegate void passingMethod();


    public static void Interact(passingMethod method)
    {
        if (isClose && Input.GetKeyDown(KeyCode.E))
        {
            method();
        }
    }    
}
