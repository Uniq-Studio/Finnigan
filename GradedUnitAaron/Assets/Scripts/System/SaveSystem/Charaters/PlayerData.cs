using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    #region Movement
    public float m_walkSpeed;
    public float m_runSpeed;
    public float m_jumpSpeed;
    public float m_jumpHeight;
    #endregion

    #region Stanima for running
    public float m_staminaMax;
    public float m_refillStaminaSpeed;
    #endregion

    #region Health
    public float m_healthCurrent;
    public float m_healthMax;
    public float m_refillHealth;
    #endregion

    #region Attack
    public float m_attackDamage;
    public float m_attackDamageSpeed;
    #endregion

    #region Defence
    public float m_defence;
    public float m_defenceMax;
    #endregion

    public float[] m_position;

    public int m_reputation;
    public int m_cameraMode;

    public PlayerData(PlayerBase player)
    {

        //m_reputation = rep.reputation;
        //m_cameraMode = camera.view;
    }
}
