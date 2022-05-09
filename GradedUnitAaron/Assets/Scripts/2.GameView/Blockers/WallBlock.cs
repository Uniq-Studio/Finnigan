using System.Collections;
using System.Collections.Generic;
using NGS.ExtendableSaveSystem;
using UnityEngine;

public class WallBlock : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        We created the scripts as a variable
        and get itself and call it ‘SELF’ for
        easier coding.
     */
    #endregion

    public GameObject self;

    private UIUpdater UI;
    private GameMaster m_GM;

    private bool doOnce;

    #endregion

    #region Unity Triggers
    void Start()
    {
        #region Comment
        /*
            We need unity to find the UI script
            and the Game Master script to use
            the methods.
         */
        #endregion

        UI = FindObjectOfType<UIUpdater>();
        m_GM = FindObjectOfType<GameMaster>();
    }

    void Update()
    {
        #region Comment
        /*
            Once the player must find the village,
            it will update the blocker location
            and save the game. When the game
            moves it and saves it and then it
            will destroy itself. It will happen
            straightway when the game loads..
         */
        #endregion
        if (Tasks.allFoodStealersGone && Tasks.filledFoodBoxOver100)
        {
            transform.localPosition += new Vector3(0, -150, 0);
            m_GM.SaveGame();
        }

        if (transform.localPosition.y <= -90)
        {
            Destroy(self);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        #region Comment
        /*
            If the player walks into it, a
            notification will tell them not to
            venture on.
         */
        #endregion
        if (collider.CompareTag("Player") && !doOnce)
        {
            UI.UpdateSubTask("You shouldn't adventure that far from your cubs!");
            doOnce = true;
            StartCoroutine(Timer());
        }
    }
    #endregion

    #region Methods

    #region Timer
    #region Comment
    /*
        The timer is there so it only displays
        once, and it does not spam the player
        until it time to show it again.
        Comments that are multiline should
        be around this length before starting
        a new line.
     */
    #endregion

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(20);
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
//Date: Mon, 09 May 2022 | Time: 16:15 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	NONE
 * By:		NONE
 * URL: 	NONE
 */
#endregion
#endregion

//Uniq Studio