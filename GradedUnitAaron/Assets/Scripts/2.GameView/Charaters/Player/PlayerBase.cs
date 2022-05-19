using System.Collections;
using NGS.ExtendableSaveSystem;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
		We link the Character Base; for the
		health the game master is also linked
		to help save the Player’s position
		and the dialogue that the player will
		say.
		We want to get the players location
		as a see able variable for other
		scripts to see it. And we want access
		to the hitbox.
		Theres a link to a Text on the UI to
		display the health.
		There are the links to the dialogue
		that will be spoken.
		DoOnces that will make script only
		run once when they hit their conditions.
     */
    #endregion

    public static CharacterBase m_CharacterBase = new CharacterBase();
    private GameMaster m_GM;
    [SerializeField] private DialogueSystem m_Dialogue;

    public static Transform m_Transform;
    public GameObject hitBox;

    public Text healthText;

    [SerializeField] private SO_DialogueData dialogueOne;
    [SerializeField] private SO_DialogueData dialogueTwo;
    [SerializeField] private SO_DialogueData dialogueThree;

    private bool doOnce;
    private bool doneDialogue2;
    private bool doneDialogue3;
    #endregion

    #region Unity Triggers
    void Start()
    {
        #region Comment
        /*
			We need to link the game master and
			then we will do a quick check where
			if the player has selected to resume
			the game and then runs the load, else
			we just start the dialogue.
			We also set the health and health max.
         */
        #endregion
        m_GM = FindObjectOfType<GameMaster>();

        if (GameMaster.triggerLoad)
            m_GM.LoadGame();
        else
            m_Dialogue.StartDialogue(dialogueOne.dialogue);

        m_CharacterBase.health = 10;
        m_CharacterBase.healthMax = 10;
    }

    void Update()
    {
        #region Comment
        /*
			We constantly update the health
			onscreen and the players location.
			We keep repeating the regeneration
			health script.
			If the player has no health, then it
			calls the dead method.
			If the player clicks, then it makes
			the hit box appear which will take
			enemy damage if they are close enough.
			Lastly its waiting for the conditions
			to start displaying the required
			dialogue.
         */
        #endregion
        healthText.text = "Health: " + m_CharacterBase.health;
        m_Transform = transform;

        if (!doOnce)
        {
            StartCoroutine(ReGenHealth());
            doOnce = true;
        }

        if (m_CharacterBase.health <= 0)
            Dead();

        if (Input.GetKeyDown(KeyCode.Mouse0))
            hitBox.gameObject.SetActive(true);

        if (Input.GetKeyUp(KeyCode.Mouse0))
            hitBox.gameObject.SetActive(false);

        if (Tasks.checkedFood && !doneDialogue2)
        {
            m_Dialogue.StartDialogue(dialogueTwo.dialogue);
            doneDialogue2 = true;
        }

        if (Tasks.allFoodStealersGone && !doneDialogue3)
        {
            m_Dialogue.StartDialogue(dialogueThree.dialogue);
            doneDialogue3 = true;
        }
    }
    #endregion

    #region Methods

    #region Dead
    #region Comment
    /*
		When the player has no more health
		and this is called, we just reload
		the game.
     */
    #endregion
    void Dead()
    {
        m_GM.LoadGame();
        Debug.LogError("YOU DIED!");
    }
    #endregion

    #region ReGenHealth
    #region Comment
    /*
		We wait 5 seconds before starting
		the code, then we check if the player
		is low on health, if so we add one.
		Just in case the player somehow went
		over health we set it to the max.
		We set DOONCE to false so we can
		rerun this code.
     */
    #endregion

    IEnumerator ReGenHealth()
    {
        yield return new WaitForSeconds(5);

        if (m_CharacterBase.health < m_CharacterBase.healthMax)
            m_CharacterBase.health++;
        else if (m_CharacterBase.health > m_CharacterBase.healthMax)
            m_CharacterBase.health = m_CharacterBase.healthMax;

        doOnce = false;
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
//Date: Wed, 18 Apr 2022 | Time: 12:40 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	NONE
 * By:		NONE
 * URL: 	NONE
 */
#endregion
#endregion

//Uniq Studio