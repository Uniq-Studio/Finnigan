using System.Collections;
using UnityEngine;

public class Defense_Maker : BuildingBase
{
    #region Variables
    #region Comment
    /*
        We have a DOONCE so the script can be
        run more than once by accident. And we
        have some Booleans for what round we
        are on with the Village Attackers, so
        we don’t start round 3 straight away
        and make the player lose all their items.
     */
    #endregion

    private bool doOnce;

    public static bool r1;
    public static bool r2;
    public static bool r3;
    public static bool CESEnabled;
    #endregion

    #region Unity Triggers

    void Start()
    {
        UI = FindObjectOfType<UIUpdater>();
        
    }
    void OnTriggerEnter(Collider collider)
    {
        #region Comment
        /*
            We want to check the Collider is seeing
            the player and ONONCE only runs the code
            once, the switch logic is so it knows
            what round we are on, so it takes what
            we need to take from the player, so it
            does not take more stuff off the player
            then we expect it to.
            If the player does not have the requirements
            two go to the next stage, then it will tell
            the player and the unlock feature is, so
            DOONCE gets disabled allowing the code to 
            work again.
            DOONCE being true at the end is so that the
            code can only run once, just for security
            that it will not take more from the player.
         */
        #endregion
        if (collider.CompareTag("Player") && !doOnce)
        {
            if (!Tasks.LearnAboutCES)
            {
                switch (TownLogic.roundCount)
                {
                    case 0:
                        if (r1)
                        {
                            RequirementsCheck(10, 20, 20, 7, 2, IncreaseNext, "Builder");
                            break;
                        }
                        else
                        {
                            UI.UpdateSubTask("You need to go to the Forger first.");
                            StartCoroutine(Unlock());
                            break;
                        }
                    case 1:
                        if (r2)
                        {
                            RequirementsCheck(30, 40, 30, 10, 2, IncreaseNext, "Builder");
                            break;
                        }
                        else
                        {
                            UI.UpdateSubTask("You need to go to the Forger first.");
                            StartCoroutine(Unlock());
                            break;
                        }
                    case 2:
                        if (r3)
                        {
                            RequirementsCheck(35, 50, 35, 5, 2, IncreaseNext, "Builder");
                            break;
                        }
                        else
                        {
                            UI.UpdateSubTask("You need to go to the Forger first.");
                            StartCoroutine(Unlock());
                            break;
                        }
                }
            }
            else if (CESEnabled)
            {
                RequirementsCheck(35,35,35,35,2,IncreaseNext,"Builder");
            }
            doOnce = true;
        }
    }
    #endregion

    #region Methods

    #region Increase Next
    #region Comment
    /*
        We want to enable the next round on
        the next building so we can walk up
        to it and start the script.
     */
    #endregion

    void IncreaseNext()
    {
        if (!Tasks.LearnAboutCES)
        {
            switch (TownLogic.roundCount)
            {
                case 0:
                    Builder.DefenseOneReady = true;
                    break;
                case 1:
                    Builder.DefenseTwoReady = true;
                    break;
                case 2:
                    Builder.DefenseThreeReady = true;
                    break;
            }
        }
        else if (CESEnabled)
        {
            Builder.CESEnabled = true;
        }
        
        doOnce = false;
    }
    #endregion

    #region Unlocker
    #region Comment
    /*
        If the player try to interact with
        the building but didn't go to the
        previous building first then it will
        notify the player but then that bit
        of code would be locked so we need
        the unlock code to automatically
        turn off DOONCE.
    */
    #endregion
    IEnumerator Unlock()
    {
        Debug.Log("Timer started");
        yield return new WaitForSeconds(2);
        doOnce = false;
        Debug.Log("Unlocked");
    }
    #endregion

    #endregion
}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE:    Wed, 27 Apr
 * TIME:    15:03
 * BY:      Aaron Hamilton
 */
#endregion

#region Edit Logs
//Date: Thurs, 28 Apr 2022  | Time: 10:30 | Edit by: Aaron Hamilton
//Date: Sat, 30 Apr 2022    | Time: 14:00 | Edit By: Aaron Hamilton
#endregion

#region Sources
/* Title:
 * By:
 * URL: 
 */
#endregion
#endregion

//Uniq Studio