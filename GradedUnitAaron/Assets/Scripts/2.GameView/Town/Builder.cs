using System.Collections;
using System.Collections.Generic;
using NGS.ExtendableSaveSystem;
using UnityEngine;

public class Builder : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        We linked all the GameObjects so we can
        activate them when the player has all of
        the requirements to build it.
     */
    #endregion
    public GameObject Farmer;
    public GameObject Miners;
    public GameObject Forgers;
    public GameObject Defense;
    public GameObject CES;

    public static int count = 1;

    private bool doOnce;
    private bool buildTown;
    private bool getOneStick;
    private GameMaster m_GM;

    public static bool DefenseOneReady;
    public static bool DefenseTwoReady;
    public static bool DefenseThreeReady;
    public static bool CESEnabled;
    #endregion

    #region Unity Triggers
    void Start()
    {
        #region Comment
        /*
            Comments that are multiline should
            be around this length before starting
            a new line.
         */
        #endregion

    }

    void OnTriggerEnter(Collider collider)
    {
        
            #region Build Town
            #region Comment
            /*
                Comments that are multiline should
                be around this length before starting
                a new line.
             */
            #endregion
            if (collider.CompareTag("Player") && !doOnce && !buildTown)
            {
                Debug.Log("Hey!");
                switch (count)
                {
                    case 1:
                        Debug.Log("Switch 1");
                        RequirementsCheck(30, 5, 10, 5, 2, Farmer);
                        break;
                    case 2:
                        Debug.Log("Switch 2");
                        RequirementsCheck(20, 20, 5, 20, 2, Miners);
                        break;
                    case 3:
                        Debug.Log("Switch 3");
                        RequirementsCheck(40, 30, 10, 30, 2, Forgers);
                        break;
                    case 4:
                        Debug.Log("Switch 4");
                        RequirementsCheck(30, 40, 40, 40, 2, Defense);
                        buildTown = true;
                        break;
                }

                doOnce = true;
            }
            #endregion

        if (!Tasks.LearnAboutCES) 
        {
            if (collider.CompareTag("Player") && buildTown && DefenseOneReady && !DefenseTwoReady && !DefenseThreeReady)
            {
                Tasks.startDefenseOne = true;
                TownLogic.roundCount = 1;
            }

            if (collider.CompareTag("Player") && buildTown && DefenseOneReady && DefenseTwoReady && !DefenseThreeReady)
            {
                Tasks.startDefenseTwo = true;
                TownLogic.roundCount = 2;
            }

            if (collider.CompareTag("Player") && buildTown && DefenseOneReady && DefenseTwoReady && DefenseThreeReady)
            {
                Tasks.startDefenseThree = true;
            }
        }
        else if (CESEnabled && !getOneStick)
        {
            Vector3 spawnin = transform.position + new Vector3(-4, 0, 0);
            Instantiate(CES, spawnin, transform.rotation);
            getOneStick = true;
        }

    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            doOnce = false;
        }
    }
    #endregion

    #region Methods

    #region Requirement Check
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
    #endregion

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
        count++;
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
//Date: Sat, 30 Apr 2022    | Time: 14:00 | Edit By: Aaron Hamilton
//Date: Mon, 09 May 2022    | Time: 15:50 | Edit By: Aaron Hamilton
#endregion

#region Sources
/* Title:
 * By:
 * URL: 
 */
#endregion
#endregion

//Uniq Studio