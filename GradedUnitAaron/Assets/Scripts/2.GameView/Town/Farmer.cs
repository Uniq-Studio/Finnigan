using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : BuildingBase
{
    #region Variables
    #region Comment
    /*
        Run code once.
     */
    #endregion
    private bool doOnce;

    #endregion

    #region Unity Triggers
    void Start()
    {
        #region Comment
        /*
            Link UI Script to update the UI.
         */
        #endregion
        UI = FindObjectOfType<UIUpdater>();
    }

    void OnTriggerEnter(Collider collider)
    {
        #region Comment
        /*
            After seeing the Player, it will
            check if the player has the items it
            need to go and create the defense.
            Unless they learnt about CES and then
            will let you build the CES.
         */
        #endregion
        if (collider.CompareTag("Player") && !doOnce)
        {
            if (!Tasks.LearnAboutCES)
            {
                switch (TownLogic.roundCount)
                {
                    case 0:
                        RequirementsCheck(30, 10, 20, 5, 2, IncreaseNext, "Miners");
                        break;
                    case 1:
                        RequirementsCheck(60, 25, 10, 10, 2, IncreaseNext, "Miners");
                        break;
                    case 2:
                        RequirementsCheck(65, 30, 20, 20, 2, IncreaseNext, "Miners");
                        break;

                }
            }
            else if (Tasks.LearnAboutCES)
                RequirementsCheck( 25,30,15,40,2,IncreaseNext, "Miners");
            
            doOnce = true;
        }
    }
    #endregion

    #region Methods

    #region Miners Increase 
    #region Comment
    /*
        This update the next scripts
        variables unless it’s about the CES
        then it tells the next one that CES
        is enabled.
     */
    #endregion

    void IncreaseNext()
    {
        if (!Tasks.LearnAboutCES)
        {
            switch (TownLogic.roundCount)
            {
                case 0:
                    Miners.r1 = true;
                    break;
                case 1:
                    Miners.r2 = true;
                    break;
                case 2:
                    Miners.r3 = true;
                    break;
            }
        }
        else if (Tasks.LearnAboutCES)
            Miners.CESEnabled = true;

        doOnce = false;
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
//Date: Wed, 18 May 2022    | Time: 16:00 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:
 * By:
 * URL: 
 */
#endregion
#endregion

//Uniq Studio