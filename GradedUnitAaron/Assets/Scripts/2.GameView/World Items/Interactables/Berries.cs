using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berries : Interactable // ID:  0
{
    #region Variables
    #region Comment
    /*
		Linking its game object and calling
		itself for easy reference.
     */
    #endregion
    private bool doOnce;
    public GameObject berries;
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
        if (collider.CompareTag("Player") && !doOnce)
        {
            GetItem(berries, 0);
            doOnce = true;
            StartCoroutine(RespawnBerries());
        }
    }
    #endregion

    #region Respawn Berries
    #region Comment
    /*
        After a random amount of time the
        berries will respawn, depending if
        the box got filled over 100, this is
        so at the beginning the player can try
        to get as many as possible in the small
        play space.
     */
    #endregion
    private IEnumerator RespawnBerries()
    {
        if (Tasks.filledFoodBoxOver100)
        {
            yield return new WaitForSeconds(Random.Range(300, 450));
        }
        else
        {
            yield return new WaitForSeconds(Random.Range(30, 60));
        }

        berries.gameObject.SetActive(true);
        doOnce = false;
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
//Date: Mon, 25 Apr 2022 | Time: 17:34 | Edit by: Aaron Hamilton
//Date: Mon, 25 Apr 2022 | Time: 18:24 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	NONE
 * By:		NONE
 * URL: 	NONE
 */
#endregion
#endregion

//Uniq Studio