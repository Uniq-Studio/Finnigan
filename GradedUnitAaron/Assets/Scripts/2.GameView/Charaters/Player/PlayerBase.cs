using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : CharacterBase
{

    public float m_WalkSpeed;
    public float m_RunSpeed;
    public float m_JumpSpeed;
    public float m_JumpHeight;

    public float m_StaminaMax;
    public float m_RefillStaminaSpeed;

    public float m_HealthCurrent;
    public float m_HealthMax;
    public float m_RefillHealth;

    public float m_AttackDamage;
    public float m_AttackDamageSpeed;

    public float m_Defence;
    public float m_DefenceMax;

    public void start()
    {

        m_WalkSpeed = walkSpeed;
        m_RunSpeed = runSpeed;
        m_JumpSpeed = jumpSpeed;
        m_JumpHeight = jumpHeight;
        m_StaminaMax = staminaMax;
        m_RefillStaminaSpeed = refillStaminaSpeed;
        m_HealthCurrent = healthCurrent;
        m_HealthMax = healthMax;
        m_RefillHealth = refillHealth;
        m_AttackDamage = attackDamage;
        m_AttackDamageSpeed = attackDamageSpeed;
        m_Defence = defence;
        m_DefenceMax = defenceMax;


    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadData();


        m_WalkSpeed = data.m_walkSpeed;
        m_RunSpeed = data.m_runSpeed;
        m_JumpSpeed = data.m_jumpSpeed;
        m_JumpHeight = data.m_jumpHeight;

        m_StaminaMax = data.m_staminaMax;
        m_RefillStaminaSpeed = data.m_refillStaminaSpeed;

        m_HealthCurrent = data.m_healthCurrent;
        m_HealthMax = data.m_healthMax;

        m_RefillHealth = data.m_refillHealth;
        m_AttackDamage = data.m_attackDamage;
        m_AttackDamageSpeed = data.m_attackDamageSpeed;

        m_Defence = data.m_defence;
        m_DefenceMax = data.m_defenceMax;

        Vector3 position;
        position.x = data.m_position[0];
        position.y = data.m_position[1];
        position.z = data.m_position[2];

        transform.position = position;
    }
}
