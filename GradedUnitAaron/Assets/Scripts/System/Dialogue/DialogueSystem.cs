using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        We link TMPro to update the Text and
        we get the array of dialogues and int
        to find the next index.
     */
    #endregion

    public TextMeshProUGUI dialogueText;
    private string[] dialogue;
    private int dialogueIndex;

    [SerializeField] private GameObject dialoguePanel;
    #endregion

    #region Unity Triggers
    void Update()
    {
        #region Comment
        /*
            If Player hits the enter key, it goes
            to the next line.
         */
        #endregion
        if (Input.GetKeyUp(KeyCode.Return))
            NextDialogue();
    }
    #endregion

    #region Methods

    #region Start
    #region Comment
    /*
        To start the dialogue, we make sure
        that the index is set to zero and 
        link the pass-through dialogue to
        the dialogue variable, then we set  
        the panel to be active so the player
        can see and then update TextMeshPro
        with the new details.
     */
    #endregion

    public void StartDialogue(string[] dialogue)
    {
        dialogueIndex = 0;
        this.dialogue = dialogue;
        dialoguePanel.SetActive(true);

        dialogueText.text = dialogue[dialogueIndex];
    }

    #endregion

    #region Next Line
    #region Comment
    /*
        We are making sure we stay within
        the parameters of the index and if we
        are out of the parameters that the
        condensation will end, if not then
        the next line will play after adding
        one.
     */

    #endregion

    public void NextDialogue()
    {
        dialogueIndex = Mathf.Min(dialogueIndex +1, dialogue.Length);

        if (dialogueIndex >= this.dialogue.Length)
            ResetDialogue();
        else
            dialogueText.text = dialogue[dialogueIndex];
    }
    #endregion

    #region Reset
    #region Comment
    /*
        When the convocation has ended, we
        want to clear out everything so that
        it is ready for the next dialogue to
        start by setting everything to null/0
        and hiding it.
     */

    #endregion

    public void ResetDialogue()
    {
        dialogue = null;
        dialogueText.text = null;
        dialoguePanel.SetActive(false);
        dialogueIndex = 0;
    }

    #endregion

    #endregion
}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE:    Wed, 4 May 2022
 * TIME:    21:30
 * BY:      Aaron Hamilton
 */
#endregion

#region Edit Logs
//Date: Wed, 18 May 2022 | Time: 15:40 | Edit by: Uniq
#endregion

#region Sources
/* Title:
 * By:
 * URL: 
 */
#endregion
#endregion

//Uniq Studio