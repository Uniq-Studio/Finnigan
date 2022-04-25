using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
		UI is for updating the UI, Inventory
		is to add the items to the inventory.
     */
    #endregion
    private UIUpdater UI;
    private Inventory inventory;
    #endregion

    #region Unity Triggers
    void Start()
    {
        #region Comment
        /*
			We will link the object to the variable
			so unity doesn’t have an issue.
         */
        #endregion
        UI = FindObjectOfType<UIUpdater>();
        inventory = FindObjectOfType<Inventory>();
    }
    #endregion

    #region Methods

    #region GetItem
    #region Comment
    /*
		First it checks the ID to see if its
		berries and if so, it will do a random
		number, else it will give you one of
		the items and then destroy itself.
     */
    #endregion
    public void GetItem(GameObject item, int id)
    {
        if (id == 0)
        {
            inventory.AddAmount(id, Mathf.FloorToInt(Random.Range(3, 8)));
            item.SetActive(false);
        }
        else
        {
            inventory.AddAmount(id, 1);
            Destroy(item);
        }
    }
    #endregion

    #region Self Destroy
    #region Comment
    /*
		To save on resources it will
		automatically despawn after 3 minutes.
     */
    #endregion
    public IEnumerator SelfDestroy(GameObject item)
    {
        yield return new WaitForSeconds(180);
        Destroy(item);
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
//Date: Mon, 25 Apr 2022 | Time: 17:25 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	NONE
 * By:		NONE
 * URL: 	NONE
 */
#endregion
#endregion

//Uniq Studio