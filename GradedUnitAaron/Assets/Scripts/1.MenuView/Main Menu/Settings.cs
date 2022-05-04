using TMPro;
using UnityEngine;

public class Settings : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        TRIGGER is going to be used to update
        whether the player pressed the button,
        to get the unlimited items or wants
        to gain the items on their own.
        Text is to tell the player if it has
        enabled.
     */
    #endregion

    private bool triggered = false;
    public TextMeshProUGUI update;
    #endregion

    #region Methods

    #region Give Unlimited Items
    #region Comment
    /*
        First, we will update the variable
        to be the opposite of what it is and
        then check if its true and give the
        player everything else make everything
        off and set to 0.
     */
    #endregion

    public void UnlimitedItems()
    {
        triggered = !triggered;

        if (triggered)
        {
            Inventory.berryAmount = 10000;
            Inventory.berriesShowing = true;

            Inventory.stoneAmount = 10000;
            Inventory.stoneShowing = true;

            Inventory.stickAmount = 10000;
            Inventory.stickShowing = true;

            Inventory.leafAmount = 10000;
            Inventory.leafShowing = true;
            update.text = "You now have 10000 items. Start the game or click again to set to 0 again!";
        }
        else if (!triggered)
        {
            Inventory.berryAmount = 0;
            Inventory.berriesShowing = false;

            Inventory.stoneAmount = 0;
            Inventory.stoneShowing = false;

            Inventory.stickAmount = 0;
            Inventory.stickShowing = false;

            Inventory.leafAmount = 0;
            Inventory.leafShowing = false;
            update.text = "You will start off with an empty inventory.";
        }
    }
    #endregion

    #endregion
}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE:    Wed, 4 May
 * TIME:    12:45
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