using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutBush : MonoBehaviour
{
    #region Unity Triggers
    void OnTriggerEnter(Collider collider)
    {
        #region Comment
        /*
            When the player Picks up the berries it
            updates the list to done.
            Comments that are multiline should
            be around this length before starting
            a new line.
         */
        #endregion

        if (collider.CompareTag("Player"))
        {
            TutTasks.pickedUpBerries = true;
            Destroy(gameObject);
        }
    }
    #endregion


}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE:    Mon, 9 May 2022
 * TIME:    21:50
 * BY:      Aaron Hamilton
 */
#endregion

#region Edit Logs
//Date: Mon, XX Jan 2000 | Time: 00:00 | Edit by: Uniq
#endregion

#region Sources
/* Title:   NONE
 * By:      NONE
 * URL:     NONE
 */
#endregion
#endregion

//Uniq Studio