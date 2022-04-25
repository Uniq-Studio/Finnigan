using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        AudioSources are used to hold the audio
        and we will fill them with sound effects
        that will play throughout the game play.
     */
    #endregion
    public AudioSource m_gainReputation;
    #endregion

    #region Methods

    #region Gain Reputation
    #region Comment
    /*
        These methods are used so if I decide
        to rename or change the audio all
        scripts will update alongside it makes
        life a little bit more convenient.
     */
    #endregion
    public void GainReputation()
    {
        m_gainReputation.Play();
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
//Date: Mon, 25 Apr 2022 | Time: 15:58 | Edit by: Aaron
#endregion

#region Sources
/* Title: 	Asteroids Assessment
 * By:		Uniq-Studio
 * URL: 	Uniq-Studio/AsteroidsAssessment
 */
#endregion
#endregion

//Uniq Studio