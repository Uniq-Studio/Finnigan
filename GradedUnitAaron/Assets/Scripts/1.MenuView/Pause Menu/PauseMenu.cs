using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    #region README
    /* IMPORTANT: This is a base file. 
     * This will be used In multiple projects.
     * It has been created for an easy drop 
     * into projects. There is no need to change
     * the code, just change the variables. */
    #endregion

    #region Variables

    //Main Menu code here
    public int MainMenuCode = 0;

    #region Dont Modify
    bool isPaused = false;
    //Linking the Pause Menu to a Variable
    [SerializeField] GameObject pauseMenu;
    #endregion
    #endregion

    #region Keyboard Input
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (isPaused == false) {Pause();} 
            else if (isPaused == true){Resume();}
        }
    }
    #endregion

    #region Methods

    #region Pause Game
    public void Pause()
    {
        isPaused = true;

        //Make the 'pauseMenu' visible
        pauseMenu.SetActive(true);

        //Set time speed to 0 so everything is paused
        Time.timeScale = 0f;
    }
    #endregion

    #region Resume Game
    public void Resume()
    {
        isPaused = false;

        //Make the 'pauseMenu' hidden
        pauseMenu.SetActive(false);

        //Restore Time
        Time.timeScale = 1f;
    }
    #endregion

    #region Return to main menu
    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MainMenuCode);
    }
    #endregion

    #region DEBUG
    public void DebugButton()
    {
        Debug.Log("Clicked!");
    }
    #endregion
    #endregion

    #region FootNotes
    /*
     * RESOURCES USED: YouTube
     * TITLE: How To Make A PAUSE MENU In 4 Minutes - Easy Unity Tutorial
     * URL: https://www.youtube.com/watch?v=tfzwyNS1LUY
     * 
     * CODE CREATED: 	Aaron Hamilton – 24/03/2022
     * COMMENTED:		Aaron Hamilton – 24/03/2022
     * COMPLETION:		Aaron Hamilton – 24/03/2022
     * DEBUGGED ON:		Aaron Hamilton – 24/03/2022
     * SPELLING CHECK:	Aaron Hamilton – 24/03/2022
     * 
     * VERSION:          1.0.0
     * GITHUB:           /aaron-hamil5/Menu-System
     **/
    #endregion
}
