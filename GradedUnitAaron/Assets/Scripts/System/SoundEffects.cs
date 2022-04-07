using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Sound System that plays audio for seletive events */
public class SoundEffects : MonoBehaviour
{
    #region Variables
    public AudioSource m_gainReputation;
    #endregion

    #region Reputation
    public void GainReputation()
    {
        m_gainReputation.Play();
    }
    #endregion
}
