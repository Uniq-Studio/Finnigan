using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderCharacter : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        We want to link all of the Builders 
        Dialogue
     */
    #endregion

    [SerializeField] private SO_DialogueData dialogueOne;
    [SerializeField] private SO_DialogueData dialogueTwo;
    [SerializeField] private SO_DialogueData dialogueThree;
    [SerializeField] private SO_DialogueData dialogueFour;
    [SerializeField] private SO_DialogueData dialogueFive;

    [SerializeField] private DialogueSystem m_Dialogue;
    private TriggerSystem m_TriggerSystem = new TriggerSystem();

    private int dialogueCount = 1;

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
            m_TriggerSystem.Interact(StartDialogue, collider);
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

    private void StartDialogue()
    {
        switch (dialogueCount)
        {
            case 1:
                m_Dialogue.StartDialogue(dialogueOne.dialogue);
                break;
            case 2:
                m_Dialogue.StartDialogue(dialogueTwo.dialogue);
                break;
            case 3:
                m_Dialogue.StartDialogue(dialogueThree.dialogue);
                break;
            case 4:
                m_Dialogue.StartDialogue(dialogueFour.dialogue);
                break;
            case 5:
                m_Dialogue.StartDialogue(dialogueFive.dialogue);
                break;
        }
    }
    #endregion

    #endregion
}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE:    Wed, 4 May
 * TIME:    21:15
 * BY:      Aaron Hamilton
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