using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSystem : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        passingMethod will help us pass through
        the method that we want. This is so we
        can write one line of code to check if the
        player has entered the collider.
        One issue we have right now is that it 
        will only run once and if we want to be
        able to press a key this code needs to 
        keep lopping which right now is not possible
        but does not affect gameplay drastically.
     */
    #endregion
    public delegate void passingMethod();

    #endregion

    #region Methods

    #region Interaction
    #region Comment
    /*
        When there’s item I want the player to
        interact with.I can call this method 
		and pass through what I want the interaction
		to do. 
        You also need to pass through the collider
        so it can see what collider it needs to check
        to see if the player has entered to run said
		method.
     */
    #endregion

    public void Interact(passingMethod method, Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            method();
        }
    }
    #endregion

    #endregion
}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE: 	UNKNOWN
 * TIME: 	UNKNOWN
 * BY:		Aaron Hamilton
 */
#endregion

#region Edit Logs
//Date: Mon, 25 Apr 2022 | Time: 15:50 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	How can i pass a method like a parameter Unity3d C#?
 * By:		ThePersister
 * URL: 	https://answers.unity.com/questions/1277650/how-can-i-pass-a-method-like-a-parameter-unity3d-c.html
 */
#endregion
#endregion

//Uniq Studio