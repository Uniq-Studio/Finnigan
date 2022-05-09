using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownAttacker : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
		This is a character so it will get a
		refence to the base. Number is which
		building it will go for. Combat is to
		see if it got attacked so in goes and
		attack the player. DOONCEREHEAL will
		make the character reheal once as it
		is in update.
     */
    #endregion

    private CharacterBase m_CharacterBase = new CharacterBase();
    private int num;
    private bool combat;
    private bool doOnceReheal;

    #endregion

    #region Unity Triggers
    void Start()
    {
        #region Comment
        /*
			We set the health and walk speed then
			we select a random number, which
			corresponds to a building then it
			goes to it.
         */
        #endregion
        m_CharacterBase.walkSpeed = 5;
        m_CharacterBase.health = 5;
        m_CharacterBase.healthMax = 5;

        num = Mathf.RoundToInt(Random.Range(1, 6));
        Debug.Log("Im going for " + num);
    }

    void Update()
    {
        #region Comment
        /*
			When the character isn’t in combat
			then it will go to the random
			building it chose to go to. If the
			player does attack it, it will call
			from the Attack script. While all
			this happens it reheal itself.
         */
        #endregion
        if (!combat)
        {
            if (num == 1)
            {
                lookAt(370, 39, 30);
            }
            else if (num == 2)
            {
                lookAt(310, 39, 55);
            }
            else if (num == 3)
            {
                lookAt(290, 39, 35);
            }
            else if (num == 4)
            {
                lookAt(350, 41, 55);
            }
            else if (num == 5)
            {
                lookAt(330, 43, 75);
            }
            else
            {
                Debug.LogError("How did the random gen fall out of its restrictions? " + num);
            }

            transform.position += transform.forward * m_CharacterBase.walkSpeed * Time.deltaTime;
        }
        else 
            FollowAttackPlayer.enabled = true;
        

        if (!doOnceReheal)
            StartCoroutine(Reheal());
    }

    void OnTriggerEnter(Collider collider)
    {
        #region Comment
        /*
			When the player attacks it, it goes
			and attacks the player.
         */
        #endregion
        if (collider.CompareTag("PlayerAttack"))
            combat = true;
    }
    #endregion

    #region Methods

    #region Look At Building
    #region Comment
    /*
		The character will look at what
		corrodents we give it.
     */
    #endregion
    void lookAt(int x, int y, int z)
    {
        transform.LookAt(new Vector3(x, y, z));
    }
    #endregion

    #region Reheal
    #region Comment
    /*
		If the health is lower than its max
		then it will regenerate by one per 3
		seconds, if it goes over somehow it
		will set it to just the max. Then
		does its usual loop.
     */
    #endregion

    IEnumerator Reheal()
    {
        if (!doOnceReheal)
        {
            if (m_CharacterBase.health < m_CharacterBase.healthMax)
                m_CharacterBase.health++;

            if (m_CharacterBase.health > m_CharacterBase.healthMax)
                m_CharacterBase.health = m_CharacterBase.healthMax;


            doOnceReheal = true;
        }
        yield return new WaitForSeconds(3);
        doOnceReheal = false;
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
//Date: Mon, 09 May 2022 | Time: 19:30 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	NONE
 * By:		NONE
 * URL: 	NONE
 */
#endregion
#endregion

//Uniq Studio