using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerButtonClickTaskCompleter : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        Comments that are multiline should
        be around this length before starting
        a new line.
     */
    #endregion

    private UIUpdater UI;

    private bool doOnceMove;
    private bool doOnceEscape;
    bool doOnceClick;
    private bool doOncef4;
    private bool doOnceCollect;
    private bool doOnceGive;
    private bool doOnceAttack;

    [SerializeField] private GameObject Stone;
    [SerializeField] private GameObject Stick;
    [SerializeField] private GameObject Leaf;
    [SerializeField] private GameObject bush;
    [SerializeField] private GameObject Guy;
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

        UI = FindObjectOfType<UIUpdater>();
        StartCoroutine(Welcome());
    }

    void Update()
    {
        #region Comment
        /*
            Getting the players input and ticking
            of the tasks list and Loading the
            next task.
         */
        #endregion

        if (Input.GetKeyUp(KeyCode.W))
        {
            TutTasks.pressedW = true;
        }


        if (Input.GetKeyUp(KeyCode.A))
        {
            TutTasks.pressedA = true;
        }


        if (Input.GetKeyUp(KeyCode.S))
        {
            TutTasks.pressedS = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            TutTasks.pressedD = true;
        }


        if (Input.GetKeyUp(KeyCode.Escape))
        {
            TutTasks.pressedEscape = true;
        }

        if (Input.GetKeyUp(KeyCode.F4))
            TutTasks.count++;

        if (TutTasks.count >= 3)
        {
            TutTasks.pressedF4 = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && doOncef4)
        {
            TutTasks.pressedLeftMouseButton = true;
        }



        if (TutTasks.pressedW && TutTasks.pressedA && TutTasks.pressedS && TutTasks.pressedD && !doOnceMove)
        {
            StartCoroutine(PauseMenu());
            doOnceMove = true;
        }

        if (TutTasks.pressedEscape && !doOnceEscape)
        {
            StartCoroutine(Cameras());
            doOnceEscape = true;
        }

        if (TutTasks.pressedF4 && !doOncef4)
        {
            StartCoroutine(Attack());
            doOncef4 = true;
        }

        if (TutTasks.pressedLeftMouseButton && !doOnceClick)
        {
            StartCoroutine(Collect());
            doOnceClick = true;
        }

        if (TutTasks.pickedUpStone && TutTasks.pickedUpStick && TutTasks.pickedUpLeaf && TutTasks.pickedUpBerries &&
            !doOnceCollect)
        {
            StartCoroutine(Give());
            doOnceCollect = true;
        }

        if (TutTasks.Interacted && !doOnceGive)
        {
            StartCoroutine(Attack());
            doOnceGive = true;
        }

        if (TutTasks.killed && doOnceGive)
            SceneManager.LoadScene(0);

    }
    #endregion

    #region Methods

    #region Method 1
    #region Comment
    /*
        Comments that are multiline should
        be around this length before starting
        a new line.
     */
    #endregion

    IEnumerator Welcome()
    {
        UI.UpdateTask("Welcome! Let's learn the basics");
        yield return new WaitForSeconds(5);
        UI.UpdateTask("Use W A S D to move");
    }

    IEnumerator PauseMenu()
    {
        UI.UpdateTask("Now we done that, Lets pause the game!");
        yield return new WaitForSeconds(5);
        UI.UpdateTask("Press esc");
    }

    IEnumerator Cameras()
    {
        UI.UpdateTask("Did you know you can change your camera view?");
        yield return new WaitForSeconds(5);
        UI.UpdateTask("Press F4, you may also need to press fn at the same time or even alt.");
    }

    IEnumerator Attack()
    {
        UI.UpdateTask("In this game you will need to fight");
        yield return new WaitForSeconds(5);
        UI.UpdateTask("Press the left mouse button.");
    }

    IEnumerator Collect()
    {
        Stone.SetActive(true);
        Stick.SetActive(true);
        Leaf.SetActive(true);
        bush.SetActive(true);

        UI.UpdateTask("Now Pick Up these items");
        yield return new WaitForSeconds(5);
        UI.UpdateTask("Just walk over them");
    }

    IEnumerator Give()
    {
        Guy.SetActive(true);
        UI.UpdateTask("Now give him the items");
        yield return new WaitForSeconds(5);
        UI.UpdateTask("Just walk over to him");
    }

    IEnumerator Kill()
    {
        UI.UpdateTask("Now attack him");
        yield return new WaitForSeconds(5);
        UI.UpdateTask("Walk up and left click till hes dead");
    }
    #endregion

    #endregion
}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE:    Mon, 9 may
 * TIME:    20:45
 * BY:      Aaron Hamilton
 */
#endregion

#region Edit Logs
//Date: Mon, XX Jan 2000 | Time: 00:00 | Edit by: Uniq
#endregion

#region Sources
/* Title:   NONE
 * By:      NONE
 * URL:     NONE
 */
#endregion
#endregion

//Uniq Studio
