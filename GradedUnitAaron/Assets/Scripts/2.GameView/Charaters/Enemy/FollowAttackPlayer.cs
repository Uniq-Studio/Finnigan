using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAttackPlayer : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
		ENABLE can be triggered from another
		script when it detects that they were
		attacked and DOONCE is to make sure
		code run once.
     */
    #endregion

    public static bool enabled = false;

    private bool doOnce;
    #endregion

    #region Unity Triggers
    void Update()
    {
        #region Comment
        /*
			Once another script enables it, it
			will check its own location and
			the players, if its more than 3
			unity distance then it will look
			at the player then move forward
			towards where its looking.
			Once in the 3 Unity distance, it wil
			l call the take health and make sure
			it runs once.
         */
        #endregion

        if (enabled)
        {
            if (Vector3.Distance(transform.position, PlayerBase.m_Transform.position) >= 3)
            {
                transform.LookAt(PlayerBase.m_Transform);
                transform.position += transform.forward * 3f * Time.deltaTime;
            }

            if (Vector3.Distance(transform.position, PlayerBase.m_Transform.position) <= 3)
            {
                transform.LookAt(PlayerBase.m_Transform);
                if (!doOnce)
                {
                    StartCoroutine(TakePlayerHealth());
                    doOnce = true;
                }
            }
        }
    }
    #endregion

    #region Methods

    #region Take Player's Health
    #region Comment
    /*
		After a second it will take 1 health
		from the player and then waits 4
		seconds to attack the player again,
		if they are in range.
	*/
    #endregion

    IEnumerator TakePlayerHealth()
    {
        yield return new WaitForSeconds(1);
        PlayerBase.m_CharacterBase.health--;
        yield return new WaitForSeconds(2);
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
//Date: Mon, 09 May 2022 | Time: 17:05 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	How to make enemy chase player. Basic AI
 * By:		Sandr0G
 * URL: 	https://answers.unity.com/questions/274809/how-to-make-enemy-chase-player-basic-ai.html
 */
#endregion
#endregion

//Uniq Studio