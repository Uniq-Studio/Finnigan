using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutBoar : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        Comments that are multiline should
        be around this length before starting
        a new line.
     */
    #endregion

    private CharacterBase m_characterBase = new CharacterBase();

    [SerializeField] private SO_DialogueData dialogueOne;
    [SerializeField] private DialogueSystem m_Dialogue;
    #endregion

    #region Unity Triggers
    void Start()
    {
        #region Comment
        /*
            Comments that are multiline should
            be around this length before starting
            a new line.
         */
        #endregion

        m_characterBase.health = 2;
    }

    void Update()
    {
        if (m_characterBase.health <= 0)
            TutTasks.killed = true;
    }

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
            Inventory.berryAmount = 0;
            Inventory.leafAmount = 0;
            Inventory.stickAmount = 0;
            Inventory.stoneAmount = 0;
            m_Dialogue.StartDialogue(dialogueOne.dialogue);
            TutTasks.Interacted = true;
        }

        if (collider.CompareTag("PlayerAttack"))
            m_characterBase.health--;
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