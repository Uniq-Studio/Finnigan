using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
		These Text variables are uses to update
		the onscreen text with the MAINTASK or 
		SUBTASK variables and update the banner 
		to display the task.
     */
    #endregion
    public Text berries;
    public Text berriesInBox;
    public Text task;

    private string mainTask;
    private string subTask;

    public GameObject banner;

    static bool showBanner;
    #endregion

    #region Unity Triggers
    void Update()
    {
        #region Comment
        /*
			If the Player hits the TAB key on
			the keyboard, then the task banner
			will once again show for a period
			of time before disappearing.
         */
        #endregion
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            StartCoroutine(DisplayBanner());
        }
    }
    #endregion

    #region Methods

    #region UpdateUI
    #region Comment
    /*
		To help save on resources we can
		update the UI when it needs to be 
		updated rather than us calling it 
		every frame.
     */
    #endregion
    public void UpdateBerries(int amount)
    {
        berries.text = "Berries: " + amount;
    }
    public void UpdateBerriesBox(int amount)
    {
        berriesInBox.text = "In Box: " + amount;
    }
    #endregion

    #region Update Tasks
    #region Comment
    /*
		The method gets called when we want
		to update the current task and we can
		save it in a different variable so when
		we need to display a warning then we
		can fall back to the original task,
		rather than the new task just saying the
		warning or needing a new panel.
     */
    #endregion
    public void UpdateTask(string includedText)
    {
        mainTask = "Task: " + includedText;
        task.text = mainTask;
        StartCoroutine(DisplayBanner());
    }

    public void UpdateSubTask(string includedText)
    {
        subTask = "Warning: " + includedText;
        task.text = subTask;
        StartCoroutine(ResetDisplayBanner());
    }
    #endregion

    #region Display Banners
    #region Comment
    /*
		We want to update the banner with the
		new task then after a few seconds it
		will disappear, with the warning it
		will display the warning then falls
		back to the original message.
     */
    #endregion
    IEnumerator DisplayBanner()
    {
        banner.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        banner.gameObject.SetActive(false);
    }

    IEnumerator ResetDisplayBanner()
    {
        StartCoroutine(DisplayBanner());
        yield return new WaitForSeconds(6);
        task.text = mainTask;
        StartCoroutine(DisplayBanner());
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
//Date: Mon, 25 Apr 2022 | Time: 16:32 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	NONE
 * By:		NONE
 * URL: 	NONE
 */
#endregion
#endregion

//Uniq Studio