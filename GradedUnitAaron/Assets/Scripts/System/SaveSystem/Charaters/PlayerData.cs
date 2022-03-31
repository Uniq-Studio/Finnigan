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
        m_position[0] = player.transform.position.x;
        m_position[1] = player.transform.position.y;
        m_position[2] = player.transform.position.z;


        m_walkSpeed = player.m_WalkSpeed;
        m_runSpeed = player.m_RunSpeed;
        m_jumpSpeed = player.m_JumpSpeed;
        m_jumpHeight = player.m_JumpHeight;

        m_staminaMax = player.m_StaminaMax;
        m_refillStaminaSpeed = player.m_RefillStaminaSpeed;

        m_healthCurrent = player.m_HealthCurrent;
        m_healthMax = player.m_HealthMax;
        m_refillHealth = player.m_HealthMax;

        m_attackDamage = player.m_AttackDamage;
        m_attackDamageSpeed = player.m_AttackDamageSpeed;

        m_defence = player.m_Defence;
        m_defenceMax = player.m_DefenceMax;

        //m_reputation = rep.reputation;
        //m_cameraMode = camera.view;
    }
}
