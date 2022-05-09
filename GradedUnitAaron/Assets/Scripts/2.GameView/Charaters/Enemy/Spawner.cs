using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
		We need a reference the Attacker
		prefab and the 3 location they should
		spawn in at. 
		A reference to the UI to update the
		task.
		MAX for how many to spawn in per
		round.
		And a DOONCE to run code once in
		the update and some rounds to keep
		on track what round to do.
	*/
    #endregion

    public GameObject Attacker;
    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;

    private UIUpdater UI;

    private int num;
    private int max;

    private bool doOnce = false;
    private bool round1;
    private bool round2;
    private bool round3;

    #endregion

    #region Unity Triggers
    void Start()
    {
        #region Comment
        /*
			Linking the object to the variable
			to use the methods.
         */
        #endregion
        UI = FindObjectOfType<UIUpdater>();
    }

    void Update()
    {
        #region Comment
        /*
			When the Task list gets updated then
			it will start the round that has been
			enabled. It will get what the max and
			spawning the attackers. Once the max
			is at 0 it will end the round.
         */
        #endregion

        if (Tasks.startDefenseOne && !round1)
        {
            max = 10;
            if (!doOnce && max > 0)
            {
                StartCoroutine(SpawnIn());
            }
            if (max <= 0)
            {
                round1 = true;
            }
        }

        if (Tasks.startDefenseTwo && !round2)
        {
            max = 20;
            if (!doOnce && max > 0)
            {
                StartCoroutine(SpawnIn());
            }
            if (max <= 0)
            {
                round1 = true;
            }
        }

        if (Tasks.startDefenseThree && !round3)
        {
            max = 30;
            if (!doOnce && max > 0)
            {
                StartCoroutine(SpawnIn());
            }
            if (max <= 0)
            {
                round3 = true;
            }
        }
    }
    #endregion

    #region Methods

    #region Spawn In
    #region Comment
    /*
		After the 4 second count down, it
		will chose a random number to select
		a random spawner then spawn in the
		attacker then enabling the once loop
		then letting it run again.
     */
    #endregion
    IEnumerator SpawnIn()
    {
        new WaitForSeconds(4);
        num = Mathf.RoundToInt(Random.Range(1, 4));
        switch (num)
        {
            case 1:
                Instantiate(Attacker, Spawner1.transform.position, transform.rotation);
                break;
            case 2:
                Instantiate(Attacker, Spawner2.transform.position, transform.rotation);
                break;
            case 3:
                Instantiate(Attacker, Spawner3.transform.position, transform.rotation);
                break;
        }
        doOnce = true;
        max--;
        yield return new WaitForSeconds(1);
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
//Date: Mon, 09 May 2022 | Time: 19:05 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	NONE
 * By:		NONE
 * URL: 	NONE
 */
#endregion
#endregion

//Uniq Studio