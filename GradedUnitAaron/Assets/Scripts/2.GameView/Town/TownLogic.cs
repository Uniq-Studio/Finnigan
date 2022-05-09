using System.Collections;
using System.Collections.Generic;
using NGS.ExtendableSaveSystem;
using UnityEngine;

public class TownLogic : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        We linked all the GameObjects so we can
        activate them when the player has all of
        the requirements to build it.
     */
    #endregion

    public GameObject Builder;
    public GameObject Farmer;
    public GameObject Miners;
    public GameObject Forgers;
    public GameObject Defense;

    public static int roundCount;

    private int count;
    private bool doOnce;
    private bool doOnceCount;
    private GameMaster m_GM;
    #endregion

    #region Unity Triggers

    void OnTriggerEnter(Collider collider)
    {
        #region Comment
        /*
            Comments that are multiline should
            be around this length before starting
            a new line.
         */
        #endregion
        if (collider.CompareTag("Player") && !doOnce)
        {
            Debug.Log("Requirements Called");
            if (Inventory.berryAmount >= 20 &&
                Inventory.stoneAmount >= 5 &&
                Inventory.leafAmount >= 6 &&
                Inventory.stickAmount >= 10)
            {
                Debug.Log("True!");
                Inventory.berryAmount -= 20;
                Inventory.stoneAmount -= 5;
                Inventory.leafAmount -= 6;
                Inventory.stickAmount -= 10;

                StartCoroutine(Timer(5, Builder));
            }
            doOnce = true;
        }
    }
    #endregion

    #region Methods

    void RequirementsCheck(int Berries, int Stones, int Leafs, int Sticks, int time, GameObject item)
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

            StartCoroutine(Timer(time, item));
        }
    }

    #region Timer
    #region Comment
    /*
        Comments that are multiline should
        be around this length before starting
        a new line.
     */
    #endregion

    IEnumerator Timer(int length, GameObject item)
    {
        m_GM = FindObjectOfType<GameMaster>();
        yield return new WaitForSeconds(length);
        item.transform.localPosition += new Vector3(0, +10, 0);
        new WaitForSeconds(1);
        m_GM.SaveGame();
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
//Date: Mon, 09 May 2022    | Time: 15:25 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:
 * By:
 * URL: 
 */
#endregion
#endregion

//Uniq Studio