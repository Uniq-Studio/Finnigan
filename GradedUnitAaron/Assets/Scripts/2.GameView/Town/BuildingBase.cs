using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBase : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        Comments that are multiline should
        be around this length before starting
        a new line.
     */

    public delegate void passingMethod();

    public UIUpdater UI;
    #endregion

    #endregion

    #region Methods

    #region Requirements Check
    #region Comment
    /*
        This will check if the player has all
        the required items to help build up
        said item. We have variables passing
        through so we have one line of code,
        and each item can be its own amount.
     */
    #endregion

    public void RequirementsCheck(int Berries, int Stones, int Leafs, int Sticks, int time, passingMethod method, string nextBuilding)
    {
        Debug.Log("Requirements Called");
        if (Inventory.berryAmount >= Berries &&
            Inventory.stoneAmount >= Stones &&
            Inventory.leafAmount >= Leafs &&
            Inventory.stickAmount >= Sticks)
        {
            Debug.Log("True!");
            Inventory.berryAmount -= Berries;
            Inventory.stoneAmount -= Stones;
            Inventory.leafAmount -= Leafs;
            Inventory.stickAmount -= Sticks;

            StartCoroutine(Timer(time, method, nextBuilding));
        }
        else
        {
            UI.UpdateTask("You need " + Berries + " Berries, " + Stones + " Stones, " + Leafs + " leafs, " + Sticks + " sticks to continue");
        }
    }

    #endregion

    #region Timer
    #region Comment
    /*
        We want the GameObject to spawn in
        in a set time where we need to use
        an IEnumerator.
     */
    #endregion

    public IEnumerator Timer(int length, passingMethod method, string nextBuilding)
    {
        UI.UpdateTask("Now we need to wait till they are done!");
        Debug.Log("Timer started");
        yield return new WaitForSeconds(length);
        Debug.Log("Timer ended");
        method();
        UI.UpdateTask("Looks like they are done, lets take it to " + nextBuilding);
    }
    #endregion

    #endregion
}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE:    Thurs, 28 Apr 2022
 * TIME:    13:30
 * BY:      Aaron Hamilton
 */
#endregion

#region Edit Logs
//Date: Mon, XX Jan 2000 | Time: 00:00 | Edit by: Uniq
#endregion

#region Sources
/* Title:
 * By:
 * URL: 
 */
#endregion
#endregion

//Uniq Studio