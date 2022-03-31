using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource m_gainReputation;

    public void GainReputation()
    {
        m_gainReputation.Play();
    }
}
