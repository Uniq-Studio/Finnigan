using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Interactable // ID:  3
{
    #region Variables
    #region Comment
    /*
		Linking its game object and calling
		itself for easy reference.
     */
    #endregion
    public GameObject self;
    #endregion

    #region Unity Triggers
    void OnTriggerEnter(Collider collider)
    {
        #region Comment
        /*
			When it sees the player, it will call
			the Interactable method Get item 
			calling itself with its ID. Then
			destroys itself after 3 minutes.
         */
        #endregion
        if (collider.CompareTag("Player"))
        {
            GetItem(self, 3);
            StartCoroutine(SelfDestroy(self));
        }
    }
    #endregion
}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE:	UNKNOWN
 * TIME:	UNKNOWN
 * BY:		Aaron Hamilton
 */
#endregion

#region Edit Logs
//Date: Mon, 25 Apr 2022 | Time: 17:12 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	NONE
 * By:		NONE
 * URL: 	NONE
 */
#endregion
#endregion

//Uniq Studio