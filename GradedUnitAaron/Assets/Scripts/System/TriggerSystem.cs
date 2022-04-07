using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem : MonoBehaviour
{
    public static bool isClose = false;
    //This helps us pass the Method
    public delegate void passingMethod();


    /* This should be called whrn the player is close to the item
     * and pass through the code chunk that you want to run */
     
    public static void Interact(passingMethod method)
    {
        if (isClose && Input.GetKeyDown(KeyCode.E))
        {
            method();
        }
    }    
}
