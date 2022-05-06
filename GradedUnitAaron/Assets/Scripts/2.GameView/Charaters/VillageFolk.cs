using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageFolk : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        Comments that are multiline should
        be around this length before starting
        a new line.
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
            Comments that are multiline should
            be around this length before starting
            a new line.
         */
        #endregion

        if (collider.CompareTag("Player"))
        {
            m_Dialogue.StartDialogue(dialogueOne.dialogue);
        }
    }

    void Update()
    {
        #region Comment
        /*
            Comments that are multiline should
            be around this length before starting
            a new line.
         */
        #endregion
    }
    #endregion

    #region Methods

    #region Method 1
    #region Comment
    /*
        Comments that are multiline should
        be around this length before starting
        a new line.
     */
    #endregion

    #endregion

    #endregion
}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE:
 * TIME:
 * BY:
 */
#endregion

#region Edit Logs
//Date: Mon, XX Jan 2000 | Time: 00:00 | Edit by: Uniq
#endregion

#region Sources
/* Title:
 * By:
 * URL: 
 */
#endregion
#endregion

//Uniq Studio