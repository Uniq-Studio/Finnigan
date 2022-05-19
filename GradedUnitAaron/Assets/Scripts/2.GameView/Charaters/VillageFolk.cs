using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageFolk : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        We link the Village Folk’s dialogue.
     */
    #endregion

    [SerializeField] private SO_DialogueData dialogueOne;
    [SerializeField] private DialogueSystem m_Dialogue;
    #endregion

    #region Unity Triggers
    void OnTriggerEnter(Collider collider)
    {
        #region Comment
        /*
            If the player walks up, the dialogue
            starts.
         */
        #endregion

        if (collider.CompareTag("Player"))
        {
            m_Dialogue.StartDialogue(dialogueOne.dialogue);
        }
    }
    #endregion
}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE:    UNKNOWN
 * TIME:    UNKNOWN
 * BY:      Aaron Hamilton
 */
#endregion

#region Edit Logs
//Date: Wed, 18 May 2022 | Time: 14:00 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:   NONE
 * By:      NONE
 * URL:     NONE
 */
#endregion
#endregion

//Uniq Studio