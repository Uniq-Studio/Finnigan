using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderCharacter : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        We want to link all of the Builders 
        Dialogue. and we get the DIALOGUE 
		and TRIGGER system and start at 
		the first line of dialogue.
     */
    #endregion

    [SerializeField] private SO_DialogueData dialogueOne;
    [SerializeField] private SO_DialogueData dialogueTwo;
    [SerializeField] private SO_DialogueData dialogueThree;
    [SerializeField] private SO_DialogueData dialogueFour;
    [SerializeField] private SO_DialogueData dialogueFive;

    [SerializeField] private DialogueSystem m_Dialogue;
    private TriggerSystem m_TriggerSystem = new TriggerSystem();

    public static int dialogueCount = 1;

    #endregion

    #region Unity Triggers
    void OnTriggerEnter(Collider collider)
    {
        #region Comment
        /*
			We use the Interact to start the dialogue.
         */
        #endregion
        m_TriggerSystem.Interact(StartDialogue, collider);
    }
    #endregion

    #region Methods

    #region Dialogues
    #region Comment
    /*
		Depending on what DIALOGUECOUNT we
		are one will run its corresponding 
		dialogue.
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
 * DATE:    Wed, 4 May 2022
 * TIME:    21:15
 * BY:      Aaron Hamilton
 */
#endregion

#region Edit Logs
//Date: Wed, 18 May 2022 | Time: 13:56 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	NONE
 * By:		NONE
 * URL: 	NONE
 */
#endregion
#endregion

//Uniq Studio