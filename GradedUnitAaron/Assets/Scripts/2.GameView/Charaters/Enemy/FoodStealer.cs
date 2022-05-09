using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStealer : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
		We want a refence to itself to delete
		it, and to make the code more
		understandable. It is also a character
		so it will need the base and we want
		to update the UI.
		In combat helps trigger it into fight
		mode and some DoOnces to run some
		code once as it will be in the Update
		function.
     */
    #endregion

    public GameObject self;
    private CharacterBase m_CharacterBase = new CharacterBase();
    private UIUpdater UI;

    private bool inCombat;

    private bool doOnce;
    private bool doOnceReheal;
    private bool doOnceDamage;

    [SerializeField] private SO_DialogueData dialogueOne;
    [SerializeField] private DialogueSystem m_Dialogue;
    #endregion

    #region Unity Triggers
    void Start()
    {
        #region Comment
        /*
			We link the object to the variables
			to use their methods and set the
			health and max health.
         */
        #endregion
        m_Dialogue = FindObjectOfType<DialogueSystem>();
        UI = FindObjectOfType<UIUpdater>();
        m_CharacterBase.health = 5;
        m_CharacterBase.healthMax = 5;
    }

    void Update()
    {
        #region Comment
        /*
			When it spawns in it will start off
			stealing berries, but if it gets
			attacked while it still has health
			it runs the Attack logic from
			another script.
			When the Food Stealer is out of
			health then it will disable the 
			Attack script and disable combat
			then deletes itself.
			The last loop is a forever loop of
			the Foodstealer rehealing.
         */
        #endregion
        //Debug.Log(m_CharacterBase.health);

        if (!inCombat)
        {
            StartCoroutine(StealingLoop());
        }
        else if (m_CharacterBase.health >= 1 && inCombat)
        {
            FollowAttackPlayer.enabled = true;
        }

        if (m_CharacterBase.health <= 0 && FoodBox.attackAttempts <= 3)
        {
            FollowAttackPlayer.enabled = false;
            inCombat = false;
            Dead();
        }

        if (!doOnceReheal)
        {
            StartCoroutine(Reheal());
            doOnceReheal = true;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        #region Comment
        /*
			If it collides with a box in front
			of the player, the attacking box, it
			takes 1 health and only run once
			until it unlocks.
         */
        #endregion
        if (collider.CompareTag("PlayerAttack") && !doOnceDamage)
        {
            StartCoroutine(TakeHealth());
        }
    }
    #endregion

    #region Methods

    #region Stealing Loop
    #region Comment
    /*
		First it checks if it can do it, the
		checks the storage is more than 0,
		if so, it will take 1 berry, another
		percussion making sure were not in
		the negatives by resetting it back to
		0 if we go in the negatives. Then
		update the UI, doing this way make
		resource lighter rather than running
		it every time in update. After 4
		seconds setting it to false to let it
		run again.
     */
    #endregion

    IEnumerator StealingLoop()
    {
        if (!doOnce)
        {
            if (FoodBox.storage > 0)
            {
                FoodBox.storage -= 1;
                if (FoodBox.storage < 0)
                    FoodBox.storage = 0;
            }

            UI.UpdateBerriesBox(FoodBox.storage);

            doOnce = true;
            yield return new WaitForSeconds(2);
            doOnce = false;
        }

    }

    #endregion

    #region Take Health
    #region Comment
    /*
		The FoodStealer gets hit, we put it
		in combat mode and take 1 health and
		set a 1 sec timer so you can spam
		the button to kill it.
     */
    #endregion
    IEnumerator TakeHealth()
    {
        inCombat = true;
        m_CharacterBase.health--;
        doOnceDamage = true;
        yield return new WaitForSeconds(1);
        doOnceDamage = false;
    }

    #endregion

    #region Reheal
    #region Comment
    /*
		Reheal will only run once every 3
		seconds, then it checks if the 
		character’s health is lower than it's
		Max and if so, it will add 1. Just in
		case we make sure that if current
		health is more than the max to reset
		it back to the max. Then we set
		reheal to false so we can run it
		again.
     */
    #endregion

    IEnumerator Reheal()
    {
        yield return new WaitForSeconds(3);
        if (m_CharacterBase.health < m_CharacterBase.healthMax)
            m_CharacterBase.health++;


        if (m_CharacterBase.health > m_CharacterBase.healthMax)
            m_CharacterBase.health = m_CharacterBase.healthMax;

        doOnceReheal = false;

    }

    #endregion

    #region Dead
    #region Comment
    /*
		We check if the FoodStealer is out
		of health and making sure it was not
		the 3rd one the reset the spawn in
		loop on FoodBox then inform the
		player to look for more berries.
		On the 3rd attempt the dialogue will
		start.
     */
    #endregion
    void Dead()
    {
        if (m_CharacterBase.health <= 0 && FoodBox.attackAttempts < 3)
        {
            FoodBox.doOnce = false;
            UI.UpdateTask("They are gone! Time to get more berries.");
            Destroy(self);
        }

        if (FoodBox.attackAttempts >= 3)
        {
            StartCoroutine(DialogueDieLogic());
        }
    }

    #endregion

    #region Dialogue before 3rd death
    #region Comment
    /*
		We start the dialogue and start a 10
		second timer, so it feels like you
		are listening to him then he will
		despawn and then the UI tells you to
		find the village and update the Tasks
		list then finally removing the last
		FoodStealer.
     */
    #endregion

    IEnumerator DialogueDieLogic()
    {
        m_Dialogue.StartDialogue(dialogueOne.dialogue);
        yield return new WaitForSeconds(10);
        UI.UpdateTask("Lets explore and find the village");
        Tasks.allFoodStealersGone = true;
        Destroy(self);
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
//Date: Mon, 09 May 2022 | Time: 17:20 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	NONE
 * By:		NONE
 * URL: 	NONE
 */
#endregion
#endregion

//Uniq Studio