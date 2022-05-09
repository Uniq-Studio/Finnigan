using System.Collections;
using System.Collections.Generic;
using System.IO;
using NGS.ExtendableSaveSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region README
    /* IMPORTANT: This is a base file. 
     * This will be used In multiple projects.
     * It has been created for an easy drop 
     * into projects. There is no need to change
     * the code, just change the variables. */
    #endregion

    #region Variables

    #region Note
    /* First check which scene has what
     * number, then change the according
     * variable to its designated number.*/
    #endregion

    public int game = 0;
    public int settings = 0;
    public int help = 0;

    //This is for Keyboard Inputs
    //Type: DISABLE to disable them
    public string gameKey = "return";
    public string settingsKey = "s";
    public string helpKey = "DISABLE";
    public string quitKey = "escape";

    //Debug with info coming out of the console
    public bool debugMode = true;

    //Linking the Settings Panel
    public GameObject m_Panel;
    public GameObject m_NewGame;
    public GameObject m_ResumeGame;
    public GameObject m_GameOver;

    public static bool loadSave;
    public static bool gameOver;

    [SerializeField] private GameMaster m_GM;

    #endregion

    #region Code

    #region Keyboard Input
    // Update is called once per frame
    void Update()
    {
        //Check if the game should not listen for this key press
        if (gameKey != "DISABLE")
        {
            if (Input.GetKey(gameKey))
            {
                //Check If the Programmer is debugging
                if (debugMode != true)
                {
                    m_GM = FindObjectOfType<GameMaster>();
                    m_GM.CheckSave();
                }
                else
                {
                    Debug.Log(gameKey + " Key Pressed");
                }
            }
        }


        //Check if the game should not listen for this key press
        if (settingsKey != "DISABLE")
        {
            if (Input.GetKey(settingsKey))
            {
                //Check If the Programmer is debugging
                if (debugMode != true)
                {
                    /* If player presses "settingsKey" 
                     * it will launch the Settings scene
                     */
                    OpenSettingPane();
                }
                else
                {
                    Debug.Log(settingsKey + " Key Pressed");
                }
            }
        }

        //Check if the game should not listen for this key press
        if (helpKey != "DISABLE")
        {
            if (Input.GetKey(helpKey))
            {
                //Check If the Programmer is debugging
                if (debugMode != true)
                {
                    /* If player presses "helpKey" 
                     * it will launch the Help scene
                     */
                    HelpPane();
                }
                else
                {
                    Debug.Log(helpKey + " Key Pressed");
                }
            }
        }

        //Check if the game should not listen for this key press
        if (helpKey != "DISABLE")
        {
            if (Input.GetKey(quitKey))
            {
                //Check If the Programmer is debugging
                if (debugMode != true)
                {
                    /* If player presses "quitKey" 
                     * it will quit the Game
                     */
                    QuitGame();
                }
                else
                {
                    Debug.Log(quitKey + " Key Pressed");
                }
            }
        }
    }
    #endregion

    #region Methods

    #region File check
    public void FileCheck()
    {
        if (File.Exists(Application.persistentDataPath + "/player.finnigan"))
        {
            m_ResumeGame.gameObject.SetActive(true);
        }
        else
        {
            m_NewGame.gameObject.SetActive(true);
        }
    }
    #endregion

    #region Close Window

    public void CloseWindow()
    {
        //When the X is clicked it will close all windows, no matter what window is active
        //This will make sure that there arent any over lapping windows.
        m_ResumeGame.gameObject.SetActive(false);
        m_NewGame.gameObject.SetActive(false);
        m_Panel.gameObject.SetActive(false);
        m_GameOver.gameObject.SetActive(false);
    }
    #endregion

    #region Game
    public void LaunchNewGame()
    {
        //Loads Game Scene
        SceneManager.LoadScene(game);
    }
    public void ResumeGame()
    {
        //Loads Game Scene
        loadSave = true;
        SceneManager.LoadScene(game);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(2);
    }
    #endregion

    #region Settings
    //These are set to public so the OnClick() can see it
    public void OpenSettingPane()
    {
        //Show the Setting panel when the cog is clicked
        m_Panel.gameObject.SetActive(true);
    }

    #endregion

    #region Help
    public void HelpPane()
    {
        //Loads Help Scene
        SceneManager.LoadScene(help);
    }
    #endregion

    #region Game Over Screen

    void Start()
    {
        if (gameOver)
        {
            GameOverWindow();
            gameOver = false;
        }
    }
    public void GameOverWindow()
    {
        m_GameOver.gameObject.SetActive(true);
    }
    #endregion

    #region Quit
    public void QuitGame()
    {
        /* This line of code will make
         * the game stop and exit the
         * application, returning the
         * player back to their desktop.*/
        Application.Quit();
    }
    #endregion
    #endregion
    #endregion

    #region FootNotes
    /*
     * RESOURCES USED: Class Notes - F869 34 3D Level Editing Notebook - Content Library - Platformer
     * TITLE: 14 Menu
     * URL: NONE
     * 
     * CODE CREATED: 	Aaron Hamilton – 22/03/2022
     * COMMENTED:		Aaron Hamilton – 22/03/2022
     * COMPLETION:		Aaron Hamilton – 22/03/2022
     * DEBUGED ON:		Aaron Hamilton – 22/03/2022
     * SPELLING CHECK:	Aaron Hamilton – 22/03/2022
     * 
     * VERSION:          1.0.0
     * GITHUB:           /aaron-hamil5/Menu-System
     **/
    #endregion
}
