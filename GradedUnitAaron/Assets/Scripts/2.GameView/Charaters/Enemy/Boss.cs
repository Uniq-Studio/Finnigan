using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        HAS STICK will only update when the
        player collects the corn encrusted
        stick. And we created unique classes
        of the base character and the trigger
        system to prevent interfering with
        other objects.
        The dialogue script will be linked
        to start the dialogue with refences
        to the bosses 2 dialogues.
     */
    #endregion

    public static bool HasStick = false;
    private CharacterBase m_CharacterBase = new CharacterBase();
    private TriggerSystem m_TriggerSystem = new TriggerSystem();

    [SerializeField] private DialogueSystem m_Dialogue;
    [SerializeField] private SO_DialogueData dialogueOne;
    [SerializeField] private SO_DialogueData dialogueTwo;

    #endregion

    #region Unity Triggers
    void OnTriggerEnter(Collider collider)
    {
        #region Comment
        /*
            If the player collides with the boss
            the trigger system will run both code
            and if any are meting its condition
            then it will run.
            Comments that are multiline should
            be around this length before starting
            a new line.
         */
        #endregion

        m_TriggerSystem.Interact(EndGame, collider);
        m_TriggerSystem.Interact(RequestForStick, collider);
    }
    #endregion

    #region Methods

    #region Request Stick
    #region Comment
    /*
        This will run the dialogue for
        requesting for the stick and then
        makes it able to create the stick at
        the town while disabling the code
        from running again.
     */
    #endregion

    void RequestForStick()
    {
        if (!Tasks.LearnAboutCES)
        {
            m_Dialogue.StartDialogue(dialogueOne.dialogue);
            Tasks.LearnAboutCES = true;
            BuilderCharacter.dialogueCount = 5;
        }
    }
    #endregion

    #region End Game
    #region Comment
    /*
        When the player has the stick, it
        will then start the game over dialogue
        and the end the game.
     */
    #endregion

    void EndGame()
    {
        if (HasStick)
        {
            m_Dialogue.StartDialogue(dialogueTwo.dialogue);
            Debug.Log("Game Over");
            MainMenu.gameOver = true;
            StartCoroutine(MenuTimer());
        }
    }
    #endregion

    #region End Game Timer
    #region Comment
    /*
        When the player has the stick, it
        will then start the game over dialogue
        and the end the game.
     */
    #endregion

    IEnumerator MenuTimer()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }
    #endregion

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
//Date: Mon, 09 May 2022 | Time: 16:50 | Edit by: Aaron Hamilton
//Date: Tus, 10 May 2022 | Time: 12:45 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	NONE
 * By:		NONE
 * URL: 	NONE
 */
#endregion
#endregion

//Uniq Studio