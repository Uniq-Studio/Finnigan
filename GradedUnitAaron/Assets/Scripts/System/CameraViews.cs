using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViews : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        Depending how it goes, its better
        to not hard code the camera in case
        we add extra cameras to the game
        and only want it to affect the one
        camera.
     */
    #endregion
    public Transform m_Camera;
    public GameObject fox;
    public int view;

    private bool changeView;
    #endregion

    #region Unity Triggers
    void Start()
    {
        #region Set View on Start
        #region Comment
        /*
            At the start of the game,
            when the player loads in, 
            I want the camera to start
            up in the OVERHEAD view. 

            The change view variable is
            set to true just to make sure
            the view does change to prevent
            any issue.
        */
        #endregion
        view = 1;
        changeView = true;
        #endregion
    }

    void Update()
    {
        #region Player's Input for ChangeView
        #region Keyboard Input
        #region Comment
        /*  When the player has hit the F4
            on keyboard then the camera view
            increases and set change view enables. 
            
            (This is so the camera view does
            not change over once by disabling
            the code till its completed.)
        */
        #endregion
        if (Input.GetKeyDown(KeyCode.F4) && !changeView)
        {
            view++;
            changeView = true;
        }
        #endregion

        #region Call the ChangeView
        //This makes sure the game is not setting the camera every frame
        if (changeView)
        {
            ChangeView();
        }
        #endregion
        #endregion
    }
    #endregion

    #region Methods

    #region View Changer
    #region Comment
    /*
        First, we need to make sure the
        variable VIEW isn’t falling out
        of range, so we make sure after
        two it goes back to zero.

        We use a switch statement to check
        what the view is at and select it
        and then make the variable CHANGEVIEW
        false so then the cycle can run again.
     */
    #endregion
    void ChangeView()
    {
        if (view > 2) { view = 0; }

        switch (view)
        {
            case 0:
                FirstPersonView();
                changeView = false;
                break;
            case 1:
                OverHeadCamera();
                changeView = false;
                break;
            case 2:
                ThirdPersonView();
                changeView = false;
                break;
        }
    }
    #endregion

    #region Views
    #region First Person View
    #region Comment
    /*  For this view we will set the fox
        as hidden as we will not be able to
        see Finnigan. Setting the GameObject
        as hidden will help us save resources
        rather than wasting it on something we
        cannot see.
        
        Setting the rotation to zero make the
        camera see straight and the position
        is set where Finnigan’s head would be.
 */
    #endregion
    void FirstPersonView()
    {
        fox.SetActive(false);
        m_Camera.localRotation = Quaternion.Euler(0f, 0f, 0f);
        m_Camera.localPosition = new Vector3(0f, 0.1f, 1f);
        Debug.Log("First");
    }
    #endregion

    #region Over Head Camera
    #region Comment
    /*  For this view we will set the fox
        viewable (so if the player selected
        First Person, the fox will reappear). 

        The rotation is set to look directly
        down at Finnigan and the position to
        be high up, floating over Finnigan.
    */
    #endregion
    void OverHeadCamera()
    {
        fox.SetActive(true);
        m_Camera.localRotation = Quaternion.Euler(75f, 0f, 0f);
        m_Camera.localPosition = new Vector3(0f, 10f, -1f);
        Debug.Log("Over");
    }
    #endregion

    #region Third Person View
    #region Comment
    /*  We will not be playing with the fox
        visibility as you cannot manually
        select what view, you must cycle
        through it.

        The camera is slightly looking to the
        right as its resting just behind
        Finnigan’s shoulder.
    */
    #endregion
    void ThirdPersonView()
    {
        m_Camera.localRotation = Quaternion.Euler(25f, 0f, 0f);
        m_Camera.localPosition = new Vector3(-1.1f, 1.3f, -1f);
        Debug.Log("Third");
    }
    #endregion
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
//Date: Mon, 25 Apr 2022 | Time: 16:06 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	Quaternion.Euler
 * By:		Unity Documentation
 * URL: 	https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html
 */
#endregion
#endregion

//Uniq Studio